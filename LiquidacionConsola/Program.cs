using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidacionConsola
{
    public class Program
    {
        static void Main(string[] args)
        {

            string numeroLiquidacion = Console.ReadLine();
            DateTime fechaLiquidacion = Convert.ToDateTime(Console.ReadLine());
            string identificacionPaciente = Console.ReadLine();
            string tipoAfilicacion = Console.ReadLine().ToUpper();
            double salarioDevengadoPaciente = Convert.ToDouble(Console.ReadLine());
            double servicioHospitalizacion = Convert.ToDouble(Console.ReadLine());
            LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService = new LiquidacionCuotaModeradoraService();
            LiquidacionCuotaModeradora liquidacionCuotaModeradora = new LiquidacionCuotaModeradoraSubsidiado(numeroLiquidacion, fechaLiquidacion, identificacionPaciente, tipoAfilicacion, salarioDevengadoPaciente, servicioHospitalizacion);
            liquidacionCuotaModeradora.CalcularLiquidacionCuotaModeradora();
            Console.WriteLine($"Su liquidacion es: {liquidacionCuotaModeradora.CuotaModeradora}");
            Console.WriteLine(liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora));
            Console.ReadKey();

        }
    }
}
