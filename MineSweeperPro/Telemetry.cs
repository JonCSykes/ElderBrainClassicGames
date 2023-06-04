using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperPro
{
    public class Telemetry
    { 
        
        public UserActionEnum Action { get; set; }

        public EventEnum Event { get; set; }
        
        public TimeSpan Timestamp { get; set; }

        public MineCell? Cell { get; set; }

        public Telemetry(UserActionEnum action, EventEnum eventCaptured, TimeSpan timestamp, MineCell? mineCell) 
        { 
            Action = action;
            Event = eventCaptured;
            Timestamp = timestamp;
            Cell = mineCell;        
        }
    
    }
}
