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

        static public Guid AddTaskWindowData(TaskData taskData)
        {
            Guid key = Guid.NewGuid();
            taskWindowData.Add(key, taskData);
            return key;
        }

        static public TaskData GetTaskWindowData(Guid Key)
        {
            return taskWindowData[Key];
        }

        static public Guid ModifyTaskWindowDataItem(Guid Key, TaskData taskData)
        {
            taskWindowData.Remove(Key);
            taskWindowData.Add(Key, taskData);
            return Key;
        }
    }
}
