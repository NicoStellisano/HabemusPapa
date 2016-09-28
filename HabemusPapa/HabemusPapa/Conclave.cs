using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabemusPapa
{
    public class Conclave
    {
        private int _cantMaxCardenales;
        private List<Cardenal> _cardenales;
        private bool _habemusPapa;
        private string _lugarEleccion;
        private Cardenal _papa;
        public static int cantidadVotaciones;
        public static DateTime fechaVotacion;

        static Conclave()
        {
            Conclave con;
            con = new Conclave();
           cantidadVotaciones = 0;
           fechaVotacion = DateTime.Today;
        }
            
            

        

        public Conclave()
        {
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";
            cantidadVotaciones = 0;
            fechaVotacion = DateTime.Today;
            this._cardenales = new List<Cardenal>();
        }

        private Conclave(int cantidadCardenales):this()
        {
            this._cantMaxCardenales = cantidadCardenales;
        }

        public Conclave(int cantidadCardenales, string lugarEleccion):this(cantidadCardenales)
        {

        }

        private void ContarVotos(Conclave conclave)
        {
            
            int ganador=conclave._cardenales[0].getCantidadVotosRecibidos();
            foreach (Cardenal item in conclave._cardenales)
            {

                if (item.getCantidadVotosRecibidos() > ganador)
                {
                    conclave._habemusPapa = true;
                    conclave._papa = item;
                    break;
                }
                else
                    ganador = item.getCantidadVotosRecibidos();
                
            }
            if (conclave._habemusPapa != true)
            {
                conclave._habemusPapa = false;
            }

        }

        public static explicit operator bool(Conclave con)
        {
            return con._habemusPapa;
        }

        private bool HayLugar()
        {
            if (this._cardenales.Count < this._cantMaxCardenales)
                return true;
            return false;
        }

        public static implicit operator Conclave(int cantidadCardenales)
        {
            return new Conclave(cantidadCardenales);
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lugar de Votacion : " + this._lugarEleccion);
            sb.AppendLine("Fecha de Votacion : " + fechaVotacion);
            sb.AppendLine("Cantidad de votos : " + cantidadVotaciones);
            if (_habemusPapa == true)
                sb.AppendLine("HABEMUS PAPA ");
            else
                sb.AppendLine("NO HABEMUS PAPA ");
            sb.AppendLine(this.MostrarCardenales());

            return sb.ToString();


        }

        private string MostrarCardenales()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CARDENALES:");
            sb.AppendLine();
            foreach (Cardenal item in this._cardenales)
            {
                sb.AppendLine(Cardenal.Mostrar(item));
            }
            return sb.ToString();
        }

        public static bool operator !=(Conclave con, Cardenal c)
        {
            foreach (Cardenal item in con._cardenales)
            {
                if (item == c)
                    return false;
            }
            return true;
        }


        public static Conclave operator +(Conclave con, Cardenal c)
        {
            if (con.HayLugar() == true)
            {
                foreach (Cardenal item in con._cardenales)
                {
                    if (item == c)
                    {
                        Console.WriteLine("El cardenal ya está en el Cónclave!!!");
                        return con;
                    }
                    
                }
                con._cardenales.Add(c);
                return con;
            }else{
                Console.WriteLine("No hay mas lugar !!!");
                return con;
            }
        }


        public static bool operator ==(Conclave con, Cardenal c)
        {
            foreach (Cardenal item in con._cardenales)
            {
                if (item == c)
                    return true;
            }
            return false;

        }
        public static void VotarPapa(Conclave conclave)
        {
            int indicePapal;
            Random objRandom = new Random();
            for (int i = 0; i < conclave._cardenales.Count; i++)      
            {
                indicePapal = objRandom.Next(0, conclave._cardenales.Count);
                conclave._cardenales[indicePapal]++;
            }
        }



    
    }
}
