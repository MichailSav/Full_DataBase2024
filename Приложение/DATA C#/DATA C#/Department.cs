using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DATA_C_
{
    public partial class Department : Form
    {

        public Department()
        {
            InitializeComponent();
        }
        private DataBase db;
        string id;


        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton1_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButton1.ForeColor = Color.Red;
        }

        private void guna2CircleButton1_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButton1.ForeColor = Color.White;
        }
        Point lastpoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)// Возможность передвигать диологовое окно
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }


        private void Traid_Load()
        {
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT Профессии.Proffe FROM Профессии";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string data = reader1.GetString(0);
                guna2ComboBox1.Items.Add(data);
            }
        }

        private void Department_Load(object sender, EventArgs e)
        {

            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point((ScreenWidth / 2) - (this.Width / 2), (ScreenHeight / 2) - (this.Height / 2));

            Traid_Load();

            LoadData();
        }

        private void LoadData()
        {
            var db = DataBase.GetInstance();
            var conn = db.GetConnection();

            // Проверьте, что соединение не равно null
            if (conn != null)
            {
                // Соединение уже открыто внутри метода GetConnection
                string query = "SELECT * FROM Human_Resources_Department";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        dataGridView1.Rows.Clear(); // Очистите существующие строки
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader["ID_workers"],
                                reader["Full_Name"],
                                reader["Profession"],
                                reader["Passport_series"],
                                reader["Passport_number"]
                            );
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Ошибка подключения к БД.");
            }
        }

        private void Ren_device_Click(object sender, EventArgs e)
        {
            Rent_device devicesForm = new Rent_device();
            devicesForm.ShowDialog();
        }

        private void Ren_position_Click(object sender, EventArgs e)
        {
            Rent_position positionForm = new Rent_position();
            positionForm.ShowDialog();
        }

        private void Ren_storage_Click(object sender, EventArgs e)
        {
            Rent_storage storageForm = new Rent_storage();
            storageForm.ShowDialog();
        }

        private void Device_Menu_Click(object sender, EventArgs e)
        {
            Rent_device deviceForm = new Rent_device(); 
            deviceForm.ShowDialog();
        }

        private void Place_menu_Click(object sender, EventArgs e)
        {
            Rent_position positionForm = new Rent_position();
            positionForm.ShowDialog();
        }

        private void Storage_Menu_Click(object sender, EventArgs e)
        {
            Rent_storage storageForm = new Rent_storage();
            storageForm.ShowDialog();
        }

        private void Renters_Menu_Click_1(object sender, EventArgs e)
        {
            Renters renterForm = new Renters();
            renterForm.ShowDialog();
        }

        private void Products_Menu_Click(object sender, EventArgs e)
        {
            Products productForm = new Products();
            productForm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }



        private void Add_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string profes = guna2ComboBox1.Text;
            string seria = Seria.Text;
            string numbers = Numer.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(profes) || string.IsNullOrEmpty(seria) || string.IsNullOrEmpty(numbers))
            {
                MessageBox.Show("Заполните все поля.");
            }
            else if (!Regex.IsMatch(profes, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните данные об профессии.");
            }
            else if (!Regex.IsMatch(seria, "^[а-яА-Я0-9 .-]+$"))
            {
                MessageBox.Show("Заполните серию пспорта.");
            }
            else if (!Regex.IsMatch(name, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните ФИО правильно.");
            }
            else if (!Regex.IsMatch(numbers, "^[0-9 .()+-]+$"))
            {
                MessageBox.Show("Заполните номер паспорта.");
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            byte[] imageBytes;
                            using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                            {
                                imageBytes = new byte[fs.Length];
                                fs.Read(imageBytes, 0, (int)fs.Length);
                            }

                            db = DataBase.GetInstance();
                            SQLiteConnection conn = db.GetConnection();
                            // ИЗМЕНЕННЫЙ SQL-ЗАПРОС: Добавлен столбец 'Photo'
                            string query = "INSERT INTO Human_Resources_Department (Full_Name, Profession, Passport_series, Passport_number, Photo) VALUES (@name, @profes, @seria, @numbers, @image)";
                            SQLiteCommand command = new SQLiteCommand(query, conn);
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@profes", profes);
                            command.Parameters.AddWithValue("@seria", seria);
                            command.Parameters.AddWithValue("@numbers", numbers);
                            command.Parameters.AddWithValue("@image", imageBytes);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Запись добавлена в базу!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при добавлении записи: " + ex.Message);
                        }
                    }
                }
                LoadData();
            }
        }
            private void Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                string id = dataGridView1.SelectedRows[0].Cells["ID_workers"].Value.ToString();

                // Диалоговое окно "Да/Нет"
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE FROM Human_Resources_Department WHERE ID_workers = @id";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Refresh();
                    MessageBox.Show("Запись удалена из базы!");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!");
            }

        }

        private void Redact_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) ||
                string.IsNullOrEmpty(guna2ComboBox1.Text) ||
                string.IsNullOrEmpty(Seria.Text) ||
                string.IsNullOrEmpty(Numer.Text))
            {
                MessageBox.Show("Заполните редактируемые поля!");
            }
            else if (!Regex.IsMatch(Name.Text, "^[а-яА-Я -]+$"))
            {
                MessageBox.Show("Заполните данные ФИО правильно.");
            }
            else if (!Regex.IsMatch(guna2ComboBox1.Text, "^[а-яА-Я .-]+$"))
            {
                MessageBox.Show("Заполните данные о профессии.");
            }
            else if (!Regex.IsMatch(Seria.Text, "^[0-9 .-]+$"))
            {
                MessageBox.Show("Заполните серию паспорта.");
            }
            else if (!Regex.IsMatch(Numer.Text, "^[0-9 .]+$"))
            {
                MessageBox.Show("Заполните номер паспорта.");
            }
            else
            {
                // Запрос согласия на внесение изменений
                DialogResult result = MessageBox.Show("Вы уверены, что хотите внести изменения?", "Подтверждение", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Проверка, выбрана ли строка в DataGridView
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Получение выбранной строки из DataGridView
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        string id = selectedRow.Cells["ID_workers"].Value.ToString();

                        // Получение экземпляра базы данных и соединения
                        db = DataBase.GetInstance();
                        SQLiteConnection conn = db.GetConnection();

                        // SQL запрос для обновления данных
                        string query = "UPDATE Human_Resources_Department SET Full_Name = @name, Profession = @pro, Passport_series = @ser, Passport_number = @num WHERE ID_workers = @id";
                        SQLiteCommand command = new SQLiteCommand(query, conn);

                        // Добавление параметров
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", Name.Text);
                         

                        command.Parameters.AddWithValue("@pro", guna2ComboBox1.Text);
                        command.Parameters.AddWithValue("@ser", Seria.Text);
                        command.Parameters.AddWithValue("@num", Numer.Text);

                        // Выполнение запроса
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись успешно изменена!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Выберите строку для редактирования.");
                    }
                }
            }


        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)// Возможность передвигать диологовое окно
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }
            

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Name.Clear();
            Seria.Clear();
            Numer.Clear();
            guna2ComboBox1.SelectedIndex = -1;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                db = DataBase.GetInstance();
                SQLiteConnection conn = db.GetConnection();
                id = dataGridView1.SelectedRows[0].Cells["ID_workers"].Value.ToString();
                string query = "SELECT Photo, Full_Name, Profession, Passport_series, Passport_number FROM Human_Resources_Department WHERE ID_workers = @id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Заполняем текстовые поля
                    Name.Text = reader["Full_Name"].ToString();
                    Seria.Text = reader["Passport_series"].ToString();
                    Numer.Text = reader["Passport_number"].ToString();
                    guna2ComboBox1.Text = reader["Profession"].ToString();
                    

                    object photoObject = reader["Photo"]; // Получаем значение как объект
                    if (photoObject != DBNull.Value) // Проверяем на DBNull.Value
                    {
                        byte[] pht = (byte[])photoObject; // Преобразуем только если не NULL
                        MemoryStream ms = new MemoryStream(pht);
                        pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Refresh();
                    }
                    else
                    {
                        pictureBox1.Image = null; // Или установите какое-то изображение по умолчанию
                        MessageBox.Show("Изображение отсутствует для этой записи."); // Информируем пользователя
                    }
                }
                reader.Close(); // Закрываем reader
            }

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox2.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Profession"].Value != null && row.Cells["Profession"].Value.ToString().ToLower().Contains(filter.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ide1 = guna2ComboBox1.Text;
            db = DataBase.GetInstance();
            SQLiteConnection conn1 = db.GetConnection();
            string query1 = "SELECT ID FROM Профессии WHERE Proffe = @ide)";
            SQLiteCommand cmd1 = new SQLiteCommand(query1, conn1);
            cmd1.Parameters.AddWithValue("@ide", ide1);
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            string filter = guna2TextBox3.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Full_Name"].Value != null && row.Cells["Full_Name"].Value.ToString().ToLower().Contains(filter.ToLower()))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}

