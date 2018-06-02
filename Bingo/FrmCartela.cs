using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingo
{
    public partial class FrmCartela : Form
    {
        int numCartela = 0;
        string nomeCartela = "Cartela {0} ({1}/15)";
        string msgPedraRepetida = "Deseja remover o número {0}?";
        string msgTituloPedraRepetida = "Esta Pedra já foi cantada!";
        List<int> listNum = new List<int>();

        List<GroupBox> listGB = new List<GroupBox>();
        Dictionary<string, Cartela> dicCartelas = new Dictionary<string, Cartela>();
        List<Cartela> listCartelas = new List<Cartela>();

        public FrmCartela()
        {
            InitializeComponent();
            listGB.Add(gbCartela1);
            listGB.Add(gbCartela2);
            listGB.Add(gbCartela3);
            listGB.Add(gbCartela4);
            LimpaPedras();
            CarregaCartelas();
            InicializaNumeros();
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            lbPedrasOrdenadas.Items.Clear();
            lbPedras.Items.Clear();
            LimpaPedras();
            InicializaNumeros();
            numCartela = 0;
        }

        private void TbPedra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string str = tbPedra.Text.ToUpper().Trim();
                tbPedra.Text = "";
                int num;
                if (int.TryParse(str, out num))
                {
                    if (num > 0)
                    {
                        if (num < 10)
                            str = "0" + num;
                        // Número não 
                        if (num <= 90 && lbPedrasOrdenadas.Items.IndexOf(str) < 0)
                        {
                            lbPedrasOrdenadas.Items.Add(str);
                            lbPedras.Items.Add(str);
                            MarcaPedra(str);
                            listNum.Remove(num);
                        }
                        else if (MessageBox.Show(string.Format(msgPedraRepetida, str), msgTituloPedraRepetida, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        {
                            lbPedrasOrdenadas.Items.Remove(str);
                            lbPedras.Items.Remove(str);
                            DesmarcaPedra(str);
                            listNum.Add(num);
                        }

                    }
                } else
                {
                    if (dicCartelas.ContainsKey(str))
                        PreencheCartela(dicCartelas[str]);
                }
            }
            else if (e.KeyChar == (char)Keys.Space)
            {
                if (listNum.Count > 0)
                {
                    int i = new Random().Next(0, listNum.Count);
                    int num = listNum[i];
                    string str = "0";
                    if (num > 9)
                        str = "";
                    str += num;
                    tbPedra.Text = str;
                }
            }
        }

        private void InicializaNumeros()
        {
            listNum.Clear();
            for (int i = 1; i < 91; i++)
            {
                listNum.Add(i);
            }
        }

        private void LimpaPedras()
        {
            int i = 1;
            foreach (GroupBox gb in listGB)
            {
                gb.Text = "Cartela " + i++;

                foreach (Panel pn in gb.Controls.OfType<Panel>())
                {
                    pn.BackColor = FrmCartela.DefaultBackColor;
                }

                foreach (TextBox tb in GetTextBoxControls(gb))
                {
                    gb.Tag = 0;
                    tb.BackColor = Color.White;
                    tb.Text = "";
                }
            }
        }

        private List<TextBox> GetTextBoxControls(Control controlePai)
        {
            List<TextBox> lstTextBox = new List<TextBox>();
            lstTextBox.AddRange(controlePai.Controls.OfType<TextBox>());
            return lstTextBox;
        }

        private void CarregaCartelas()
        {
            StreamReader sr = File.OpenText("lstCartelas.txt");
            List<string> lCartela = new List<string>();
            while (!sr.EndOfStream)
                lCartela.Add(sr.ReadLine());
            sr.Close();

            foreach (string cartela in lCartela)
            {
                if (cartela.Trim().Length > 0 && cartela.IndexOf(';') > 0)
                {
                    string[] tmp = cartela.Split(';');
                    if (!dicCartelas.ContainsKey(tmp[0]))
                    {
                        Cartela c = new Cartela(tmp[0], tmp[1]);
                        dicCartelas.Add(c.GetCodigo(), c);
                        listCartelas.Add(c);
                    }
                }
            }
        }

        private void MarcaPedra(string str)
        {
            // marca cartelas da tela
            foreach (GroupBox gb in listGB)
            {
                foreach (TextBox tb in GetTextBoxControls(gb))
                {
                    if (tb.Text.CompareTo(str) == 0)
                    {
                        tb.BackColor = Color.Tomato;
                        // Cartela A-3 (0/15)
                        try
                        {
                            Cartela cart = (Cartela)gb.Tag;
                            int i = cart.MarcaPedra(int.Parse(str));
                            string nome = gb.Text;
                            nome = nome.Split('(')[0] + "(" + i + "/" + nome.Split('/')[1];
                            gb.Text = nome;
                            foreach (Panel pn in gb.Controls.OfType<Panel>())
                            {
                                if (cart.FileiraFechada(pn.TabIndex))
                                    pn.BackColor = Color.Tomato;
                            }
                        }
                        catch (Exception)
                        {
                        }

                    }
                }
            }
            // marca cartelas armazenadas
//            int n = int.Parse(str);
//            int qtde14 = 0,
//                qtde15 = 0;
//            string cod15 = string.Empty,
//                cod14 = string.Empty;
//            foreach (Cartela c in listCartelas)
//            {
//                int ns = c.NumerosSorteados(n);
//                if (ns == 14)
//                {
//                    qtde14++;
//                    if (!string.IsNullOrEmpty(cod14))
//                        cod14 += ", ";
//                     cod14 += c.GetCodigo();
//                }
//                else if (ns == 15)
//                {
//                    qtde15++;
//                    if (!string.IsNullOrEmpty(cod15))
//                        cod15 += ", ";
//                    cod15 += c.GetCodigo();
//                }
//            }
//            if (qtde14 > 0 || qtde15 > 0)
//            {
//                MessageBox.Show("Já temos " + qtde15 + " cartelas sorteadas: " + cod15 + @"
//e " + qtde14 + " cartelas por uma: " + cod14);
//            }
        }

        private void DesmarcaPedra(string str)
        {
            // desmarca cartelas da tela
            foreach (GroupBox gb in listGB)
            {
                foreach (TextBox tb in GetTextBoxControls(gb))
                {
                    if (tb.Text.CompareTo(str) == 0)
                    {
                        tb.BackColor = Color.White;
                        try
                        {
                            Cartela cart = (Cartela)gb.Tag;
                            int i = cart.DesmarcaPedra(int.Parse(str));
                            // Cartela A-3 (0/15)
                            string nome = gb.Text;
                            nome = nome.Split('(')[0] + "(" + i + "/" + nome.Split('/')[1];
                            gb.Text = nome;
                            foreach (Panel pn in gb.Controls.OfType<Panel>())
                            {
                                if (cart.FileiraFechada(pn.TabIndex))
                                    pn.BackColor = Color.Tomato;
                                else
                                    pn.BackColor = FrmCartela.DefaultBackColor;
                            }

                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        private void PreencheCartela(Cartela cartela)
        {
            if (numCartela > 3)
                numCartela = 0;
            GroupBox gb = listGB[numCartela++];

            gb.Tag = cartela;
            gb.Text = string.Format(nomeCartela, cartela.GetCodigo(), cartela.NumerosSorteados());

            foreach (TextBox tb in GetTextBoxControls(gb))
            {
                int nAtual = (cartela.GetNumeros())[tb.TabIndex];
                if (nAtual == 0)
                    tb.Text = "";
                else
                {
                    if (nAtual < 10)
                        tb.Text = "0";
                    tb.Text += "" + nAtual;
                }
            }
        }

    }
}
