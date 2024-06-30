using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Validacion
    {
        public bool isEmpty(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return true;

            return false;
        }

        public bool onlyNumbers(string cadena)
        {
            if (decimal.TryParse(cadena, NumberStyles.Number, CultureInfo.GetCultureInfo("es-ES"), out _))
                return true;

            return false;
        }
    }
}
