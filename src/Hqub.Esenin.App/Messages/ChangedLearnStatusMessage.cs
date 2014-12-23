using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hqub.Esenin.App.Messages
{
    public class ChangedLearnStatusMessage
    {
        public bool Value { get; set; }

        public ChangedLearnStatusMessage(bool val)
        {
            Value = val;
        }
    }
}
