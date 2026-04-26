using Playnite.Controls;
using Playnite.Windows;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;

namespace Playnite.DesktopApp.Windows
{
    public class FirstTimeStartupWindowFactory : WindowFactory
    {
        public override WindowBase CreateNewWindowInstance()
        {
            return new FirstTimeStartupWindow();
        }
    }

    /// <summary>
    /// Interaction logic for FirstTimeStartupWindow.xaml
    /// </summary>
    public partial class FirstTimeStartupWindow : WindowBase
    {        
        public FirstTimeStartupWindow() : base()
        {
            InitializeComponent();
            Loaded += FirstTimeStartupWindow_Loaded;
        }

        private void FirstTimeStartupWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is INotifyPropertyChanged notify)
            {
                notify.PropertyChanged += DataContext_PropertyChanged;
            }

            FocusCurrentPage();
        }

        private void DataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedIndex")
            {
                Dispatcher.BeginInvoke(new System.Action(FocusCurrentPage));
            }
        }

        private void FocusCurrentPage()
        {
            var page = TabMain.SelectedIndex == 0 ? WizardPageIntro :
                TabMain.SelectedIndex == 1 ? WizardPageLibraries :
                TabMain.SelectedIndex == 2 ? WizardPageLibrarySettings :
                WizardPageFinish;

            page?.Focus();
            var peer = UIElementAutomationPeer.FromElement(page) ?? UIElementAutomationPeer.CreatePeerForElement(page);
            peer?.RaiseAutomationEvent(AutomationEvents.AutomationFocusChanged);
        }

        private void ButtonFinish_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (ButtonFinish.IsVisible)
            {
                ButtonFinish.Focus();
            }
        }
    }
}
