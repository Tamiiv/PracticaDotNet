using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    public class Ejercicios
    {
        public void EjercicioListas()
        {
            /*   Tema: Listas
                 *Crear una lista de números
                 *Recorrerla con foreach
                 *Mostrar los pares   
            */

            List<int> numeros = [1, 2, 3, 4, 5, 6, 7, 8];

            Console.WriteLine("EJEMPLO 1");
            foreach (var numero in numeros)
            {
                if (numero % 2 == 0)
                {
                    Console.WriteLine(numero);
                }
            }

            Console.WriteLine();

            Console.WriteLine("EJEMPLO 2");
            foreach (var numero in numeros.Where(n => n % 2 == 0))
            {
                Console.WriteLine(numero);
            }
        }

        public void EjercicioLinq()
        {
            /*   Tema: LINQ básico
                 *.Where()
                 *.Select()
     
                 *Lista de productos (nombre + precio)
                 *Filtrar los que valen más de X
                 *Mostrar solo nombres
            */

            var productos = new List<(string Nombre, decimal Precio)>
{
                ("Arroz", 1450),
                ("Atún", 999.90m),
                ("Agua mineral", 1200),
                ("Tang", 500.50m)
            };

            // Mostrar productos que valgan más de $1.000
            Console.WriteLine("EJEMPLO 1");
            var nombres = productos.Where(p => p.Precio > 1000).Select(p => p.Nombre).ToList();

            foreach (var nombre in nombres)
            {
                Console.WriteLine(nombre);
            }

            Console.WriteLine();

            Console.WriteLine("EJEMPLO 2");
            var resultado2 = from producto in productos where producto.Precio > 1000 select producto.Nombre;

            foreach (var producto in resultado2)
            {
                Console.WriteLine(producto);
            }
        }

        public void EjercicioObjetos()
        {
            /*   Tema: Objetos - Clases simples
     
                 *Crear clase Producto
                 *Crear lista de productos
                 *Mostrar info formateada
            */

            List<Producto> productos = new List<Producto>();
            productos.Add(new Producto { Nombre = "Arroz", Precio = 1450 });
            productos.Add(new Producto { Nombre = "Atún", Precio = 999.90m });
            productos.Add(new Producto { Nombre = "Agua mineral", Precio = 1200 });
            productos.Add(new Producto { Nombre = "Tang", Precio = 500.50m });

            Console.WriteLine("EJEMPLO 1");
            foreach (var producto in productos)
            {
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Precio: $" + producto.Precio.ToString("N2", new CultureInfo("es-ES")));
            }

            Console.WriteLine();

            Console.WriteLine("EJEMPLO 2");

            foreach (var producto in productos)
            {
                producto.Mostrar();
            }
        }

        public void EjercicioDiccionarios()
        {
            /*   Tema: Diccionarios - Dictionary<TKey, TValue>
     
                 *Guardar productos por ID
                 *Buscar uno por ID
                 *Mostrar resultado
            */
            Console.WriteLine("EJEMPLO 1");
            Dictionary<int, string> productos = new Dictionary<int, string>(){
                {1, "Arroz"},
                {2, "Atún"},
                {3, "Agua Mineral"},
                {4, "Tang"}
            };

            // Buscar Agua Mineral
            if (productos.TryGetValue(3, out string producto))
            {
                Console.WriteLine("Producto encontrado: " + producto);
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }

            Console.WriteLine();

            Console.WriteLine("EJEMPLO 2");

            Dictionary<int, Producto> listaProductos = new Dictionary<int, Producto>();

            listaProductos.Add(1, new Producto { Nombre = "Arroz", Precio = 1450 });
            listaProductos.Add(2, new Producto { Nombre = "Atún", Precio = 999.90m });
            listaProductos.Add(3, new Producto { Nombre = "Agua Mineral", Precio = 1200 });

            if (listaProductos.TryGetValue(1, out Producto obj))
            {
                Console.WriteLine("Producto encontrado: " + obj.Nombre);
            }

        }

        public void EjercicioIntegracion()
        {
            /*   Tema: Mini integración
     
                 *Lista de productos
                 *Filtrar con LINQ
                 *Guardar en diccionario
                 *Mostrar resultado final
            */

            List<Producto> productos = new List<Producto>();
            productos.Add(new Producto { Id = 1, Nombre = "Arroz", Precio = 1450 });
            productos.Add(new Producto { Id = 2, Nombre = "Atún", Precio = 999.90m });
            productos.Add(new Producto { Id = 3, Nombre = "Agua mineral", Precio = 1200 });
            productos.Add(new Producto { Id = 4, Nombre = "Tang", Precio = 500.50m });

            // Guardar productos que valgan más de $1.000
            var productosGuardados = productos.Where(p => p.Precio > 1000).ToDictionary(p => p.Id, p => p.Nombre);

            // Mostrar productos
            Console.WriteLine("PRODUCTOS");
            foreach (var producto in productosGuardados)
            {
                Console.WriteLine("Nombre: " + producto.Value);
            }

        }

    }
}
