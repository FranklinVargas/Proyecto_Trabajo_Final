using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eCompra
    {
        public int Codigo_compra { get; set; }
        public int Dni { get; set; }
        public int Codigo_producto { get; set; }
        public string Color { get; set; }
        public double Precio { get; set; }

    }
}
