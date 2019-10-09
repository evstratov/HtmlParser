using HTMLParser.Core;
using HTMLParser.Core.Habr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserHtml
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new HabrParser());

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }
        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Done");
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.AddRange(arg2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            parser.Settings = new HabrSettings(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            parser.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
