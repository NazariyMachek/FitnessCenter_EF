using FitnessCenter_EF.WPF.View.InstructorViews;
using FitnessCenter_EF.WPF.View.SubscriptionViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnessCenter_EF.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += InstructorSelect;
        }


        private void InstructorSelect(object sender, RoutedEventArgs e)
        {
            MainWindowContent.Content = new InstructorControl();
        }
        private void SubscriptionSelect(object sender, RoutedEventArgs e)
        {
            MainWindowContent.Content = new SubscriptionControl();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
