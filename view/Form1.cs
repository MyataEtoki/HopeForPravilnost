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
            comboBox1.Items.Add("�����������");
            comboBox1.Items.Add("�������");
            comboBox1.Items.Add("�����");
            comboBox1.Items.Add("�����");
            
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
            var ����������� = presenter.Get�����������();
            var ������� = presenter.Get�������();
            var ������ = presenter.Get������();
            var ������ = presenter.Get������();
            // �������� ������
            listBox1.DataSource = null;
            listBox1.DataSource = �����������;
            listBox1.DisplayMember = "��������"; // ���������� ������ ��������
            listBox2.DataSource = null;
            listBox2.DataSource = �������;
            listBox2.DisplayMember = "��������";
            listBox3.DataSource = null;
            listBox3.DataSource = ������;
            listBox3.DisplayMember = "��������";
            listBox4.DataSource = null;
            listBox4.DataSource = ������;
            listBox4.DisplayMember = "��������";

        }

        
        private void button_SearchId_Click(object sender, EventArgs e) // ������ - ����� �� ID
        {
            var ����������� = presenter.Get�����������();
            var ������� = presenter.Get�������();
            var ������ = presenter.Get������();
            var ������ = presenter.Get������();
            richTextBox1.Clear();
            // �������� ID �� numericUpDown
            int id = (int)numericUpDown1.Value;

            if (comboBox1.Text == "�����������")
            {

                // ����� ����������� �� ID
                ����������� �������������������� = �����������.Find(g => g.ID == id);

                if (�������������������� != null)
                {
                    richTextBox1.Text = ��������������������.������������������();
                    //richTextBox1.Text = $"�����������: {��������������������.��������}, ID: {id}";
                    if (��������������������.����������� != 0)
                    {
                        richTextBox1.Text += $", ��� ��������: {��������������������.�����������}";
                        richTextBox1.Text += $", �������: {��������������������.����������������()}";
                    }
                    richTextBox1.Text += ��������������������.����������������������������();

                    if (��������������������.������������� != null)
                    {
                        pictureBox1.ImageLocation = ��������������������.�������������;
                    }
                    else { pictureBox1.ImageLocation = null; }

                }
                else
                {
                    richTextBox1.Text = $"����������� � ID {id} �� �������.";
                }
            }
            else if (comboBox1.Text == "�������")
            {

                // ����� ������� �� ID
                ������� ���������������� = �������.Find(g => g.ID == id);

                if (���������������� != null)
                {
                    richTextBox1.Text = ����������������.������������������();
                }
            }
            else if (comboBox1.Text == "�����")
            {
                ����� �������������� = ������.Find(g => g.ID == id);
                if (�������������� != null)
                {
                    richTextBox1.Text = ��������������.������������������();
                }
            }
            else if (comboBox1.Text == "�����")
            {
                ����� �������������� = ������.Find(g => g.ID == id);
                if (�������������� != null)
                {
                    richTextBox1.Text = ��������������.������������������();
                }
            }
        }

        private void button_Create_Click(object sender, EventArgs e) // ������ - �������� ��������
        {
            // �������� �������� ID � ��������
            int id = (int)numericUpDown2.Value; // ����� ��������������
            string �������� = textBox2.Text;

            if (comboBox1.Text == "�����������")
            {
                int _����������� = (int)numericUpDown4.Value;
                presenter.Add�����������(id, ��������, _�����������);
                SetupListBox();

                // ������� ����� ��� �����
                textBox2.Clear();
                numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� �������� �� ���������
            }
            else if (comboBox1.Text == "�������")
            {
                int id������������ = (int)numericUpDown5.Value;
                presenter.Add�������(id, ��������, id������������);

                SetupListBox();
                // ������� ����� ��� �����
                textBox2.Clear();
                numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� �������� �� ���������
            }
            else if (comboBox1.Text == "�����")
            {
                int id�������� = (int)numericUpDown5.Value;
                presenter.Add�����(id, ��������, id��������);
                
                SetupListBox();
                // ������� ����� ��� �����
                textBox2.Clear();
                numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� �������� �� ���������
            }
            else if (comboBox1.Text == "�����")
            {
                int id������� = (int)numericUpDown5.Value;
                presenter.Add�����(id, ��������, id�������);

                SetupListBox();
                // ������� ����� ��� �����
                textBox2.Clear();
                numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� �������� �� ���������
            }
        }

        private void button_CreatePresident_Click(object sender, EventArgs e) // ������ - ������� ���������
        {
            int id = (int)numericUpDown1.Value;
            string t1 = textBox3.Text;
            string t2 = textBox4.Text; 
            string t3 = textBox5.Text;
            int age = (int)numericUpDown3.Value;
            presenter.Set���������(id, t1,t2,t3,age);
        }

        //�������� ��
        private void button_UploadDB_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "�������� ���� ��� ��������";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    presenter.���������������Button(filePath);

                    SetupListBox();
                }
            }
        }

        //���������� ��
        private void button_DownloadDB_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "��������� ���� ���";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    presenter.���������������Button(filePath);

                    MessageBox.Show("������ ������� ��������� � ����.");
                }
            }
        }


        // ���������� ��������
        private void button_AddPicture_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            ����������� �������������������� = presenter.Find�����������Id(id);
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK && �������������������� != null)
                {
                    string imagePath = openFileDialog.FileName;
                    pictureBox1.ImageLocation = imagePath;
                    ��������������������.������������� = imagePath;
                }
            }
        }

        //��������� ������ � listBox1, ��� ����� ������. �������������
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            if (listBox1.SelectedItem != null)
            {
                // �������� ��������� �������� �� ListBox
                string �������� = listBox1.GetItemText(listBox1.SelectedItem);

                // ����� ����������� �� ��������
                ����������� �������������������� = presenter.Find�����������Name(��������);

                if (�������������������� != null)
                {
                    // ����� ���������� � �����������
                    richTextBox1.Text = ��������������������.ToString();

                    if (��������������������.����������� != 0)
                    {
                        richTextBox1.Text += $", ��� ��������: {��������������������.�����������}";
                        richTextBox1.Text += $", �������: {��������������������.����������������()}";
                    }

                    // ���������� ������ � ������� �����������
                    for (int i = 0; i < ��������������������.�������.Count; i++)
                    {
                        richTextBox1.Text += $"\n������� {i + 1}: {��������������������[i].��������}\n";
                    }

                    richTextBox1.Text += ��������������������.����������������������������();

                    if (!string.IsNullOrEmpty(��������������������.�������������))
                    {
                        pictureBox1.ImageLocation = ��������������������.�������������;
                    }
                    else
                    {
                        pictureBox1.ImageLocation = null;
                    }
                }
            }
        }

        // �������� �������� ����������� - ���������� ref
        private void button_ChangeName_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            ����������� �������������������� = presenter.Find�����������Id(id);
            if (�������������������� != null)
            {
                presenter.���������������������������(ref ��������������������, textBox6.Text);
            }
            SetupListBox();
        }

        // ListBoxs //
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) // listBox ����� �������
        {
            richTextBox1.Clear();

            if (listBox2.SelectedItem != null)
            {
                // �������� ��������� �������� �� ListBox2
                string �������� = listBox2.GetItemText(listBox2.SelectedItem);

                // ����� ������� �� ��������
                ������� ���������������� = presenter.Find�������Name(��������);

                if (���������������� != null)
                {
                    // ����� ���������� �� �������
                    richTextBox1.Text = ����������������.ToString();
                    richTextBox1.Text += ����������������.������������();

                    // ���������� ������ � ������� �����������
                    for (int i = 0; i < ����������������.������.Count; i++)
                    {
                        richTextBox1.Text += $"\n����� {i + 1}: {����������������[i].��������}";
                    }
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) // listBox ����� �����
        {
            if (listBox3.SelectedItem != null)
            {
                // �������� ��������� �������� �� ListBox2
                string �������� = listBox3.GetItemText(listBox3.SelectedItem);

                // ����� ������ �� ��������
                ����� �������������� = presenter.Find�����Name(��������);

                if (�������������� != null)
                {
                    // ����� ���������� � ������
                    richTextBox1.Text = $"ID: {��������������.ID}, ��������: {��������������.��������}";
                    richTextBox1.Text += ��������������.������������();

                    // ���������� ������ � ������� �����������
                    for (int i = 0; i < ��������������.������.Count; i++)
                    {
                        richTextBox1.Text += $"\n����� {i + 1}: {��������������[i].��������}";
                    }
                }
            }

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem != null)
            {
                // �������� ��������� �������� �� ListBox2
                string �������� = listBox4.GetItemText(listBox4.SelectedItem);
                
                // ����� ������ �� ��������
                ����� �������������� = presenter.Find�����Name(��������);

                if (�������������� != null)
                {
                    // ����� ���������� � ������
                    richTextBox1.Text = ��������������.ToString();
                    richTextBox1.Text += ��������������.������������();
                    richTextBox1.Text += ��������������.������������();
                }
            }
        }

        // �������� ������ ���� �� ������
        private void button_ClearPicture_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        // �������� ��������� - �������� ��������� � ��������

        private void button_SetRevolution_Click(object sender, EventArgs e) // ������ - �������� ���������
        {
            int id = (int)numericUpDown1.Value;
            presenter.Set���������Button(id);
        }
        // ���� � ��������� - ��������� ��������� ������������ ������
        private void button_CheckStreet_Click(object sender, EventArgs e) // ������ - ��������� ��������� ������
        {
            int id = (int)numericUpDown1.Value;
            ����� ���������������� = presenter.Find�����Id(id);

            if (���������������� != null)
            {
                MessageBox.Show($"��������� ������ '{����������������.��������}': '{����������������.���������������������}'.",
                            "�������� ���������",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
        }
        private void button_SetStreetDangerous_Click(object sender, EventArgs e) // ������ - ������� ����� �������
        {
            presenter.Set������������((int)numericUpDown1.Value);
        }

        private void button_SetStreetUndangerous_Click(object sender, EventArgs e) // ������ - ������� ����� ����������
        {
            presenter.Set���������������((int)numericUpDown1.Value);
        }

        
    }
}
