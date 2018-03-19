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
        static private Guid taskDataGUID;
        static private StopWatchChildWindow StopWatchCallerObject;

        static public void OpenAddLogWindow(Guid StopWatchChildWindowGUID)
        {
            CheckInstance();

            if (instance.IsVisible)
                return;

            StopWatchCallerObject = TaskDataManager.GetStopWatchChildWindow(StopWatchChildWindowGUID);

            instance.DescriptionField.Text = "Description";
            instance.TopicField.Text = "Enter Topic";
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
            taskData.TopicProperty = TopicField.ToString();
            taskData.DescriptionProperty = DescriptionField.ToString();
            taskDataGUID = TaskDataManager.AddTaskWindowData(taskData);
            StopWatchCallerObject.AddTaskLogItem()
            this.Hide();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
