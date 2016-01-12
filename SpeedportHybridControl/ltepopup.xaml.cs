using SpeedportHybridControl.PageModel;
using System.Windows;

namespace SpeedportHybridControl
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ltepopup : Window
    {
        public ltepopup()
        {
            InitializeComponent();
        }

        // quick & dirty
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ltepopupModel lm = Application.Current.FindResource("ltepopupModel") as ltepopupModel;
            lm.StopTimer();
        }
    }
}
