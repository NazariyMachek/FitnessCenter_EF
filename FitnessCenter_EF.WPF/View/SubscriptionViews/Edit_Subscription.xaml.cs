using FitnessCenter_EF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace FitnessCenter_EF.WPF.View.SubscriptionViews
{
    /// <summary>
    /// Логика взаимодействия для Edit_Subscription.xaml
    /// </summary>
    public partial class Edit_Subscription : Window
    {
        private Subscription _subscription { get; set; }
        public Edit_Subscription(Subscription entity)
        {
            InitializeComponent();

            _subscription = entity;
            DataContext = entity;
            Init();
        }

        private async void Init()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://localhost:5296/ef/customer");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var temp = await response.Content.ReadAsStringAsync();
                    var list = JsonSerializer.Deserialize<ObservableCollection<Customer>>(temp);
                    selectedCustomer.ItemsSource = list;
                }
            }
        }
        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            var temp = (Customer)selectedCustomer.SelectedItem;
            Decimal.TryParse(Price.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"), out Decimal result);
            var updateEntity = new Subscription
            {
                SubscriptionId = _subscription.SubscriptionId,
                CustomerId = temp?.CustomerId ?? _subscription.CustomerId,
                StartDate = StartDate.SelectedDate ?? _subscription.StartDate,
                EndDate = EndDate.SelectedDate ?? _subscription.EndDate,
                Price = result,
            };
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync("http://localhost:5296/ef/subscription/" + updateEntity.SubscriptionId, updateEntity);
            }
            this.Close();
        }
    }
}
