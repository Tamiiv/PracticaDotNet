using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public string Mostrar()
        {
            return $"Nombre: {Nombre} - Precio: ${Precio:N2}";
        }

    }
}
