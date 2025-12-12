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
using System.Windows.Shapes;
using System.IO;
using System.Text.RegularExpressions;


namespace AzharaP2C
{
    /// <summary>
    /// Lógica de interacción para WinSignUp.xaml
    /// </summary>
    public partial class WinSignUp : Window
    {
        private readonly string RegistroArchivos = "D:\\signup\\registroUsers.txt";
        string datos;
        public WinSignUp()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //bool swEntrada = false;
            if (txtNombre.Text == "" || txtAñoNac.Text == "" || txtCelular.Text == "" || txtApMaterno.Text == "" ||
                txtApPaterno.Text == "" || pwdContraseña.Password == "")
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "debe llenar TODOS los campos!";
            }
            else
            {
                //los campos no estan vacios
                string letterPattern = "^[A-Za-zñ]+$";
                string numericPattern = "^[0-9]{4,8}$";
                if (!Regex.IsMatch(txtNombre.Text, letterPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del Nombre es incorrecto";
                    txtNombre.Clear();
                    txtNombre.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtApMaterno.Text, letterPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del Apellido Materno es incorrecto";
                    txtApMaterno.Clear();
                    txtApMaterno.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtApPaterno.Text, letterPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del Apellido Paterno es incorrecto";
                    txtApPaterno.Clear();
                    txtApPaterno.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtCelular.Text, numericPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del celular es incorrecto";
                    txtCelular.Clear();
                    txtCelular.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtAñoNac.Text, numericPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del año de nacimiento es incorrecto";
                    txtAñoNac.Clear();
                    txtAñoNac.Focus();
                    return;
                }
                if (!txtCorreo.Text.Contains("@gmail.com"))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del correo no es correcto";
                    txtCorreo.Clear();
                    txtCorreo.Focus();
                    return;
                }
                string paswordPattern = "^[a-zA-Z0-9.#]{8,}$";
                if (!Regex.IsMatch(pwdContraseña.Password, paswordPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "La contraseña debe tener numero, letras, . o #";
                    if (pwdContraseña.Password.Length < 8)
                    {
                        lblMensaje.Content = "La contraseña debe tener un minimo de 8 caractes";
                    }
                    pwdContraseña.Clear();
                    pwdContraseña.Focus();
                    return;
                }
                //crear el correo a partir del nombre de
                //string correo = txtNombre.Text.ToLower()[0] + txtPaterno.Text.ToLower() + txtMaterno.Text.ToLower()[0] + "@univalle.edu";
                //colocar todos los datos en una cadena para guardarla en el archivo
                string datos = txtCorreo.Text.Trim() + "," + pwdContraseña.Password + "," + txtNombre.Text.Trim() + " " + txtApPaterno.Text.Trim() + " " + txtApMaterno.Text.Trim() + "," +
                               txtCelular.Text.Trim() + "," + txtAñoNac.Text.Trim() + "\n";
                //guardar en el archivo: rutArchLigin = "C:\\singup\\RegistroUsrs.txt"
                File.AppendAllText(RegistroArchivos, datos, Encoding.UTF8);

                lblMensaje.Foreground = Brushes.Black;
                lblMensaje.Content = "Bienvenido" + txtNombre.Text + " !";

                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
           
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            txtNombre.Clear();
            txtApPaterno.Clear();
            txtApMaterno.Clear();
            txtCelular.Clear();
            txtCorreo.Clear();
            txtAñoNac.Clear();
            pwdContraseña.Clear();
        }
        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            WpfPrincipal principal = new WpfPrincipal();
            principal.Show();       
            this.Close();
        }
    }
}
