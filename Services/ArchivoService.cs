using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProyectoDesafioFundaProgra.Models;

namespace ProyectoDesafioFundaProgra.Services
{
    public class ArchivoService
    {
        private readonly string _rutaArchivo;

        public ArchivoService(string ruta = "expedientes_guardados.txt")
        {
            _rutaArchivo = ruta;
        }

        public void CargarDatos(GestorExpedientes gestor)
        {
            if (!File.Exists(_rutaArchivo)) return;

            string[] lineas = File.ReadAllLines(_rutaArchivo);
            foreach (string linea in lineas)
            {
                Expediente exp = Expediente.DesdeLineaTexto(linea);
                if (exp != null) gestor.Agregar(exp);
            }
        }

        public bool GuardarDatos(Expediente[] expedientes)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_rutaArchivo, false))
                {
                    foreach (var exp in expedientes)
                    {
                        if (exp != null) writer.WriteLine(exp.ALineaTexto());
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}