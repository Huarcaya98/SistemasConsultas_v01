using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDesafioFundaProgra.Models;

namespace ProyectoDesafioFundaProgra.Services
{
    public class GestorExpedientes
    {
        private Expediente[] _expedientes;
        private int _totalExpedientes;

        public GestorExpedientes(int capacidadMax = 100)
        {
            _expedientes = new Expediente[capacidadMax];
            _totalExpedientes = 0;
        }

        public int Total => _totalExpedientes;

        public string GenerarCodigo()
        {
            return $"EXP-{DateTime.Now.Year}-{(_totalExpedientes + 1):D3}";
        }

        public bool Agregar(Expediente expediente)
        {
            if (_totalExpedientes >= _expedientes.Length) return false;
            _expedientes[_totalExpedientes] = expediente;
            _totalExpedientes++;
            return true;
        }

        public Expediente BuscarPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;
            string codBuscado = codigo.Trim().ToUpper();

            for (int i = 0; i < _totalExpedientes; i++)
            {
                if (_expedientes[i].Codigo.Equals(codBuscado, StringComparison.OrdinalIgnoreCase))
                    return _expedientes[i];
            }
            return null;
        }

        public void OrdenarPorCodigo()
        {
            for (int i = 0; i < _totalExpedientes - 1; i++)
            {
                for (int j = 0; j < _totalExpedientes - i - 1; j++)
                {
                    if (string.Compare(_expedientes[j].Codigo, _expedientes[j + 1].Codigo, StringComparison.Ordinal) > 0)
                    {
                        Expediente aux = _expedientes[j];
                        _expedientes[j] = _expedientes[j + 1];
                        _expedientes[j + 1] = aux;
                    }
                }
            }
        }

        public Expediente[] ObtenerTodos()
        {
            Expediente[] copia = new Expediente[_totalExpedientes];
            Array.Copy(_expedientes, copia, _totalExpedientes);
            return copia;
        }
    }
}

