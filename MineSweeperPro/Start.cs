using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Start : ThemedForm
    {
        public Start()
        {
            InitializeComponent();

            ApplyTheme(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
