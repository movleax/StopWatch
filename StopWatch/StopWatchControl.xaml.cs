﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for StopWatchControl.xaml
    /// </summary>
    public partial class StopWatchControl : UserControl
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;
        public StopWatchControl()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            stopWatch.Start();
            dispatcherTimer.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                lblTime.Content = currentTime;
            }
        }

        public void start()
        {
            stopWatch.Start();
            dispatcherTimer.Start();
        }

        public void stop()
        {
            stopWatch.Stop();
            dispatcherTimer.Stop();
        }
    }
}
