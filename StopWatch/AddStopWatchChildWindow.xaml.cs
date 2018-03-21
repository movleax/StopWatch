using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for AddStopWatchChildWindow.xaml
    /// </summary>
    public partial class AddStopWatchChildWindow : Window
    {
        static private AddStopWatchChildWindow instance;
        static private StopWatchChildWindow StopWatchCallerObject;

        public static void OpenAddStopWatchChildWindow()
        {
            CheckInstance();

            if (instance.IsVisible)
                return;

            instance.Show();
        }

        static public void CloseAddStopWatchChildWindow()
        {
            CheckInstance();
            instance.Close();
        }

        static private void CheckInstance()
        {
            if (instance == null)
                instance = new AddStopWatchChildWindow();
        }

        private AddStopWatchChildWindow()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            CheckInstance();

            if (TaskNameField.Text == null || TaskNameField.Text == "")
            {
                MessageBox.Show("Cannot create new task with an Empty Name", "Unable to create task...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            StopWatchChildWindow stopWatchChildWindow = new StopWatchChildWindow(TaskNameField.Text);
            TaskDataManager.AddStopWatchChildWindow(stopWatchChildWindow);
            MainWindow.AddNewStopWatchChildWindow(stopWatchChildWindow.GetGuid());
            StopWatchCallerObject = null;
            TaskNameField.Text = null;
            this.Hide();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CheckInstance();
            TaskNameField.Text = null;
            
            StopWatchCallerObject = null;
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
