using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpListener list;
        private void button1_Click_1(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 27001;
            try
            {
                list = new TcpListener(ip, port);
                list.Start();
                Thread thread = new Thread(new ThreadStart(ThreadFunction));
                thread.IsBackground = true;
                thread.Start();
                label2.Text = "Succ";
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Socket exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex.Message);
            }
        }

        void ThreadFunction()
        {
            while (true)
            {
                TcpClient cl = list.AcceptTcpClient();
                StreamReader sr = new StreamReader(
                    cl.GetStream(), Encoding.Unicode
                );
                string s = sr.ReadLine();
                messageList.Items.Add(s);
                cl.Close();
                if (s.ToUpper() == "EXIT")
                {
                    list.Stop();
                    this.Close();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (list != null)
                list.Stop();
        }
    }
}
