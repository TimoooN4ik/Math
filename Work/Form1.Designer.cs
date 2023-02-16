
namespace Work
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(872, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Date Base";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(11, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Температура (°C)";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.Gray;
            this.textBox2.Location = new System.Drawing.Point(11, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(299, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Относительная плотность (кг/м³ при +20 °C)";
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(11, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Расчитать плотность";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.Color.Gray;
            this.textBox3.Location = new System.Drawing.Point(328, 82);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(299, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Кинематическая вязкость (м2/c)";
            this.textBox3.Visible = false;
            this.textBox3.Enter += new System.EventHandler(this.textBox3_Enter);
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(11, 29);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(299, 21);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.Text = "Уравнение Мановяна";
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // textBox4
            // 
            this.textBox4.ForeColor = System.Drawing.Color.Gray;
            this.textBox4.Location = new System.Drawing.Point(11, 108);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(299, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "Альфа";
            this.textBox4.Visible = false;
            this.textBox4.Enter += new System.EventHandler(this.textBox4_Enter);
            this.textBox4.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // textBox5
            // 
            this.textBox5.ForeColor = System.Drawing.Color.Gray;
            this.textBox5.Location = new System.Drawing.Point(11, 56);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(299, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "Молекулярная масса (Mr)";
            this.textBox5.Visible = false;
            this.textBox5.Enter += new System.EventHandler(this.textBox5_Enter);
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // textBox6
            // 
            this.textBox6.ForeColor = System.Drawing.Color.Gray;
            this.textBox6.Location = new System.Drawing.Point(11, 82);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(299, 20);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "Температура (°C)";
            this.textBox6.Visible = false;
            this.textBox6.Enter += new System.EventHandler(this.textBox6_Enter);
            this.textBox6.Leave += new System.EventHandler(this.textBox6_Leave);
            // 
            // textBox7
            // 
            this.textBox7.ForeColor = System.Drawing.Color.Gray;
            this.textBox7.Location = new System.Drawing.Point(11, 108);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(299, 20);
            this.textBox7.TabIndex = 11;
            this.textBox7.Text = "Давление (МПа)";
            this.textBox7.Visible = false;
            this.textBox7.Enter += new System.EventHandler(this.textBox7_Enter);
            this.textBox7.Leave += new System.EventHandler(this.textBox7_Leave);
            // 
            // textBox8
            // 
            this.textBox8.ForeColor = System.Drawing.Color.Gray;
            this.textBox8.Location = new System.Drawing.Point(328, 56);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(299, 20);
            this.textBox8.TabIndex = 12;
            this.textBox8.Text = "Плотность (кг/м³)";
            this.textBox8.Visible = false;
            this.textBox8.Enter += new System.EventHandler(this.textBox8_Enter);
            this.textBox8.Leave += new System.EventHandler(this.textBox8_Leave);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(732, 308);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 34);
            this.button4.TabIndex = 17;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 297);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(957, 262);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Результат";
            this.columnHeader1.Width = 320;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Метод";
            this.columnHeader2.Width = 320;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Классификация";
            this.columnHeader3.Width = 320;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(415, 186);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 34);
            this.button5.TabIndex = 19;
            this.button5.Text = "Рассчитать вязкость";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(328, 29);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(299, 21);
            this.comboBox3.TabIndex = 20;
            this.comboBox3.SelectedValueChanged += new System.EventHandler(this.comboBox3_SelectedValueChanged);
            // 
            // textBox9
            // 
            this.textBox9.ForeColor = System.Drawing.Color.Gray;
            this.textBox9.Location = new System.Drawing.Point(328, 56);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(299, 20);
            this.textBox9.TabIndex = 21;
            this.textBox9.Text = "Абсолютная температура (°C)";
            this.textBox9.Visible = false;
            this.textBox9.Enter += new System.EventHandler(this.textBox9_Enter);
            this.textBox9.Leave += new System.EventHandler(this.textBox9_Leave);
            // 
            // textBox10
            // 
            this.textBox10.ForeColor = System.Drawing.Color.Gray;
            this.textBox10.Location = new System.Drawing.Point(328, 82);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(299, 20);
            this.textBox10.TabIndex = 22;
            this.textBox10.Text = "Экспериментальное значение T1";
            this.textBox10.Visible = false;
            this.textBox10.Enter += new System.EventHandler(this.textBox10_Enter);
            this.textBox10.Leave += new System.EventHandler(this.textBox10_Leave);
            // 
            // textBox11
            // 
            this.textBox11.ForeColor = System.Drawing.Color.Gray;
            this.textBox11.Location = new System.Drawing.Point(328, 108);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(299, 20);
            this.textBox11.TabIndex = 23;
            this.textBox11.Text = "Значение v1 при температуре T1";
            this.textBox11.Visible = false;
            this.textBox11.Enter += new System.EventHandler(this.textBox11_Enter);
            this.textBox11.Leave += new System.EventHandler(this.textBox11_Leave);
            // 
            // textBox12
            // 
            this.textBox12.ForeColor = System.Drawing.Color.Gray;
            this.textBox12.Location = new System.Drawing.Point(328, 134);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(299, 20);
            this.textBox12.TabIndex = 24;
            this.textBox12.Text = "Экспериментальное значение T2";
            this.textBox12.Visible = false;
            this.textBox12.Enter += new System.EventHandler(this.textBox12_Enter);
            this.textBox12.Leave += new System.EventHandler(this.textBox12_Leave);
            // 
            // textBox13
            // 
            this.textBox13.ForeColor = System.Drawing.Color.Gray;
            this.textBox13.Location = new System.Drawing.Point(328, 160);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(299, 20);
            this.textBox13.TabIndex = 25;
            this.textBox13.Text = "Значение v2 при температуре T2";
            this.textBox13.Visible = false;
            this.textBox13.Enter += new System.EventHandler(this.textBox13_Enter);
            this.textBox13.Leave += new System.EventHandler(this.textBox13_Leave);
            // 
            // textBox14
            // 
            this.textBox14.ForeColor = System.Drawing.Color.Gray;
            this.textBox14.Location = new System.Drawing.Point(328, 56);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(299, 20);
            this.textBox14.TabIndex = 26;
            this.textBox14.Text = "Температура (°C)";
            this.textBox14.Visible = false;
            this.textBox14.Enter += new System.EventHandler(this.textBox14_Enter);
            this.textBox14.Leave += new System.EventHandler(this.textBox14_Leave);
            // 
            // textBox15
            // 
            this.textBox15.ForeColor = System.Drawing.Color.Gray;
            this.textBox15.Location = new System.Drawing.Point(328, 82);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(299, 20);
            this.textBox15.TabIndex = 27;
            this.textBox15.Text = "Коэффициент a";
            this.textBox15.Visible = false;
            this.textBox15.Enter += new System.EventHandler(this.textBox15_Enter);
            this.textBox15.Leave += new System.EventHandler(this.textBox15_Leave);
            // 
            // textBox16
            // 
            this.textBox16.ForeColor = System.Drawing.Color.Gray;
            this.textBox16.Location = new System.Drawing.Point(328, 108);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(299, 20);
            this.textBox16.TabIndex = 28;
            this.textBox16.Text = "Коэффициент b";
            this.textBox16.Visible = false;
            this.textBox16.Enter += new System.EventHandler(this.textBox16_Enter);
            this.textBox16.Leave += new System.EventHandler(this.textBox16_Leave);
            // 
            // textBox17
            // 
            this.textBox17.ForeColor = System.Drawing.Color.Gray;
            this.textBox17.Location = new System.Drawing.Point(644, 56);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(299, 20);
            this.textBox17.TabIndex = 29;
            this.textBox17.Text = "Относительная плотность (кг/м³ при +20 °C)";
            this.textBox17.Enter += new System.EventHandler(this.textBox17_Enter);
            this.textBox17.Leave += new System.EventHandler(this.textBox17_Leave);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(644, 29);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(299, 21);
            this.comboBox4.TabIndex = 30;
            this.comboBox4.SelectedValueChanged += new System.EventHandler(this.comboBox4_SelectedValueChanged);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(817, 186);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(126, 34);
            this.button6.TabIndex = 31;
            this.button6.Text = "Рассчитать массу";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox18
            // 
            this.textBox18.ForeColor = System.Drawing.Color.Gray;
            this.textBox18.Location = new System.Drawing.Point(644, 56);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(299, 20);
            this.textBox18.TabIndex = 32;
            this.textBox18.Text = "Средняя температура кипения (°C)";
            this.textBox18.Enter += new System.EventHandler(this.textBox18_Enter);
            this.textBox18.Leave += new System.EventHandler(this.textBox18_Leave);
            // 
            // textBox19
            // 
            this.textBox19.ForeColor = System.Drawing.Color.Gray;
            this.textBox19.Location = new System.Drawing.Point(644, 56);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(299, 20);
            this.textBox19.TabIndex = 33;
            this.textBox19.Text = "Коэффициент a";
            this.textBox19.Enter += new System.EventHandler(this.textBox19_Enter);
            this.textBox19.Leave += new System.EventHandler(this.textBox19_Leave);
            // 
            // textBox20
            // 
            this.textBox20.ForeColor = System.Drawing.Color.Gray;
            this.textBox20.Location = new System.Drawing.Point(644, 82);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(299, 20);
            this.textBox20.TabIndex = 34;
            this.textBox20.Text = "Коэффициент b";
            this.textBox20.Enter += new System.EventHandler(this.textBox20_Enter);
            this.textBox20.Leave += new System.EventHandler(this.textBox20_Leave);
            // 
            // textBox21
            // 
            this.textBox21.ForeColor = System.Drawing.Color.Gray;
            this.textBox21.Location = new System.Drawing.Point(644, 108);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(299, 20);
            this.textBox21.TabIndex = 35;
            this.textBox21.Text = "Коэффициент c";
            this.textBox21.Enter += new System.EventHandler(this.textBox21_Enter);
            this.textBox21.Leave += new System.EventHandler(this.textBox21_Leave);
            // 
            // textBox22
            // 
            this.textBox22.ForeColor = System.Drawing.Color.Gray;
            this.textBox22.Location = new System.Drawing.Point(644, 134);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(299, 20);
            this.textBox22.TabIndex = 36;
            this.textBox22.Text = "Средняя температура кипения (°C)";
            this.textBox22.Enter += new System.EventHandler(this.textBox22_Enter);
            this.textBox22.Leave += new System.EventHandler(this.textBox22_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbToolStripMenuItem,
            this.inputToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dbToolStripMenuItem
            // 
            this.dbToolStripMenuItem.Name = "dbToolStripMenuItem";
            this.dbToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.dbToolStripMenuItem.Text = "База данных";
            this.dbToolStripMenuItem.Click += new System.EventHandler(this.dbToolStripMenuItem_Click);
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.inputToolStripMenuItem.Text = "Вывод в файл";
            this.inputToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 226);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 65);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(328, 226);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(299, 65);
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(644, 226);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(299, 65);
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 558);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Calc";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

