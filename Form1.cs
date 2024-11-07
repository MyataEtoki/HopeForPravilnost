using Microsoft.VisualBasic;
using StavteClassy;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
namespace HopeForPravilnost
{
    public partial class Form1 : Form
    {
        private List<Государство> государства = new List<Государство>();

        public Form1()
        {
            InitializeComponent();
            // Инициализация нескольких объектов государства для демонстрации
            государства.Add(new Государство("Франция", 111) { ID = 0 });
            государства.Add(new Государство("Испания") { ID = 1, ГодСоздания = 1211 });
            государства.Add(new Государство("Лапландия") { ID = 2 });
            государства.Add(new Государство("Россия") { ID = 3, ГодСоздания = 2222 });
            SetupListBox();

            this.BackColor = Субъект.BackColor;
            numericUpDown1.Maximum = 2500;
        }

        private void SetupListBox()
        {
            // Привязка данных
            listBox1.DataSource = null;
            listBox1.DataSource = государства;
            listBox1.DisplayMember = "Название"; // Отображаем только название
        }
        private bool ЗагрузитьДанные(string filePath, out int количествоЗаписей)
        {
            количествоЗаписей = 0;
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    количествоЗаписей++;
                    var parts = line.Split(',');

                    var государство = new Государство(parts[1].Trim());
                    государство.ID = int.Parse(parts[0].Trim());
                    if (parts.Length > 2)
                        государство.ГодСоздания = int.Parse(parts[2].Trim());

                    if (parts.Length > 3) // если есть данные о правителе
                    {
                        var правитель = new Правитель
                        {
                            Имя = parts[3].Trim(),
                            Фамилия = parts[4].Trim(),
                            Отчество = parts[5].Trim(),
                            Возраст = int.Parse(parts[6].Trim()),
                            НачалоПравления = DateTime.Parse(parts[7].Trim()),
                            Существует = true
                        };
                        // для разнообразия глупость - передаём классу сразу структуру, а не через метод аргументы.
                        государство.ТекущийПравитель = правитель;
                        государство.КтоТоПравит = true;
                    }

                    государства.Add(государство);

                }

                return true;
            }
            else
            {
                return false;
            }
        }
        private void ИзменитьНазвание(ref Государство государство, string новоеНазвание)
        {
            государство.Название = новоеНазвание;
        }
        private void button1_Click(object sender, EventArgs e) // кнопка - Поиск государства по ID
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
                if (найденноеГосударство.ГодСоздания != 0)
                {
                    richTextBox1.Text += $", Год создания: {найденноеГосударство.ГодСоздания}";
                    richTextBox1.Text += $", Возраст: {найденноеГосударство.ВычислитьВозраст()}";
                }
                richTextBox1.Text += найденноеГосударство.ПоказатьИнформациюОПравителе();

                if (найденноеГосударство.ПутьККартинке != null)
                {
                    pictureBox1.ImageLocation = найденноеГосударство.ПутьККартинке;
                }
                else { pictureBox1.ImageLocation = null; }

            }
            else
            {
                richTextBox1.Text = $"Государство с ID {id} не найдено.";
            }

        }

        private void button2_Click(object sender, EventArgs e) // кнопка - Создание государств
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

            int _годСоздания = (int)numericUpDown4.Value;
            // Создание нового государства в списке
            Государство новоеГосударство = new Государство(название) { ID = id, ГодСоздания = _годСоздания };
            государства.Add(новоеГосударство);

            // Выводим сообщение об успешном создании
            MessageBox.Show($"Государство '{название}' с ID {id} успешно создано!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetupListBox();

            // Очистка полей для ввода
            textBox2.Clear();
            numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
        }

        private void button3_Click(object sender, EventArgs e) // кнопка - создать правителя
        {
            int id = (int)numericUpDown1.Value;
            Государство найденноеГосударство = государства.Find(g => g.ID == id);
            if (найденноеГосударство != null)
            {
                найденноеГосударство.УстановитьПравителя(textBox3.Text, textBox4.Text, textBox5.Text, (int)numericUpDown3.Value, DateTime.Now);
            }
        }

        //Загрузка БД
        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл для загрузки";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Очищаем коллекцию перед загрузкой
                    государства.Clear();

                    // Загружаем данные из файла
                    if (ЗагрузитьДанные(filePath, out int колЗаписей))
                    {
                        MessageBox.Show($"Успешно загружено {колЗаписей} записей.");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось загрузить данные из файла.");
                    }
                    SetupListBox();
                }
            }
        }

        //Сохранение БД
        private void button5_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить файл как";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Записываем данные в файл
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var государство in государства)
                        {
                            if (государство.ТекущийПравитель.Существует)
                            {
                                writer.WriteLine($"{государство.ID},{государство.Название},{государство.ГодСоздания}," +
                                    $"{государство.ТекущийПравитель.Имя},{государство.ТекущийПравитель.Фамилия}," +
                                    $"{государство.ТекущийПравитель.Отчество},{государство.ТекущийПравитель.Возраст}," +
                                    $"{государство.ТекущийПравитель.НачалоПравления}");
                            }
                            else
                            {
                                writer.WriteLine($"{государство.ID},{государство.Название},{государство.ГодСоздания}");
                            }
                        }
                    }

                    MessageBox.Show("Данные сохранены в файл.");
                }
            }
        }
        // Государство по-строчно
        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        //Добавление картинки
        private void button7_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            Государство найденноеГосударство = государства.Find(g => g.ID == id);
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK && найденноеГосударство != null)
                {
                    string imagePath = openFileDialog.FileName;
                    pictureBox1.ImageLocation = imagePath;
                    найденноеГосударство.ПутьККартинке = imagePath;
                }
            }
        }

        //Выбираешь страну в listBox1, она сразу ищется. ДОПОЛНИТЕЛЬНО
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            if (listBox1.SelectedItem != null)
            {
                // Получаем выбранное название из ListBox
                string название = listBox1.GetItemText(listBox1.SelectedItem);

                // Поиск государства по названию
                Государство найденноеГосударство = государства.Find(g => g.Название == название);

                if (найденноеГосударство != null)
                {
                    // Вывод информации о государстве
                    richTextBox1.Text = $"Название: {найденноеГосударство.Название}, ID: {найденноеГосударство.ID}";

                    if (найденноеГосударство.ГодСоздания != 0)
                    {
                        richTextBox1.Text += $", Год создания: {найденноеГосударство.ГодСоздания}";
                        richTextBox1.Text += $", Возраст: {найденноеГосударство.ВычислитьВозраст()}";
                    }

                    richTextBox1.Text += найденноеГосударство.ПоказатьИнформациюОПравителе();

                    if (!string.IsNullOrEmpty(найденноеГосударство.ПутьККартинке))
                    {
                        pictureBox1.ImageLocation = найденноеГосударство.ПутьККартинке;
                    }
                    else
                    {
                        pictureBox1.ImageLocation = null;
                    }
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            Государство найденноеГосударство = государства.Find(g => g.ID == id);
            if (найденноеГосударство != null)
            {
                ИзменитьНазвание(ref найденноеГосударство, textBox6.Text);
            }
            SetupListBox();
        }
    }
}
