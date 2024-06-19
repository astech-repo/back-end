using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astech_DTO.Validations
{
    public class ImeiValidation
    {
        public bool ValidateIMEI(string imei)
        {
            if (imei.Length != 15)
                return false;

            int sum = 0;
            bool doubleDigit = true;

            for (int i = 0; i < 14; i++)
            {
                int digit = imei[i] - '0';

                if (doubleDigit)
                {
                    digit *= 2;
                    digit = digit / 10 + digit % 10;
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }

            int expectedDigit = (10 - (sum % 10)) % 10;

            int lastDigit = imei[14] - '0';
            return expectedDigit == lastDigit;
        }
    }
}
