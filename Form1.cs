using Microsoft.VisualBasic;
using StavteClassy;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
namespace HopeForPravilnost
{
    public partial class Form1 : Form
    {
        private List<�����������> ����������� = new List<�����������>();

        public Form1()
        {
            InitializeComponent();
            // ������������� ���������� �������� ����������� ��� ������������
            �����������.Add(new �����������("�������", 111) { ID = 0 });
            �����������.Add(new �����������("�������") { ID = 1, ����������� = 1211 });
            �����������.Add(new �����������("���������") { ID = 2 });
            �����������.Add(new �����������("������") { ID = 3, ����������� = 2222 });
            SetupListBox();

            this.BackColor = �������.BackColor;
            numericUpDown1.Maximum = 2500;
        }

        private void SetupListBox()
        {
            // �������� ������
            listBox1.DataSource = null;
            listBox1.DataSource = �����������;
            listBox1.DisplayMember = "��������"; // ���������� ������ ��������
        }
        private bool ���������������(string filePath, out int �����������������)
        {
            ����������������� = 0;
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    �����������������++;
                    var parts = line.Split(',');

                    var ����������� = new �����������(parts[1].Trim());
                    �����������.ID = int.Parse(parts[0].Trim());
                    if (parts.Length > 2)
                        �����������.����������� = int.Parse(parts[2].Trim());

                    if (parts.Length > 3) // ���� ���� ������ � ���������
                    {
                        var ��������� = new ���������
                        {
                            ��� = parts[3].Trim(),
                            ������� = parts[4].Trim(),
                            �������� = parts[5].Trim(),
                            ������� = int.Parse(parts[6].Trim()),
                            ��������������� = DateTime.Parse(parts[7].Trim()),
                            ���������� = true
                        };
                        // ��� ������������ �������� - ������� ������ ����� ���������, � �� ����� ����� ���������.
                        �����������.���������������� = ���������;
                        �����������.����������� = true;
                    }

                    �����������.Add(�����������);

                }

                return true;
            }
            else
            {
                return false;
            }
        }
        private void ����������������(ref ����������� �����������, string �������������)
        {
            �����������.�������� = �������������;
        }
        private void button1_Click(object sender, EventArgs e) // ������ - ����� ����������� �� ID
        {
            richTextBox1.Clear();

            // �������� ID �� numericUpDown
            int id = (int)numericUpDown1.Value;

            // ����� ����������� �� ID
            ����������� �������������������� = �����������.Find(g => g.ID == id);

            if (�������������������� != null)
            {
                //richTextBox1.Text = ��������������������.ToString();
                richTextBox1.Text = $"��������: {��������������������.��������}, ID: {id}";
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

        private void button2_Click(object sender, EventArgs e) // ������ - �������� ����������
        {
            // �������� �������� ID � �������� ������
            int id = (int)numericUpDown2.Value;
            string �������� = textBox2.Text; // �� ���� ��� ����� ��������

            // ��������, ���������� �� ��� ����������� � ����� ID
            if (�����������.Exists(g => g.ID == id))
            {
                MessageBox.Show($"����������� � ID {id} ��� ����������. ����������, �������� ������ ID.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int _����������� = (int)numericUpDown4.Value;
            // �������� ������ ����������� � ������
            ����������� ���������������� = new �����������(��������) { ID = id, ����������� = _����������� };
            �����������.Add(����������������);

            // ������� ��������� �� �������� ��������
            MessageBox.Show($"����������� '{��������}' � ID {id} ������� �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SetupListBox();

            // ������� ����� ��� �����
            textBox2.Clear();
            numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� �������� �� ���������
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
                            if (�����������.����������������.����������)
                            {
                                writer.WriteLine($"{�����������.ID},{�����������.��������},{�����������.�����������}," +
                                    $"{�����������.����������������.���},{�����������.����������������.�������}," +
                                    $"{�����������.����������������.��������},{�����������.����������������.�������}," +
                                    $"{�����������.����������������.���������������}");
                            }
                            else
                            {
                                writer.WriteLine($"{�����������.ID},{�����������.��������},{�����������.�����������}");
                            }
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
    }
}
