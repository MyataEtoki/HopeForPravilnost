using StavteClassy;
using System.Threading.Tasks.Sources;
namespace HopeForPravilnost
{
    public partial class Form1 : Form
    {
        private List<Государство> государства = new List<Государство>();
        private List<Область> области = new List<Область>();
        private List<Город> города = new List<Город>();
        private List<Район> районы = new List<Район>();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Государство");
            comboBox1.Items.Add("Область");
            comboBox1.Items.Add("Город");
            comboBox1.Items.Add("Район");
            // Инициализация нескольких объектов государства для демонстрации
            var франция = new Государство(0, "Франция", 111);
            var испания = new Государство(1, "Испания") { ГодСоздания = 1211 };
            var лапландия = new Государство(2, "Лапландия");
            var россия = new Государство(3, "Россия") { ГодСоздания = 2222 };
            var мухоженуи = new Город(0, "Мухоженуи");
            var мухосранск = new Город(1, "Мухосранск");
            var шампань = new Область(0, "Шампань");
            var ростовская = new Область(1, "Ростовская");
            var тринадцатый = new Район(0, "Тринадцатый");
            //var московский = new Район(1, "Московский");
            //районы.Add(московский);
            районы.Add(тринадцатый);
            города.Add(мухоженуи);
            города.Add(мухосранск);
            области.Add(шампань);
            области.Add(ростовская);
            государства.Add(франция);
            государства.Add(испания);
            государства.Add(лапландия);
            государства.Add(россия);
            франция.ДобавитьОбласть(шампань);
            SetupListBox();

            //this.BackColor = Субъект.BackColor;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday || DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                this.BackColor = Color.MistyRose;
            }
            else
            {
                this.BackColor = Color.White;
            }

