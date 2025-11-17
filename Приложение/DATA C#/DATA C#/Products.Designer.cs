namespace DATA_C_
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_renter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.License = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valid_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valid_untill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Redact = new Guna.UI2.WinForms.Guna2Button();
            this.Del = new Guna.UI2.WinForms.Guna2Button();
            this.Add = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Name = new Guna.UI2.WinForms.Guna2TextBox();
            this.Untill = new Guna.UI2.WinForms.Guna2TextBox();
            this.From = new Guna.UI2.WinForms.Guna2TextBox();
            this.Traid_ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DO_TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Filter_Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.OT_TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Licen_ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 30;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(932, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Товары";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_product,
            this.ID_renter,
            this.Product_name,
            this.License,
            this.Valid_from,
            this.Valid_untill});
            this.dataGridView1.Location = new System.Drawing.Point(12, 105);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(543, 590);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID_product
            // 
            this.ID_product.HeaderText = "ID";
            this.ID_product.Name = "ID_product";
            this.ID_product.ReadOnly = true;
            this.ID_product.Visible = false;
            this.ID_product.Width = 40;
            // 
            // ID_renter
            // 
            this.ID_renter.HeaderText = "Продавец";
            this.ID_renter.Name = "ID_renter";
            this.ID_renter.ReadOnly = true;
            this.ID_renter.Width = 115;
            // 
            // Product_name
            // 
            this.Product_name.HeaderText = "Товар";
            this.Product_name.Name = "Product_name";
            this.Product_name.ReadOnly = true;
            this.Product_name.Width = 120;
            // 
            // License
            // 
            this.License.HeaderText = "Лицензия";
            this.License.Name = "License";
            this.License.ReadOnly = true;
            // 
            // Valid_from
            // 
            this.Valid_from.HeaderText = "Годен от...";
            this.Valid_from.Name = "Valid_from";
            this.Valid_from.ReadOnly = true;
            this.Valid_from.Width = 80;
            // 
            // Valid_untill
            // 
            this.Valid_untill.HeaderText = "Годен до...";
            this.Valid_untill.Name = "Valid_untill";
            this.Valid_untill.ReadOnly = true;
            this.Valid_untill.Width = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(724, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "-";
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.guna2CircleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Gray;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(883, 12);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(37, 33);
            this.guna2CircleButton1.TabIndex = 10;
            this.guna2CircleButton1.Text = "X";
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            this.guna2CircleButton1.MouseEnter += new System.EventHandler(this.guna2CircleButton1_MouseEnter);
            this.guna2CircleButton1.MouseLeave += new System.EventHandler(this.guna2CircleButton1_MouseLeave);
            // 
            // Redact
            // 
            this.Redact.BorderColor = System.Drawing.Color.Green;
            this.Redact.BorderRadius = 20;
            this.Redact.BorderThickness = 2;
            this.Redact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Redact.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Redact.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Redact.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Redact.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Redact.FillColor = System.Drawing.Color.ForestGreen;
            this.Redact.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Redact.ForeColor = System.Drawing.Color.White;
            this.Redact.Location = new System.Drawing.Point(575, 458);
            this.Redact.Name = "Redact";
            this.Redact.Size = new System.Drawing.Size(161, 45);
            this.Redact.TabIndex = 16;
            this.Redact.Text = "Редактрировать";
            this.Redact.Click += new System.EventHandler(this.Redact_Click_1);
            // 
            // Del
            // 
            this.Del.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Del.BorderRadius = 20;
            this.Del.BorderThickness = 2;
            this.Del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Del.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Del.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Del.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Del.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Del.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Del.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Del.ForeColor = System.Drawing.Color.White;
            this.Del.Location = new System.Drawing.Point(763, 458);
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(119, 45);
            this.Del.TabIndex = 15;
            this.Del.Text = "Удалить";
            this.Del.Click += new System.EventHandler(this.Del_Click_1);
            // 
            // Add
            // 
            this.Add.BorderColor = System.Drawing.Color.Green;
            this.Add.BorderRadius = 20;
            this.Add.BorderThickness = 2;
            this.Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Add.FillColor = System.Drawing.Color.ForestGreen;
            this.Add.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Location = new System.Drawing.Point(575, 407);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(307, 45);
            this.Add.TabIndex = 14;
            this.Add.Text = "Добавить";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(587, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Срок годности:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(561, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(284, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Новый / Редактируемый товар:";
            // 
            // Name
            // 
            this.Name.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Name.BorderColor = System.Drawing.Color.Black;
            this.Name.BorderRadius = 20;
            this.Name.BorderThickness = 2;
            this.Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Name.DefaultText = "";
            this.Name.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Name.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Name.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Name.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Name.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Name.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.Name.ForeColor = System.Drawing.Color.Gray;
            this.Name.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Name.Location = new System.Drawing.Point(578, 140);
            this.Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name.MaxLength = 20;
            this.Name.Name = "Name";
            this.Name.PasswordChar = '\0';
            this.Name.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name.PlaceholderText = "Товар";
            this.Name.SelectedText = "";
            this.Name.Size = new System.Drawing.Size(307, 45);
            this.Name.TabIndex = 20;
            // 
            // Untill
            // 
            this.Untill.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Untill.BorderColor = System.Drawing.Color.Black;
            this.Untill.BorderRadius = 20;
            this.Untill.BorderThickness = 2;
            this.Untill.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Untill.DefaultText = "";
            this.Untill.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Untill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Untill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Untill.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Untill.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Untill.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Untill.ForeColor = System.Drawing.Color.Gray;
            this.Untill.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Untill.Location = new System.Drawing.Point(751, 277);
            this.Untill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Untill.MaxLength = 10;
            this.Untill.Name = "Untill";
            this.Untill.PasswordChar = '\0';
            this.Untill.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Untill.PlaceholderText = "До";
            this.Untill.SelectedText = "";
            this.Untill.Size = new System.Drawing.Size(156, 44);
            this.Untill.TabIndex = 24;
            // 
            // From
            // 
            this.From.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.From.BorderColor = System.Drawing.Color.Black;
            this.From.BorderRadius = 20;
            this.From.BorderThickness = 2;
            this.From.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.From.DefaultText = "";
            this.From.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.From.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.From.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.From.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.From.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.From.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.From.ForeColor = System.Drawing.Color.Gray;
            this.From.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.From.Location = new System.Drawing.Point(566, 277);
            this.From.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.From.MaxLength = 10;
            this.From.Name = "From";
            this.From.PasswordChar = '\0';
            this.From.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.From.PlaceholderText = "От";
            this.From.SelectedText = "";
            this.From.Size = new System.Drawing.Size(156, 44);
            this.From.TabIndex = 23;
            // 
            // Traid_ComboBox1
            // 
            this.Traid_ComboBox1.AutoRoundedCorners = true;
            this.Traid_ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.Traid_ComboBox1.BorderColor = System.Drawing.Color.Black;
            this.Traid_ComboBox1.BorderRadius = 17;
            this.Traid_ComboBox1.BorderThickness = 2;
            this.Traid_ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Traid_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Traid_ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Traid_ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Traid_ComboBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.Traid_ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Traid_ComboBox1.ItemHeight = 30;
            this.Traid_ComboBox1.Location = new System.Drawing.Point(578, 212);
            this.Traid_ComboBox1.Name = "Traid_ComboBox1";
            this.Traid_ComboBox1.Size = new System.Drawing.Size(307, 36);
            this.Traid_ComboBox1.TabIndex = 27;
            this.Traid_ComboBox1.SelectedIndexChanged += new System.EventHandler(this.Traid_ComboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(587, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Имя продавца:";
            // 
            // DO_TextBox2
            // 
            this.DO_TextBox2.BorderColor = System.Drawing.Color.Black;
            this.DO_TextBox2.BorderRadius = 10;
            this.DO_TextBox2.BorderThickness = 2;
            this.DO_TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DO_TextBox2.DefaultText = "";
            this.DO_TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.DO_TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.DO_TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.DO_TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.DO_TextBox2.FillColor = System.Drawing.Color.LightGray;
            this.DO_TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DO_TextBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.DO_TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DO_TextBox2.Location = new System.Drawing.Point(692, 555);
            this.DO_TextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DO_TextBox2.MaxLength = 10;
            this.DO_TextBox2.Name = "DO_TextBox2";
            this.DO_TextBox2.PasswordChar = '\0';
            this.DO_TextBox2.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DO_TextBox2.PlaceholderText = "До";
            this.DO_TextBox2.SelectedText = "";
            this.DO_TextBox2.Size = new System.Drawing.Size(96, 36);
            this.DO_TextBox2.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(664, 561);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 27);
            this.label7.TabIndex = 32;
            this.label7.Text = "-";
            // 
            // Filter_Button1
            // 
            this.Filter_Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Filter_Button1.BorderRadius = 10;
            this.Filter_Button1.BorderThickness = 2;
            this.Filter_Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Filter_Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Filter_Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Filter_Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Filter_Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Filter_Button1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Filter_Button1.ForeColor = System.Drawing.Color.White;
            this.Filter_Button1.Location = new System.Drawing.Point(805, 555);
            this.Filter_Button1.Name = "Filter_Button1";
            this.Filter_Button1.Size = new System.Drawing.Size(98, 36);
            this.Filter_Button1.TabIndex = 33;
            this.Filter_Button1.Text = "Фильтр сроков";
            this.Filter_Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(558, 520);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "Фильтарация и поиск:";
            // 
            // OT_TextBox1
            // 
            this.OT_TextBox1.BorderColor = System.Drawing.Color.Black;
            this.OT_TextBox1.BorderRadius = 10;
            this.OT_TextBox1.BorderThickness = 2;
            this.OT_TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OT_TextBox1.DefaultText = "";
            this.OT_TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.OT_TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.OT_TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OT_TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OT_TextBox1.FillColor = System.Drawing.Color.LightGray;
            this.OT_TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.OT_TextBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OT_TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.OT_TextBox1.Location = new System.Drawing.Point(562, 555);
            this.OT_TextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OT_TextBox1.MaxLength = 10;
            this.OT_TextBox1.Name = "OT_TextBox1";
            this.OT_TextBox1.PasswordChar = '\0';
            this.OT_TextBox1.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OT_TextBox1.PlaceholderText = "От";
            this.OT_TextBox1.SelectedText = "";
            this.OT_TextBox1.Size = new System.Drawing.Size(102, 36);
            this.OT_TextBox1.TabIndex = 30;
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2ImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton1.Image")));
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton1.Location = new System.Drawing.Point(863, 520);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2ImageButton1.Size = new System.Drawing.Size(27, 23);
            this.guna2ImageButton1.TabIndex = 35;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.BorderColor = System.Drawing.Color.Black;
            this.guna2TextBox2.BorderRadius = 10;
            this.guna2TextBox2.BorderThickness = 2;
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FillColor = System.Drawing.Color.LightGray;
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Location = new System.Drawing.Point(561, 610);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2TextBox2.MaxLength = 20;
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PasswordChar = '\0';
            this.guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox2.PlaceholderText = "Поиск по названию товара";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.Size = new System.Drawing.Size(280, 36);
            this.guna2TextBox2.TabIndex = 36;
            this.guna2TextBox2.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderColor = System.Drawing.Color.Black;
            this.guna2TextBox1.BorderRadius = 10;
            this.guna2TextBox1.BorderThickness = 2;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FillColor = System.Drawing.Color.LightGray;
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(562, 659);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2TextBox1.MaxLength = 20;
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox1.PlaceholderText = "Поиск по имени продавца";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(279, 36);
            this.guna2TextBox1.TabIndex = 37;
            this.guna2TextBox1.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(587, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 21);
            this.label4.TabIndex = 38;
            this.label4.Text = "Лицензия:";
            // 
            // Licen_ComboBox1
            // 
            this.Licen_ComboBox1.AutoRoundedCorners = true;
            this.Licen_ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.Licen_ComboBox1.BorderColor = System.Drawing.Color.Black;
            this.Licen_ComboBox1.BorderRadius = 17;
            this.Licen_ComboBox1.BorderThickness = 2;
            this.Licen_ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Licen_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Licen_ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Licen_ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Licen_ComboBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Licen_ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Licen_ComboBox1.ItemHeight = 30;
            this.Licen_ComboBox1.Location = new System.Drawing.Point(578, 349);
            this.Licen_ComboBox1.Name = "Licen_ComboBox1";
            this.Licen_ComboBox1.Size = new System.Drawing.Size(307, 36);
            this.Licen_ComboBox1.TabIndex = 39;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(932, 707);
            this.Controls.Add(this.Licen_ComboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.guna2TextBox2);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Filter_Button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DO_TextBox2);
            this.Controls.Add(this.OT_TextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Traid_ComboBox1);
            this.Controls.Add(this.Untill);
            this.Controls.Add(this.From);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Redact);
            this.Controls.Add(this.Del);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(932, 707);
            this.MinimumSize = new System.Drawing.Size(932, 707);
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2Button Redact;
        private Guna.UI2.WinForms.Guna2Button Del;
        private Guna.UI2.WinForms.Guna2Button Add;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox Untill;
        private Guna.UI2.WinForms.Guna2TextBox From;
        private Guna.UI2.WinForms.Guna2TextBox Name;
        private Guna.UI2.WinForms.Guna2ComboBox Traid_ComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox DO_TextBox2;
        private Guna.UI2.WinForms.Guna2Button Filter_Button1;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox OT_TextBox1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_renter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn License;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valid_from;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valid_untill;
        private Guna.UI2.WinForms.Guna2ComboBox Licen_ComboBox1;
        private System.Windows.Forms.Label label4;
    }
}