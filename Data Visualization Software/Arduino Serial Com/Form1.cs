using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Media;

namespace Arduino_Serial_Com
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            int k = ports.Length;
            int i = 0;
            comboBox2.Items.Clear();
            for (i = 0; i < k; i++)
            {
                comboBox2.Items.Add(ports[i]) ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.BaudRate = int.Parse(comboBox1.Text);
                serialPort1.PortName = comboBox2.Text;
                serialPort1.Close();
                serialPort1.Open();
                serialPort1.WriteLine(textBox2.Text);
                textBox2.Clear();
                serialPort1.Close();
            }
            catch
            {
                MessageBox.Show("No device found. Check Baud Rate and Port", "Warning!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.BaudRate = int.Parse(comboBox1.Text);
                serialPort1.PortName = comboBox2.Text;
                serialPort1.Open();
                SystemSounds.Beep.Play();
                textBox1.Text = comboBox2.Text + " Is Ready To Receive Incoming Data \r\n";
            }
            catch
            {
                MessageBox.Show("No device found. Check Baud Rate and Port", "Warning!!!");
            }

        }
        public void txt_add()
        {
            string k = serialPort1.ReadLine();
            this.textBox1.Text = this.textBox1.Text + k;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            txt_add();
        }
    }
}
