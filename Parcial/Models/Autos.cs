using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial.Models
{
    public class Autos
    {

        // private int idAuto;
        private string patente;
        private int idMarca;
        private int km;
        private bool promocion;
        private float precioReal;
        private Marcas marca;


        public Autos()
        {
            
        }

        public Autos(string patente, int idMarca, int km, bool promocion, float precioReal)
        {
            this.patente = patente;
            this.idMarca = idMarca;
            this.km = km;
            this.promocion = promocion;
            this.precioReal = precioReal;
            this.Marca = new Marcas();
            this.Marca.IdMarca = idMarca;
        }

        public string Patente { get => patente; set => patente = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
        public int Km { get => km; set => km = value; }
        public bool Promocion { get => promocion; set => promocion = value; }
        public float PrecioReal { get => precioReal; set => precioReal = value; }
        public Marcas Marca { get => marca; set => marca = value; }

        public string PromocionSiNo()
        {
            string valor = "";
            if (Promocion)
            {
                valor = "SI";
            }
            else
            {
                valor = "No";
            }
            return valor;
        }

        public float Precio()
        {
            float valor = 0;
            if (Promocion)
            {
                valor = precioReal-( precioReal * 0.10f);
            }
            else
            {
                valor = precioReal;
            }

            return valor;
        }
    }
}

