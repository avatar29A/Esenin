using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hqub.Esenin.App.Model
{
    public partial class Poem
    {
        public int CompleatePercent
        {
            get
            {
                var compleatedCount = Quatrains.Count(q => q.Compleated);
                
                double percent = 0;
                percent = Math.Round(Quatrains.Count == 0 ? 0f : (compleatedCount/(Quatrains.Count*1.0))*100);

                return (int) percent;
            }
        }
    }
}
