using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using P1;
using P1.Login_account;

namespace P1.Login_account
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string[] Users = File.ReadAllLines(@"C:\git\AP97982\P1\P1\Login account\UserList.csv");
            //Dictionary<User,int> usernames = new Dictionary<User,int>();
           List<User> usernames = new List<User>();
            bool isavailable = true;
            User thisuser = new User( Userbox.Text, Passbox.Password);
            for (int i = 1; i <Users.Length; i++)
            {
                string[] str = Users[i].Split(',');
                User u = new User(str[0], str[1]);
                usernames.Add(u);
                
            }
            if(Userbox.Text == "" || Passbox.Password == "")
            {
                MessageBox.Show("Fill in the blanks");
               isavailable = false;
            }
            if (/*usernames.ContainsKey(thisuser) &&*/ isavailable == true)
            {
                for (int i = 0; i < usernames.Count; i++)
                    if (usernames[i].Username == Userbox.Text && usernames[i].Password == Passbox.Password)
                    {
                        MessageBox.Show($"welcom {Userbox.Text}");
                        MainWindow mw = new MainWindow();
                        mw.UserView.Text = $"this user {Userbox.Text} is online  ";
                        mw.Login.Content = "Logout";
                        this.Close();
                        mw.ShowDialog();
                        break;
                    }
            }
            else if(usernames.Contains(thisuser) && isavailable == true)
            {
                MessageBox.Show("Invalid username or password \n if you don't have an account please create a new account");
            }

        }

        private void CreatUser_Click(object sender, RoutedEventArgs e)
        {
            bool isavailable = true;
            string[] Users = File.ReadAllLines(@"C:\git\AP97982\P1\P1\Login account\UserList.csv");
            List<string> usernames = new List<string>();
            List<string> emails = new List<string>();
            foreach(string s in Users)
            {
                string[] str = s.Split(',');
                usernames.Add(str[0]);
                emails.Add(str[2]);
            }
            if (Creat_User.Text == "" || Email.Text == ""|| PassCreat.Password == "" || RePassCreat.Password == "")
            {
                MessageBox.Show("Fill in the blanks");
                isavailable = false;
            }
            if (PassCreat.Password != RePassCreat.Password)
            {
                MessageBox.Show("password and re-password are not equal");
                isavailable = false;
            }
            if (usernames.Contains(Creat_User.Text))
                MessageBox.Show("This user name already exist");
            if (emails.Contains(Email.Text))
                MessageBox.Show("This Email already exist");
            if((!usernames.Contains(Creat_User.Text))
                && (!emails.Contains(Creat_User.Text))
                &&isavailable==true)
            {
                File.AppendAllText(@"C:\git\AP97982\P1\P1\Login account\UserList.csv", Environment.NewLine+
                    Creat_User.Text+","+PassCreat.Password+","+Email.Text );
                MessageBox.Show($"welcom {Creat_User.Text}");
                MainWindow mw = new MainWindow();
                mw.UserView.Text = $"this user {Creat_User.Text} is online ";
                mw.Login.Content = "Logout";
                Creat_User.Text = null;
                Email.Text = null;
                PassCreat.Password = null;
                RePassCreat.Password = null;
                this.Close();
                mw.ShowDialog();

            }


        }
    }
}
