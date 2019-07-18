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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;
using A10;
using P1.Equations;
using P1.Clock;
using P1.Login_account;

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> s = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            PersianCalendar p = new PersianCalendar();
            calander.Text = p.GetYear(DateTime.Now).ToString() + "/"+
                p.GetMonth(DateTime.Now).ToString("0#") + "/"+
                p.GetDayOfMonth(DateTime.Now).ToString("0#");
            //var mw = new MainWindow
            //{
            DataContext = new AnalogClock();
            //};
            //mw.Show();

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Min_y.Text = null;
            Min_x.Text = null;
            Max_y.Text = null;
            Max_x.Text = null;
            Function.Text = null;
        }

        private void Clear_E_Click(object sender, RoutedEventArgs e)
        {
            Eq.Text = null;
            Calc_show.Text = null;
        }

        private void Min_y_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Max_y_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Min_x_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Max_x_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if(MessageBox.Show("Are you sure?","Exit",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            string[] equations = Eq.Text.Split(',');
            List<char> variables = new List<char>();
            
                char[] chr = equations[0].ToCharArray();
                foreach(char c in chr)
                {
                    if (char.IsLetter(c))
                    {
                        variables.Add(c);
                    }
                }
            List<double> rightside = new List<double>();
            for(int i = 0; i < equations.Length; i++)
            {
                chr = equations[i].ToCharArray();
                double d = 0;
                for(int j = 0; j < chr.Length; j++)
                {
                    if (chr[j] == '=')
                    {
                        for (int k = j+1; k < chr.Length; k++)
                        {
                            d = (d * 10) + double.Parse(chr[k].ToString());
                        }
                        rightside.Add(d);
                            break;
                    }
                }
            }
            SquareMatrix<double> matrix = Matrixsolution.Converttomatrix(equations, variables);
            SquareMatrix<double> matrix1 = Matrixsolution.Converttomatrix(equations, variables);
            List<double> solved = Matrixsolution.Solvetheequation(matrix,matrix1,rightside);
            string result = "";
            for(int i = 0; i < variables.Count; i++)
            {
                result += $"{variables[i]} = {solved[i]}  ";
            }
            Calc_show.Text = result;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Content == "Logout")
            {
                if (MessageBox.Show("are you sure?", "Logout", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MainWindow mw = new MainWindow();
                    this.Close();
                    mw.ShowDialog();
                }
            }
            LoginWindow lw = new LoginWindow();
            this.Close();
            lw.ShowDialog();
            
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.ShowDialog();
        }
    }
   
}
