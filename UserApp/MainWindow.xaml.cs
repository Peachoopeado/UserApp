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

namespace UserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            List<User> users = db.Users.ToList();
            string str = "";
            foreach(User user in users)
            {
                str += "Login:" + user.Login + " | ";
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = PassBox.Text.Trim();
            string password2 = PassBox2.Text.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Проверьте корректность данных";
                textBoxLogin.Background = Brushes.Red;
            }
            else if(password.Length < 5)
            {
                PassBox.ToolTip = "Проверьте корректность данных";
                textBoxLogin.Background = Brushes.Red;
            }
            else if(password2 != password)
            {
                PassBox2.ToolTip = "Пароли не совпадают";
            }
            else if(email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "E-mail-адрес введён некорректно";
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                PassBox2.ToolTip = "";
                textBoxEmail.ToolTip = "";

                MessageBox.Show("Всё ок");

                User user = new User(login, email, password);

                db.Users.Add(user);

                db.SaveChanges();
            }
        }
    }
}
