using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    class TaskData
    {
        string topic;
        string description;
        Guid id;

        public TaskData(string Topic, string Description)
        {
            id = Guid.NewGuid();
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

        public Guid GuidProperty
        {
            get { return id; }
        }

        public override string ToString()
        {
            return TopicProperty;
        }
    }
}
