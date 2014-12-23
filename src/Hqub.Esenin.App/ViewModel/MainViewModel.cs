using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using Hqub.Esenin.App.Code;
using Hqub.Esenin.App.Model;

namespace Hqub.Esenin.App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<IPoem> _poems;
        private List<AlphaKeyGroup<IPoem>> _poemDataSource;
        private IPoem _selectedPoem;
        private List<AlphaKeyGroup<IPoem>> _favoritePoemDataSource;
        private List<AlphaKeyGroup<IPoem>> _compleatedPoemDataSource;

        public MainViewModel()
        {
            LoadData();
        }

        #region Properties

        public bool IsDataLoad { get; set; }

        public ObservableCollection<IPoem> Poems
        {
            get { return _poems; }
            set
            {
                _poems = value; 
                RaisePropertyChanged();
            }
        }

        public List<AlphaKeyGroup<IPoem>> PoemDataSource
        {
            get { return _poemDataSource; }
            set
            {
                _poemDataSource = value;
                RaisePropertyChanged();
            }
        }

        public List<AlphaKeyGroup<IPoem>> FavoritePoemDataSource
        {
            get { return _favoritePoemDataSource; }
            set
            {
                _favoritePoemDataSource = value; 
                RaisePropertyChanged();
            }
        }

        public List<AlphaKeyGroup<IPoem>> CompleatedPoemDataSource
        {
            get { return _compleatedPoemDataSource; }
            set
            {
                _compleatedPoemDataSource = value;
                RaisePropertyChanged();
            }
        }

        public IPoem SelectedPoem
        {
            get { return _selectedPoem; }
            set
            {
                _selectedPoem = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        #endregion

        /// <summary>
        /// Load poems from db
        /// </summary>
        public void LoadData()
        {
            using (var context = DbContext.Create())
            {
                PoemDataSource = AlphaKeyGroup<IPoem>.CreateGroups(context.Poems,
                    System.Threading.Thread.CurrentThread.CurrentUICulture,
                    s => s.Title, true);

                var favPoems = context.Poems.Where(p => p.Bookmarked).ToList();
                FavoritePoemDataSource = AlphaKeyGroup<IPoem>.CreateGroups(favPoems,
                    System.Threading.Thread.CurrentThread.CurrentUICulture,
                    s => s.Title, true);

                var compleatedPoems = context.Poems.Where(p => p.Compleated).ToList();
                CompleatedPoemDataSource = AlphaKeyGroup<IPoem>.CreateGroups(compleatedPoems,
                    System.Threading.Thread.CurrentThread.CurrentUICulture,
                    s => s.Title, true);
            }
        }
    }
}