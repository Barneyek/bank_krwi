using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Bank_krwi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    
    public partial class App : Application
    {
        private const int min_spl_time = 5000;

        protected override void OnStartup(StartupEventArgs e) {
            splashScreen splash = new splashScreen();
            splash.Show();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            timer.Stop();
            int remainingTime = min_spl_time - (int)timer.ElapsedMilliseconds;
            if (remainingTime > 0) {
                Thread.Sleep(remainingTime);
            }
            splash.Close();
            
        
        }
    }
}
