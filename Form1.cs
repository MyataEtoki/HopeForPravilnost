using StavteClassy;
using System.Threading.Tasks.Sources;
namespace HopeForPravilnost
{
    public partial class Form1 : Form
    {
        private List<�����������> ����������� = new List<�����������>();
        private List<�������> ������� = new List<�������>();
        private List<�����> ������ = new List<�����>();
        private List<�����> ������ = new List<�����>();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("�����������");
            comboBox1.Items.Add("�������");
            comboBox1.Items.Add("�����");
            comboBox1.Items.Add("�����");
            // ������������� ���������� �������� ����������� ��� ������������
            var ������� = new �����������(0, "�������", 111);
            var ������� = new �����������(1, "�������") { ����������� = 1211 };
            var ��������� = new �����������(2, "���������");
            var ������ = new �����������(3, "������") { ����������� = 2222 };
            var ��������� = new �����(0, "���������");
            var ���������� = new �����(1, "����������");
            var ������� = new �������(0, "�������");
            var ���������� = new �������(1, "����������");
            var ����������� = new �����(0, "�����������");
            //var ���������� = new �����(1, "����������");
            //������.Add(����������);
            ������.Add(�����������);
            ������.Add(���������);
            ������.Add(����������);
            �������.Add(�������);
            �������.Add(����������);
            �����������.Add(�������);
            �����������.Add(�������);
            �����������.Add(���������);
            �����������.Add(������);
            �������.���������������(�������);
            SetupListBox();

            //this.BackColor = �������.BackColor;
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
        private bool ���������������(string filePath, out int �����������������)
        {
            // ������� ��������� ����� ��������� ����� ������
            �����������.Clear();
            �������.Clear();
            ������.Clear();
            ������.Clear();

            ����������������� = 0;
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    �����������������++;
                    var parts = line.Split(',');

                    if (parts.Length >= 2)
                    {
                        // �������� ��������������� ������
                        if (parts[0].Trim() == "�����������")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string �������� = parts[2].Trim();

                            // ��������� ������� ��������� �� ID ��� �����
                            if (!�����������.Exists(g => g.ID == id || g.��������.Equals(��������, StringComparison.OrdinalIgnoreCase)))
                            {
                                var ����������� = new �����������(id, ��������)
                                {
                                    ����������� = parts.Length > 3 ? int.Parse(parts[3].Trim()) : 0
                                };

                                // �������� ���������� � ���������, ���� ��������
                                if (parts.Length > 8) // ���� ���� ������ � ���������
                                {
                                    var ��������� = new ���������
                                    {
                                        ��� = parts[4].Trim(),
                                        ������� = parts[5].Trim(),
                                        �������� = parts[6].Trim(),
                                        ������� = int.Parse(parts[7].Trim()),
                                        ��������������� = DateTime.Parse(parts[8].Trim()),
                                        ���������� = true
                                    };
                                    �����������.���������������� = ���������;
                                    �����������.����������� = true;
                                }

                                �����������.Add(�����������); // ��������� ������ ���� ��� ����������
                            }
                        }
                        else if (parts[0].Trim() == "�������")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string �������� = parts[2].Trim();

                            // ��������� ������� ���������
                            if (!�������.Exists(o => o.ID == id || o.��������.Equals(��������, StringComparison.OrdinalIgnoreCase)))
                            {
                                var ������� = new �������(id, ��������);
                                �������.Add(�������);
                            }
                        }
                        else if (parts[0].Trim() == "�����")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string �������� = parts[2].Trim();

