using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PatikaflixTask
{
    public class Series
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Director { get; set; }
        public DateTime ProduceYear { get; set; }
        public DateTime PublishYear { get; set; }
        public string FirstPlatform { get; set; }
    }
}
