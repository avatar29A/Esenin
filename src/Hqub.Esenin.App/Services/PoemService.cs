using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hqub.Esenin.App.Model;

namespace Hqub.Esenin.App.Services
{
    public interface IPoemService
    {
        IList<IPoem> List(); 
        void SetBookmark(string poemId, bool isBookmark);
    }

    public class PoemService : IPoemService
    {
        public IList<IPoem> List()
        {
            using (var context = DbContext.Create())
            {
                return context.Poems.ToList();
            }
        }

        public void SetBookmark(string poemId, bool isBookmark)
        {
            using (var context = DbContext.Create())
            {
                var poem = context.Poems.Single(p => p.Id == poemId);

                poem.Bookmarked = isBookmark;
                context.SaveChanges();
            }
        }

    }
}
