using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimus.DB;
using Minimus.Services;
using Minimus.Models;
using System.Configuration;

namespace Minimus
{
    public partial class Form1 : Form
    {
        private static UserService _service;

        public Form1()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            _service = new UserService(connectionString);
        }

        //AÑADIR USUARIO
        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User();
            var result = _service.Exist(textBox1.Text);

            if (result == "No existe")
            {
                user.mail = textBox1.Text;
                user.pasword = textBox2.Text;
                user.cities = "";

                textBox1.Text = "";
                textBox2.Text = "";

                MessageBox.Show("Cuenta no registrada, únete!");
            }
            else if (result == "Existe")
            {
                result = _service.Verify(textBox1.Text, textBox2.Text);

                if (result == "Incorrecto")
                {
                    textBox2.Text = "";
                    MessageBox.Show("Contraseña incorrecta!");
                }
                if (result == "Correcto")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Bienvenido!");
                }
            }
            



        }
    }
}
