using System;
using ProyectoDesafioFundaProgra.Models;
using ProyectoDesafioFundaProgra.Services;

namespace MesaDePartesDigital
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorExpedientes gestor = new GestorExpedientes(100);
            ArchivoService archivoService = new ArchivoService();

            archivoService.CargarDatos(gestor);

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("  MESA DE PARTES DIGITAL - MUNICIPALIDAD DISTRITAL");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Registrar nuevo expediente");
                Console.WriteLine("2. Buscar expediente por código");
                Console.WriteLine("3. Ordenar y listar expedientes");
                Console.WriteLine("4. Salir y Guardar");
                Console.WriteLine("--------------------------------------------------");
                Console.Write("Seleccione una opción (1-4): ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Registrar(gestor, archivoService);
                        break;
                    case "2":
                        Buscar(gestor);
                        break;
                    case "3":
                        Listar(gestor);
                        break;
                    case "4":
                        archivoService.GuardarDatos(gestor.ObtenerTodos());
                        continuar = false;
                        Console.WriteLine("\n[+] Datos guardados. Saliendo...");
                        break;
                    default:
                        Console.WriteLine("\n[!] Opción inválida. Presione ENTER.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void Registrar(GestorExpedientes gestor, ArchivoService archivo)
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE NUEVO EXPEDIENTE ---");
            Console.Write("DNI ciudadano (8 dígitos): ");
            string dni = Console.ReadLine();

            if (!ValidacionService.ValidarDni(dni))
            {
                Console.WriteLine("\n[ERROR] DNI inválido. Debe tener 8 dígitos.");
                Console.ReadLine();
                return;
            }

            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Asunto: ");
            string asunto = Console.ReadLine();

            string codigo = gestor.GenerarCodigo();
            Expediente nuevoExp = new Expediente(codigo, dni.Trim(), ValidacionService.LimpiarTexto(nombre), asunto.Trim(), DateTime.Now);

            if (gestor.Agregar(nuevoExp))
            {
                archivo.GuardarDatos(gestor.ObtenerTodos());
                Console.WriteLine($"\n[ÉXITO] Registrado con código: {codigo}");
            }
            Console.ReadLine();
        }

        static void Buscar(GestorExpedientes gestor)
        {
            Console.Clear();
            Console.WriteLine("--- BÚSQUEDA DE EXPEDIENTE ---");
            Console.Write("Código a buscar (ej. EXP-2026-001): ");
            string cod = Console.ReadLine();

            Expediente resultado = gestor.BuscarPorCodigo(cod);
            Console.WriteLine(resultado != null ? $"\nEncontrado: {resultado}" : "\n[!] No encontrado.");
            Console.ReadLine();
        }

        static void Listar(GestorExpedientes gestor)
        {
            Console.Clear();
            Console.WriteLine("--- LISTADO DE EXPEDIENTES ---");
            gestor.OrdenarPorCodigo();
            Expediente[] lista = gestor.ObtenerTodos();

            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {lista[i]}");
            }
            Console.ReadLine();
        }
    }
}