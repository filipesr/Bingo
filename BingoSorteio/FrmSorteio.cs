using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingoSorteio
{
    public partial class FrmSorteio : Form
    {
        List<int> lstNum = new List<int>();

        public FrmSorteio()
        {
            InitializeComponent();
            InicializaNumeros();
        }

        private void InicializaNumeros()
        {
            lbPedrasOrdenadas.Items.Clear();
            lbPedras.Items.Clear();
            lstNum.Clear();
            for (int i = 1; i < 91; i++)
            {
                lstNum.Add(i);
            }
        }

        private void FrmSorteio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                InicializaNumeros();
                lPedraSorteada.Text = "";
            }
            else if (e.KeyCode == Keys.Space)
            {
                timer1.Interval = 1;
                timer1.Enabled = true;
                lPedraSorteada.ForeColor = Color.Black;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int i = new Random().Next(0, lstNum.Count);
            int num = lstNum[i];
            string str = "0";
            if (num > 9)
                str = "";
            str += num;
            lPedraSorteada.Text = str;
            if(timer1.Interval < 200)
                timer1.Interval += 5;
            else
                timer1.Interval += 300;
            if (timer1.Interval > 500)
            {
                lbPedrasOrdenadas.Items.Add(str);
                lbPedras.Items.Add(str);
                lPedraSorteada.ForeColor = Color.Red;
                lstNum.RemoveAt(i);
                timer1.Interval = 1;
                timer1.Enabled = false;
            }
        }


    }
}
