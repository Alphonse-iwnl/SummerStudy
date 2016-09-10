using EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace printDemo
{
    /// <summary>
    /// Interaction logic for typePage.xaml
    /// </summary>
    public partial class typePage : Page
    {
        SimpleEventBus eventBus = SimpleEventBus.GetDefaultEventBus();
        public interface Callback
        {
            void textChange(string text);
            void ScroChange(double height);
        }

        private Callback callback;

        public void setCallBack(Callback callback)
        {
            this.callback = callback;
        }
       
        public typePage()
        {
            InitializeComponent();
            eventBus.Register(this);
            
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {           
            this.callback.textChange(typeBox.Text);
        }

        private void typeScro_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            this.callback.ScroChange(typeScro.VerticalOffset);
        }

        [EventSubscriber]
        public void HandleEvent(double height)
        {
            Thread nThread = new Thread(() =>
            {
                this.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(() =>
                {
                    typeScro.ScrollToVerticalOffset(height);
                }
                ));
            });
            nThread.Start();
        }
    }
}
