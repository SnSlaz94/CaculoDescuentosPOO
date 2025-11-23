using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaculoDescuentosPOO
{
    public class ProductoGeneral : Producto
    {
        public ProductoGeneral(string nombre, decimal precio) : base(nombre, precio)
        {
        }

        public override decimal CalcularDescuento()
        {
            return Precio * (1m - 0.05m);
        }
    }
}
