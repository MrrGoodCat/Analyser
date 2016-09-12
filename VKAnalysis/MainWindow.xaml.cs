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
        string sex = null;
        int minAge = 0;
        int maxAge = 0;

        public int MinAge
        {
            get
            {
                return minAge;
            }

            set
            {
                if (value > maxAge)
                {
                    maxAge = value;
                }
                else
                {
                    if (value < 0)
                    {
                        minAge = 0;
                    }
                    else
                    {
                        minAge = value;
                    }
                }
                
            }
        }

        public int MaxAge
        {
            get
            {
                return maxAge;
            }

            set
            {
                if (value < minAge)
                {
                    maxAge = minAge;
                }
                else
                {
                    if (value < 0)
                    {
                        maxAge = minAge;
                    }
                    else
                    {
                        maxAge = value;
                    }
                }
                
            }
        }

        public MainWindow()
        {
            model = new Model();
            InitializeComponent();
            
            model.DeSerializeData();
            labelMinABM.Content = Math.Round(model.GetMinAmountOfBooks(25, 50, "Male"), 2);
            labelAABM.Content = Math.Round(model.GetAverageAmountOfBooks("Male"), 2);
            labelMABM.Content = Math.Round(model.GetMaxAmountOfBooks(25, 50, "Male"), 2);

        }


        private void setComboBox()
        {

        }

        private void setAge(int minAge, int maxAge)
        {
            labelMinABF.Content = Math.Round(model.GetMinAmountOfBooks(minAge, maxAge), 2);
            labelAABF.Content = Math.Round(model.GetAverageAmountOfBooks(minAge, maxAge), 2);
            labelMABF.Content = Math.Round(model.GetMaxAmountOfBooks(minAge, maxAge), 2);
        }

        private void setAgeAndSex(int minAge, int maxAge, string sex)
        {
            labelMinABF.Content = Math.Round(model.GetMinAmountOfBooks(minAge, maxAge, sex), 2);
            labelAABF.Content = Math.Round(model.GetAverageAmountOfBooks(minAge, maxAge, sex), 2);
            labelMABF.Content = Math.Round(model.GetMaxAmountOfBooks(minAge, maxAge, sex), 2);
        }

        private void radioButtonMale_Checked(object sender, RoutedEventArgs e)
        {
            sex = "Male";
            setAgeAndSex(MinAge, MaxAge, sex);
        }

        private void radioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            sex = "Fenale";
            setAgeAndSex(MinAge, MaxAge, sex);
        }
    }
}
