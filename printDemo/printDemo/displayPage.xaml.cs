using EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace printDemo
{
    /// <summary>
    /// Interaction logic for displayPage.xaml
    /// </summary>
    public partial class displayPage : Page,typePage.Callback
    {
        SimpleEventBus eventBus = SimpleEventBus.GetDefaultEventBus();
 
        public displayPage()
        {
            InitializeComponent();
            eventBus.Register(this);
        }

        public void textChange(string text)
        {                   
             displayTb.Text  = text;
        }

        public void ScroChange(double height)
        {
            displayScro.ScrollToVerticalOffset(height);
        }

        private void displayScro_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            eventBus.Post(displayScro.VerticalOffset, TimeSpan.Zero);
        }
    }
}
