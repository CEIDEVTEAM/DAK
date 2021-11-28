using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Valdations.GlobalValidationsRules
{
    public class PositiveDoubleValidationRule
    {
        
        public PositiveDoubleValidationRule()
        {
            
        }

        public bool Validate(double value)
        {
            bool response = false;
            if (value > 0)
                response = true;

            return response;



        }
    }
}
