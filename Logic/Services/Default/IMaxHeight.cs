using Logic.Model;
using System.Threading.Tasks;

namespace Logic
{
    public interface IMaxHeight
    {
        Task<double> CheckMaxHeight(CalculationModel input);
    }
}