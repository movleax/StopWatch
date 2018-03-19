using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    class TaskData
    {
        string topic;
        string description;

        public TaskData(string Topic, string Description)
        {
            TopicProperty = Topic;
            DescriptionProperty = Description;
        }

        public string TopicProperty
        {
            set { topic = value; }
            get { return topic; }
        }

        public string DescriptionProperty
        {
            set { description = value; }
            get { return description; }
        }
    }
}
