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
    /// Interaction logic for AddLogWindow.xaml
    /// </summary>
    public partial class AddLogWindow : Window
    {
        static private AddLogWindow instance;
        static private TaskData taskData;
        static private StopWatchChildWindow StopWatchCallerObject;

        public static void OpenAddLogWindow(Guid StopWatchChildWindowGUID)
        {
            CheckInstance();

            if (instance.IsVisible)
                return;

            StopWatchCallerObject = TaskDataManager.GetStopWatchChildWindow(StopWatchChildWindowGUID);

            //instance.DescriptionField.Text = "Description";
            //instance.TopicField.Text = "Enter Topic";
            instance.Show();
        }

        static public void CloseAddLogWindow()
        {
            CheckInstance();
            instance.Close();
        }

        static private void CheckInstance()
        {
            if(instance == null)
                instance = new AddLogWindow();
            //return instance;
        }

        private AddLogWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            CheckInstance();

            if(TopicField.Text == null || TopicField.Text == "")
            {
                MessageBox.Show("Cannot Add Log Item with an Empty Topic", "Unable to Add Log Item...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            taskData = new TaskData(TopicField.Text, DescriptionField.Text);
            TaskDataManager.AddTaskWindowData(taskData);
            StopWatchCallerObject.AddTaskWindowData(taskData);
            taskData = null;
            StopWatchCallerObject = null;
            TopicField.Text = null;
            DescriptionField.Text = null;
            this.Hide();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CheckInstance();
            TopicField.Text = null;
            DescriptionField.Text = null;
            taskData = null;
            StopWatchCallerObject = null;
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
