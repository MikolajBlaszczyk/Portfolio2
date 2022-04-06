using Logic.Model;
using System.Threading.Tasks;

namespace Logic
{
    public interface IStairs
    {
        Task<int> AmountOfStairs(CalculationModel input);
        Task<int> AmountOfStairs(decimal floorHeight, decimal maxStairHeight);
    }
}