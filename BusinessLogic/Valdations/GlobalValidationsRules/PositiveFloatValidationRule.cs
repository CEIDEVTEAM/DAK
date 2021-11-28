using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Valdations.GlobalValidationsRules
{
    public class PositiveFloatValidationRule
    {
        
        public PositiveFloatValidationRule()
        {
            
        }

        public bool Validate(float value)
        {
            bool response = false;
            if (value > 0)
                response = true;

            return response;



        }
    }
}
