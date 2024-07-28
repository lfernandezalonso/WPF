namespace MyChronometerWPFApp
{
    /*
     * La clase "MyTimerChronometer" se deriva de la clase abstracta MyAbstractChronometer y aquí si voy a tener en cuenta (e implementar) uno de los mecanismos / 
     * eventos que debe ser lanzado cada 1000 milisegundos (1 segundo) y que permite mostrar el tiempo acumulado en hh:mm:ss del cronómetro 
     * (SRP) Su responsabilidad es definir el funcionamiento del cronómetro que parte de dicho funcionamiento se base en el uso de una clase de tipo timer definido 
     * por "ITimerManager" que permite que cada 1 segundo se incremente el contador/total de milisegundos del cronómeto y en base a ese contador se muestra 
     * el total en hh:mm:ss transcurridos desde que se inició el cronómetro.
     */
    public class MyTimerChronometer : MyAbstractChronometer
    {
        private ITimerManager _timerManager;

        public MyTimerChronometer(ITimerManager timerManager) : base() //Aquí llamammos al constructor de la clase padre 
        {
            _timerManager = timerManager;
        }

        /*
         * Defino el cuerpo/código de los métodos que son abstractos en la clase base que a su vez es abstracta
         */
        public override void Start()
        {
            _timerManager.Start();
            if (IsPaused)
            {
                IsPaused = false;
            }
            if (IsStopped)
            {
                IsStopped = false;
            }
        }

        public override void Pause()
        {
            _timerManager.Stop();
            if (!IsPaused)
            {
                IsPaused = true;
            }
            if (IsStopped)
            {
                IsStopped = false;
            }
        }

        public override void Stop()
        {
            TotMilliSeconds = 0;
            _timerManager.Stop();
            if (!IsStopped)
            {
                IsStopped = true;
            }
            if (IsPaused)
            {
                IsPaused = false;
            }
        }

        /*
         * 
         */
        ~MyTimerChronometer()
        {
            if ((_timerManager as MySystemTimerManager) != null)
            {
                (_timerManager as MySystemTimerManager).Dispose();
            }
        }

    }
}