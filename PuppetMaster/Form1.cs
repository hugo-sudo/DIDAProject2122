using Grpc.Net.Client;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuppetMaster
{
    public partial class Form1 : Form
    {
        private string schedulerUrl;
        public Form1()
        {
            InitializeComponent();
            schedulerUrl = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // funcao para lançar Scheduler
        private void button1_Click(object sender, EventArgs e)
        {
            Process scheduler = new Process();
            scheduler.StartInfo.FileName = @"C:\Users\tomas\OneDrive\Área de Trabalho\Técnico\Semestre1\DAD\Projeto\DIDAProject2122\Scheduler\bin\Debug\netcoreapp3.1\Scheduler.exe";
            scheduler.StartInfo.Arguments = textBox2.Text;
            schedulerUrl = textBox2.Text;
            scheduler.Start();
            
        }

        //funcao para mandar um client request para o Scheduler
        private void button2_Click(object sender, EventArgs e)
        {
            // setup the client side
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            GrpcChannel channel = GrpcChannel.ForAddress("http://" + schedulerUrl);

            var client = new DIDASchedulerService.DIDASchedulerServiceClient(channel);

            client.receiveClientRequest(new DIDARequest { Input = textBox4.Text, ApplicationFile = textBox3.Text});
         


        }

        // funcao para lançar Worker
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
