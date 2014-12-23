using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hqub.Esenin.App.Model;

namespace Hqub.Esenin.App.Services
{
    public interface IQuatraineService
    {
        IList<IQuatrain> Quatrains { get; set; }

        void SetQuatrainSelected(string quatraineId, bool isSelected);
        void SetQuatrainLearned(string quatrainId, bool isLearned);
    }

    public class QuatraineService : IQuatraineService
    {
        public IList<IQuatrain> Quatrains { get; set; }
        public void SetQuatrainSelected(string quatraineId, bool isSelected)
        {
            using (var context = DbContext.Create())
            {
               var quatraine = context.Quatrains.Single(q => q.Id == quatraineId);
                quatraine.Selected = isSelected;

                context.SaveChanges();
            }
        }

        public void SetQuatrainLearned(string quatrainId, bool isLearned)
        {
            using (var context = DbContext.Create())
            {
                var quatraine = context.Quatrains.Single(q => q.Id == quatrainId);
                quatraine.Compleated = isLearned;

                context.SaveChanges();

                UpdatePoemCompelated(quatraine.ParentPoem.Id);
            }
        }

        public void UpdatePoemCompelated(string poemId)
        {
            using (var context = DbContext.Create())
            {
                var poem = context.Poems.Single(p => p.Id == poemId);

                var isAllCompleated = poem.Quatrains.All(q => q.Compleated);
                poem.Compleated = isAllCompleated;

                context.SaveChanges();
            }
        }
    }
}