                            // ��������� ������� ���������
                            if (!������.Exists(c => c.ID == id || c.��������.Equals(��������, StringComparison.OrdinalIgnoreCase)))
                            {
                                var ����� = new �����(id, ��������);
                                ������.Add(�����);
                            }
                        }
                        else if (parts[0].Trim() == "�����")
                        {
                            int id = int.Parse(parts[1].Trim());
                            string �������� = parts[2].Trim();

                            // ��������� ������� ���������
                            if (!������.Exists(d => d.ID == id || d.��������.Equals(��������, StringComparison.OrdinalIgnoreCase)))
                            {
                                var ����� = new �����(id, ��������);
                                ������.Add(�����);
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
        // ���������� � ����������� �������� - ����� ref.
        private void ����������������(ref ����������� �����������, string �������������)
        {
            �����������.�������� = �������������;
        }
        private void button1_Click(object sender, EventArgs e) // ������ - ����� �� ID
        {
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
                    richTextBox1.Text = $"�������: {����������������.��������}, ID: {id}";
                }
            }
            else if (comboBox1.Text == "�����")
            {
                ����� �������������� = ������.Find(g => g.ID == id);
                if (�������������� != null)
                {
                    richTextBox1.Text = $"�����: {��������������.��������}, ID: {id}";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // ������ - �������� ����������
        {
            // �������� �������� ID � ��������
            int id = (int)numericUpDown2.Value; // ����� ��������������
            string �������� = textBox2.Text;

            if (comboBox1.Text == "�����������")
            {
                // ��������, ���������� �� ��� ����������� � ����� ID
                if (�����������.Exists(g => g.ID == id))
                {
                    MessageBox.Show($"����������� � ID {id} ��� ����������. ����������, �������� ������ ID.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int _����������� = (int)numericUpDown4.Value;
                // �������� ������ ����������� � ������
                ����������� ���������������� = new �����������(id, ��������) { ����������� = _����������� };
                �����������.Add(����������������);

                // ������� ��������� �� �������� ��������
                MessageBox.Show($"����������� '{��������}' � ID {id} ������� �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetupListBox();

                // ������� ����� ��� �����
                textBox2.Clear();
                numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� �������� �� ���������
            }
            else if (comboBox1.Text == "�������")
            {

                // ��������, ���������� �� ��� ������� � ����� ID
                if (�������.Exists(g => g.ID == id))
                {
                    MessageBox.Show($"������� � ID {id} ��� ����������. ����������, �������� ������ ID.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ������� ������������ = new �������(id, ��������);
                ������� ������������ = (�������)������������;
                �������.Add(������������);

                // ������� ��������� �� �������� ��������
                MessageBox.Show($"������� '{��������}' � ID {id} ������� �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SetupListBox();
                // ������� ����� ��� �����
                textBox2.Clear();
                numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� �������� �� ���������
            }
            else if (comboBox1.Text == "�����")
            {
                // ��������, ���������� �� ��� ����������� � ����� ID
                if (������.Exists(g => g.ID == id))
                {
                    MessageBox.Show($"����� � ID {id} ��� ����������. ����������, �������� ������ ID.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ������� ������������ = new �����(id, ��������); // ������� ��������������
                //������������.������������� = "\"C:\\Users\\etoki\\Pictures\\�� ������ ������ ��� ������ 2 ����������� ������� � ����� ����� ����.jpg\"";
                //������������.���������������(pictureBox1);
                MessageBox.Show($"�� ����� ������: {������������.ToString()}"); // ��� ��� new - ������� - �� ����� ���������� �� ������ �������
                ����� ���������� = (�����)������������; // ����� ��������������
                MessageBox.Show($"�� ������ ������ => {����������.ToString()}"); // ��� ��� new - ������� - �� ����� ���������� �� ������ �����
                ������.Add(����������);
                MessageBox.Show($"����� '{��������}' � ID {id} ������� �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetupListBox();
                // ������� ����� ��� �����
                textBox2.Clear();
                numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� �������� �� ���������
            }
        }

        private void button3_Click(object sender, EventArgs e) // ������ - ������� ���������
        {
            int id = (int)numericUpDown1.Value;
            ����������� �������������������� = �����������.Find(g => g.ID == id);
            if (�������������������� != null)
            {
                ��������������������.�������������������(textBox3.Text, textBox4.Text, textBox5.Text, (int)numericUpDown3.Value, DateTime.Now);
            }
        }

        //�������� ��
        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "�������� ���� ��� ��������";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // ������� ��������� ����� ���������
                    �����������.Clear();

                    // ��������� ������ �� �����
                    if (���������������(filePath, out int ����������))
                    {
                        MessageBox.Show($"������� ��������� {����������} �������.");
                    }
                    else
                    {
                        MessageBox.Show("�� ������� ��������� ������ �� �����.");
                    }
                    SetupListBox();
                }
            }
        }

        //���������� ��
        private void button5_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "��������� ���� ���";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // ���������� ������ � ����
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var ����������� in �����������)
                        {
                            if (�����������.����������������.���������� && �����������.�����������)
                            {
                            writer.WriteLine($"�����������,{�����������.ID},{�����������.��������},{�����������.�����������}," +
                            $"{�����������.����������������.���},{�����������.����������������.�������}," +
                            $"{�����������.����������������.��������},{�����������.����������������.�������}," +
                            $"{�����������.����������������.���������������}");
                            }
                            else
                            {
                            writer.WriteLine($"�����������,{�����������.ID},{�����������.��������},{�����������.�����������}");
                            }
                        }
                        // ��������� �������
                        foreach (var ������� in �������)
                        {
                            writer.WriteLine($"�������,{�������.ID},{�������.��������}");
                        }

                        // ��������� ������
                        foreach (var ����� in ������)
                        {
                            writer.WriteLine($"�����,{�����.ID},{�����.��������}");
                        }

                        // ��������� ������
                        foreach (var ����� in ������)
                        {
                            writer.WriteLine($"�����,{�����.ID},{�����.��������}");
                        }
                    }

                    MessageBox.Show("������ ��������� � ����.");
                }
            }
        }
        // ����������� ��-�������
        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        //���������� ��������
        private void button7_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            ����������� �������������������� = �����������.Find(g => g.ID == id);
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
                ����������� �������������������� = �����������.Find(g => g.�������� == ��������);

                if (�������������������� != null)
                {
                    // ����� ���������� � �����������
                    richTextBox1.Text = $"��������: {��������������������.��������}, ID: {��������������������.ID}";

                    if (��������������������.����������� != 0)
                    {
                        richTextBox1.Text += $", ��� ��������: {��������������������.�����������}";
                        richTextBox1.Text += $", �������: {��������������������.����������������()}";
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
        private void button8_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            ����������� �������������������� = �����������.Find(g => g.ID == id);
            if (�������������������� != null)
            {
                ����������������(ref ��������������������, textBox6.Text);
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

                // ����� ����������� �� ��������
                ������� ����������������� = �������.Find(g => g.�������� == ��������);

                if (����������������� != null)
                {
                    // ����� ���������� � �����������
                    richTextBox1.Text = $"��������: {�����������������.��������}, ID: {�����������������.ID}";
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e) // listBox ����� �����
        {
            if (listBox3.SelectedItem != null)
            {
                // �������� ��������� �������� �� ListBox2
                string �������� = listBox3.GetItemText(listBox3.SelectedItem);

                // ����� ����������� �� ��������
                ����� ��������������� = ������.Find(g => g.�������� == ��������);

                if (��������������� != null)
                {
                    // ����� ���������� � �����������
                    richTextBox1.Text = $"��������: {���������������.��������}, ID: {���������������.ID}";
                }
            }

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem != null)
            {
                // �������� ��������� �������� �� ListBox2
                string �������� = listBox4.GetItemText(listBox4.SelectedItem);

                // ����� ����������� �� ��������
                ����� ��������������� = ������.Find(g => g.�������� == ��������);

                if (��������������� != null)
                {
                    // ����� ���������� � �����������
                    richTextBox1.Text = $"��������: {���������������.��������}, ID: {���������������.ID}";
                }
            }
        }
    }
}
