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
        private Dictionary<string, string> workers_servers;
        private string schedulerUrl;
        public Form1()
        {
            InitializeComponent();
            workers_servers = new Dictionary<string, string>();
            schedulerUrl = "";
        }

     
        // funcao para lançar Scheduler
        private void button1_Click(object sender, EventArgs e)
        {
            Process scheduler = new Process();
            scheduler.StartInfo.FileName = "../../../../Scheduler/bin/Debug/netcoreapp3.1/Scheduler.exe";
            schedulerUrl = textBox2.Text;

            string args = textBox2.Text + " " + textBox7.Text;

            foreach (var item in workers_servers)
            {
                args += " " + item.Key + "|" + item.Value;
            }

            
            scheduler.StartInfo.Arguments = args;

            
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
            Process worker = new Process();
            worker.StartInfo.FileName = "../../../../Worker/bin/Debug/netcoreapp3.1/Worker.exe";
            worker.StartInfo.Arguments = textBox1.Text + " " + textBox5.Text + " " + textBox6.Text;

            workers_servers.Add(textBox1.Text, textBox5.Text);

            worker.Start();
        }

        
       
    }
}
