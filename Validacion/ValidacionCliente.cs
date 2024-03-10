﻿using APPEmpresa.ENTITY;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPEmpresa.Validacion
{
    public class ValidacionCliente : AbstractValidator<CLIENTE>
    {
        public ValidacionCliente()
        {

            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Deber escribir un nombre")
                                  .MinimumLength(2).WithMessage("El nombre no es valido")
                                  .Must(Letras).WithMessage("El nombre no puede contener caracteres especiales y/o números");

            RuleFor(x => x.APaterno).NotEmpty().WithMessage("Deber escribir un apellido paterno")
                                  .MinimumLength(2).WithMessage("El apellido paterno no es valido")
                                  .Must(Letras).WithMessage("El apellido paterno no puede contener caracteres especiales y/o números");

            RuleFor(x => x.AMaterno).NotEmpty().WithMessage("Deber escribir un apellido materno")
                                    .MinimumLength(2).WithMessage("El apellido materno no es valido")
                                    .Must(Letras).WithMessage("El apellido materno no puede contener caracteres especiales y/o números");

            RuleFor(x => x.RFC).NotEmpty().WithMessage("Deber escribir un RFC")
                               .MinimumLength(12).WithMessage("El RFC debe contener como minimo 12 caracteres")
                               .MaximumLength(13).WithMessage("El RFC debe contener como maximo 13 caracteres");

        }

        private bool Letras(string Texto)
        {
            bool Resultado = true;

            foreach (char Letra in Texto.Replace(" ", ""))
            {
                if (!char.IsLetter(Letra))
                {
                    Resultado = false;
                    break;
                }
            }
            return Resultado;
        }


    }
}
