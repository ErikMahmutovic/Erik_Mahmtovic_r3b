using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankomat
{
    public partial class izpis : Form
    {
        public izpis()
        {
            InitializeComponent();
        }

        private void izpis_Load(object sender, EventArgs e)
        {
            DateTime datum = DateTime.Now;
            label7.Text = datum.ToString();
        }
        public string st_racuna
        {
            get
            {
                return this.label5.Text;
            }
            set
            {
                this.label5.Text = value;
            }
        }
        public string znesek_racuna
        {
            get
            {
                return this.label10.Text;
            }
            set
            {
                this.label10.Text = value;
            }
        }
    }
    
}
