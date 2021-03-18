using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionCuotaModeradoraContributivo : LiquidacionCuotaModeradora
    {

        public LiquidacionCuotaModeradoraContributivo()
        {

        }

        public LiquidacionCuotaModeradoraContributivo(string numeroLiquidacion, DateTime fechaLiquidacion, String identificacionPaciente, String tipoAfiliacion, double salarioDevengado, double valorHospitalizacion) : base(numeroLiquidacion, fechaLiquidacion, identificacionPaciente, tipoAfiliacion, salarioDevengado, valorHospitalizacion)
        {

        }

        public override void CalcularTarifa()
        {
            if (SalarioDevengadoPaciente < DosSalariosMinimo)
            {
                Tarifa = 0.15;
            }
            else if (SalarioDevengadoPaciente >= DosSalariosMinimo && SalarioDevengadoPaciente <= CincoSalariosMinimo)
            {
                Tarifa = 0.2;
            }
            else
            {
                Tarifa = 0.25;
            }
        }

        public override void CalcularTope()
        {
            if (CuotaModeradoraInicial > DosSalariosMinimo)
            {
                Tope = 250000;
            }
            else if (CuotaModeradoraInicial >= DosSalariosMinimo && CuotaModeradoraInicial <= CincoSalariosMinimo)
            {
                Tope = 900000;
            }
            else
            {
                Tope = 1500000;
            }
        }

    }
}
