using ArchitectureUI.Models;

namespace ArchitectureUI.Validation
{
    public class ValidateModel : IValidateModel
    {
        public bool Validate(CalculateModel input)
        {
            double height = input.FloorHeight;

            if (height < 2.5 || height > 12)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