            numericUpDown1.Maximum = 2500;
        }

        private void SetupListBox()
        {
            // Привязка данных
            listBox1.DataSource = null;
            listBox1.DataSource = государства;
            listBox1.DisplayMember = "Название"; // Отображаем только название
            listBox2.DataSource = null;
            listBox2.DataSource = области;
            listBox2.DisplayMember = "Название";
            listBox3.DataSource = null;
            listBox3.DataSource = города;
            listBox3.DisplayMember = "Название";
            listBox4.DataSource = null;
            listBox4.DataSource = районы;
            listBox4.DisplayMember = "Название";

        }
        private bool ЗагрузитьДанные(string filePath, out int количествоЗаписей)
        {
            // Очищаем коллекции перед загрузкой новых данных
            государства.Clear();
            области.Clear();
            города.Clear();
            районы.Clear();

            количествоЗаписей = 0;
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    количествоЗаписей++;
                    var parts = line.Split(',');

                    if (parts.Length >= 2)
                    {
                        // Загрузка государственных данных
                        if (parts[0].Trim() == "Государство")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string название = parts[2].Trim();

                            // Проверяем наличие дубликата по ID или имени
                            if (!государства.Exists(g => g.ID == id || g.Название.Equals(название, StringComparison.OrdinalIgnoreCase)))
                            {
                                var государство = new Государство(id, название)
                                {
                                    ГодСоздания = parts.Length > 3 ? int.Parse(parts[3].Trim()) : 0
                                };

                                // Загрузка информации о правителе, если доступна
                                if (parts.Length > 8) // если есть данные о правителе
                                {
                                    var правитель = new Правитель
                                    {
                                        Имя = parts[4].Trim(),
                                        Фамилия = parts[5].Trim(),
                                        Отчество = parts[6].Trim(),
                                        Возраст = int.Parse(parts[7].Trim()),
                                        НачалоПравления = DateTime.Parse(parts[8].Trim()),
                                        Существует = true
                                    };
                                    государство.ТекущийПравитель = правитель;
                                    государство.КтоТоПравит = true;
                                }

                                государства.Add(государство); // Добавляем только если нет дубликатов
                            }
                        }
                        else if (parts[0].Trim() == "Область")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string название = parts[2].Trim();

                            // Проверяем наличие дубликата
                            if (!области.Exists(o => o.ID == id || o.Название.Equals(название, StringComparison.OrdinalIgnoreCase)))
                            {
                                var область = new Область(id, название);
                                области.Add(область);
                            }
                        }
                        else if (parts[0].Trim() == "Город")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string название = parts[2].Trim();

                            // Проверяем наличие дубликата
                            if (!города.Exists(c => c.ID == id || c.Название.Equals(название, StringComparison.OrdinalIgnoreCase)))
                            {
                                var город = new Город(id, название);
                                города.Add(город);
                            }
                        }
                        else if (parts[0].Trim() == "Район")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string название = parts[2].Trim();

                            // Проверяем наличие дубликата
                            if (!районы.Exists(d => d.ID == id || d.Название.Equals(название, StringComparison.OrdinalIgnoreCase)))
                            {
                                var район = new Район(id, название);
                                районы.Add(район);
                            }
                        }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        // обращаемся к государству напрямую - через ref.
        private void ИзменитьНазвание(ref Государство государство, string новоеНазвание)
        {
            государство.Название = новоеНазвание;
        }
        private void button1_Click(object sender, EventArgs e) // кнопка - Поиск по ID
        {
            richTextBox1.Clear();
            // Получаем ID из numericUpDown
            int id = (int)numericUpDown1.Value;

            if (comboBox1.Text == "Государство")
            {

                // Поиск государства по ID
                Государство найденноеГосударство = государства.Find(g => g.ID == id);

                if (найденноеГосударство != null)
                {
                    richTextBox1.Text = найденноеГосударство.ПолучитьИнформацию();
                    //richTextBox1.Text = $"Государство: {найденноеГосударство.Название}, ID: {id}";
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
            else if (comboBox1.Text == "Область")
            {

                // Поиск области по ID
                Область найденнаяОбласть = области.Find(g => g.ID == id);

                if (найденнаяОбласть != null)
                {
                    richTextBox1.Text = $"Область: {найденнаяОбласть.Название}, ID: {id}";
                }
            }
            else if (comboBox1.Text == "Город")
            {
                Город найденныйГород = города.Find(g => g.ID == id);
                if (найденныйГород != null)
                {
                    richTextBox1.Text = $"Город: {найденныйГород.Название}, ID: {id}";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // кнопка - Создание государств
        {
            // Получаем значение ID и название
            int id = (int)numericUpDown2.Value; // явное преобразование
            string название = textBox2.Text;

            if (comboBox1.Text == "Государство")
            {
                // Проверка, существует ли уже государство с таким ID
                if (государства.Exists(g => g.ID == id))
                {
                    MessageBox.Show($"Государство с ID {id} уже существует. Пожалуйста, выберите другой ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int _годСоздания = (int)numericUpDown4.Value;
                // Создание нового государства в списке
                Государство новоеГосударство = new Государство(id, название) { ГодСоздания = _годСоздания };
                государства.Add(новоеГосударство);

                // Выводим сообщение об успешном создании
                MessageBox.Show($"Государство '{название}' с ID {id} успешно создано!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetupListBox();

                // Очистка полей для ввода
                textBox2.Clear();
                numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
            }
            else if (comboBox1.Text == "Область")
            {

                // Проверка, существует ли уже субъект с таким ID
                if (области.Exists(g => g.ID == id))
                {
                    MessageBox.Show($"Область с ID {id} уже существует. Пожалуйста, выберите другой ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Субъект новыйСубъект = new Область(id, название);
                Область новаяОбласть = (Область)новыйСубъект;
                области.Add(новаяОбласть);

                // Выводим сообщение об успешном создании
                MessageBox.Show($"Область '{название}' с ID {id} успешно создано!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetupListBox();
                // Очистка полей для ввода
                textBox2.Clear();
                numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
            }
            else if (comboBox1.Text == "Город")
            {
                // Проверка, существует ли уже государство с таким ID
                if (города.Exists(g => g.ID == id))
                {
                    MessageBox.Show($"Город с ID {id} уже существует. Пожалуйста, выберите другой ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Субъект новыйСубъект = new Город(id, название); // Неявное преобразование
                //новыйСубъект.ПутьККартинке = "\"C:\\Users\\etoki\\Pictures\\ну ничего полежу так часика 2 позагоняюсь поплачу а потом точно усну.jpg\"";
                //новыйСубъект.ВывестиКартинку(pictureBox1);
                MessageBox.Show($"Вы ввели данные: {новыйСубъект.ToString()}"); // так как new - скрытие - то метод вызывается из класса Субъект
                Город новыйГород = (Город)новыйСубъект; // явное преобразование
                MessageBox.Show($"На основе данных => {новыйГород.ToString()}"); // так как new - скрытие - то метод вызывается из класса Город
                города.Add(новыйГород);
                MessageBox.Show($"Город '{название}' с ID {id} успешно создано!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetupListBox();
                // Очистка полей для ввода
                textBox2.Clear();
                numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
            }
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
                            if (государство.ТекущийПравитель.Существует && государство.КтоТоПравит)
                            {
                            writer.WriteLine($"Государство,{государство.ID},{государство.Название},{государство.ГодСоздания}," +
                            $"{государство.ТекущийПравитель.Имя},{государство.ТекущийПравитель.Фамилия}," +
                            $"{государство.ТекущийПравитель.Отчество},{государство.ТекущийПравитель.Возраст}," +
                            $"{государство.ТекущийПравитель.НачалоПравления}");
                            }
                            else
                            {
                            writer.WriteLine($"Государство,{государство.ID},{государство.Название},{государство.ГодСоздания}");
                            }
                        }
                        // Сохраняем области
                        foreach (var область in области)
                        {
                            writer.WriteLine($"Область,{область.ID},{область.Название}");
                        }

                        // Сохраняем города
                        foreach (var город in города)
                        {
                            writer.WriteLine($"Город,{город.ID},{город.Название}");
                        }

                        // Сохраняем районы
                        foreach (var район in районы)
                        {
                            writer.WriteLine($"Район,{район.ID},{район.Название}");
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

        // Изменить название государства - применение ref
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

        // ListBoxs //
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) // listBox поиск Область
        {
            richTextBox1.Clear();

            if (listBox2.SelectedItem != null)
            {
                // Получаем выбранное название из ListBox2
                string название = listBox2.GetItemText(listBox2.SelectedItem);

                // Поиск государства по названию
                Область найденннаяОбласть = области.Find(g => g.Название == название);

                if (найденннаяОбласть != null)
                {
                    // Вывод информации о государстве
                    richTextBox1.Text = $"Название: {найденннаяОбласть.Название}, ID: {найденннаяОбласть.ID}";
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) // listBox поиск Город
        {
            if (listBox3.SelectedItem != null)
            {
                // Получаем выбранное название из ListBox2
                string название = listBox3.GetItemText(listBox3.SelectedItem);

                // Поиск государства по названию
                Город найденнныйГород = города.Find(g => g.Название == название);

                if (найденнныйГород != null)
                {
                    // Вывод информации о государстве
                    richTextBox1.Text = $"Название: {найденнныйГород.Название}, ID: {найденнныйГород.ID}";
                }
            }

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem != null)
            {
                // Получаем выбранное название из ListBox2
                string название = listBox4.GetItemText(listBox4.SelectedItem);

                // Поиск государства по названию
                Район найденнныйРайон = районы.Find(g => g.Название == название);

                if (найденнныйРайон != null)
                {
                    // Вывод информации о государстве
                    richTextBox1.Text = $"Название: {найденнныйРайон.Название}, ID: {найденнныйРайон.ID}";
                }
            }
        }
    }
}
