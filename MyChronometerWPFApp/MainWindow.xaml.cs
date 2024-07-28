using System.Timers;
using System;
using System.Windows;

namespace MyChronometerWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //MainWindow(ITimerManager _timerManager 
    {
        private MyAbstractChronometer ch;

        private readonly ITimerManager timerManager;

        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ch.Increment();
            Application.Current.Dispatcher.Invoke(() => lblTimeDisplay.Content = ch.TimeTxt);
        }

        public void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ch.Increment();
            Application.Current.Dispatcher.Invoke(() => lblTimeDisplay.Content = ch.TimeTxt);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(ITimerManager _timerManager) /* : this() */
        {
            InitializeComponent();

            timerManager = _timerManager;


            ((MyDispatcherTimerManager) timerManager).SetEventHandler(dispatcherTimer_Tick);

            /*
            * A continuación hay un ejemplo del uso del principio "Liskov Substitution Principle (LSP)":
            * A variables de la clase base "MyAbstractChronometer" le pueden ser asignadas instancias/objetos de sus clases hijas/derivadas como por ejemplo de la 
            * clase "MyTimerChronometer" sin que haya alguna alteración de la correcta ejecución de la aplicación.
            */
            ch = new MyTimerChronometer(timerManager);

            /*
             * En estos momentos ch.TimeText devuelve "00:00:00" como es lógico
             */
            lblTimeDisplay.Content = ch.TimeTxt;

            btnStart.IsEnabled = true;
            btnPause.IsEnabled = false;
            btnStop.IsEnabled = false;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ch.Start();
            btnStart.IsEnabled = false;
            btnPause.IsEnabled = true;            
            btnStop.IsEnabled = true;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            ch.Pause();
            btnStart.IsEnabled = true;
            btnPause.IsEnabled = false;
            btnStop.IsEnabled = false;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            ch.Stop();
            lblTimeDisplay.Content = ch.TimeTxt;
            btnStart.IsEnabled = true;
            btnPause.IsEnabled = false;
            btnStop.IsEnabled = false;
        }
    }
}
