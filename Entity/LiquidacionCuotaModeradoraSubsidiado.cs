using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionCuotaModeradoraSubsidiado : LiquidacionCuotaModeradora
    {
        public LiquidacionCuotaModeradoraSubsidiado()
        {

        }
        public LiquidacionCuotaModeradoraSubsidiado(string numeroLiquidacion, DateTime fechaLiquidacion, String identificacionPaciente, String tipoAfiliacion, double salarioDevengado, double valorHospitalizacion) : base(numeroLiquidacion, fechaLiquidacion, identificacionPaciente, tipoAfiliacion, salarioDevengado, valorHospitalizacion)
        {

        }

        public override void CalcularTarifa()
        {
            Tarifa = 0.05;
        }

        public override void CalcularTope()
        {
            Tope = 200000;
        }
    }
}
