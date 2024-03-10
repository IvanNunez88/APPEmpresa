using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPEmpresa.DAL;
using APPEmpresa.ENTITY;
using APPEmpresa.Validacion;

namespace APPEmpresa.BLL
{
    public class BL_CLIENTE
    {
        public static List<string> ValidaDatosCliente(CLIENTE Cliente)
        {
            List<string> lstValidaciones = [];

            ValidacionCliente validationRules = new();
            var Resul = validationRules.Validate(Cliente);

            if (!Resul.IsValid)
            {
                lstValidaciones = Resul.Errors.Select(x => x.ErrorMessage).ToList();
            }

            return lstValidaciones;
        }

        public static List<string> RegistroCliente(CLIENTE Cliente)
        {
            List<string> lstDatos = [];

            try
            {
                var dpParametros = new
                {
                    P_Nombre = Cliente.Nombre,
                    P_APaterno = Cliente.APaterno,
                    P_AMaterno = Cliente.AMaterno,
                    P_RFC = Cliente.RFC
                };

                DapperContext.Procedimiento_StoreDB("spInsertCliente", dpParametros);
                lstDatos.Add("00");
                lstDatos.Add("Cliente guardado con éxito");

            }
            catch (Exception ex) 
            {
                lstDatos.Add("14");
                lstDatos.Add(ex.Message);
            }

            return lstDatos;
        }

    }
}
