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
            labelMinABM.Content = Math.Round(model.GetMinAmountOfBooks(25, 50, comboBoxSex.Text), 2);

            labelAABM.Content = Math.Round(model.GetAverageAmountOfBooks("Male"), 2);
            labelMABM.Content = Math.Round(model.GetMaxAmountOfBooks(25, 50, "Male"), 2);

            labelMinABF.Content = Math.Round(model.GetMinAmountOfBooks(25, 50, "Female"), 2);
            labelAABF.Content = Math.Round(model.GetAverageAmountOfBooks("Female"), 2);
            labelMABF.Content = Math.Round(model.GetMaxAmountOfBooks(25, 50, "Female"), 2);
            // model.GenerateBooks();
        }


        private void setComboBox()
        {
            
        }

        private void comboBoxSex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            labelMinABM.Content = Math.Round(model.GetMinAmountOfBooks(25, 50, comboBoxSex.Text), 2);
        }
    }
}
