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
using Minimus.Strategy;
using Minimus.Services.Proxy;

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

            hide();
        }

        public void hide()
        {
            comboBox1.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            comboBox2.Visible = false;
            label7.Visible = false;
            button11.Visible = false;
            dataGridView1.Visible = false;
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
            comboBox1.Visible = b;
            label5.Visible = b;
            button7.Visible = b;

        }

        public void loadData(ComboBox c)
        {
            IProxyCountry proxyCountry = new ProxyCountry();
            var response3 = proxyCountry.country();

            c.Visible = true;
            button6.Visible = true;

            for (int i = 0; i < response3.Count; i++)
            {
                c.Items.Add(response3[i].name + ", " + response3[i].capital+".");
            }
        }


        //AÑADIR USUARIO
        private void button1_Click(object sender, EventArgs e)
        {
            var val1 = new MailValidation(new AtValidation(), textBox1.Text);
            var result1 = val1.Verification();

            var val2 = new MailValidation(new DomainValidation(), textBox1.Text);
            var result2 = val2.Verification();

            var user = new User();
            var result = _service.Exist(textBox1.Text);

            if (result1 == false || result2 == false)
            {
                MessageBox.Show("Su correo no tiene el formato correcto.");
                textBox1.Text = "Email";
                textBox2.Text = "Password";
            }
            else if(result == "No existe")
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
                    label6.Visible = false;
                    button7.Visible = true;
                    dataGridView1.Visible = true;

                    signupVisible(false);
                    loginVisible(false);

                    loadData(comboBox1);


                }
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            signupVisible(true);
            loginVisible(false);

            textBox3.Text = "Email";
            textBox4.Text = "Password";
            label6.Text = "Join Mimimus Today!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            signupVisible(false);
            loginVisible(true);

            textBox1.Text = "Email";
            textBox2.Text = "Password";
            label6.Text = "Welcome back!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /////////
            ///

            var val1 = new MailValidation(new AtValidation(), textBox3.Text);
            var result1 = val1.Verification();

            var val2 = new MailValidation(new DomainValidation(), textBox3.Text);
            var result2 = val2.Verification();

            var user = new User();
            var result = _service.Exist(textBox3.Text);

            user.mail = textBox3.Text;
            user.pasword = textBox4.Text;
            user.cities = "";

            if (result1 == false || result2 == false)
            {
                MessageBox.Show("Su correo no tiene el formato correcto.");
                textBox3.Text = "Email";
                textBox4.Text = "Password";
            }
            else if (result == "No existe")
            {
                textBox3.Text = "Email";
                textBox4.Text = "Password";
                _service.AddUser(user);

                MessageBox.Show("Bienvenido!");
                signupVisible(false);
                loginVisible(false);
                label6.Visible = false;
                button7.Visible = true;
                dataGridView1.Visible = true;

                loadData(comboBox1);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            dashboardVisible(false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(comboBox1.SelectedIndex);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            dashboardVisible(true);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            label5.Visible = true;
            label6.Visible = true;
            loginVisible(true);
            dashboardVisible(false);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //textBox4.PasswordChar = 'x';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.PasswordChar = 'x';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dashboardVisible(false);
            label6.Visible = false;
            hide();
            label7.Visible = true;
            comboBox2.Visible = true;
            button11.Visible = true;
            loadData(comboBox2);
        }
    }
}
