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
        
        public TimeSpan Timestamp { get; set; }

        public MineCell? Cell { get; set; }

        public Telemetry(UserActionEnum action, TimeSpan timestamp, MineCell? mineCell) 
        { 
            Action = action;
            Timestamp = timestamp;
            Cell = mineCell;        
        }
    
    }
}
