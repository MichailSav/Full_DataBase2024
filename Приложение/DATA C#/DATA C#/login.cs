using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DATA_C_
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        Point lastpoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close(); //Закрывает окно авторизации
        }

        private void guna2CircleButton1_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButton1.ForeColor = Color.Red;
        }

        private void guna2CircleButton1_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButton1.ForeColor = Color.White;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = "admin"; // Здесь укажите верный логин
            string password = "admin"; // Здесь укажите верный пароль

            if (guna2TextBox1.Text == username && guna2TextBox2.Text == password)
            {
                this.Hide();
                // Затем открываем диалоговое окно "Department"
                Department departmentForm = new Department();
                departmentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка авторизации. Пожалуйста, попробуйте снова.");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            ///
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
      
        }
    }
}
