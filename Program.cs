using APPEmpresa.ENTITY;
using APPEmpresa.BLL;
using APPEmpresa.Validacion;
using FluentValidation;
using System.Collections.Generic;

CLIENTE Cliente = new()
{
    Nombre = "Mario",
    APaterno = "Villa",
    AMaterno = "Ortega",
    RFC = "AAAAAAAAAAAA"
};

List<string> lstValidaciones = BL_CLIENTE.ValidaDatosCliente(Cliente);

if (lstValidaciones.Count == 0)
{

    List<string> lstDatos = BL_CLIENTE.RegistroCliente(Cliente);

    if (lstDatos[0] == "00")
    {
        Console.WriteLine(lstDatos[1]);
    }
    else
    {
        Console.WriteLine(lstDatos[1]);
    }

}
else
{
    Console.WriteLine("Listado de errores: ");

    foreach (var lst in lstValidaciones)
    {
        Console.WriteLine(lst);
    }
}


Console.ReadKey();