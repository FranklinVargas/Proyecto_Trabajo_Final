﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eCliente
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Contrasenia { get; set; }
        public string Tipo_pago { get; set; }
    }
}
