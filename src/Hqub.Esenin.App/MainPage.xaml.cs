using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using Hqub.Esenin.App.Model;
using Hqub.Esenin.App.Pages;
using Microsoft.Phone.Controls;

namespace Hqub.Esenin.App
{
    public partial class MainPage : ApplicationPageBase
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = App.ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if(e.NavigationMode == NavigationMode.Back)
                App.ViewModel.LoadData();
        }

        private void LongListSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var poemList = sender as LongListSelector;

            if (poemList == null || poemList.SelectedItem == null)
                return;

            var poem = poemList.SelectedItem as IPoem;
            if (poem == null)
                return;
            
            // Reset selected item:
            poemList.SelectedItem = null;

            NavigationTo(new Uri(string.Format("/Pages/PoemPortraitPage.xaml?poemId={0}", poem.Id), UriKind.Relative));
        }
    }
}