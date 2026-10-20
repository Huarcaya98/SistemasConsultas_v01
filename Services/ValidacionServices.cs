using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace ProyectoDesafioFundaProgra.Services
{
    public static class ValidacionService
    {
        public static bool ValidarDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;
            return Regex.IsMatch(dni.Trim(), @"^\d{8}$");
        }

        public static bool ValidarTexto(string texto, int minLongitud = 3)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;
            return texto.Trim().Length >= minLongitud;
        }

        public static string LimpiarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;
            return texto.Trim().ToUpper();
        }
    }
}
