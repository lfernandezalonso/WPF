using System;

namespace MyChronometerWPFApp
{
    /* 
     * Esta es una clase abstracta (de alto nivel) y es la clase base de donde se van a derivar clases de tipo cronómetro que podemos usar en este app.
     * 
     * (SRP) Su responsabilidad es definir los campos (fields), properties y métodos que deben de tener los cronómetros. Y dejamos para otra/s clases derivadas
     * la responsabilidad de definir el funcionamiento del cronómetro y el detalle de la implementaciónn del mecanismo/evento que debe ser lanzado cada 
     * 1000 milisegundos (1 segundo) y que permite mostrar el tiempo acumulado en hh:mm:ss. Por ese motivo varios de los métodos están declarados como "abstract". 
     * He creado al menos 1 clase derivada de esta clase que si implementa dichos métodos abstractos.
     * 
     * Creo que esta clase es un ejemplo del principio SOLID Open-Closed (OCP). Esta clase está abierta a ser extendida (y de hecho he creado clase derivadas),
     * pero cerrada a modificaciones.
     */
    public abstract class MyAbstractChronometer
    {
        /*
         * Creo que la mejor forma de poder implementar el cronómetro es acumulando milisegundos (o segundos). Yo me he decantado por los milisegundos.
         * Además del total de milisegundos hay otros 2 campos tipo bool necesarios para el funcionamiento y/o control de los cronómetros.
          */
        private double _TotMilliSeconds;

        /*
         * Necesito este campo para saber si el usuario pausó temporalemente el cronómetro o no.
         */
        private bool _IsPaused;

        /*
         * Necesito este campo para saber si el usuario paró el cronómetro definitivamente (solo se podría relanzar de nuevo con Start) y al pararlo
         * se restablece a 0 el contador de milisegundos del cronómetro.
         */
        private bool _IsStopped;

        /* 
        * Properties
        */
        public double TotMilliSeconds
        {
            get => _TotMilliSeconds;
            set
            {
                _TotMilliSeconds = value;
            }
        }

        /*
         * Propiedad que dado el número de milisegundos acumulados/total nos devuelve una cadena de caracteres
         */
        public string TimeTxt
        {
            get
            {
                TimeSpan temp = TimeSpan.FromMilliseconds(TotMilliSeconds);
                return temp.ToString(@"hh\:mm\:ss");
            }
        }

        public bool IsPaused
        {
            get => _IsPaused;
            set
            {
                _IsPaused = value;
            }
        }

        public bool IsStopped
        {
            get => _IsStopped;
            set
            {
                _IsStopped = value;
            }
        }

        /*
         * Constructor:
         * Al crear una instancia de esta clase el total de milisegundos debe ser 0, el cronómetro no ha sido pausado por el usuario y si está totalmente detenido.
         */
        public MyAbstractChronometer()
        {
            _TotMilliSeconds = 0;
            _IsPaused = false;
            _IsStopped = true;
        }

        /*
         * Métodos 
         */

        /*
         * Debe haber un evento que cada 1000 milisegundos (o sea 1 segundo) debe llamar este método que incrementa el total de Milisegundos
         */
        public void Increment() => _TotMilliSeconds += 1000;

        /*
         * Método que permite que el cronómetro se active por primera vez después de creado, o luego de haber sido pausado temporalmente, 
         * o despues de haber sido detenido lo cual resetea su contador
         */
        public abstract void Start();

        /*
         * Método que permite pausar el cronómetro por un tiempo, el total de milisegundos (o segundos) acumulados no se debe incrementar durante esa
         * pausa de tiempo
         */
        public abstract void Pause();

        /*
         * Método que permite detener el cronómetro y reinicia su contador de milisegundos internos
         */
        public abstract void Stop();

    }
}