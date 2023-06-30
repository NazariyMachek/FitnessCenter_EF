using FitnessCenter_EF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitnessCenter_EF.WPF.View
{
    /// <summary>
    /// Логика взаимодействия для Add_Instructor.xaml
    /// </summary>
    public partial class Add_Instructor : Window
    {
        public Add_Instructor()
        {
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var entity = new Instructor
            {
                InstructorId = Guid.NewGuid(),
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                Phone = Phone.Text,
                Specialization = Specialization.Text
            };
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync("http://localhost:5296/ef/instructor/", entity);
            }
            this.Close();
        }
    }
}
