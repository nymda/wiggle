using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wiggle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread a = new Thread(() => thread());
            a.IsBackground = true;
            a.Start();

        }

        public void thread()
        {
            Random r = new Random();
            for (; ; )
            {
                int current = r.Next(10, 1000);
                int size = 10;
                Thread.Sleep(1);
                //this.Invoke(new MethodInvoker(delegate ()
                //{
                     //this.Size = new Size(20, current);
                //}));

                for (int i = 10; i < current; i = i + 15)
                {
                    Thread.Sleep(1);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.Size = new Size(20, i);
                    }));
                }
                for (int i = current; i > 10; i = i - 15)
                {
                    Thread.Sleep(1);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.Size = new Size(20, i);
                    }));
                }
            }
        }
    }
}
