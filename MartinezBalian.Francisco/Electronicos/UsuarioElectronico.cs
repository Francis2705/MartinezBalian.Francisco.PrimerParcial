﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronicos
{
    public class UsuarioElectronico
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Legajo { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Perfil { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre} - Apellido: {Apellido}\n";
        }
    }
}