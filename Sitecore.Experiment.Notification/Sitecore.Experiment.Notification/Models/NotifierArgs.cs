using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Experiment.Notification.Models
{
    public class NotifierArgs : EventArgs
    {
        public string EventName { get; set; }
    }
}
