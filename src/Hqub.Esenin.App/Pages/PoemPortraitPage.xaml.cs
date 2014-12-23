using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Hqub.Esenin.App.Model;
using Hqub.Esenin.App.ViewModel;
using Microsoft.Phone.Controls;

namespace Hqub.Esenin.App.Pages
{
    public partial class PoemPortraitPage : ApplicationPageBase
    {
        public PoemPortraitPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string poemId;

            NavigationContext.QueryString.TryGetValue("poemId", out poemId);
            var vm = new PoemItemViewModel(poemId);
            vm.ScrollTo = ScrollToSelected;
            DataContext = vm;

//            vm.ScrollToSelectedItem();
        }

        private void ScrollToSelected(IQuatrain quatrain)
        {
            if(quatrain == null)
                return;

            QuatrainsCollection.ScrollTo(quatrain);
        }

        private void LongListSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as LongListSelector;
            if (list == null || DataContext == null)
                return;
            
            ((PoemItemViewModel) DataContext).SetSelectedItem(list.SelectedItem);
        }

        private void PoemPortraitPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(() => ((PoemItemViewModel) DataContext).ScrollToSelectedItem());

        }
    }
}