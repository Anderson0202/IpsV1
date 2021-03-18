using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Paciente
    {

        public string NumeroLiquidacion { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string TipoAfiliacion { get; set; }
        public double SalarioDevengadoPaciente { get; set; }
        public double ValorServicio { get; set; }

        public Paciente()
        {

        }

        public Paciente(string numeroLiquidacion, DateTime fechaLiquidacion, string identificacionPaciente, string tipoAfiliacion, double salarioDevengadoPaciente, double valorServicio)
        {
            NumeroLiquidacion = numeroLiquidacion;
            FechaLiquidacion = fechaLiquidacion;
            IdentificacionPaciente = identificacionPaciente;
            TipoAfiliacion = tipoAfiliacion;
            SalarioDevengadoPaciente = salarioDevengadoPaciente;
            ValorServicio = valorServicio;
        }
    }
}
