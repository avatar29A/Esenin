using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightstarDB.EntityFramework;

namespace Hqub.Esenin.App.Model
{
    [Entity]
    public interface IPoem
    {
        string Id { get; }
        string Title { get; set; }

        int Year { get; set; }

        bool Compleated { get; set; }

        /// <summary>
        /// Должен отображаться в избранном
        /// </summary>
        bool Bookmarked { get; set; }

        [InverseProperty("ParentPoem")]
        ICollection<IQuatrain> Quatrains { get; set; } 
    }
}
