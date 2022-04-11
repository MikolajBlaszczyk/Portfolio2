using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Logic;
using ArchitectureUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Model;
using ArchitectureUI.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace ArchSite.Controllers
{
    public class MainController : Controller
    {
        public ICalculation Calculation { get; set; }
        public IMemoryCache Cache { get; set; }
        public  IValidateModel ModelValidation { get; set; }
        private readonly ILogger<MainController> _logger;


        public MainController(ICalculation calculation, ILogger<MainController> logger, IValidateModel modelValidation, IMemoryCache cache)
        {
            Calculation = calculation;
            _logger = logger;
            ModelValidation = modelValidation;
            Cache = cache;
        }

        //(GET)Page with building Law
        public async Task<IActionResult> Index()
        {
            _logger.Log(LogLevel.Information, "MainController index initilized");
            return View();
        }


        //(GET)Page with calculator
        public async Task<IActionResult> Calculate()
        {
            CalculateModel model = new();
            //setting
            model.Success = false;
            ViewBag.Note = "Podaj wysokość kondygnacji i wybierz typ budynku";
            _logger.LogInformation("CalculateModel Initilize");
      
            return View(model);
        }

        
        //Calculation results
        [RequireHttps]
        [HttpPost]
        public async Task<IActionResult> Calculate(IFormCollection collection, string FloorHeightText, CalculateModel model)
        {
            if(collection["type"].Count !=0)
            {
                string radioResult = collection["type"];
                await RadioResult(radioResult, model);
                await CacheChoice(radioResult);
                if (FloorHeightText is not null && double.TryParse(FloorHeightText, out _))
                {
                    model.FloorHeight = Convert.ToDouble(FloorHeightText.Replace('.', ','));
                    try
                    {
                        await CalculateModel(model, false);
                        _logger.LogInformation("Calculation success");
                    }
                    catch (Exception)
                    {
                        ViewBag.Note = "nie wybrano typu budynku";
                        _logger.LogError("invalid building type");
                    }
                    
                }
                else if (FloorHeightText == "")
                {
                    ViewBag.Note = "nie podano wysokości kondygnacji";
                    _logger.LogError("Invalid floor height");
                }
                else if (double.TryParse(FloorHeightText, out _) == false)
                {
                    ViewBag.Note = "należy wpisać numer";
                    _logger.LogError("Invalid input");
                }

                await GetInputValues(model);
            }
            else
            {
                ViewBag.Note = "należy podać typ budynku";
                _logger.LogError("Building type wasn't chosen");
            }
            return View(model);
        }


        //Changin results via range inputs
        [RequireHttps]
        [HttpPost]
        public async Task<IActionResult> AdjustCalculations(CalculateModel model, IFormCollection collection, string FloorHeightText)
        {
            _logger.LogInformation("adjusting calculation params");
            try
            {
                double w = Convert.ToDouble(collection["width"].ToString().Replace('.', ','));
                double h = Convert.ToDouble(collection["height"].ToString().Replace('.', ','));
                double d = Convert.ToDouble(collection["depth"].ToString().Replace('.', ','));
                string radioResult = await CacheGet();
                model.FloorHeight = Convert.ToDouble(FloorHeightText);
                await RadioResult(radioResult, model);
                await CalculateModel(model, true, w, h, d);
            }
            catch (Exception e)
            {
                ViewBag.Note = "coś poszło nie tak";
                _logger.LogError("error occured" + e.Message);
            }
            model.Success = true;

            await GetInputValues(model);
            return View("Calculate", model);
        }

        //Calculate Model outputs
        public async Task CalculateModel(CalculateModel model, bool change, double width = 0, double height = 0, double depth = 0)
        {
            //Success
            if (ModelValidation.Validate(model)==true)
            {
                CalculationModel process = new()
                {
                    DetachedHouse = model.DetachedHouse,
                    MultiFamilyHouse = model.MultiFamilyHouse,
                    Kindergarten = model.Kindergarten,
                    HealthCareBuilding = model.HealthCareBuilding,
                    Underground = model.Underground,
                    Garage = model.Garage,
                    FloorHeight = model.FloorHeight
                };

                await Calculation.MainCalculation(process, change,height,width,depth);

                //initilizie all model outputs
                model.AmoutOfStairs = process.AmoutOfStairs;
                model.Landing = process.Landing;
                if (model.Landing == true)
                {
                    model.LandingStairs += "";
                    foreach (var landing in process.LandingStairs)
                    {
                        model.LandingStairs += landing + " ";
                    }
                }
                else
                {
                    model.Landing = true;
                    model.LandingStairs = "brak";
                }
                model.Height = Math.Round(process.MaxHeight,3);
                model.Depth = Math.Round(process.Depth,3);
                model.Width = Math.Round(process.MinWidth,3);
                model.Success = true;
            }
            //Fail
            else
            {
                model.Success = false;
                ViewBag.Note = "Wysokość kondygnacji musi być większa niż 2.5 metra oraz mniejsza niż 12 metrów";
            }
        }
        //Caching
        public async Task CacheChoice(string radioResult)
        {
            //Keys
            Cache.Remove("radioResult");
            //Caching 
            Cache.Set("radioResult", radioResult);
        }
        //Getting user's choice from Cache
        public async Task<string> CacheGet()
        {
            string result = Cache.Get<string>("radioResult");
            return result;
        }
        //input range 
        public async Task GetInputValues(CalculateModel model)
        {
            if (model.DetachedHouse == true)
            {
                ViewData["height"] = MaximumHeight.DetachedHouse;
                ViewData["width"] = MinimumWidth.DetachedHouse;
            }
            else if(model.MultiFamilyHouse == true)
            {
                ViewData["height"] = MaximumHeight.MultiFamilyHouse;
                ViewData["width"] = MinimumWidth.MultiFamilyHouse;
            }
            else if(model.Kindergarten == true)
            {
                ViewData["height"] = MaximumHeight.Kindergarten;
                ViewData["width"] = MinimumWidth.Kindergarten;
            }
            else if(model.HealthCareBuilding == true)
            {
                ViewData["height"] = MaximumHeight.HealthCareBuilding;
                ViewData["width"] = MinimumWidth.HealthCareBuilding;
            }
            else if(model.Garage == true)
            {
                ViewData["height"] = MaximumHeight.Garage;
                ViewData["width"] = MinimumWidth.Garage;
            }
            else if(model.Underground == true)
            {
                ViewData["height"] = MaximumHeight.Underground;
                ViewData["width"] = MinimumWidth.Underground;
            }
        }
        
        public async Task RadioResult(string result, CalculateModel model)
        {
            if (result == "DetachedHouse")
            {
                model.DetachedHouse = true;
            }
            else if(result == "MultiFamilyHouse")
            {
                model.MultiFamilyHouse = true;
            }
            else if (result == "Kindergarten")
            {
                model.Kindergarten = true;
            }
            else if (result == "HealthCareBuilding")
            {
                model.HealthCareBuilding = true;
            }
            else if (result == "Garage")
            {
                model.Garage = true;
            }
            else if (result == "Underground")
            {
                model.Underground = true;
            }
        }
    }
}
