using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Loggers
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
