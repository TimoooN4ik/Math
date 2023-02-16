using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Work
{
    public partial class Form1 : Form
    {
        AppContext db;
        List<string> data = new List<string>();     //глобальный список для сохранения полученых вычислений

        string[,] str = new string[6, 3];        //8 предметов (айтемАрей максимум), 6 дней недели (строк максимум)
        public Form1()
        {
            InitializeComponent();
            
            button1.BringToFront();

            db = new AppContext();

            comboBox2.Items.Add("Уравнение Мановяна");
            comboBox2.Items.Add("Уравнение Менделеева");
            comboBox2.Items.Add("Относительность плотности");
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Add("Динамическая взякость");
            comboBox3.Items.Add("Вальтера-ASTM (T1, T2, v1, v2)");
            comboBox3.Items.Add("Вальтера-ASTM (T, a, b)");
            comboBox3.SelectedIndex = 0;

            comboBox4.Items.Add("Молекулярная масса по плотности");
            comboBox4.Items.Add("Логарифмическая зависимость");
            comboBox4.Items.Add("Формула Войнова");
            comboBox4.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #region additional

        void updateList(int i)
        {
            string d = str[i, 0] + ". " +  str[i, 2] + ". " + str[i, 1];
            data.Add(d);
            ListViewItem item = new ListViewItem(new[] { str[i, 0], str[i, 2], str[i, 1]});
            listView1.Items.Add(item);
        }

        

        void ShowDataForMethod()
        {
            if(comboBox2.Text == "Уравнение Мановяна")
            {
                pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\manovian.jpg"); ;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
            }
            if(comboBox2.Text == "Уравнение Менделеева")
            {
                pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\mend.jpg"); ;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
            }
            if(comboBox2.Text == "Относительность плотности")
            {
                pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "\\rev.jpg"); ;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
            }
        }

        #endregion

        #region calculation
        double density(int t, double p20)                   //уравнение мановяна
        {
            return (1000 * p20 - (0.58 / p20) * (t - 20) - (t - 1200 * (p20 - 0.68)) * (t - 20) / 1000);
        }

        double mu(double pT, double v)                      //мю
        {
            return (pT * v);
        }

        double muASTM(double T, double T1, double T2, double v1, double v2)     //формула Вальтера – ASTM
        {
            double b = (Math.Log10(Math.Log10(v1 + 0.8)) - Math.Log10(Math.Log10(v2 + 0.8))) / Math.Log10(T1 / T2);
            double a = Math.Log10(Math.Log10(v1 + 0.8)) - b * Math.Log10(T1);

            double v = Math.Exp(2.3026 * Math.Exp(2.3026 * (a + b * Math.Log10(T)))) - 0.8;

            return v;
        }

        double muASTM(double T, double a, double b)                      //формула Вальтера – ASTM
        {
            double v = Math.Exp(2.3026 * Math.Exp(2.3026 * (a + b * Math.Log10(T)))) - 0.8;
            return v;
        }

        double Mend(int t, double d, double a)              //уравнение меделеева
        {
            return d - a * (t - 20);
        }

        double relatively(double m, double t, double p)     //функция относительной плотности
        {
            return 273.15 * m * p / (22.4 * t);
        }

        double M(double p)                                  //формула бриджмана
        {
            return 39 * p / (1 - p);
        }

        double MLog(double t)
        {
            double pw = (2.51 * Math.Log10(t + 393) - 4.7523);
            return Math.Pow(10, pw);
        }

        double usualM(double a, double b, double c, double t)
        {
            return a + b * t + c * t * t;
        }

        void result(double p)
        {
            
        }
        #endregion

        #region косметические (посянительные) модификации для полей ввода данных
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Температура (°C)")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Температура (°C)";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Относительная плотность (кг/м³ при +20 °C)")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Относительная плотность (кг/м³ при +20 °C)";
                textBox2.ForeColor = Color.Gray;
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Кинематическая вязкость (м2/c)")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Кинематическая вязкость (м2/c)";
                textBox3.ForeColor = Color.Gray;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Альфа")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Альфа";
                textBox4.ForeColor = Color.Gray;
            }
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Молекулярная масса (Mr)")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Молекулярная масса (Mr)";
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {

            if (textBox6.Text == "Температура (°C)")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Температура (°C)";
                textBox6.ForeColor = Color.Gray;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {

            if (textBox7.Text == "Давление (МПа)")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Давление (МПа)";
                textBox7.ForeColor = Color.Gray;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {

            if (textBox8.Text == "Плотность (кг/м³)")
            {
                textBox8.Text = "";
                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Плотность (кг/м³)";
                textBox8.ForeColor = Color.Gray;
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {

            if (textBox9.Text == "Абсолютная температура (°C)")
            {
                textBox9.Text = "";
                textBox9.ForeColor = Color.Black;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = "Абсолютная температура (°C)";
                textBox9.ForeColor = Color.Gray;
            }
        }
        private void textBox10_Enter(object sender, EventArgs e)
        {

            if (textBox10.Text == "Экспериментальное значение T1")
            {
                textBox10.Text = "";
                textBox10.ForeColor = Color.Black;
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "Экспериментальное значение T1";
                textBox10.ForeColor = Color.Gray;
            }
        }
        private void textBox11_Enter(object sender, EventArgs e)
        {

            if (textBox11.Text == "Значение v1 при температуре T1")
            {
                textBox11.Text = "";
                textBox11.ForeColor = Color.Black;
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                textBox11.Text = "Значение v1 при температуре T1";
                textBox11.ForeColor = Color.Gray;
            }
        }
        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Text == "Экспериментальное значение T2")
            {
                textBox12.Text = "";
                textBox12.ForeColor = Color.Black;
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                textBox12.Text = "Экспериментальное значение T2";
                textBox12.ForeColor = Color.Gray;
            }
        }
        private void textBox13_Enter(object sender, EventArgs e)
        {

            if (textBox13.Text == "Значение v2 при температуре T2")
            {
                textBox13.Text = "";
                textBox13.ForeColor = Color.Black;
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                textBox13.Text = "Значение v2 при температуре T2";
                textBox13.ForeColor = Color.Gray;
            }
        }
        private void textBox14_Enter(object sender, EventArgs e)
        {

            if (textBox14.Text == "Температура (°C)")
            {
                textBox14.Text = "";
                textBox14.ForeColor = Color.Black;
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {
                textBox14.Text = "Температура (°C)";
                textBox14.ForeColor = Color.Gray;
            }
        }
        private void textBox15_Enter(object sender, EventArgs e)
        {

            if (textBox15.Text == "Коэффициент a")
            {
                textBox15.Text = "";
                textBox15.ForeColor = Color.Black;
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                textBox15.Text = "Коэффициент a";
                textBox15.ForeColor = Color.Gray;
            }
        }
        private void textBox16_Enter(object sender, EventArgs e)
        {

            if (textBox16.Text == "Коэффициент b")
            {
                textBox16.Text = "";
                textBox16.ForeColor = Color.Black;
            }
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                textBox16.Text = "Коэффициент b";
                textBox16.ForeColor = Color.Gray;
            }
        }

        private void textBox17_Enter(object sender, EventArgs e)
        {

            if (textBox17.Text == "Относительная плотность (кг/м³ при +20 °C)")
            {
                textBox17.Text = "";
                textBox17.ForeColor = Color.Black;
            }
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {
                textBox17.Text = "Относительная плотность (кг/м³ при +20 °C)";
                textBox17.ForeColor = Color.Gray;
            }
        }

        private void textBox18_Enter(object sender, EventArgs e)
        {

            if (textBox18.Text == "Средняя температура кипения (°C)")
            {
                textBox18.Text = "";
                textBox18.ForeColor = Color.Black;
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
            {
                textBox18.Text = "Средняя температура кипения (°C)";
                textBox18.ForeColor = Color.Gray;
            }
        }

        private void textBox19_Enter(object sender, EventArgs e)
        {

            if (textBox19.Text == "Коэффициент a")
            {
                textBox19.Text = "";
                textBox19.ForeColor = Color.Black;
            }
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            if (textBox19.Text == "")
            {
                textBox19.Text = "Коэффициент a";
                textBox19.ForeColor = Color.Gray;
            }
        }

        private void textBox20_Enter(object sender, EventArgs e)
        {

            if (textBox20.Text == "Коэффициент b")
            {
                textBox20.Text = "";
                textBox20.ForeColor = Color.Black;
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            if (textBox20.Text == "")
            {
                textBox20.Text = "Коэффициент b";
                textBox20.ForeColor = Color.Gray;
            }
        }

        private void textBox21_Enter(object sender, EventArgs e)
        {

            if (textBox21.Text == "Коэффициент c")
            {
                textBox21.Text = "";
                textBox21.ForeColor = Color.Black;
            }
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            if (textBox21.Text == "")
            {
                textBox21.Text = "Коэффициент c";
                textBox21.ForeColor = Color.Gray;
            }
        }

        private void textBox22_Enter(object sender, EventArgs e)
        {

            if (textBox22.Text == "Средняя температура кипения (°C)")
            {
                textBox22.Text = "";
                textBox22.ForeColor = Color.Black;
            }
        }

        private void textBox22_Leave(object sender, EventArgs e)
        {
            if (textBox22.Text == "")
            {
                textBox22.Text = "Средняя температура кипения (°C)";
                textBox22.ForeColor = Color.Gray;
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Температура (°C)" && textBox2.Text != "Относительная плотность (кг/м³ при +20 °C)")  //проверяем что данные введены в поля
            {
                string tB2 = textBox2.Text, tB3 = textBox3.Text, tB4 = textBox4.Text;   //считываем значения
                //дробные числа приводим к нужному виду
                tB2.Replace('.', ',');
                tB3.Replace('.', ',');
                tB4.Replace('.', ',');

                if (comboBox2.Text == "Уравнение Мановяна")
                {
                    try
                    {
                        //записываем данные в переменные
                        int t = Convert.ToInt32(textBox1.Text);
                        double d = Convert.ToDouble(tB2);

                        if(d < 0.69 || d > 1)
                            throw new Exception("Некорректное значение плотности");
                        
                        if (t <= 0)
                            throw new Exception("Отрицательное значение температуры");

                        //вызываем функцию по расчету
                        double pT = density(t, d);
                        str[0, 0] = "Плотность: " + pT.ToString();

                        if (pT < 850)
                        {
                            str[0, 1] = "Классификация: Легкая нефть";
                        }
                        else if (pT > 850)
                        {
                            str[0, 1] = "Классификация: Тяжелая нефть";
                        }
                        else if (pT < 0)
                            str[0, 1] = "Классификация: Ошибка в расчетах";

                        str[0, 2] = "Метод: Уравнение Мановяна";

                        updateList(0);

                        textBox1.Text = "Температура (°C)";
                        textBox1.ForeColor = Color.Gray;
                        textBox2.Text = "Относительная плотность (кг/м³ при +20 °C)";
                        textBox2.ForeColor = Color.Gray;
                        /*textBox3.Text = "Кинематическая вязкость";
                        textBox3.ForeColor = Color.Gray;*/
                    }
                    catch(Exception ex) //если возникает ошибка, выводим предупреждение
                    {
                        if (ex.Message == "Входная строка имела неверный формат.")
                            MessageBox.Show("Некорректные данные");
                        else
                            MessageBox.Show(ex.Message);
                    }
                }
                if (comboBox2.Text == "Уравнение Менделеева")   //далее аналогично
                {
                    if (textBox4.Text != "Альфа")
                    {
                        try
                        {
                            int t = Convert.ToInt32(textBox1.Text);
                            double d = Convert.ToDouble(tB2);
                            double a = Convert.ToDouble(tB4);

                            if (d < 0.69 || d > 1)
                                throw new Exception("Некорректное значение плотности");

                            if (t <= 0)
                                throw new Exception("Отрицательное значение температуры");

                            double pT = Mend(t, d, a);
                            str[0, 0] = "Плотность: " + pT.ToString();

                            if (pT < 850)
                            {
                                str[0, 1] = "Классификация: Легкая нефть";
                            }
                            else if (pT > 850)
                            {
                                str[0, 1] = "Классификация: Тяжелая нефть";
                            }
                            else if (pT < 0)
                                str[0, 1] = "Классификация: Ошибка в расчетах";

                            str[0, 2] = "Метод: Уравнение Менделеева";

                            updateList(0);

                            textBox1.Text = "Температура (°C)";
                            textBox1.ForeColor = Color.Gray;
                            textBox2.Text = "Относительная плотность (кг/м³ при +20 °C)";
                            textBox2.ForeColor = Color.Gray;
                            textBox4.Text = "Альфа";
                            textBox4.ForeColor = Color.Gray;
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message == "Входная строка имела неверный формат")
                                MessageBox.Show("Некорректные данные");
                            else
                                MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("Input data");
                }
            }
            else if (textBox5.Text != "Молекулярная масса (Mr)" && textBox6.Text != "Температура (°C)" && textBox7.Text != "Давление (МПа)")
            {
                string tB2 = textBox5.Text, tB3 = textBox6.Text, tB4 = textBox7.Text;
                tB2.Replace('.', ',');
                tB3.Replace('.', ',');
                tB4.Replace('.', ',');
                if (comboBox2.Text == "Относительность плотности")
                {
                    try
                    {
                        double M = Convert.ToDouble(tB2);
                        double T = Convert.ToDouble(tB3);
                        double p = Convert.ToDouble(tB4);
                        
                        if (T <= 0 || M <= 0 || p <= 0)
                            throw new Exception("Введено некорректное значение");

                        double pT = relatively(M, T, p);
                        str[0, 0] = "Плотность: " + pT.ToString();

                        if (pT < 850)
                        {
                            str[0, 1] = "Классификация: Легкая нефть";
                        }
                        else if (pT > 850)
                        {
                            str[0, 1] = "Классификация: Тяжелая нефть";
                        }
                        else if (pT < 0)
                            str[0, 1] = "Классификация: Ошибка в расчетах";
                        
                        str[0, 2] = "Метод: Относительная плотность";

                        updateList(0);

                        textBox5.Text = "Молекулярная масса (Mr)";
                        textBox5.ForeColor = Color.Gray;
                        textBox6.Text = "Температура (°C)";
                        textBox6.ForeColor = Color.Gray;
                        textBox7.Text = "Давление (МПа)";
                        textBox7.ForeColor = Color.Gray;
                        /*textBox8.Text = "v";
                        textBox8.ForeColor = Color.Gray;*/
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                        else
                            MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Input data");  //если поля данных пустые, выводим предупреждение
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*DB dB = new DB();
            dB.Show();*/

            /*dataHandler dh = new dataHandler();
            dh.read();*/

            /*List<calc> calcs = db.calcs.ToList();
            string s = "";
            foreach (calc cl in calcs)
                s += cl.A + " | ";
            MessageBox.Show(s);*/
            ShowDB sdb = new ShowDB();
            sdb.Show();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowDataForMethod();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + "\\result.txt", false))
            {
                for(int i = 0; i < data.Count; i++)
                    writer.WriteLineAsync(data[i]);

                data.Clear();
                MessageBox.Show("Данные записаны в файл result.txt");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Динамическая взякость")
            {
                string tB2 = textBox3.Text, tB3 = textBox8.Text;
                
                if (textBox3.Text != "Кинематическая вязкость (м2/c)" && textBox8.Text != "Плотность (кг/м³)")
                {
                    try
                    {
                        double v = Convert.ToDouble(tB2);
                        double p = Convert.ToDouble(tB3);

                        if (v <= 0 || p <= 0)
                            throw new Exception("Введено некорректное значение");

                        double m = mu(p, v);
                        str[1, 0] = "Вязкость: " + m.ToString();

                        if (m < 1000)
                        {
                            str[1, 1] = "Классификация: Незначительная вязкость";
                        }
                        else if (m > 1000 && m < 5000)
                        {
                            str[1, 1] = "Классификация: Маловязкая";
                        }
                        else if (m > 5000 && m < 25000)
                        {
                            str[1, 1] = "Классификация: Повышенная вязкость";
                        }
                        else if (m > 25000 && m < 30000)
                        {
                            str[1, 1] = "Классификация: Высоковязкая";
                        }
                        else if (m > 30000)
                        {
                            str[1, 1] = "Классификация: Сверхвязкая";
                        }
                        else
                            str[1, 1] = "Классификация: Ошибка в расчетах";

                        str[1, 2] = "Метод: " + comboBox3.Text;

                        updateList(1);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                        else
                            MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Данные не введены");
            }
            if (comboBox3.Text == "Вальтера-ASTM (T1, T2, v1, v2)")
            {

                string tB2 = textBox9.Text, tB3 = textBox10.Text, tB4 = textBox11.Text, tB5 = textBox12.Text, tB6 = textBox13.Text;
                if (textBox9.Text != "Абсолютная температура (°C)" && textBox10.Text != "Экспериментальное значение T1" 
                    && textBox11.Text != "Значение v1 при температуре T1" && textBox12.Text != "Экспериментальное значение T2" && textBox13.Text != "Значение v2 при температуре T2")
                {
                    tB2.Replace('.', ',');
                    tB3.Replace('.', ',');
                    tB4.Replace('.', ',');
                    tB5.Replace('.', ',');
                    tB6.Replace('.', ',');
                    try
                    {
                        double T = Convert.ToDouble(tB2);
                        double T1 = Convert.ToDouble(tB3);
                        double v1 = Convert.ToDouble(tB4);
                        double T2 = Convert.ToDouble(tB5);
                        double v2 = Convert.ToDouble(tB6);

                        if (T <= 0 || T1 < 0 || T2 < 0 || v1 < 0 || v2 < 0)
                            throw new Exception("Введено некорректное значение");

                        double m = muASTM(T, T1, T2, v1, v2);
                        str[1, 0] = "Вязкость: " + m.ToString();

                        if (m < 1000)
                        {
                            str[1, 1] = "Классификация: Незначительная вязкость";
                        }
                        else if (m > 1000 && m < 5000)
                        {
                            str[1, 1] = "Классификация: Маловязкая";
                        }
                        else if (m > 5000 && m < 25000)
                        {
                            str[1, 1] = "Классификация: Повышенная вязкость";
                        }
                        else if (m > 25000 && m < 30000)
                        {
                            str[1, 1] = "Классификация: Высоковязкая";
                        }
                        else if (m > 30000)
                        {
                            str[1, 1] = "Классификация: Сверхвязкая";
                        }
                        else
                            str[1, 1] = "Классификация: Ошибка в расчетах";


                        str[1, 2] = "Метод: " + comboBox3.Text;
                        updateList(1);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                        else
                            MessageBox.Show(ex.Message);
                    }

                }
                else
                    MessageBox.Show("Данные не введены");
            }
            if (comboBox3.Text == "Вальтера-ASTM (T, a, b)")
            {
                string tB2 = textBox14.Text, tB3 = textBox15.Text, tB4 = textBox16.Text;

                if (textBox14.Text != "Температура (°C)" && textBox15.Text != "Коэффициент a" && textBox16.Text != "Коэффициент b")
                {
                    tB2.Replace('.', ',');
                    tB3.Replace('.', ',');
                    tB4.Replace('.', ',');
                    try
                    {
                        double T = Convert.ToDouble(tB2);
                        double a = Convert.ToDouble(tB3);
                        double b = Convert.ToDouble(tB4);

                        if (T <= 0 /*|| a < 0 || b < 0*/)
                            throw new Exception("Введено некорректное значение");

                        double m = muASTM(T, a, b);
                        str[1, 0] = "Вязкость: " + m.ToString();

                        if (m < 1000)
                        {
                            str[1, 1] = "Классификация: Незначительная вязкость";
                        }
                        else if (m > 1000 && m < 5000)
                        {
                            str[1, 1] = "Классификация: Маловязкая";
                        }
                        else if (m > 5000 && m < 25000)
                        {
                            str[1, 1] = "Классификация: Повышенная вязкость";
                        }
                        else if (m > 25000 && m < 30000)
                        {
                            str[1, 1] = "Классификация: Высоковязкая";
                        }
                        else if (m > 30000)
                        {
                            str[1, 1] = "Классификация: Сверхвязкая";
                        }
                        else
                            str[1, 1] = "Классификация: Ошибка в расчетах";

                        str[1, 2] = "Метод: " + comboBox3.Text;
                        updateList(1);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                        else
                            MessageBox.Show(ex.Message);
                    }

                }
                else
                    MessageBox.Show("Данные не введены");
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Динамическая взякость")
            {
                pictureBox2.Image = Image.FromFile(Environment.CurrentDirectory + "\\dinR.png");
                textBox8.Visible = true;
                textBox3.Visible = true;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
            }
            if (comboBox3.Text == "Вальтера-ASTM (T1, T2, v1, v2)")
            {
                pictureBox2.Image = Image.FromFile(Environment.CurrentDirectory + "\\valterT.png");
                textBox8.Visible = false;
                textBox3.Visible = false;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
            }
            if (comboBox3.Text == "Вальтера-ASTM (T, a, b)")
            {
                pictureBox2.Image = Image.FromFile(Environment.CurrentDirectory + "\\valter.jpg");
                textBox8.Visible = false;
                textBox3.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = true;
                textBox15.Visible = true;
                textBox16.Visible = true;
            }
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBox4.Text == "Молекулярная масса по плотности")
            {
                pictureBox3.Image = Image.FromFile(Environment.CurrentDirectory + "\\bridjman.png");
                textBox17.Visible = true;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                textBox22.Visible = false;
            }
            if(comboBox4.Text == "Логарифмическая зависимость")
            {
                pictureBox3.Image = Image.FromFile(Environment.CurrentDirectory + "\\log.png");
                textBox17.Visible = false;
                textBox18.Visible = true;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                textBox22.Visible = false;
            }
            if(comboBox4.Text == "Формула Войнова")
            {
                pictureBox3.Image = Image.FromFile(Environment.CurrentDirectory + "\\voinov.png");
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = true;
                textBox20.Visible = true;
                textBox21.Visible = true;
                textBox22.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Молекулярная масса по плотности")
            {
                if(textBox17.Text != "Относительная плотность (кг/м³ при +20 °C)")
                {
                    string tb = textBox17.Text;

                    tb.Replace('.', ',');
                    try
                    {
                        double p = Convert.ToDouble(tb);

                        if (p < 0.69 || p >= 1)
                            throw new Exception("Некорректное значение плотности");

                        double m = M(p);

                        str[2, 0] = "Молекулярная масса: " + m.ToString();

                        str[2, 2] = "Метод: " + comboBox4.Text;
                        updateList(2);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                        else
                            MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Данные не введены");
            }
            if (comboBox4.Text == "Логарифмическая зависимость")
            {
                if (textBox18.Text != "Средняя температура кипения (°C)")
                {
                    string tb = textBox18.Text;

                    tb.Replace('.', ',');
                    try
                    {
                        double t = Convert.ToDouble(tb);

                        if (t <= 0)
                            throw new Exception("Введено некорректное значение");

                        double m = MLog(t);

                        str[2, 0] = "Молекулярная масса: " + m.ToString();

                        str[2, 2] = "Метод: " + comboBox4.Text;
                        updateList(2);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                        else
                            MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Данные не введены");
            }
            if (comboBox4.Text == "Формула Войнова")
            {
                if (textBox19.Text != "Коэффициент a" && textBox20.Text != "Коэффициент b" && textBox20.Text != "Коэффициент c" && textBox20.Text != "Средняя температура кипения (°C)")
                {
                    string tB2 = textBox19.Text, tB3 = textBox20.Text, tB4 = textBox21.Text, tB5 = textBox22.Text;
                    tB2.Replace('.', ',');
                    tB3.Replace('.', ',');
                    tB4.Replace('.', ',');
                    tB5.Replace('.', ',');
                    try
                    {
                        double a = Convert.ToDouble(tB2);
                        double b = Convert.ToDouble(tB3);
                        double c = Convert.ToDouble(tB4);
                        double t = Convert.ToDouble(tB5);

                        if (a < 56 || a > 69 || b < 0.18 || b > 0.24 || c  < 0.0008 || c > 0.0014)
                            throw new Exception("Коэффициент не удовлетворяет табличным");

                        if (t <= 0)
                            throw new Exception("Введено некорректное значение");

                        double m = usualM(a, b, c, t);
                        str[2, 0] = "Молекулярная масса: " + m.ToString();

                        str[2, 2] = "Метод: " + comboBox4.Text;
                        updateList(2);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                        else
                            MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Данные не введены");
            }
            /*if (comboBox4.Text == "Формула Войнова для парафиновых углеводородов")
            {
                if (textBox17.Text != "")
                {
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                    }
                }
                else
                    MessageBox.Show("Данные не введены");
            }
            if (comboBox4.Text == "Формула Войнова для аломатических углеводородов")
            {
                if (textBox17.Text != "")
                {
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Входная строка имела неверный формат")
                            MessageBox.Show("Некорректные данные");
                    }
                }
                else
                    MessageBox.Show("Данные не введены");
            }*/
        }

        private void dbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDB sdb = new ShowDB();
            sdb.Show();
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + "\\result.txt", false))
            {
                for (int i = 0; i < data.Count; i++)
                    writer.WriteLineAsync(data[i]);

                data.Clear();
                MessageBox.Show("Данные записаны в файл result.txt");
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string path = Environment.CurrentDirectory;

            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\info.docx");
        }
    }
}
