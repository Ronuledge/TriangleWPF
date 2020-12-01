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

namespace TriangleWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Triangle triangle = new Triangle();
        int equilateralTriangle = 0;
        int isoscelesTriangle = 0;
        int rightTriangle = 0;
        int arbitraryTriangle = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                triangle.StoronaA = Convert.ToInt32(txtStoronaA.Text);
                triangle.StoronaB = Convert.ToInt32(txtStoronaB.Text);
                triangle.StoronaC = Convert.ToInt32(txtStoronaC.Text);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if ((triangle.StoronaA + triangle.StoronaB) <= triangle.StoronaC
                | (triangle.StoronaC + triangle.StoronaB) <= triangle.StoronaA
                | (triangle.StoronaC + triangle.StoronaA) <= triangle.StoronaB)
            {
                MessageBox.Show("Ошибка, такого треугольника не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                view_Trienagle();
                listBoxMasBus.Items.Add("Сторона А= " + triangle.StoronaA + " Сторона B= "
                    + triangle.StoronaB + " Сторона С= " + triangle.StoronaC +
                    " вид треугольника: " + triangle.viewTriangle);
                update_StatusBar();
            }
        }

        private void view_Trienagle()
        {
            if (triangle.StoronaA == triangle.StoronaB & triangle.StoronaB == triangle.StoronaC)
            {
                triangle.viewTriangle = "Равносторонний";
                equilateralTriangle++;
            }
            else if (triangle.StoronaA == triangle.StoronaB
                || triangle.StoronaB == triangle.StoronaC
                || triangle.StoronaA == triangle.StoronaC)
            {
                triangle.viewTriangle = "Равнобедренный";
                isoscelesTriangle++;
            }
            else if (Math.Pow(triangle.StoronaA, 2) + Math.Pow(triangle.StoronaB, 2) == Math.Pow(triangle.StoronaC, 2)
                || Math.Pow(triangle.StoronaB, 2) + Math.Pow(triangle.StoronaC, 2) == Math.Pow(triangle.StoronaA, 2)
                || Math.Pow(triangle.StoronaA, 2) + Math.Pow(triangle.StoronaC, 2) == Math.Pow(triangle.StoronaB, 2))
            {
                triangle.viewTriangle = "Прямоугольный";
                rightTriangle++;
            }
            else
            {
                triangle.viewTriangle = "Произвольный";
                arbitraryTriangle++;
            }
        }

        private void update_StatusBar()
        {
            lbnEquilateralTriangle.Content = "Кол-во равносторонних трегуольников: " + equilateralTriangle;
            lbnIsoscelesTriangle.Content = "Кол-во равнобедренных трегуольников: " + isoscelesTriangle;
            lbnRightTriangle.Content = "Кол-во прямоугольных трегуольников: " + rightTriangle;
            lbnArbitraryTriangle.Content = "Кол-во произвольных трегуольников: " + arbitraryTriangle;
        }
    }
}
