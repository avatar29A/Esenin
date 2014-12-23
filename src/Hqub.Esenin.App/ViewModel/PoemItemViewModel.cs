using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Hqub.Esenin.App.Messages;
using Hqub.Esenin.App.Model;
using Remotion.Linq.Collections;

namespace Hqub.Esenin.App.ViewModel
{
    public interface IPoemItemViewModel
    {
        
    }

    public class PoemItemViewModel : ViewModelBase, IPoemItemViewModel
    {
        private MyEntityContext _context;
        private List<IQuatrain> _quatrains;
        private IPoem _poem;
        private IQuatrain _selectedQuatrain;

        public PoemItemViewModel(string poemId)
        {
//            MessengerInstance.Register();

            LoadData(poemId);
        }

        private void LoadData(string poemId)
        {
            // Extract id poem from NavigationConext:
            _context = DbContext.Create();

            Poem = _context.Poems.Single(p => p.Id == poemId);
            Quatrains = Poem.Quatrains.OrderBy(q => q.Order).ToList();

            SetSelectedItem(Quatrains.FirstOrDefault(q => q.Selected));
        }

        #region Methods

        public void SetSelectedItem(object item)
        {
            SelectedQuatrain = item as IQuatrain;
            ScrollToSelectedItem();
        }

        public void ScrollToSelectedItem()
        {
            var selectedIndex = Quatrains.IndexOf(SelectedQuatrain);

            if (ScrollTo != null && selectedIndex > -1)
                ScrollTo(Quatrains[selectedIndex - 1 >= 0 ? selectedIndex - 1 : selectedIndex]);
        }

        #endregion

        #region Callback

        public Action<IQuatrain> ScrollTo;

        #endregion

        #region Commands

        #endregion

        #region Properties

        public IQuatrain SelectedQuatrain
        {
            get { return _selectedQuatrain; }
            set
            {
                _selectedQuatrain = value;
                RaisePropertyChanged();
            }
        }

        public List<IQuatrain> Quatrains
        {
            get { return _quatrains; }
            set
            {
                _quatrains = value;
                RaisePropertyChanged();
            }
        }

        public IPoem Poem
        {
            get { return _poem; }
            set
            {
                _poem = value;
                RaisePropertyChanged();
            }
        }

        public string IsFavoriteText
        {
            get
            {
                if (Poem == null)
                    return string.Empty;

                return Poem.Bookmarked ? "в избранном" : string.Empty;
            }
        }

        #endregion
    }
}
