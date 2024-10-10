using StavteClassy;
using System.Windows.Forms;
namespace HopeForPravilnost
{
    public partial class Form1 : Form
    {
        // Хранение стран
        private List<Государство> государства = new List<Государство>();

        public Form1()
        {
            InitializeComponent();
            // Инициализация нескольких объектов государства для демонстрации
            государства.Add(new Государство("Франция", 111) { ID = 0});
            государства.Add(new Государство("Испания") { ID = 1, ГодСоздания = 1211 });
            государства.Add(new Государство("Лапландия") { ID = 2 });
            государства.Add(new Государство("Россия") { ID = 3, ГодСоздания = 2222 });
            this.BackColor = Субъект.BackColor;

        }
        private void button1_Click(object sender, EventArgs e) // Поиск государств по ID
        {
            richTextBox1.Clear();

            // Получаем ID из numericUpDown
            int id = (int)numericUpDown1.Value;

            // Поиск государства по ID
            Государство найденноеГосударство = государства.Find(g => g.ID == id);

            if (найденноеГосударство != null)
            {
                //richTextBox1.Text = найденноеГосударство.ToString();
                richTextBox1.Text = $"Название: {найденноеГосударство.Название}, ID: {id}";
                if (найденноеГосударство.ГодСоздания != 0 ) { 
                    richTextBox1.Text += $", Год создания: {найденноеГосударство.ГодСоздания}"; 
                }
                richTextBox1.Text += найденноеГосударство.ПоказатьИнформациюОПравителе();


            }
            else
            {
                richTextBox1.Text = $"Государство с ID {id} не найдено.";
            }

            if (checkBox1.Checked == true && найденноеГосударство != null)
            {
                найденноеГосударство.УстановитьПравителя(textBox3.Text, textBox4.Text, textBox5.Text, (int)numericUpDown3.Value) ;
            }

        }

        private void button2_Click(object sender, EventArgs e) // Создание государств
        {
            // Получаем значение ID и название страны
            int id = (int)numericUpDown2.Value;
            string название = textBox2.Text; // из поля для ввода названия

            // Проверка, существует ли уже государство с таким ID
            if (государства.Exists(g => g.ID == id))
            {
                MessageBox.Show($"Государство с ID {id} уже существует. Пожалуйста, выберите другой ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создание нового государства в списке
            Государство новоеГосударство = new Государство(название) { ID = id };
            государства.Add(новоеГосударство);

            // Выводим сообщение об успешном создании
            MessageBox.Show($"Государство '{название}' с ID {id} успешно создано!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Очистка полей для ввода
            textBox2.Clear();
            numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
        }

    }
}
