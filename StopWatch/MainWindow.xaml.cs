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
        public MainWindow()
        {
            InitializeComponent();

            //ListItem item = new ListItem();
            //item.TextInput = "A bold item";
            //item.Attributes.Add("style", "font-weight:bold");


            CreateNewStopWatchChildWindow();

            //this.IsEnabled = false;


            //listBox.Items.Add(" -- Add New Log Item --");
            //listBox.Items.Add("asdfasdfasdfasdfasdfasdfasdfasdfasdfasfasdf");
        }

        public void CreateNewStopWatchChildWindow()
        {
            StopWatchChildWindow stopWatchChildWindow = new StopWatchChildWindow();
            TaskDataManager.AddStopWatchChildWindow(stopWatchChildWindow);
            cntr1.Children.Add(stopWatchChildWindow);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddLogWindow.CloseAddLogWindow();
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
