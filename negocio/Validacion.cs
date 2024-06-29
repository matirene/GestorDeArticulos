using System;
using System.Collections.Generic;
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
            if (int.TryParse(cadena, out _))
                return true;

            return false;
        }
    }
}
