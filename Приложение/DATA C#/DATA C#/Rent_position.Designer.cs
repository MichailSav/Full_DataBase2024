namespace DATA_C_
{
    partial class Rent_position
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rent_position));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Num_position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_lessers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_renters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rent_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Redact = new Guna.UI2.WinForms.Guna2Button();
            this.Del = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.untill_TextBox7 = new Guna.UI2.WinForms.Guna2TextBox();
            this.from_TextBox8 = new Guna.UI2.WinForms.Guna2TextBox();
            this.Trade_ComboBox2 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lesser_ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ADD_Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.DEL_Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox5 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label8 = new System.Windows.Forms.Label();
            this.Filter_Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label9 = new System.Windows.Forms.Label();
            this.DO_TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.OT_TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox6 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox3 = new Guna.UI2.WinForms.Guna2TextBox();
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
            this.label1.Size = new System.Drawing.Size(852, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Аренда мест";
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num_position,
            this.ID_lessers,
            this.ID_renters,
            this.Rent_from,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 101);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(469, 621);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Num_position
            // 
            this.Num_position.HeaderText = "№ места";
            this.Num_position.Name = "Num_position";
            this.Num_position.ReadOnly = true;
            this.Num_position.Width = 70;
            // 
            // ID_lessers
            // 
            this.ID_lessers.HeaderText = "Арендодатель";
            this.ID_lessers.Name = "ID_lessers";
            this.ID_lessers.ReadOnly = true;
            this.ID_lessers.Width = 85;
            // 
            // ID_renters
            // 
            this.ID_renters.HeaderText = "Продавец";
            this.ID_renters.Name = "ID_renters";
            this.ID_renters.ReadOnly = true;
            this.ID_renters.Width = 75;
            // 
            // Rent_from
            // 
            this.Rent_from.HeaderText = "Аренда от...";
            this.Rent_from.Name = "Rent_from";
            this.Rent_from.ReadOnly = true;
            this.Rent_from.Width = 95;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Аренда до...";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 95;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(505, 215);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(0, 0);
            this.guna2TextBox1.TabIndex = 2;
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
            this.guna2CircleButton1.Location = new System.Drawing.Point(803, 12);
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
            this.Redact.Location = new System.Drawing.Point(487, 338);
            this.Redact.Name = "Redact";
            this.Redact.Size = new System.Drawing.Size(169, 45);
            this.Redact.TabIndex = 16;
            this.Redact.Text = "Изменить данные";
            this.Redact.Click += new System.EventHandler(this.Redact_Click);
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
            this.Del.Location = new System.Drawing.Point(684, 338);
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(156, 45);
            this.Del.TabIndex = 15;
            this.Del.Text = "Очистить место";
            this.Del.Click += new System.EventHandler(this.Del_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(526, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 21);
            this.label5.TabIndex = 20;
            this.label5.Text = "Время аренды:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(496, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Редактируемое место:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(657, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 27);
            this.label7.TabIndex = 23;
            this.label7.Text = "-";
            // 
            // untill_TextBox7
            // 
            this.untill_TextBox7.BorderColor = System.Drawing.Color.Black;
            this.untill_TextBox7.BorderRadius = 20;
            this.untill_TextBox7.BorderThickness = 2;
            this.untill_TextBox7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.untill_TextBox7.DefaultText = "";
            this.untill_TextBox7.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.untill_TextBox7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.untill_TextBox7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.untill_TextBox7.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.untill_TextBox7.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.untill_TextBox7.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.untill_TextBox7.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.untill_TextBox7.Location = new System.Drawing.Point(684, 279);
            this.untill_TextBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.untill_TextBox7.MaxLength = 10;
            this.untill_TextBox7.Name = "untill_TextBox7";
            this.untill_TextBox7.PasswordChar = '\0';
            this.untill_TextBox7.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.untill_TextBox7.PlaceholderText = "До";
            this.untill_TextBox7.SelectedText = "";
            this.untill_TextBox7.Size = new System.Drawing.Size(156, 44);
            this.untill_TextBox7.TabIndex = 22;
            // 
            // from_TextBox8
            // 
            this.from_TextBox8.BorderColor = System.Drawing.Color.Black;
            this.from_TextBox8.BorderRadius = 20;
            this.from_TextBox8.BorderThickness = 2;
            this.from_TextBox8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.from_TextBox8.DefaultText = "";
            this.from_TextBox8.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.from_TextBox8.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.from_TextBox8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.from_TextBox8.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.from_TextBox8.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.from_TextBox8.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.from_TextBox8.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.from_TextBox8.Location = new System.Drawing.Point(500, 279);
            this.from_TextBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.from_TextBox8.MaxLength = 10;
            this.from_TextBox8.Name = "from_TextBox8";
            this.from_TextBox8.PasswordChar = '\0';
            this.from_TextBox8.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.from_TextBox8.PlaceholderText = "От";
            this.from_TextBox8.SelectedText = "";
            this.from_TextBox8.Size = new System.Drawing.Size(156, 44);
            this.from_TextBox8.TabIndex = 21;
            // 
            // Trade_ComboBox2
            // 
            this.Trade_ComboBox2.AutoRoundedCorners = true;
            this.Trade_ComboBox2.BackColor = System.Drawing.Color.Transparent;
            this.Trade_ComboBox2.BorderColor = System.Drawing.Color.Black;
            this.Trade_ComboBox2.BorderRadius = 17;
            this.Trade_ComboBox2.BorderThickness = 2;
            this.Trade_ComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Trade_ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Trade_ComboBox2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Trade_ComboBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Trade_ComboBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.Trade_ComboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Trade_ComboBox2.ItemHeight = 30;
            this.Trade_ComboBox2.Location = new System.Drawing.Point(500, 147);
            this.Trade_ComboBox2.Name = "Trade_ComboBox2";
            this.Trade_ComboBox2.Size = new System.Drawing.Size(307, 36);
            this.Trade_ComboBox2.TabIndex = 25;
            this.Trade_ComboBox2.SelectedIndexChanged += new System.EventHandler(this.Trade_ComboBox2_SelectedIndexChanged);
            // 
            // lesser_ComboBox1
            // 
            this.lesser_ComboBox1.AutoRoundedCorners = true;
            this.lesser_ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.lesser_ComboBox1.BorderColor = System.Drawing.Color.Black;
            this.lesser_ComboBox1.BorderRadius = 17;
            this.lesser_ComboBox1.BorderThickness = 2;
            this.lesser_ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lesser_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lesser_ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lesser_ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lesser_ComboBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.lesser_ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lesser_ComboBox1.ItemHeight = 30;
            this.lesser_ComboBox1.Location = new System.Drawing.Point(500, 212);
            this.lesser_ComboBox1.Name = "lesser_ComboBox1";
            this.lesser_ComboBox1.Size = new System.Drawing.Size(307, 36);
            this.lesser_ComboBox1.TabIndex = 26;
            this.lesser_ComboBox1.SelectedIndexChanged += new System.EventHandler(this.lesser_ComboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(526, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Имя продавца:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(526, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 21);
            this.label3.TabIndex = 28;
            this.label3.Text = "Имя арендодателя:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(496, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 23);
            this.label4.TabIndex = 29;
            this.label4.Text = "Новое место:";
            // 
            // ADD_Button1
            // 
            this.ADD_Button1.BorderColor = System.Drawing.Color.Green;
            this.ADD_Button1.BorderRadius = 10;
            this.ADD_Button1.BorderThickness = 2;
            this.ADD_Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ADD_Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ADD_Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ADD_Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ADD_Button1.FillColor = System.Drawing.Color.ForestGreen;
            this.ADD_Button1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ADD_Button1.ForeColor = System.Drawing.Color.White;
            this.ADD_Button1.Location = new System.Drawing.Point(487, 460);
            this.ADD_Button1.Name = "ADD_Button1";
            this.ADD_Button1.Size = new System.Drawing.Size(166, 45);
            this.ADD_Button1.TabIndex = 31;
            this.ADD_Button1.Text = "Добавить";
            this.ADD_Button1.Click += new System.EventHandler(this.ADD_Button1_Click);
            // 
            // DEL_Button2
            // 
            this.DEL_Button2.BorderColor = System.Drawing.Color.Maroon;
            this.DEL_Button2.BorderRadius = 10;
            this.DEL_Button2.BorderThickness = 2;
            this.DEL_Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DEL_Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DEL_Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DEL_Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DEL_Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DEL_Button2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.DEL_Button2.ForeColor = System.Drawing.Color.White;
            this.DEL_Button2.Location = new System.Drawing.Point(684, 460);
            this.DEL_Button2.Name = "DEL_Button2";
            this.DEL_Button2.Size = new System.Drawing.Size(156, 45);
            this.DEL_Button2.TabIndex = 32;
            this.DEL_Button2.Text = "Удалить";
            this.DEL_Button2.Click += new System.EventHandler(this.DEL_Button2_Click);
            // 
            // guna2TextBox5
            // 
            this.guna2TextBox5.AutoRoundedCorners = true;
            this.guna2TextBox5.BorderColor = System.Drawing.Color.Black;
            this.guna2TextBox5.BorderRadius = 17;
            this.guna2TextBox5.BorderThickness = 2;
            this.guna2TextBox5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox5.DefaultText = "";
            this.guna2TextBox5.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox5.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox5.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox5.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.guna2TextBox5.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox5.Location = new System.Drawing.Point(500, 417);
            this.guna2TextBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2TextBox5.MaxLength = 2;
            this.guna2TextBox5.Name = "guna2TextBox5";
            this.guna2TextBox5.PasswordChar = '\0';
            this.guna2TextBox5.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox5.PlaceholderText = "Номер";
            this.guna2TextBox5.SelectedText = "";
            this.guna2TextBox5.Size = new System.Drawing.Size(200, 36);
            this.guna2TextBox5.TabIndex = 35;
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
            this.guna2ImageButton1.Location = new System.Drawing.Point(700, 523);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2ImageButton1.Size = new System.Drawing.Size(27, 23);
            this.guna2ImageButton1.TabIndex = 45;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(496, 523);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 23);
            this.label8.TabIndex = 44;
            this.label8.Text = "Фильтарация и поиск:";
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
            this.Filter_Button1.Location = new System.Drawing.Point(742, 556);
            this.Filter_Button1.Name = "Filter_Button1";
            this.Filter_Button1.Size = new System.Drawing.Size(98, 36);
            this.Filter_Button1.TabIndex = 43;
            this.Filter_Button1.Text = "Фильтр сроков";
            this.Filter_Button1.Click += new System.EventHandler(this.Filter_Button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(601, 562);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 27);
            this.label9.TabIndex = 42;
            this.label9.Text = "-";
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
            this.DO_TextBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DO_TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DO_TextBox2.Location = new System.Drawing.Point(629, 556);
            this.DO_TextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DO_TextBox2.MaxLength = 10;
            this.DO_TextBox2.Name = "DO_TextBox2";
            this.DO_TextBox2.PasswordChar = '\0';
            this.DO_TextBox2.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DO_TextBox2.PlaceholderText = "До";
            this.DO_TextBox2.SelectedText = "";
            this.DO_TextBox2.Size = new System.Drawing.Size(96, 36);
            this.DO_TextBox2.TabIndex = 41;
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
            this.OT_TextBox1.Location = new System.Drawing.Point(499, 556);
            this.OT_TextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OT_TextBox1.MaxLength = 10;
            this.OT_TextBox1.Name = "OT_TextBox1";
            this.OT_TextBox1.PasswordChar = '\0';
            this.OT_TextBox1.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OT_TextBox1.PlaceholderText = "От";
            this.OT_TextBox1.SelectedText = "";
            this.OT_TextBox1.Size = new System.Drawing.Size(102, 36);
            this.OT_TextBox1.TabIndex = 40;
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
            this.guna2TextBox2.Location = new System.Drawing.Point(500, 686);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2TextBox2.MaxLength = 20;
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PasswordChar = '\0';
            this.guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox2.PlaceholderText = "Поиск по имени продавца";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.Size = new System.Drawing.Size(323, 36);
            this.guna2TextBox2.TabIndex = 48;
            this.guna2TextBox2.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged_1);
            // 
            // guna2TextBox6
            // 
            this.guna2TextBox6.BorderColor = System.Drawing.Color.Black;
            this.guna2TextBox6.BorderRadius = 10;
            this.guna2TextBox6.BorderThickness = 2;
            this.guna2TextBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox6.DefaultText = "";
            this.guna2TextBox6.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox6.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox6.FillColor = System.Drawing.Color.LightGray;
            this.guna2TextBox6.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2TextBox6.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox6.Location = new System.Drawing.Point(500, 598);
            this.guna2TextBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2TextBox6.MaxLength = 2;
            this.guna2TextBox6.Name = "guna2TextBox6";
            this.guna2TextBox6.PasswordChar = '\0';
            this.guna2TextBox6.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox6.PlaceholderText = "Поиск по № места";
            this.guna2TextBox6.SelectedText = "";
            this.guna2TextBox6.Size = new System.Drawing.Size(184, 36);
            this.guna2TextBox6.TabIndex = 47;
            this.guna2TextBox6.TextChanged += new System.EventHandler(this.guna2TextBox6_TextChanged);
            // 
            // guna2TextBox3
            // 
            this.guna2TextBox3.BorderColor = System.Drawing.Color.Black;
            this.guna2TextBox3.BorderRadius = 10;
            this.guna2TextBox3.BorderThickness = 2;
            this.guna2TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox3.DefaultText = "";
            this.guna2TextBox3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox3.FillColor = System.Drawing.Color.LightGray;
            this.guna2TextBox3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2TextBox3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox3.Location = new System.Drawing.Point(500, 642);
            this.guna2TextBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2TextBox3.MaxLength = 20;
            this.guna2TextBox3.Name = "guna2TextBox3";
            this.guna2TextBox3.PasswordChar = '\0';
            this.guna2TextBox3.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2TextBox3.PlaceholderText = "Поиск по имени арендатора";
            this.guna2TextBox3.SelectedText = "";
            this.guna2TextBox3.Size = new System.Drawing.Size(324, 36);
            this.guna2TextBox3.TabIndex = 46;
            this.guna2TextBox3.TextChanged += new System.EventHandler(this.guna2TextBox3_TextChanged);
            // 
            // Rent_position
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(852, 737);
            this.Controls.Add(this.guna2TextBox2);
            this.Controls.Add(this.guna2TextBox6);
            this.Controls.Add(this.guna2TextBox3);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Filter_Button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DO_TextBox2);
            this.Controls.Add(this.OT_TextBox1);
            this.Controls.Add(this.guna2TextBox5);
            this.Controls.Add(this.DEL_Button2);
            this.Controls.Add(this.ADD_Button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lesser_ComboBox1);
            this.Controls.Add(this.Trade_ComboBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.untill_TextBox7);
            this.Controls.Add(this.from_TextBox8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Redact);
            this.Controls.Add(this.Del);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(852, 824);
            this.MinimumSize = new System.Drawing.Size(852, 724);
            this.Name = "Rent_position";
            this.Text = "Rent_position";
            this.Load += new System.EventHandler(this.Rent_position_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2Button Redact;
        private Guna.UI2.WinForms.Guna2Button Del;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox untill_TextBox7;
        private Guna.UI2.WinForms.Guna2TextBox from_TextBox8;
        private Guna.UI2.WinForms.Guna2ComboBox lesser_ComboBox1;
        private Guna.UI2.WinForms.Guna2ComboBox Trade_ComboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button DEL_Button2;
        private Guna.UI2.WinForms.Guna2Button ADD_Button1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox5;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button Filter_Button1;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox DO_TextBox2;
        private Guna.UI2.WinForms.Guna2TextBox OT_TextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num_position;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_lessers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_renters;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rent_from;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox6;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox3;
    }
}