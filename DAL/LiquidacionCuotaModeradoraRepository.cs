using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {

        private readonly string ruta = @"PacienteLiquidacionCuotaModeradora.txt";

        public void Guardar(LiquidacionCuotaModeradora liquidacionPaciente)
        {

            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{liquidacionPaciente.NumeroLiquidacion};{liquidacionPaciente.FechaLiquidacion};{liquidacionPaciente.IdentificacionPaciente};{liquidacionPaciente.TipoAfiliacion};{liquidacionPaciente.SalarioDevengadoPaciente};{liquidacionPaciente.ValorServicio};{liquidacionPaciente.Tarifa};{liquidacionPaciente.CuotaModeradoraInicial};{liquidacionPaciente.CuotaModeradora};{liquidacionPaciente.Tope}");
            escritor.Close();
            file.Close();
        }

        public LiquidacionCuotaModeradora BuscarPorIdentificacion(string identificacion)
        {

            foreach (var item in Consultar())
            {
                if (item.IdentificacionPaciente.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        private List<LiquidacionCuotaModeradora> Consultar()
        {
            List<LiquidacionCuotaModeradora> pacientes = new List<LiquidacionCuotaModeradora>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                LiquidacionCuotaModeradora paciente = MapearPaciente(linea);
                pacientes.Add(paciente);
            }
            file.Close();
            reader.Close();
            return pacientes;
        }

        private static LiquidacionCuotaModeradora MapearPaciente(string linea)
        {
            string[] vectorDatosPaciente = linea.Split(';');
            LiquidacionCuotaModeradora liquidacionCuotaModeradoraPaciente;

            if (vectorDatosPaciente[3       ] == "C")
            {
                liquidacionCuotaModeradoraPaciente = new LiquidacionCuotaModeradoraContributivo();
            }
            else
            {
                liquidacionCuotaModeradoraPaciente = new LiquidacionCuotaModeradoraSubsidiado();
            }
            liquidacionCuotaModeradoraPaciente.NumeroLiquidacion = vectorDatosPaciente[0];
            liquidacionCuotaModeradoraPaciente.FechaLiquidacion = Convert.ToDateTime(vectorDatosPaciente[1]);
            liquidacionCuotaModeradoraPaciente.IdentificacionPaciente = vectorDatosPaciente[2];
            liquidacionCuotaModeradoraPaciente.TipoAfiliacion = vectorDatosPaciente[3];
            liquidacionCuotaModeradoraPaciente.SalarioDevengadoPaciente = Convert.ToDouble(vectorDatosPaciente[4]);
            liquidacionCuotaModeradoraPaciente.ValorServicio = Convert.ToDouble(vectorDatosPaciente[5]);
            liquidacionCuotaModeradoraPaciente.Tarifa = Convert.ToDouble(vectorDatosPaciente[6]);
            liquidacionCuotaModeradoraPaciente.CuotaModeradoraInicial = Convert.ToDouble(vectorDatosPaciente[7]);
            liquidacionCuotaModeradoraPaciente.CuotaModeradora = Convert.ToDouble(vectorDatosPaciente[8]);
            liquidacionCuotaModeradoraPaciente.Tope = Convert.ToDouble(vectorDatosPaciente[9]);
            return liquidacionCuotaModeradoraPaciente;
        }

    }
}
