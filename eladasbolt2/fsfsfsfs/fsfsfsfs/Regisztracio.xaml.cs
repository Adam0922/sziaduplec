using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace fsfsfsfs
{
    /// <summary>
    /// Interaction logic for Regisztracio.xaml
    /// </summary>
    public partial class Regisztracio : Window
    {
        public Regisztracio()
        {
            InitializeComponent();
        }

        private void Belepes_Click(object sender, RoutedEventArgs e)
        {
            Belepes login = new Belepes();
            login.Show();
            Close();
        }
        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            textBoxVezeteknev.Text = "";
            textBoxKeresztnev.Text = "";
            textBoxEmail.Text = "";
            textBoxCim.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void Megse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Adja meg az Emailt.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Adjon meg érvényes Emailt.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string firstname = textBoxVezeteknev.Text;
                string lastname = textBoxKeresztnev.Text;
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Adjon meg jelszót.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Adja meg a megerősítő jelszót.";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "A két jelszónak azonosnak kell lennie.";
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter("regisztraltak.txt", true))
                        {
                            sw.WriteLine($"Regisztrált neve: {textBoxVezeteknev}  {textBoxKeresztnev}, Email: {email}, Cím: {textBoxCim}, Jelszo: {passwordBox1}");
                            MessageBox.Show("Sikeresen regisztrált!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hiba történt a regisztrálás közben: {ex.Message}");
                    }

                }
            }
        }
    }
}
