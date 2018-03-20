using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    static class TaskDataManager
    {
        static Dictionary<Guid, StopWatchChildWindow> taskWindows = new Dictionary<Guid, StopWatchChildWindow>();
        static Dictionary<Guid, TaskData> taskWindowData = new Dictionary<Guid, TaskData>();

        static public Guid AddStopWatchChildWindow(StopWatchChildWindow stopWatchChildWindowObj)
        {
            taskWindows.Add(stopWatchChildWindowObj.GetGuid(), stopWatchChildWindowObj);
            return stopWatchChildWindowObj.GetGuid();
        }

        static public StopWatchChildWindow GetStopWatchChildWindow(Guid Key)
        {
            return taskWindows[Key];
        }

        //static public Guid AddTaskToStopWatchChild(Guid taskKey, Guid taskKey)
        //{
        //    taskWindows.Remove(Key);
        //    taskWindows.Add(Key, taskData);
        //    return Key;
        //}

        static public void AddTaskWindowData(TaskData taskData)
        {
            taskWindowData.Add(taskData.GuidProperty, taskData);
        }

        static public TaskData GetTaskWindowData(Guid Key)
        {
            return taskWindowData[Key];
        }

        static public void ModifyTaskWindowDataItem(TaskData taskData)
        {
            taskWindowData[taskData.GuidProperty] = taskData;
        }

        static public void DeleteTaskWindowDataItem(TaskData taskData)
        {
            taskWindowData.Remove(taskData.GuidProperty);
        }
    }
}
