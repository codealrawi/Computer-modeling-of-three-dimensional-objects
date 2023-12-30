using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form2 form2 = new WindowsFormsApplication1.Form2
            {

                // Прямоугольник, в котором будет выведен график функции
                left = 20,
                top = 20,
                width = 300,
                height = 300,

                f_show = false,
                x0 = 0,
                y0 = 0,
                z0 = 0,
                A = -8,
                alfa = 10,
                beta = 12,
                X_min = -3,
                X_max = 3,
                Y_min = -3,
                Y_max = 3
            };
            form2.ShowDialog();
        }
    }
}
