using System.Threading.Tasks;

namespace Logic.Services.Change
{
    public interface IChangeParams
    {
        Task<double> MatchParams(double height, double depth);
    }
}