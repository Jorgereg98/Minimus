﻿using System;
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
            signupVisible(false);

            
        }

        public void signupVisible(bool b)
        {
            label3.Visible = b;
            label4.Visible = b;
            textBox3.Visible = b;
            textBox4.Visible = b;
            button3.Visible = b;
            button4.Visible = b;
            button5.Visible = b;
        }

        public void loginVisible(bool b)
        {
            label1.Visible = b;
            label2.Visible = b;
            textBox1.Visible = b;
            textBox2.Visible = b;
            button1.Visible = b;
            button2.Visible = b;
        }

        public void dashboardVisible(bool b)
        {

        }


        //AÑADIR USUARIO
        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User();
            var result = _service.Exist(textBox1.Text);

            if (result == "No existe")
            {
                textBox1.Text = "Email";
                textBox2.Text = "Password";

                MessageBox.Show("Cuenta no registrada, únete!");
            }
            else if (result == "Existe")
            {
                result = _service.Verify(textBox1.Text, textBox2.Text);

                if (result == "Incorrecto")
                {
                    textBox1.Text = "Email";
                    textBox2.Text = "Password";
                    MessageBox.Show("Contraseña incorrecta!");
                }
                if (result == "Correcto")
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Bienvenido!");
                    loginVisible(false);

                    
                }
            }
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            signupVisible(true);
            loginVisible(false);

            textBox3.Text = "Email";
            textBox4.Text = "Password";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            signupVisible(false);
            loginVisible(true);

            textBox1.Text = "Email";
            textBox2.Text = "Password";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var user = new User();
            user.mail = textBox3.Text;
            user.pasword = textBox4.Text;
            user.cities = "";

            var result = _service.Exist(textBox3.Text);

            if (result == "No existe")
            {
                textBox1.Text = "Email";
                textBox2.Text = "Password";
                _service.AddUser(user);

                MessageBox.Show("Bienvenido!");
            }
            else if (result == "Existe")
            {
                textBox3.Text = "Email";
                textBox4.Text = "Password";

                MessageBox.Show("Cuenta ya registrada.");
            }           
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length < 5)
            {
                Password password = PasswordFluentBuilder.Create(DifficultyEnum.Weak)
                    .Finish();
                MessageBox.Show(password.ToString());
            }
            else if (textBox4.Text.Length >= 5 && textBox4.Text.Length <= 8)
            {
                Password password = PasswordFluentBuilder.Create(DifficultyEnum.Regular)
                    .Finish();
                MessageBox.Show(password.ToString());
            }
            else if (textBox4.Text.Length > 8)
            {
                Password password = PasswordFluentBuilder.Create(DifficultyEnum.Strong)
                    .Finish();
                MessageBox.Show(password.ToString());

            }
        }
    }
}
