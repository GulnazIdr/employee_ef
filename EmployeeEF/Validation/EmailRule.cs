using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmployeeEF.Validation
{
    public class EmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = string.Empty;
            if (value == null)
            {
                return new ValidationResult(false, "Адрес эл. почты не задан");
            }
            else
            {
                email = value.ToString();
                if (email.Contains("@") && email.Contains("."))
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Адрес эл почты должен содержать символы @ и точки " +
                        " \n Шаблон адреса: address@mymail.com");
                }
            }
        }
    }
}
