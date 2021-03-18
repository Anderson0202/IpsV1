using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacionCuotaModeradoraService
    {

        LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();

        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            try
            {
                if (liquidacionCuotaModeradoraRepository.BuscarPorIdentificacion(liquidacionCuotaModeradora.IdentificacionPaciente)== null)
                {
                    liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuotaModeradora);
                    return "Se guardaron los sus correctamente";
                }
                return $"No se pudo guardar, la identificacion ya existe: {liquidacionCuotaModeradora.IdentificacionPaciente}";
            }
            catch (Exception exception)
            {

                return $"Error o incohererncia de ingreso de dato: {exception.Message}";
            }
        }

    }   
}
