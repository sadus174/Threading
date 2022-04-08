using System.Threading;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public delegate void ThreadStart();
        Thread myThread1;
        Thread myThread2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myThread1 = new Thread(MethodTr1);
            myThread2 = new Thread(MethodTr2);
        }

        //����� ��� ������� ������
        void MethodTr1()
        {
            Random rnd = new Random();  
            for (int i = 0; i < 100; i++)
            {
                listBox1.Items.Add(rnd.Next(111,999));
                Thread.Sleep(rnd.Next(99, 999));
            }
        }

        //����� ��� ������� ������
        void MethodTr2()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                listBox2.Items.Add(rnd.Next(111, 999));
                Thread.Sleep(rnd.Next(99, 999));
            }
        }

        //������ ������ 1
        private void button1_Click(object sender, EventArgs e)
        {
            myThread1.Start();
        }

        //������ ������ 2
        private void button2_Click(object sender, EventArgs e)
        {
            myThread2.Start();
        }
    }
}