using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial.Models
{
    public class AutoMarcas
    {

        private Autos auto;
        private List<Marcas> marcas;

        public Autos Auto { get => auto; set => auto = value; }
        public List<Marcas> Marcas { get => marcas; set => marcas = value; }
    }
}