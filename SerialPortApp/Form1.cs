using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;

namespace SerialPortApp
{
    public partial class Form1 : Form
    {
        string RxString;
        SerialPort mySerPort = new SerialPort();    //create a Serial Port object

        public Form1()
        {
            InitializeComponent();
            mySerPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mySerPort.IsOpen) mySerPort.Close();
        }

        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RxString = mySerPort.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox2.AppendText(RxString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mySerPort.IsOpen == false)
            {
                mySerPort.PortName = "COM" + textBox3.Text;

                try
                {
                    mySerPort.Open();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            try
            {
                mySerPort.Write(textBox1.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //mySerPort.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
