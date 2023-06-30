using FitnessCenter_EF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitnessCenter_EF.WPF.View.InstructorViews
{
    /// <summary>
    /// Логика взаимодействия для Add_Instructor.xaml
    /// </summary>
    public partial class Edit_Instructor : Window
    {
        private Instructor _instructor { get; set; }
        public Edit_Instructor(Instructor entity)
        {
            InitializeComponent();

            _instructor = entity;
            DataContext = entity;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            var updateEntity = new Instructor
            {
                InstructorId = _instructor.InstructorId,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                Phone = Phone.Text,
                Specialization = Specialization.Text
            };
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync("http://localhost:5296/ef/instructor/" + updateEntity.InstructorId, updateEntity);
            }
            this.Close();
        }
    }
}
