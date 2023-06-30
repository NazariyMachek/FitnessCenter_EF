using FitnessCenter_EF.WPF.View.InstructorViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessCenter_EF.WPF.ViewModel
{
    public class NewCommands
    {
        public static RoutedCommand Edit { get; set; }
        static NewCommands()
        {
            Edit = new RoutedCommand("Edit", typeof(InstructorControl));
        }
    }
}
