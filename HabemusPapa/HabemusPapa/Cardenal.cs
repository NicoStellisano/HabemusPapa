using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabemusPapa
{
    public class Cardenal
    {
        private int _cantVotosRecibidos;
        private ENacionalidades _nacionalidad;
        private string _nombre;
        private string _nombrePapal;

        private Cardenal()
        {
            this._cantVotosRecibidos = 0;
        }

        public Cardenal(string nombre, string nombrePapal):this()
        {
            this._nombre = nombre;
            this._nombrePapal = nombrePapal;
        }

        public Cardenal(string nombre, string nombrePapal,ENacionalidades nacionalidad):this(nombre,nombrePapal)
        {
            this._nacionalidad = nacionalidad;
        }

        public int getCantidadVotosRecibidos()
        {
            return this._cantVotosRecibidos;
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ObtenerNombreYNombrePapal());
            sb.AppendLine("Votos recibidos : " + this._cantVotosRecibidos);
            sb.AppendLine("Nacionalidad : " + this._nacionalidad);

            return sb.ToString();
        }

        public static string Mostrar(Cardenal c)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(c.ObtenerNombreYNombrePapal());
            sb.AppendLine("Votos recibidos : " + c._cantVotosRecibidos);
            sb.AppendLine("Nacionalidad : " + c._nacionalidad);

            return sb.ToString();
        }

        public string ObtenerNombreYNombrePapal()
        {
            string concatenado = "El cardenal" + this._nombre + " se llamara Papa " +this._nombrePapal;

            return concatenado;
        }

        public static bool operator !=(Cardenal c1,Cardenal c2)
        {
            if (c1._nombre == c2._nombre && c1._nombrePapal == c2._nombrePapal && c1._nacionalidad == c2._nacionalidad)
                return false;
            return true;
        }

        public static Cardenal operator ++(Cardenal c)
        {
            c._cantVotosRecibidos++;
            return c;
        }

          public static bool operator ==(Cardenal c1,Cardenal c2)
        {
            if (c1._nombre == c2._nombre && c1._nombrePapal == c2._nombrePapal && c1._nacionalidad == c2._nacionalidad)
                return true;
            return false;
        }



    }
}
