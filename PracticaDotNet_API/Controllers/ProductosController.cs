using Ejercicios;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace PracticaDotNet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> productos = new List<Producto>()
        {
            new Producto { Id = 1, Nombre = "Arroz", Precio = 1450 },
            new Producto { Id = 2, Nombre = "Atún", Precio = 999.90m },
            new Producto { Id = 3, Nombre = "Agua mineral", Precio = 1200 },
            new Producto { Id = 4, Nombre = "Tang", Precio = 500.50m }
        };


        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return productos;
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = productos.Where(p  => p.Id == id).FirstOrDefault();

            if (producto == null) 
                return NotFound();
            
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Create(Producto producto)
        {
            if (productos.Any(p => p.Id == producto.Id))
                return Conflict("El ID ya existe");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                return BadRequest("Nombre requerido");

            if (producto.Precio <= 0)
                return BadRequest("Precio inválido");

            productos.Add(producto);

            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Producto updated)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(updated.Nombre))
                return BadRequest("Nombre requerido");

            if (updated.Precio <= 0)
                return BadRequest("Precio inválido");

            producto.Nombre = updated.Nombre;
            producto.Precio = updated.Precio;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
                return NotFound();

            productos.Remove(producto);

            return NoContent();
        }

    }
}
