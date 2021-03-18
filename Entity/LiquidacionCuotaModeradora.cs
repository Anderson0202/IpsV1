using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionCuotaModeradora : Paciente
    {
        public Paciente Paciente { get; set; }
        public double Tarifa { get; set; }
        public double Tope { get; set; }
        public double Liquidacion { get; set; }
        public double CuotaModeradora { get; set; }
        public double CuotaModeradoraInicial { get; set; }
        public double DosSalariosMinimo = 1817052;
        public double CincoSalariosMinimo = 4542630;

        public LiquidacionCuotaModeradora(string numeroLiquidacion, DateTime fechaLiquidacion, string identificacionPaciente, string tipoAfiliacion, double salarioDevengadoPaciente, double valorServicio) : base (numeroLiquidacion, fechaLiquidacion, identificacionPaciente, tipoAfiliacion, salarioDevengadoPaciente, valorServicio) 
        {
            
        }

        public LiquidacionCuotaModeradora()
        {

        }

        public void CalcularLiquidacionCuotaModeradora()
        {
            CalcularTarifa();
            CuotaModeradoraInicial = ValorServicio * Tarifa;
            CalcularTope();
            CuotaModeradora = CalcularCuotaModeradoraFinal();
        }

        private double CalcularCuotaModeradoraFinal()
        {
            if (CuotaModeradoraInicial >
                Tope)
            {
                return Tope;
            }

            return CuotaModeradoraInicial;
        }

        public abstract void CalcularTope();

        public abstract void CalcularTarifa();

        
    }
}
