using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial.Models
{
    public class Marcas
    {

        private int idMarca;
        private string nombre;

        public Marcas(int idmarca, string nombre)
        {  
            this.nombre = nombre;
            this.idMarca = idmarca;
        }

        public Marcas()
        {
            
        }

        public int IdMarca { get => idMarca; set => idMarca = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}