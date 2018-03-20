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
    /// Interaction logic for EditLogWindow.xaml
    /// </summary>
    public partial class EditLogWindow : Window
    {
        static private EditLogWindow instance;
        static private TaskData taskData;
        static private StopWatchChildWindow StopWatchCallerObject;

        public static void OpenEditLogWindow(Guid StopWatchChildWindowGUID, Guid taskDataGUID)
        {
            CheckInstance();

            if (instance.IsVisible)
                return;

            StopWatchCallerObject = TaskDataManager.GetStopWatchChildWindow(StopWatchChildWindowGUID);
            taskData = TaskDataManager.GetTaskWindowData(taskDataGUID);

            instance.TopicField.Text = taskData.TopicProperty;
            instance.DescriptionField.Text = taskData.DescriptionProperty;
            instance.Show();
        }

        static public void CloseEditLogWindow()
        {
            CheckInstance();
            instance.Close();
        }

        static private void CheckInstance()
        {
            if (instance == null)
                instance = new EditLogWindow();
            //return instance;
        }

        private EditLogWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            CheckInstance();

            if (TopicField.Text == null || TopicField.Text == "")
            {
                MessageBox.Show("Cannot Edit Log Item with an Empty Topic", "Unable to Add Log Item...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            taskData.TopicProperty = TopicField.Text;
            taskData.DescriptionProperty = DescriptionField.Text;
            StopWatchCallerObject.ModifyTaskWindowDataItem(taskData);
            TaskDataManager.ModifyTaskWindowDataItem(taskData);

            TopicField.Text = null;
            DescriptionField.Text = null;
            taskData = null;
            StopWatchCallerObject = null;
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            CheckInstance();

            StopWatchCallerObject.DeleteTaskWindowDataItem(taskData);
            TaskDataManager.DeleteTaskWindowDataItem(taskData);

            taskData = null;
            StopWatchCallerObject = null;
            TopicField.Text = null;
            DescriptionField.Text = null;
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
