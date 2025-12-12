using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzharaP2C
{
    public class Producto
    {
        //propidades 
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Talla { get; set; }
        //contructores
        public Producto()
        {
            Nombre = "no definido";
            Precio = "no definido";
            Talla = "No definido";
        }
        public Producto(string nom, string prc, string tlla)
        {
            Nombre = nom;
            Precio = prc;
            Talla = tlla;
        }
        //funcionalidad
        public string VerDatos()
        {
            return Nombre + " " + Precio + Talla.ToString();
        }
    }
}
