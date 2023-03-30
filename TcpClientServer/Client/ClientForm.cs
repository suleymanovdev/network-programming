using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 27001;
            try
            {
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                client = new TcpClient();
                client.Connect(endPoint);
                NetworkStream nstream = client.GetStream();
                byte[] barray = Encoding.Unicode.GetBytes(textBox3.Text);
                nstream.Write(barray, 0, barray.Length);
                client.Close();
                label2.Text = "Succ";
                if (textBox3.Text.ToUpper() == "EXIT")
                {
                    this.Close();
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Socket Exception:" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception :" + ex.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
            {
                client.Close();
            }
        }
    }
}
