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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Xceed.Wpf.Toolkit.Primitives.WindowContainer winContainer;

        public MainWindow()
        {
            InitializeComponent();
            winContainer = new Xceed.Wpf.Toolkit.Primitives.WindowContainer();
            DockPanel.Children.Insert(1, winContainer);
        }

        static public void AddNewStopWatchChildWindow(Guid TaskWindowKey)
        {
            if(winContainer != null)
                winContainer.Children.Add(TaskDataManager.GetStopWatchChildWindow(TaskWindowKey));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddLogWindow.CloseAddLogWindow();
            EditLogWindow.CloseEditLogWindow();
            AddStopWatchChildWindow.CloseAddStopWatchChildWindow();
        }

        private void MenuItem_CreateTask_Click(object sender, RoutedEventArgs e)
        {
            AddStopWatchChildWindow.OpenAddStopWatchChildWindow();
        }

        private void MenuItem_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    object foo = listBox.SelectedItem;
        //    var nop = 0;
        //}

        //private void listBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    object foo = listBox.SelectedItem;
        //    var nop = 0;
        //}
    }
}
