using StavteClassy;
using System.Windows.Forms;
namespace HopeForPravilnost
{
    public partial class Form1 : Form
    {
        // �������� �����
        private List<�����������> ����������� = new List<�����������>();

        public Form1()
        {
            InitializeComponent();
            // ������������� ���������� �������� ����������� ��� ������������
            �����������.Add(new �����������("�������") { ID = 0 });
            �����������.Add(new �����������("�������") { ID = 1 });
            �����������.Add(new �����������("������") { ID = 2 });
            �����������.Add(new �����������("������") { ID = 3 });
        }
        private void button1_Click(object sender, EventArgs e) // ����� ���������� �� ID
        {
            richTextBox1.Clear();

            // �������� ID �� numericUpDown
            int id = (int)numericUpDown1.Value;

            // ����� ����������� �� ID
            ����������� �������������������� = �����������.Find(g => g.ID == id);

            if (�������������������� != null)
            {
                richTextBox1.Text = ��������������������.ToString();
            }
            else
            {
                richTextBox1.Text = $"����������� � ID {id} �� �������.";
            }

        }

        private void button2_Click(object sender, EventArgs e) // �������� ����������
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

            // �������� ������ �����������
            ����������� ���������������� = new �����������(��������) { ID = id };
            �����������.Add(����������������); // ��������� ����� ����������� � ������

            // ������� ��������� �� �������� ��������
            MessageBox.Show($"����������� '{��������}' � ID {id} ������� �������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ������� ����� ��� �����
            textBox2.Clear();
            numericUpDown1.Value = 0; // ����� ID ��� ���������� ��� �� ���� �������� �� ���������
        }

    }
}
