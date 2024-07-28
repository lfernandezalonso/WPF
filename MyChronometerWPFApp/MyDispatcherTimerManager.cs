using System;
using System.Windows.Threading;

namespace MyChronometerWPFApp
{
    /*
    * La calase MyDispatcherTimerManager implementa la interface ITimerManager.
    * (SRP) Su responsabilidad es administrar objetos Timer del tipo System.Windows.Threading.DispatcherTimer que han sido creados para trabajar en el entorno de 
    * las aplicaciones WPF.
    */
    public class MyDispatcherTimerManager : ITimerManager
    {
        /*
         * No voy a defininir propiedades con respecto a este campo porque no quiero que sea accesible fuera de esta clase.
         * Aparentemente "DispatcherTimer _timer" es una dependencia para la clase "MyDispatcherTimerManager" pero no es del todo así porque:
         * 1- No estamos a cargo de la definición de la clase DispatcherTimer, más bien es una clase interna a nivel del S.O. por tanto nosostros no podemos
         * cambiar su definición en un futuro.
         * 2- No existe una interface "IDispatcherTimer" con la cual podamos sustituir "DispatcherTimer" 
         */
        private DispatcherTimer _timer;

        public MyDispatcherTimerManager()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000) };
        }

        public MyDispatcherTimerManager(EventHandler eventHandler)
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000) };
            _timer.Tick += eventHandler;
        }

        public void SetEventHandler(EventHandler eventHandler)
        {
            _timer.Tick += eventHandler;
        }

        /*
         * Definición de los métodos Start y Stop que vienen de la interface "ITimerManager"
         */
        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
