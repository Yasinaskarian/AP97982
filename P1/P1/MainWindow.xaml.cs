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
        private double xmin = -6;

        private double xmax = 6;
        private double ymin = -8;
        private double ymax = 8;


        public MainWindow()
        {
            InitializeComponent();
            PersianCalendar p = new PersianCalendar();
            calander.Text = p.GetYear(DateTime.Now).ToString() + "/"+
                p.GetMonth(DateTime.Now).ToString("0#") + "/"+
                p.GetDayOfMonth(DateTime.Now).ToString("0#");
            DataContext = new AnalogClock();
        }



        

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Min_y.Text = null;
            Min_x.Text = null;
            Max_y.Text = null;
            Max_x.Text = null;
            Function.Text = null;
            MyCanvas.Children.Clear();
            
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
        #region Equation
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            string[] equations = Eq.Text.Split(',');
            List<char> variables = new List<char>();
            int hamgen = 0;
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
                        if (d == 0)
                        {
                            hamgen++;
                        }
                        rightside.Add(d);
                            break;
                    }
                }
            }
            SquareMatrix<double> matrix = Matrixsolution.Converttomatrix(equations, variables);
            bool Isavailable = true;
            if (Matrixsolution.Det(matrix) == 0)
            {
                Calc_show.Text = "No Solution";
                Isavailable = false;
            }
            if (Matrixsolution.Det(matrix) == 0 && hamgen == variables.Count)
            {
                Calc_show.Text = "No Unique Solution";
                Isavailable = false;
            }
            if (Isavailable == true)
            {

                List<double> solved = Matrixsolution.Solvetheequation(matrix, rightside);
                string result = "";
                for (int i = 0; i < variables.Count; i++)
                {
                    result += $"{variables[i]} = {solved[i]}  ";
                }
                Calc_show.Text = result;
            }
        }
        #endregion
        #region Login
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
        #endregion
        #region Draw
        private void Draw_Click(object sender, RoutedEventArgs e)
        {

            Xcordinate();
            Ycordinate();
            char[] f = Function.Text.ToCharArray();
            Polyline pl  = new Polyline();
            pl.Stroke = Brushes.Red;
            pl.StrokeThickness = 1.5;
            double x=0;
            List<int> zarayeb = new List<int>();
            List<int> pow = new List<int>();
            List<char> op = new List<char>();
            int num = 0;
            op.Add('+');
            for(int i=0;i< f.Length;i++)
            {
                int d = 0;
                
                    
                        while (f[i] != '^')
                        {
                            if (char.IsNumber(f[i])) 
                            d = (d * 10) + int.Parse(f[i].ToString());
                    if (i == f.Length - 1)
                        break;
                            i++;
                        }
                    zarayeb.Add(d);
                    if (f[i ] == '^')
                    {
                        d = 0;
                      while (f[i] != '+' && f[i] != '-')
                      {
                        
                        if (char.IsNumber(f[i]))
                            d = (d * 10) + int.Parse(f[i].ToString());
                        if (i == f.Length - 1)
                            break;
                        i++;
                      }
                        pow.Add(d);
                    }
                if (i == f.Length - 1)
                    break;
                    if (f[i] == '+' || f[i] == '-')
                        op.Add(f[i]);
                    
                
            }
            for (int i = f.Length - 1; i > 0; i--)
            {
                if (char.IsNumber(f[i]))
                    while (f[i] != '-' && f[i] != '+'&f[i-1]!='^')
                    {

                        num = (num * 10) + int.Parse(f[i].ToString());
                        i--;
                    }
                zarayeb.Add(num);
                pow.Add(0);
                op.Add(f[i]);
                break;
            }
                double y=0;
  
            for (double i =double.Parse(Min_x.Text); i < double.Parse(Max_x.Text); i=i+0.1)
            {
                    x = i ;
                y = 0;
                for (int j = 0; j < pow.Count; j++)
                {
                    if (op[j] == '+')
                    {
                        y += zarayeb[j] * Math.Pow(x, pow[j]);
                    }
                    else if (op[j] == '-')
                        y -= zarayeb[j] * Math.Pow(x, pow[j]);
                }
                if(y>double.Parse(Min_y.Text)&& y < double.Parse(Max_y.Text))
                    pl.Points.Add(convertpoint(
                    new Point(x, y)));
            }
            MyCanvas.Children.Add(pl);
        }
        public void Ycordinate()
        {
            Line line;
            
            
            for (double i = double.Parse(Min_y.Text); i < 0; i++)
            {
                line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 0;
                line.X2 = MyCanvas.Width;
                line.Y1 = MyCanvas.Height - (i - double.Parse(Min_y.Text)) * MyCanvas.Height
                / (double.Parse(Max_y.Text) - double.Parse(Min_y.Text));
                line.Y2 = line.Y1;
                line.StrokeThickness = 0.2;

                MyCanvas.Children.Add(line);
            }
            line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = 0;
            line.X2 = MyCanvas.Width;
            line.Y1 = MyCanvas.Height - (0 - double.Parse(Min_y.Text)) * MyCanvas.Height
            / (double.Parse(Max_y.Text) - double.Parse(Min_y.Text));
            line.Y2 = line.Y1;
            line.StrokeThickness = 0.9;

            MyCanvas.Children.Add(line);
            for (double i = 0; i < double.Parse(Max_y.Text); i++)
            {
                line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 0;
                line.X2 = MyCanvas.Width;
                line.Y1 = MyCanvas.Height - (i - double.Parse(Min_y.Text)) * MyCanvas.Height
                / (double.Parse(Max_y.Text) - double.Parse(Min_y.Text));
                line.Y2 = line.Y1;
                line.StrokeThickness = 0.2;

                MyCanvas.Children.Add(line);
            }
        }
        public void Xcordinate()
        {
            
            Line line;
            
            line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = (0 - double.Parse(Min_x.Text)) * MyCanvas.Width /
                (double.Parse(Max_x.Text) - double.Parse(Min_x.Text));
            line.X2 = line.X1;
            line.Y1 = 0;
            line.Y2 = MyCanvas.Height;
            line.StrokeThickness = 0.9;
            MyCanvas.Children.Add(line);
            for (double i = 0; i < double.Parse(Max_x.Text); i++)
            {
                line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = (i - double.Parse(Min_x.Text)) * MyCanvas.Width /
                    (double.Parse(Max_x.Text) - double.Parse(Min_x.Text));
                line.X2 = line.X1;
                line.Y1 = 0;
                line.Y2 = MyCanvas.Height;
                line.StrokeThickness = 0.2;
                MyCanvas.Children.Add(line);
            }
            for (double i = double.Parse(Min_x.Text); i < 0; i++)
            {
                line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = (i - double.Parse(Min_x.Text)) * MyCanvas.Width /
                    (double.Parse(Max_x.Text) - double.Parse(Min_x.Text));
                line.X2 = line.X1;
                line.Y1 = 0;
                line.Y2 = MyCanvas.Height;
                line.StrokeThickness = 0.2;
                MyCanvas.Children.Add(line);
            }

        }
        private Point convertpoint(Point p)
        {
            Point result = new Point();
            result.X = (p.X - double.Parse( Min_x.Text)) * MyCanvas.Width / (double.Parse(Max_x.Text) - double.Parse(Min_x.Text));
            result.Y = MyCanvas.Height - (p.Y - double.Parse(Min_y.Text)) * MyCanvas.Height
            / (double.Parse(Max_y.Text) - double.Parse(Min_y.Text));
            return result;
        }
        #endregion
        #region Fdraw
        private void Draw_F_Click(object sender, RoutedEventArgs e)
        {
            YFcordinate();
            XFcordinate();
            Polyline  pl = new Polyline();
            pl.Stroke = Brushes.Red;
            pl.StrokeThickness = 2;
            for (double i = xmin; i < xmax; i=i+0.1)
            {
                double x = i ;
                double y = Math.Sin(x);
                if(y>ymin&&y<ymax)
                pl.Points.Add(fconvertpoint(
                new Point(x, y)));
            }
            Fcanvas.Children.Add(pl);

            pl = new Polyline();
            pl.Stroke = Brushes.Black;
            pl.StrokeThickness = 2;
            for (double i = xmin; i < xmax; i=i+0.1)
            {
                double x = i-double.Parse(x0text.Text);
                int k = 1;
                double y = 0;
                for (double j = 0; j <double.Parse(Ntext.Text); j ++)
                {
                    
                        if (j% 2 == 0)
                        {
                            y += Math.Pow(x, k) / fac(k);
                        }
                        else
                            y -= Math.Pow(x, k) / fac(k);
                        k=k+2;
                }


                if (y > ymin && y < ymax)
                    pl.Points.Add(fconvertpoint(
                new Point(x, y)));
            }
            Fcanvas.Children.Add(pl);

        }
        public void YFcordinate()
        {
            Line line;


            for (double i = ymin; i < 0; i++)
            {
                line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 0;
                line.X2 = Fcanvas.Width;
                line.Y1 = Fcanvas.Height - (i - (ymin)) * Fcanvas.Height
                / ((ymax) - (ymin));
                line.Y2 = line.Y1;
                line.StrokeThickness = 0.2;

                Fcanvas.Children.Add(line);
            }
            line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = 0;
            line.X2 = Fcanvas.Width;
            line.Y1 = Fcanvas.Height - (0 - (ymin)) * Fcanvas.Height
            / ((ymax) - (ymin));
            line.Y2 = line.Y1;
            line.StrokeThickness = 0.9;

            Fcanvas.Children.Add(line);
            for (double i = 0; i < ymax; i++)
            {
                line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 0;
                line.X2 = Fcanvas.Width;
                line.Y1 = Fcanvas.Height - (i - (ymin)) * Fcanvas.Height
                / ((ymax) - (ymin));
                line.Y2 = line.Y1;
                line.StrokeThickness = 0.2;

                Fcanvas.Children.Add(line);
            }
        }
        public void XFcordinate()
        {

            Line line;

            line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = (0 - (xmin) * Fcanvas.Width /
                ((xmax) - (xmin)));
            line.X2 = line.X1;
            line.Y1 = 0;
            line.Y2 = Fcanvas.Height;
            line.StrokeThickness = 0.9;
            Fcanvas.Children.Add(line);
            for (double i = 0; i < xmax; i++)
            {
                line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = (i - (xmin)) * Fcanvas.Width /
                    ((xmax) - (xmin));
                line.X2 = line.X1;
                line.Y1 = 0;
                line.Y2 = Fcanvas.Height;
                line.StrokeThickness = 0.2;
                Fcanvas.Children.Add(line);
            }
            for (double i = xmin; i < 0; i++)
            {
                line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = (i - (xmin)) * Fcanvas.Width /
                    ((xmax)- (xmin));
                line.X2 = line.X1;
                line.Y1 = 0;
                line.Y2 = Fcanvas.Height;
                line.StrokeThickness = 0.2;
                Fcanvas.Children.Add(line);
            }

        }
        private double fac(double j)
        {
            double d = 1;
            while (j != 0)
            {
                d = d * j;
                j--;
            }
            return d;
        }

        private Point fconvertpoint(Point p)
        {
            Point result = new Point();
            result.X = (p.X - xmin) * Fcanvas.Width / (xmax - xmin);
            result.Y = Fcanvas.Height - (p.Y - ymin) * Fcanvas.Height
            / (ymax - ymin);
            return result;
        }
        #endregion
        #region Them
        private void Them_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var a =(byte) Them.Value;
            var color = Color.FromArgb(a, a, a, 100);
            if (color != null)
            {
                l2.Background = new SolidColorBrush(color);
                L1.Background = new SolidColorBrush(color);
                this.Background= new SolidColorBrush(color);
                G1.Background = new SolidColorBrush(color);
                G2.Background = new SolidColorBrush(color);
                G3.Background = new SolidColorBrush(color);
            }
        }
        #endregion

        private void Clear_F_Click(object sender, RoutedEventArgs e)
        {
           
            Fcanvas.Children.Clear();
            Ntext.Text = null;
            x0text.Text = null;
        }

        private void Zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double a = double.Parse((Max_x.Text)) + Zoom.Value;
            double b = double.Parse((Min_x.Text)) + Zoom.Value;
            double c = double.Parse((Max_y.Text)) + Zoom.Value;
            double d = double.Parse((Min_y.Text)) + Zoom.Value;
            Max_x.Text = a.ToString();
            Min_x.Text= b.ToString();
            Max_y.Text=c.ToString();
            Min_y.Text=d.ToString();
            MyCanvas.Children.Clear();
            Draw_Click(sender, e);
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog prnt = new PrintDialog();
            if (prnt.ShowDialog() == true)
            {
                prnt.PrintVisual(MyCanvas, "Printing Canvas");
            }
            
        }
    }

}
