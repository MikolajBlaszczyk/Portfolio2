using Logic.Model;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IMaxWidth
    {
        Task<double> CheckMaxHeight(CalculationModel input);
    }
}