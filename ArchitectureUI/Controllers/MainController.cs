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

namespace ArchSite.Controllers
{
    public class MainController : Controller
    {
        public ICalculation Calculation { get; set; }
        public  IValidateModel ModelValidation { get; set; }
        private readonly ILogger<MainController> _logger;

        public MainController(ICalculation calculation, ILogger<MainController> logger, IValidateModel modelValidation)
        {
            Calculation = calculation;
            _logger = logger;
            ModelValidation = modelValidation;
        }

        public async Task<IActionResult> Index()
        {
            _logger.Log(LogLevel.Information, "MainController index initilized");
            return View();
        }

        public async Task<IActionResult> Calculate()
        {
            CalculateModel model = new();
            //setting
            model.Success = false;
            ViewBag.Note = "Podaj wysokość kondygnacji i wybierz typ budynku";
            _logger.LogInformation("Calculate Initilize");
            return View(model);
        }

        [RequireHttps]
        [HttpPost]
        public async Task<IActionResult> Calculate(CalculateModel model, string FloorHeightText)
        {
            if (FloorHeightText is not null)
            {
                model.FloorHeight = Convert.ToDouble(FloorHeightText.Replace('.', ','));
                try
                {
                    await CalculateModel(model);
                }
                catch (Exception)
                {
                    ViewBag.Note = "nie wybrano typu budynku";
                    _logger.LogError("invalid building type");
                }

            }
            else
            {
                ViewBag.Note = "nie podano wysokości kondygnacji";
                _logger.LogError("Invalid floor height");
            }

            return View(model);
        }

        public async Task CalculateModel(CalculateModel model)
        {
           
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
                await Calculation.MainCalculation(process);
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
                model.MaxHeight = process.MaxHeight;
                model.Depth = process.Depth;
                model.MaxWidth = process.MaxWidth;
                model.Success = true;
            }
            else
            {
                model.Success = false;
                ViewBag.Note = "Wysokość kondygnacji musi być większa niż 2.5 metra oraz mniejsza niż 12 metrów";
            }
        }
    }
}
