using System.Timers;

namespace MyChronometerWPFApp
{
    /*
    * La clase "MySystemTimerManager" implementa la interface ITimerManager.
    * (SRP) Su responsabilidad es administrar objetos Timer del tipo Sytem.Timers.Timer que aunque no hayan sido creados especificamente  para trabajar en el entorno 
    * de las aplicaciones WPF si están funcionando con estas.
    * Aunque era suficiente con haber definido solo la clase "MyDispatcherTimerManager" y realmente no hace mucha falta esta clase, de todas formas la definí para
    * que hubiera más ejemplos de principios SOLID en este proyecto.
    */
    public class MySystemTimerManager : ITimerManager
    {
        /*
         * No voy a defininir propiedades con respecto a este campo porque no quiero que sea accesible fuera de esta clase
         * Aparentemente "Timer _timer" es una dependencia para la clase "MyDispatcherTimerManager" pero no es del todo así porque:
         * 1- No estamos a cargo de la definición de la clase DispatcherTimer, más bien es una clase interna a nivel del S.O. por tanto nosostros no podemos
         * cambiar su definición en un futuro.
         * 2- No existe una interface "IDispatcherTimer" con la cual podamos sustituir "DispatcherTimer" 
       */
        private Timer _timer;

        public MySystemTimerManager(ElapsedEventHandler eventHandler) : base()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += eventHandler;
        }

        public void SetEventHandler(ElapsedEventHandler eventHandler)
        {
            _timer.Elapsed += eventHandler;
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

        public void Dispose()
        {
            _timer.Dispose();
        }

        ~MySystemTimerManager()
        {
            _timer.Dispose();
        }
    }
}