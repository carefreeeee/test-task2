using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testZad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SaveData saveData = new SaveData();

        private void button1_Click(object sender, EventArgs e) // расчет искомой величины
        {
            Error();

            try
            {
                double[] typeGround = new double[4]; // массив значений в зависимости от типа грунта (первые 4)
                for (int i = 0; i < typeGround.Length; i++)
                    typeGround[i] = -0.1 - 0.05 * i;

                double[] salinity = new double[3] { 0, 1, 0.85 }; //массив значений в зависимости от засоленности
                double? humidity;

                if (saveData.iciness > 0.4) // значение влажности (выбор) в зависимости от льдистости
                    humidity = saveData.humidityFrozen;
                else humidity = saveData.totalHumidity;
                
                var сoncentration = saveData.degree / (saveData.degree + 100 * humidity); // Концентрация порового раствора
                if (saveData.type != -1 && saveData.salt != -1) // проверка заполненности параметров типа грунта и засоленности
                textBox5.Text = (typeGround[saveData.type] - salinity[saveData.salt] * (53 * сoncentration + 40 * сoncentration * сoncentration)).ToString();
               
            }
            catch
            {
                Form3 newForm = new Form3();
                newForm.Show();
                if (saveData.type == 4)
                    textBox5.Text = saveData.totalHumidity == 7.30 ? "-0,14" : saveData.totalHumidity == 5.90 ? "-0,16" : saveData.totalHumidity == 3.27 ? "-0,25" : saveData.totalHumidity == 1.64 ? "-0,35" : "отсутствует расчетное табличное значение";
                else
                    textBox5.Text = saveData.totalHumidity == 3.90 ? "-0,13" : saveData.totalHumidity == 0.90 ? "-0,23" : "отсутствует расчетное табличное значение";
            }
        }

        private void button2_Click(object sender, EventArgs e) // кнопка сохранения раннее введеных данных
        {
            MakeCheck();

            var json = JsonConvert.SerializeObject(saveData);

            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    byte[] buffer = Encoding.Default.GetBytes(json);
                    myStream.Write(buffer, 0, buffer.Length);
                    myStream.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // загрузка данных из файла
        {
            Stream myStream;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    var filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var fileContent = reader.ReadToEnd();
                        saveData = JsonConvert.DeserializeObject<SaveData>(fileContent);
                    }
                }
            }

            ReadData();
        }

        private void Form1_Load(object sender, EventArgs e) // загрузка на форму времени и даты
        {
            timer1.Interval = 10;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) // вывод времени и даты
        {
            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();
        }

        private void MakeCheck() // проверка корректности заполнения полей, если они пусты то заполнение нулями
        {
            try
            {
                saveData = new SaveData
                {
                    type = comboBox1.SelectedIndex,
                    salt = comboBox2.SelectedIndex,
                    degree = textBox1.Text == "" ? 0 : double.Parse(textBox1.Text),
                    iciness = textBox2.Text == "" ? 0 : double.Parse(textBox2.Text),
                    totalHumidity = textBox3.Text == "" ? 0 : double.Parse(textBox3.Text),
                    humidityFrozen = textBox4.Text == "" ? 0 : double.Parse(textBox4.Text)
                };
            }

            catch
            {
                Form2 newForm = new Form2();
                newForm.Show();
            }
        }
        private void ReadData() // загрузка элементов с файла
        {
            comboBox1.SelectedIndex = saveData.type;
            comboBox2.SelectedIndex = saveData.salt;
            textBox1.Text = Convert.ToString(saveData.degree);
            textBox2.Text = Convert.ToString(saveData.iciness);
            textBox3.Text = Convert.ToString(saveData.totalHumidity);
            textBox4.Text = Convert.ToString(saveData.humidityFrozen);
        }

        private void Error() // ошибка заполнения данных при пустых полях
        {
            Form2 newForm = new Form2();
            if (comboBox1.Text == "" || comboBox2.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                newForm.Show();
           
            MakeCheck();
        }
    }
}
