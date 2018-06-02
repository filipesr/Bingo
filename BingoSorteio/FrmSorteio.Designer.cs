namespace BingoSorteio
{
    partial class FrmSorteio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lPedraSorteada = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbPedrasOrdenadas = new System.Windows.Forms.ListBox();
            this.lbPedras = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lPedraSorteada
            // 
            this.lPedraSorteada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPedraSorteada.Font = new System.Drawing.Font("Arial", 200F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPedraSorteada.Location = new System.Drawing.Point(0, 0);
            this.lPedraSorteada.Name = "lPedraSorteada";
            this.lPedraSorteada.Size = new System.Drawing.Size(781, 396);
            this.lPedraSorteada.TabIndex = 0;
            this.lPedraSorteada.Text = "00";
            this.lPedraSorteada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lbPedrasOrdenadas
            // 
            this.lbPedrasOrdenadas.ColumnWidth = 20;
            this.lbPedrasOrdenadas.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbPedrasOrdenadas.FormattingEnabled = true;
            this.lbPedrasOrdenadas.Location = new System.Drawing.Point(0, 0);
            this.lbPedrasOrdenadas.MultiColumn = true;
            this.lbPedrasOrdenadas.Name = "lbPedrasOrdenadas";
            this.lbPedrasOrdenadas.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbPedrasOrdenadas.Size = new System.Drawing.Size(70, 396);
            this.lbPedrasOrdenadas.Sorted = true;
            this.lbPedrasOrdenadas.TabIndex = 1;
            // 
            // lbPedras
            // 
            this.lbPedras.ColumnWidth = 20;
            this.lbPedras.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbPedras.FormattingEnabled = true;
            this.lbPedras.Location = new System.Drawing.Point(711, 0);
            this.lbPedras.MultiColumn = true;
            this.lbPedras.Name = "lbPedras";
            this.lbPedras.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbPedras.Size = new System.Drawing.Size(70, 396);
            this.lbPedras.TabIndex = 2;
            // 
            // FrmSorteio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 396);
            this.Controls.Add(this.lbPedras);
            this.Controls.Add(this.lbPedrasOrdenadas);
            this.Controls.Add(this.lPedraSorteada);
            this.KeyPreview = true;
            this.Name = "FrmSorteio";
            this.Text = "Bingo Sorteio - by FSRezende.com.br";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSorteio_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lPedraSorteada;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lbPedrasOrdenadas;
        private System.Windows.Forms.ListBox lbPedras;
    }
}

