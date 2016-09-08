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
            
            model.DeSerializeData();
            labelAverageAmountOfBook.Content = Math.Round(model.GetAverageAmountOfBooks("Female"), 2);

           // model.GenerateBooks();
        }

        private void GetFiendsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(model.GetMoustPopularBook());
            ////model.SerializeData();
            //model.GenerateUsers(10000);
            //model.DistributeBooks();
            //UsersListView.Items.Refresh();
        }

        private void GetBooksButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(model.GetLeastPopularBook());
            //BooksListView.Items.Refresh();
            //UsersListView.Items.Refresh();
            //model.GenerateBooks();
            //BooksListView.Items.Refresh();
        }

        private void ButtonGenerateXML_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(model.GetMinAmountOfBooks(25, 50, "Male").ToString());

        }

        private void buttonCounts_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(model.GetMaxAmountOfBooks(25, 50, "Male").ToString());
        }
    }
}
