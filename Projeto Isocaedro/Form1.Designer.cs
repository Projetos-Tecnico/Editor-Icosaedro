namespace Projeto_Isocaedro
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawPanel = new System.Windows.Forms.Panel();
            this.palettePanel = new System.Windows.Forms.Panel();
            this.panelBlack = new System.Windows.Forms.Panel();
            this.panelGray = new System.Windows.Forms.Panel();
            this.panelPurple = new System.Windows.Forms.Panel();
            this.panelOrange = new System.Windows.Forms.Panel();
            this.panelMagente = new System.Windows.Forms.Panel();
            this.panelCyan = new System.Windows.Forms.Panel();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.panelBlue = new System.Windows.Forms.Panel();
            this.panelGreen = new System.Windows.Forms.Panel();
            this.panelRed = new System.Windows.Forms.Panel();
            this.tbX = new System.Windows.Forms.TrackBar();
            this.tbY = new System.Windows.Forms.TrackBar();
            this.tbScale = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblScale = new System.Windows.Forms.Label();
            this.palettePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).BeginInit();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel.Location = new System.Drawing.Point(249, 35);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(308, 338);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            this.drawPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseClick);
            // 
            // palettePanel
            // 
            this.palettePanel.Controls.Add(this.panelBlack);
            this.palettePanel.Controls.Add(this.panelGray);
            this.palettePanel.Controls.Add(this.panelPurple);
            this.palettePanel.Controls.Add(this.panelOrange);
            this.palettePanel.Controls.Add(this.panelMagente);
            this.palettePanel.Controls.Add(this.panelCyan);
            this.palettePanel.Controls.Add(this.panelYellow);
            this.palettePanel.Controls.Add(this.panelBlue);
            this.palettePanel.Controls.Add(this.panelGreen);
            this.palettePanel.Controls.Add(this.panelRed);
            this.palettePanel.Location = new System.Drawing.Point(582, 22);
            this.palettePanel.Name = "palettePanel";
            this.palettePanel.Size = new System.Drawing.Size(200, 100);
            this.palettePanel.TabIndex = 1;
            // 
            // panelBlack
            // 
            this.panelBlack.BackColor = System.Drawing.Color.Black;
            this.panelBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBlack.Location = new System.Drawing.Point(27, 45);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(18, 17);
            this.panelBlack.TabIndex = 3;
            this.panelBlack.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelGray
            // 
            this.panelGray.BackColor = System.Drawing.Color.Gray;
            this.panelGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelGray.Location = new System.Drawing.Point(3, 45);
            this.panelGray.Name = "panelGray";
            this.panelGray.Size = new System.Drawing.Size(18, 17);
            this.panelGray.TabIndex = 3;
            this.panelGray.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelPurple
            // 
            this.panelPurple.BackColor = System.Drawing.Color.Purple;
            this.panelPurple.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelPurple.Location = new System.Drawing.Point(171, 22);
            this.panelPurple.Name = "panelPurple";
            this.panelPurple.Size = new System.Drawing.Size(18, 17);
            this.panelPurple.TabIndex = 3;
            this.panelPurple.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelOrange
            // 
            this.panelOrange.BackColor = System.Drawing.Color.Orange;
            this.panelOrange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelOrange.Location = new System.Drawing.Point(147, 22);
            this.panelOrange.Name = "panelOrange";
            this.panelOrange.Size = new System.Drawing.Size(18, 17);
            this.panelOrange.TabIndex = 3;
            this.panelOrange.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelMagente
            // 
            this.panelMagente.BackColor = System.Drawing.Color.Magenta;
            this.panelMagente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelMagente.Location = new System.Drawing.Point(123, 22);
            this.panelMagente.Name = "panelMagente";
            this.panelMagente.Size = new System.Drawing.Size(18, 17);
            this.panelMagente.TabIndex = 3;
            this.panelMagente.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelCyan
            // 
            this.panelCyan.BackColor = System.Drawing.Color.Cyan;
            this.panelCyan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelCyan.Location = new System.Drawing.Point(99, 22);
            this.panelCyan.Name = "panelCyan";
            this.panelCyan.Size = new System.Drawing.Size(18, 17);
            this.panelCyan.TabIndex = 3;
            this.panelCyan.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelYellow
            // 
            this.panelYellow.BackColor = System.Drawing.Color.Yellow;
            this.panelYellow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelYellow.Location = new System.Drawing.Point(75, 22);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(18, 17);
            this.panelYellow.TabIndex = 3;
            this.panelYellow.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelBlue
            // 
            this.panelBlue.BackColor = System.Drawing.Color.Blue;
            this.panelBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBlue.Location = new System.Drawing.Point(51, 22);
            this.panelBlue.Name = "panelBlue";
            this.panelBlue.Size = new System.Drawing.Size(18, 17);
            this.panelBlue.TabIndex = 2;
            this.panelBlue.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelGreen
            // 
            this.panelGreen.BackColor = System.Drawing.Color.Lime;
            this.panelGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelGreen.Location = new System.Drawing.Point(27, 22);
            this.panelGreen.Name = "panelGreen";
            this.panelGreen.Size = new System.Drawing.Size(18, 17);
            this.panelGreen.TabIndex = 1;
            this.panelGreen.Click += new System.EventHandler(this.Form1_Click);
            // 
            // panelRed
            // 
            this.panelRed.BackColor = System.Drawing.Color.Red;
            this.panelRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRed.Location = new System.Drawing.Point(3, 22);
            this.panelRed.Name = "panelRed";
            this.panelRed.Size = new System.Drawing.Size(18, 17);
            this.panelRed.TabIndex = 0;
            this.panelRed.Click += new System.EventHandler(this.Form1_Click);
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(41, 22);
            this.tbX.Maximum = 180;
            this.tbX.Minimum = -180;
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(104, 45);
            this.tbX.TabIndex = 2;
            this.tbX.ValueChanged += new System.EventHandler(this.tbX_ValueChanged);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(41, 67);
            this.tbY.Maximum = 180;
            this.tbY.Minimum = -180;
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(104, 45);
            this.tbY.TabIndex = 3;
            this.tbY.ValueChanged += new System.EventHandler(this.tbY_ValueChanged);
            // 
            // tbScale
            // 
            this.tbScale.Location = new System.Drawing.Point(41, 130);
            this.tbScale.Maximum = 250;
            this.tbScale.Minimum = 30;
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(104, 45);
            this.tbScale.TabIndex = 4;
            this.tbScale.Value = 100;
            this.tbScale.ValueChanged += new System.EventHandler(this.tbScale_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(65, 195);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(78, 13);
            this.lblX.TabIndex = 6;
            this.lblX.Text = "Girar Eixo X: 0°";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(68, 230);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(78, 13);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "Girar Eixo Y: 0°";
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(68, 257);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(71, 13);
            this.lblScale.TabIndex = 8;
            this.lblScale.Text = "Escala: 100%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbScale);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.palettePanel);
            this.Controls.Add(this.drawPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Click += new System.EventHandler(this.Form1_Click);
            this.palettePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Panel palettePanel;
        private System.Windows.Forms.Panel panelBlue;
        private System.Windows.Forms.Panel panelGreen;
        private System.Windows.Forms.Panel panelRed;
        private System.Windows.Forms.Panel panelBlack;
        private System.Windows.Forms.Panel panelGray;
        private System.Windows.Forms.Panel panelPurple;
        private System.Windows.Forms.Panel panelOrange;
        private System.Windows.Forms.Panel panelMagente;
        private System.Windows.Forms.Panel panelCyan;
        private System.Windows.Forms.Panel panelYellow;
        private System.Windows.Forms.TrackBar tbX;
        private System.Windows.Forms.TrackBar tbY;
        private System.Windows.Forms.TrackBar tbScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblScale;
    }
}

