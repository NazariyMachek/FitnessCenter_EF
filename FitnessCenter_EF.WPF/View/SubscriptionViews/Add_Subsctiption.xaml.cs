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
    /// Логика взаимодействия для Add_Subsctiption.xaml
    /// </summary>
    public partial class Add_Subsctiption : Window
    {
        public Add_Subsctiption()
        {
            InitializeComponent();
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
        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var temp = (Customer)selectedCustomer.SelectedItem;
            Decimal.TryParse(Price.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"), out Decimal result);
            var entity = new Subscription
            {
                SubscriptionId = Guid.NewGuid(),
                CustomerId = temp.CustomerId,
                StartDate = StartDate.SelectedDate ?? DateTime.UtcNow,
                EndDate = EndDate.SelectedDate ?? DateTime.UtcNow,
                Price = result,
            };
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync("http://localhost:5296/ef/subscription/", entity);
                if (response.IsSuccessStatusCode)
                {
                    this.Close();
                }
            }
        }
    }
}
