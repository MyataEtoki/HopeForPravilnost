using StavteClassy;
using System.Threading.Tasks.Sources;
using System.Windows.Forms;
using HopeForPravilnost.view;
using HopeForPravilnost.presenter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace HopeForPravilnost
{
    public partial class Form1 : Form, IFormView
    {
        private MainPresenter presenter;

        public Form1()
        {
            presenter = new MainPresenter(this);

            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Государство");
            comboBox1.Items.Add("Область");
            comboBox1.Items.Add("Город");
            comboBox1.Items.Add("Район");
            
            SetupListBox();
            SetBackground();

            numericUpDown1.Maximum = 2500;
        }

        private void SetBackground()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday || DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                this.BackColor = Color.MistyRose;
            }
            else
            {
                this.BackColor = Color.White;
            }
        }
        private void SetupListBox()
        {
            var государства = presenter.GetГосударства();
            var области = presenter.GetОбласти();
            var города = presenter.GetГорода();
            var районы = presenter.GetРайоны();
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

        
        private void button_SearchId_Click(object sender, EventArgs e) // кнопка - Поиск по ID
        {
            var государства = presenter.GetГосударства();
            var области = presenter.GetОбласти();
            var города = presenter.GetГорода();
            var районы = presenter.GetРайоны();
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
                    richTextBox1.Text = найденнаяОбласть.ПолучитьИнформацию();
                }
            }
            else if (comboBox1.Text == "Город")
            {
                Город найденныйГород = города.Find(g => g.ID == id);
                if (найденныйГород != null)
                {
                    richTextBox1.Text = найденныйГород.ПолучитьИнформацию();
                }
            }
            else if (comboBox1.Text == "Район")
            {
                Район найденныйРайон = районы.Find(g => g.ID == id);
                if (найденныйРайон != null)
                {
                    richTextBox1.Text = найденныйРайон.ПолучитьИнформацию();
                }
            }
        }

        private void button_Create_Click(object sender, EventArgs e) // кнопка - Создание субъекта
        {
            // Получаем значение ID и название
            int id = (int)numericUpDown2.Value; // явное преобразование
            string название = textBox2.Text;

            if (comboBox1.Text == "Государство")
            {
                int _годСоздания = (int)numericUpDown4.Value;
                presenter.AddГосударство(id, название, _годСоздания);
                SetupListBox();

                // Очистка полей для ввода
                textBox2.Clear();
                numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
            }
            else if (comboBox1.Text == "Область")
            {
                int idВГосударстве = (int)numericUpDown5.Value;
                presenter.AddОбласть(id, название, idВГосударстве);

                SetupListBox();
                // Очистка полей для ввода
                textBox2.Clear();
                numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
            }
            else if (comboBox1.Text == "Город")
            {
                int idВОбласти = (int)numericUpDown5.Value;
                presenter.AddГород(id, название, idВОбласти);
                
                SetupListBox();
                // Очистка полей для ввода
                textBox2.Clear();
                numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
            }
            else if (comboBox1.Text == "Район")
            {
                int idВГороде = (int)numericUpDown5.Value;
                presenter.AddРайон(id, название, idВГороде);

                SetupListBox();
                // Очистка полей для ввода
                textBox2.Clear();
                numericUpDown1.Value = 0; // Сброс ID или установите его на значение по умолчанию
            }
        }

        private void button_CreatePresident_Click(object sender, EventArgs e) // кнопка - создать правителя
        {
            int id = (int)numericUpDown1.Value;
            string t1 = textBox3.Text;
            string t2 = textBox4.Text; 
            string t3 = textBox5.Text;
            int age = (int)numericUpDown3.Value;
            presenter.SetПравитель(id, t1,t2,t3,age);
        }

        //Загрузка БД
        private void button_UploadDB_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл для загрузки";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    presenter.ЗагрузитьДанныеButton(filePath);

                    SetupListBox();
                }
            }
        }

        //Сохранение БД
        private void button_DownloadDB_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить файл как";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    presenter.СохранитьДанныеButton(filePath);

                    MessageBox.Show("Данные успешно сохранены в файл.");
                }
            }
        }


        // Добавление картинки
        private void button_AddPicture_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            Государство найденноеГосударство = presenter.FindГосударствоId(id);
            
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
                Государство найденноеГосударство = presenter.FindГосударствоName(название);

                if (найденноеГосударство != null)
                {
                    // Вывод информации о государстве
                    richTextBox1.Text = найденноеГосударство.ToString();

                    if (найденноеГосударство.ГодСоздания != 0)
                    {
                        richTextBox1.Text += $", Год создания: {найденноеГосударство.ГодСоздания}";
                        richTextBox1.Text += $", Возраст: {найденноеГосударство.ВычислитьВозраст()}";
                    }

                    // Перебираем районы с помощью индексатора
                    for (int i = 0; i < найденноеГосударство.Области.Count; i++)
                    {
                        richTextBox1.Text += $"\nОбласть {i + 1}: {найденноеГосударство[i].Название}\n";
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
        private void button_ChangeName_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            Государство найденноеГосударство = presenter.FindГосударствоId(id);
            if (найденноеГосударство != null)
            {
                presenter.ИзменитьНазваниеГосударства(ref найденноеГосударство, textBox6.Text);
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

                // Поиск области по названию
                Область найденнаяОбласть = presenter.FindОбластьName(название);

                if (найденнаяОбласть != null)
                {
                    // Вывод информации об области
                    richTextBox1.Text = найденнаяОбласть.ToString();
                    richTextBox1.Text += найденнаяОбласть.ГдеНаходится();

                    // Перебираем города с помощью индексатора
                    for (int i = 0; i < найденнаяОбласть.Города.Count; i++)
                    {
                        richTextBox1.Text += $"\nГород {i + 1}: {найденнаяОбласть[i].Название}";
                    }
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) // listBox поиск Город
        {
            if (listBox3.SelectedItem != null)
            {
                // Получаем выбранное название из ListBox2
                string название = listBox3.GetItemText(listBox3.SelectedItem);

                // Поиск города по названию
                Город найденныйГород = presenter.FindГородName(название);

                if (найденныйГород != null)
                {
                    // Вывод информации о городе
                    richTextBox1.Text = $"ID: {найденныйГород.ID}, Название: {найденныйГород.Название}";
                    richTextBox1.Text += найденныйГород.ГдеНаходится();

                    // Перебираем районы с помощью индексатора
                    for (int i = 0; i < найденныйГород.Районы.Count; i++)
                    {
                        richTextBox1.Text += $"\nРайон {i + 1}: {найденныйГород[i].Название}";
                    }
                }
            }

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem != null)
            {
                // Получаем выбранное название из ListBox2
                string название = listBox4.GetItemText(listBox4.SelectedItem);
                
                // Поиск района по названию
                Район найденныйРайон = presenter.FindРайонName(название);

                if (найденныйРайон != null)
                {
                    // Вывод информации о районе
                    richTextBox1.Text = найденныйРайон.ToString();
                    richTextBox1.Text += найденныйРайон.ГдеНаходится();
                    richTextBox1.Text += найденныйРайон.ВывестиУлицы();
                }
            }
        }

        // Очистить пикчюр бокс от района
        private void button_ClearPicture_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        // Устроить революцию - удаление правителя с событием

        private void button_SetRevolution_Click(object sender, EventArgs e) // кнопка - устроить революцию
        {
            int id = (int)numericUpDown1.Value;
            presenter.SetРеволюцияButton(id);
        }
        // Блок с событиями - изменения состояния безопасности Района
        private void button_CheckStreet_Click(object sender, EventArgs e) // кнопка - проверить опасность района
        {
            int id = (int)numericUpDown1.Value;
            Район найденныйСубъект = presenter.FindРайонId(id);

            if (найденныйСубъект != null)
            {
                MessageBox.Show($"Состояние района '{найденныйСубъект.Название}': '{найденныйСубъект.СостояниеБезопасности}'.",
                            "Проверка состояния",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }
        private void button_SetStreetDangerous_Click(object sender, EventArgs e) // кнопка - сделать район опасным
        {
            presenter.SetРайонОпасный((int)numericUpDown1.Value);
        }

        private void button_SetStreetUndangerous_Click(object sender, EventArgs e) // кнопка - сделать район безопасным
        {
            presenter.SetРайонБезопасный((int)numericUpDown1.Value);
        }

        
    }
}
