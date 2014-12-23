using BrightstarDB.EntityFramework;

namespace Hqub.Esenin.App.Model
{
    [Entity]
    public interface IQuatrain
    {
        string Id { get; }
        string Text { get; set; }
        int Order { get; set; }

        /// <summary>
        /// Блок выучен
        /// </summary>
        bool Compleated { get; set; }

        bool Selected { get; set; }

        IPoem ParentPoem { get; set; }
    }
}
