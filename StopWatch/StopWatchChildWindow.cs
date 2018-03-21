using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace StopWatch
{
    class StopWatchChildWindow : ChildWindow
    {
        private Label StopWatchTaskLabel;
        private StopWatchControl swc;
        private Button ToggleWatchButton;
        private ListBox taskList;
        private bool toggleButton;
        private Guid windowGUID;
        private Dictionary<Guid, TaskData> taskListData = new Dictionary<Guid, TaskData>();

        public StopWatchChildWindow(string TaskName)
        {
            // define childwindow properties
            this.Left = 0;
            this.Top = 0;
            this.Width = 221;
            this.Height = 217;
            this.WindowState = Xceed.Wpf.Toolkit.WindowState.Open;

            // Stop Watch task Label
            StopWatchTaskLabel = new Label();
            StopWatchTaskLabel.Content = TaskName;
            StopWatchTaskLabel.FontSize = 18;
            StopWatchTaskLabel.Margin = new System.Windows.Thickness(0, 0, -0.4, 129.4);
            StopWatchTaskLabel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            StopWatchTaskLabel.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            // Timer control
            swc = new StopWatchControl();
            swc.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            swc.Margin = new System.Windows.Thickness(10, 0, 0, 74.4);
            swc.Width = 198;

            // Toggle Stop Watch button
            ToggleWatchButton = new Button();
            ToggleWatchButton.Content = "Start";
            ToggleWatchButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            ToggleWatchButton.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            ToggleWatchButton.Margin = new System.Windows.Thickness(10, 73, 0, 0);
            ToggleWatchButton.Width = 198;
            ToggleWatchButton.Height = 32;
            ToggleWatchButton.Click += ToggleWatchButton_Click;

            // our toggle button boolean
            toggleButton = false;

            //< ListBox Name = "listBox" HorizontalAlignment = "Left" Height = "66" Margin = "10,110,0,0" VerticalAlignment = "Top" Width = "198" MouseDoubleClick = "listBox_MouseDoubleClick" MouseLeftButtonUp = "listBox_MouseLeftButtonUp" />
            taskList = new ListBox();
            taskList.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            taskList.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            taskList.Width = 198;
            taskList.Height = 66;
            taskList.Margin = new System.Windows.Thickness(10, 110, 0, 0);
            taskList.MouseDoubleClick += taskList_MouseDoubleClick;
            taskList.MouseUp += taskList_MouseLeftButtonUp;
            taskList.Items.Add(" -- Add New Log Item --");  

            // Create a new grid to stuff all of these controls into
            Grid grid = new Grid();

            grid.Children.Add(StopWatchTaskLabel);
            grid.Children.Add(swc);
            grid.Children.Add(ToggleWatchButton);
            grid.Children.Add(taskList);

            // add the Grid, which contains our controls
            this.AddChild(grid);

            windowGUID = Guid.NewGuid();

            //AddLogWindow alw = new AddLogWindow();
            //AddLogWindow.OpenAddLogWindow(GetGuid());
            //alw.Show();

            
        }

        public void AddTaskWindowData(TaskData taskData)
        {
            taskListData.Add(taskData.GuidProperty, taskData);
            taskList.Items.Add(taskData);
        }

        public TaskData GetTaskWindowData(Guid Key)
        {
            return taskListData[Key];
        }

        public void ModifyTaskWindowDataItem(TaskData taskData)
        {
            taskListData[taskData.GuidProperty] = taskData;
            int index = taskList.Items.IndexOf(taskData);
            taskList.Items[index] = taskData;

            taskList.Items.Clear();
            taskList.Items.Add(" -- Add New Log Item --");
            
            foreach(var data in taskListData)
            {
                taskList.Items.Add(data.Value);
            }

        }

        public void DeleteTaskWindowDataItem(TaskData taskData)
        {
            taskListData.Remove(taskData.GuidProperty);
            //int index = taskList.Items.IndexOf(taskData);
            taskList.Items.Remove(taskData);
        }

        public Guid GetGuid()
        {
            return windowGUID;
        }
        
        public void AddTaskLogItem(Guid taskGuid, string topic)
        {
            taskList.Items.Add("test");
        }

        private void ToggleWatchButton_Click(object sender, RoutedEventArgs e)
        {
            if (!toggleButton)
            {
                ToggleWatchButton.Content = "Stop";
                swc.Start();
            }
            else
            {
                ToggleWatchButton.Content = "Start";
                swc.Stop();
            }

            toggleButton = !toggleButton;
        }

        private void taskList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (taskList.SelectedItem == null)
            {
                return;
            }
            if(taskList.SelectedItem.ToString().Contains("Add New Log Item"))
            {
                AddLogWindow.OpenAddLogWindow(this.GetGuid());
            }
            if(taskList.SelectedItem.GetType() == typeof(TaskData) && !taskList.SelectedItem.ToString().Contains("Add New Log Item"))
            {
                EditLogWindow.OpenEditLogWindow(this.GetGuid(), ((TaskData)taskList.SelectedItem).GuidProperty);
            }
        }

        private void taskList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
