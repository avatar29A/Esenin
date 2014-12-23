using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;

namespace Hqub.Esenin.App.Pages
{
    public class ApplicationPageBase : PhoneApplicationPage
    {
        public void NavigationTo(Uri uri)
        {
            if (uri.ToString() == "/GoBack.xaml")
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(uri);
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Messenger.Default.Unregister<Uri>(this);
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Messenger.Default.Register<Uri>(this, "NavigationRequest", NavigationTo);
            base.OnNavigatedTo(e);
        }
    }
}
