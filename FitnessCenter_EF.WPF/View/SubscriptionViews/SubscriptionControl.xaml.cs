using FitnessCenter_EF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessCenter_EF.WPF.View.SubscriptionViews
{
    /// <summary>
    /// Логика взаимодействия для SubscriptionControl.xaml
    /// </summary>
    public partial class SubscriptionControl : UserControl
    {
        public Action CloseAction { get; set; }

        public SubscriptionControl()
        {
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            using (var client = new HttpClient())
            {
                string fields = "SubscriptionId, CustomerId, StartDate, EndDate, Price";
                var response = await client.GetAsync($"http://localhost:5296/ef/Subscription?PageNumber=1&PageSize=100&Fields={fields}");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var temp = await response.Content.ReadAsStringAsync();
                    var list = JsonSerializer.Deserialize<ObservableCollection<Subscription>>(temp);
                    itemsList.ItemsSource = list;
                    Count.Text = $"Count: {list?.Count}";
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new Add_Subsctiption().ShowDialog();
            Init();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var item = (Subscription)itemsList.SelectedItem;

            new Edit_Subscription(item).Show();
        }
        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (Subscription)itemsList.SelectedItem;
            if (item is Subscription)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync("http://localhost:5296/ef/subscription/" + item.SubscriptionId);
                    if (response.IsSuccessStatusCode) Init();
                }
            }
        }
    }
}
