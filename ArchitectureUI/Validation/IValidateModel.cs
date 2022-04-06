using ArchitectureUI.Models;

namespace ArchitectureUI.Validation
{
    public interface IValidateModel
    {
        bool Validate(CalculateModel input);
    }
}