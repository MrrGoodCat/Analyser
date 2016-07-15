using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace VKAnalysis
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model;
        public MainWindow()
        {
            model = new Model();
            InitializeComponent();
            UsersListView.ItemsSource = model.users;

        }

        private void GetFiendsButton_Click(object sender, RoutedEventArgs e)
        {
            model.GenerateUsers(1000);
            UsersListView.Items.Refresh();
        }
    }
}
