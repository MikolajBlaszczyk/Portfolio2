using Logic.Model;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IDepthCalculations
    {
        Task<double> CalculateDepth(CalculationModel input);
    }
}