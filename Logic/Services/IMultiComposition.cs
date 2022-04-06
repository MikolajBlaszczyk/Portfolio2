using Logic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public interface IMultiComposition
    {
        Task<List<int>> CalculateLandings(CalculationModel model);
        Task<List<int>> Landings(double stairsNumber);
    }
}