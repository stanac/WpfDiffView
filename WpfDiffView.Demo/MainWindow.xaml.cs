using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;

namespace WpfDiffView.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
           // DiffControl.LeftText = new DemoViewModel().Left;
           // DiffControl.RightText = new DemoViewModel().Right;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as DemoModel;
            string temp = vm.Left;
            vm.Left = vm.Right;
            vm.Right = temp;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            string url = ((Hyperlink)sender).NavigateUri.OriginalString;
            Process.Start(url);
        }
    }
}
