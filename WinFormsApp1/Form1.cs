using System.Threading;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //������������ ������� ������������� ������, 
        //������� ��� ��������� ������� ���������� �������� �������. ���� ����� �� �����������.
        ManualResetEvent mre1 = new ManualResetEvent(false);
        ManualResetEvent mre2 = new ManualResetEvent(false);
        ManualResetEvent mre3 = new ManualResetEvent(false);

        public delegate void ThreadStart();
        public delegate void ThreadStop();
        
        //��������� ������
        Thread myThread1;
        Thread myThread2;
        Thread myThread3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //����� ��� ������� ������
        public void MethodTr1()
        {
            Random rnd = new Random();  
            for (int i = 0; i < 100; i++)
            {
                mre1.WaitOne();
                this.Invoke(new Action(() => { listBox1.Items.Add("������ �����:" + (i).ToString()); }));
                Thread.Sleep(rnd.Next(0, 1000));
            }
        }

        //����� ��� ������� ������
        public void MethodTr2()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                mre2.WaitOne();
                this.Invoke(new Action(() => { listBox2.Items.Add("������ �����:" + (i).ToString()); }));
                Thread.Sleep(rnd.Next(1000, 2000));
            }
        }

        //����� ��� �������� ������
        public void MethodTr3()
        {
            Random rnd = new Random();
            while (true)
            {
                mre3.WaitOne();

                this.Invoke(new Action(() => 
                {
                    this.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)); 
                }));
                Thread.Sleep(rnd.Next(0, 1000));

            }
        }

        //������ ������ 1
        private void button1_Click(object sender, EventArgs e)
        {
            myThread1 = new Thread(MethodTr1);
            myThread1.Name = "Thread1";
            myThread1.Start(); // ��������� �����
            mre1.Set();
        }

        //������ ������ 2
        private void button2_Click(object sender, EventArgs e)
        {
            myThread2 = new Thread(MethodTr2);
            myThread2.Name = "Thread2";
            myThread2.Start(); // ��������� �����
            mre2.Set();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myThread3 = new Thread(MethodTr3);
            myThread3.Name = "Thread3";
            myThread3.Start(); // ��������� �����
            mre3.Set();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //������������� ManualResetEvent
            mre1.Reset();
            //���� ����� �������, ������������� ���
            if (myThread1 != null) myThread1.Abort();
            mre2.Reset();
            if (myThread2 != null) myThread2.Abort();
            mre3.Reset();
            if (myThread3 != null) myThread3.Abort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mre1.Set();
            label1.Text = "����� " + myThread1.Name + " �������";
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            mre1.Reset();
            label1.Text = "����� " + myThread1.Name + " ����������";
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mre2.Set();
            label2.Text = "����� " + myThread1.Name + " �������";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mre2.Reset();
            label2.Text = "����� " + myThread1.Name + " ����������";
        }
    }
}