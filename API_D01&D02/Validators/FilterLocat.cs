using System.ComponentModel.DataAnnotations;

namespace API_D01_D02.Validators
{
    public class FilterLocatAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            if (value == null) 
                return false;
            if (value.ToString() == "EG" ||  value.ToString() == "USA") 
            {
                return true;
            }
            return false;

        }
    }
}
