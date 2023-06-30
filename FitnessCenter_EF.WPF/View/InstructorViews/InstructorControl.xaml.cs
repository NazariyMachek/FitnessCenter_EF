using FitnessCenter_EF.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using Bogus.Bson;
using System.Windows.Input;
using System.Net.Http.Json;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace FitnessCenter_EF.WPF.View.InstructorViews
{
    /// <summary>
    /// Логика взаимодействия для InstructorControl.xaml
    /// </summary>
    public partial class InstructorControl : UserControl
    {
        public InstructorControl()
        {
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5296/ef/instructor");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var temp = await response.Content.ReadAsStringAsync();
                    var list = JsonSerializer.Deserialize<ObservableCollection<Instructor>>(temp);
                    itemsList.ItemsSource = list;
                    Count.Text = $"Count: {list?.Count}";
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new Add_Instructor().ShowDialog();
            Init();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = (Instructor)itemsList.SelectedItem;

            new Edit_Instructor(item).Show();
        }
        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (Instructor)itemsList.SelectedItem;
            if (item is Instructor)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync("http://localhost:5296/ef/instructor/" + item.InstructorId);
                    if (response.IsSuccessStatusCode) Init();
                }
            }
        }
    }
}
