using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Hqub.Esenin.App.Messages;
using Hqub.Esenin.App.Model;
using Microsoft.Practices.ServiceLocation;

namespace Hqub.Esenin.App.Controls
{
    public partial class QuatraineControl : UserControl
    {
        public static readonly DependencyProperty PoemProperty = DependencyProperty.Register(
            "Poem", typeof (IPoem), typeof (QuatraineControl), new PropertyMetadata(default(IPoem), (o, args) =>
            {
                var sender = o as QuatraineControl;
                var poem = args.NewValue as IPoem;

                if (sender == null || poem == null)
                    return;

                sender.SetPoemBookmarked(poem.Bookmarked);
            }));

        public static readonly DependencyProperty QuatrainProperty = DependencyProperty.Register(
            "Quatrain", typeof (IQuatrain), typeof (QuatraineControl), new PropertyMetadata(default(IQuatrain),
                (o, args) =>
                {
                    var sender = o as QuatraineControl;
                    var quatrain = args.NewValue as IQuatrain;
                    if (sender == null || quatrain == null)
                        return;

                    sender.SetQuatrainSelectedStatus(quatrain.Selected);
                    sender.SetLearnTurnOnOff(quatrain.Compleated);
                }));

        #region Fields

        private Services.IQuatraineService _quatraineService;
        private Services.IPoemService _poemService;

        #endregion

        #region .ctor

        public QuatraineControl()
        {
            InitializeComponent();

            SubscribeOnEvents();
            SetupBindings();

            _quatraineService = ServiceLocator.Current.GetInstance<Services.IQuatraineService>();
            _poemService = ServiceLocator.Current.GetInstance<Services.IPoemService>();
        }

        #endregion

        public IQuatrain Quatrain
        {
            get { return (IQuatrain) GetValue(QuatrainProperty); }
            set { SetValue(QuatrainProperty, value); }
        }

        public IPoem Poem
        {
            get { return (IPoem)GetValue(PoemProperty); }
            set { SetValue(PoemProperty, value); }
        }

        #region Methods

        private void SubscribeOnEvents()
        {
            Messenger.Default.Register<ChangedLearnStatusMessage>(this, ChangeLearnStatus);
            Messenger.Default.Register<ChangeSelectedQuatrainMessage>(this, ChangeSelectedQuatrain);
        }

        private void ChangeSelectedQuatrain(ChangeSelectedQuatrainMessage message)
        {
            if(Quatrain.Id == message.QuatrainId)
                return;

            SetQuatrainSelectedStatus(false);
        }

        private void SetupBindings()
        {
            LearnCommandMenuItem.Command = LearnCommand;
            BookmarkedMenuItem.Command = SetPoemBookmarkedCommand;
        }

        public void ChangeLearnStatus(ChangedLearnStatusMessage message)
        {
            SetLearnTurnOnOff(message.Value);
        }

        private void SetLearnTurnOnOff(bool isLearned)
        {
            LearnCommandMenuItem.Header = isLearned ? "Отметить как не выучен" : "Отметить как выучен";

            LayoutRoot.Background = isLearned
                ? (SolidColorBrush) Resources["PhoneChromeBrush"]
                : new SolidColorBrush(Color.FromArgb(0xFF, 00, 00, 00));

            _quatraineService.SetQuatrainLearned(Quatrain.Id, isLearned);
        }

        private void SetPoemBookmarked(bool isBookmarked)
        {
            Poem.Bookmarked = isBookmarked;
            _poemService.SetBookmark(Poem.Id, Poem.Bookmarked);

            BookmarkedMenuItem.Header = Poem.Bookmarked ? "Убрать стих из избранного" : "Добавить стих в избранное";
        }

        private void SetQuatrainSelectedStatus(bool isSelected)
        {
            Quatrain.Selected = isSelected;

            LayoutRoot.BorderBrush = !Quatrain.Selected
                ? (SolidColorBrush) Resources["PhoneChromeBrush"]
                : new SolidColorBrush(Colors.Cyan);

            _quatraineService.SetQuatrainSelected(Quatrain.Id, Quatrain.Selected);
        }

        #endregion

        #region Command

        public ICommand LearnCommand
        {
            get { return new RelayCommand(LearnCommandExecute); }
        }

        private void LearnCommandExecute()
        {
            Quatrain.Compleated = !Quatrain.Compleated;
            SetLearnTurnOnOff(Quatrain.Compleated);
        }

        public ICommand SetActiveCommand
        {
            get { return new RelayCommand(SetActiveCommandExecute); }
        }

        private void SetActiveCommandExecute()
        {
            if (Poem == null)
                return;

            Poem.Bookmarked = !Poem.Bookmarked;
        }

        public ICommand SetPoemBookmarkedCommand
        {
            get { return new RelayCommand(SetPoemBookmarkedCommandExecute); }
        }

        private void SetPoemBookmarkedCommandExecute()
        {
            SetPoemBookmarked(!Poem.Bookmarked);
        }

        #endregion

        #region Event Handle

        private void LayoutRoot_OnDoubleTap(object sender, GestureEventArgs e)
        {
            SetQuatrainSelectedStatus(!Quatrain.Selected);
            Messenger.Default.Send(new ChangeSelectedQuatrainMessage(Quatrain.Id));
        }

        #endregion
    }
}
