using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace ServidorrGrados
{
    public partial class Form1 : Form
    {
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9040);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Connect(ipep);
            this.BackColor = Color.Green;

           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Celsius.Checked)
            {
                if (numero2.Text == null)
                {
                    MessageBox.Show("No ha insertado un numero para convertir");
                }
                else
                {
                    string mensaje = "1/" + numero2.Text + "/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("El resultado en Celsius es" + mensaje);
                }
            }
            else
            {
                if (numero.Text == null)
                {
                    MessageBox.Show("No ha insertado un numero para convertir");
                }
                else
                {
                    string mensaje = "2/" + numero.Text + "/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("El resultado en Farenheit es" + mensaje);
                }
               
            }

        }
    }
}
