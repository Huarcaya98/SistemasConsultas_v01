using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesafioFundaProgra.Models
{

        public class Expediente
        {
            public string Codigo { get; set; }
            public string Dni { get; set; }
            public string Nombre { get; set; }
            public string Asunto { get; set; }
            public DateTime FechaRegistro { get; set; }

            public Expediente(string codigo, string dni, string nombre, string asunto, DateTime fechaRegistro)
            {
                Codigo = codigo;
                Dni = dni;
                Nombre = nombre;
                Asunto = asunto;
                FechaRegistro = fechaRegistro;
            }

            public override string ToString()
            {
                return $"[{Codigo}] | DNI: {Dni} | Nombre: {Nombre} | Asunto: {Asunto} | Fecha: {FechaRegistro:dd/MM/yyyy HH:mm}";
            }

            public string ALineaTexto()
            {
                return $"{Codigo}|{Dni}|{Nombre}|{Asunto}|{FechaRegistro:o}";
            }

            public static Expediente DesdeLineaTexto(string linea)
            {
                if (string.IsNullOrWhiteSpace(linea)) return null;
                string[] partes = linea.Split('|');
                if (partes.Length < 5) return null;

                return new Expediente(partes[0], partes[1], partes[2], partes[3], DateTime.Parse(partes[4]));
            }
        }
    }