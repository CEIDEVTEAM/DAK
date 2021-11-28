using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Valdations.GlobalValidationsRules
{
    public class PositiveIntValidationRule
    {
        
        public PositiveIntValidationRule()
        {
          
        }

        public bool Validate(int value)
        {
            bool response = false;
            if (value > 0)
                response = true;

            return response;



        }
    }
}
