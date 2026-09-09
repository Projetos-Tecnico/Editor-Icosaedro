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
            this.pnlControles = new System.Windows.Forms.Panel();
            this.lblFaces = new System.Windows.Forms.Label();
            this.btnFace1 = new System.Windows.Forms.Button();
            this.btnFace2 = new System.Windows.Forms.Button();
            this.btnFace3 = new System.Windows.Forms.Button();
            this.btnFace4 = new System.Windows.Forms.Button();
            this.btnFace5 = new System.Windows.Forms.Button();
            this.btnFace6 = new System.Windows.Forms.Button();
            this.btnFace7 = new System.Windows.Forms.Button();
            this.btnFace8 = new System.Windows.Forms.Button();
            this.btnFace9 = new System.Windows.Forms.Button();
            this.btnFace10 = new System.Windows.Forms.Button();
            this.lblCores = new System.Windows.Forms.Label();
            this.panelRed = new System.Windows.Forms.Panel();
            this.panelGreen = new System.Windows.Forms.Panel();
            this.panelBlue = new System.Windows.Forms.Panel();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.panelCyan = new System.Windows.Forms.Panel();
            this.panelMagenta = new System.Windows.Forms.Panel();
            this.panelOrange = new System.Windows.Forms.Panel();
            this.panelPurple = new System.Windows.Forms.Panel();
            this.panelBlack = new System.Windows.Forms.Panel();
            this.panelGray = new System.Windows.Forms.Panel();
            this.btnAplicarCores = new System.Windows.Forms.Button();
            this.lblTransX = new System.Windows.Forms.Label();
            this.tbTransX = new System.Windows.Forms.TrackBar();
            this.lblTransY = new System.Windows.Forms.Label();
            this.tbTransY = new System.Windows.Forms.TrackBar();
            this.lblScale = new System.Windows.Forms.Label();
            this.tbScale = new System.Windows.Forms.TrackBar();
            this.pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTransX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTransY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).BeginInit();
            this.SuspendLayout();
            //
            // drawPanel
            //
            this.drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawPanel.BackColor = System.Drawing.Color.White;
            this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel.Location = new System.Drawing.Point(12, 12);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(812, 676);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            this.drawPanel.Resize += new System.EventHandler(this.drawPanel_Resize);
            //
            // pnlControles
            //
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.Controls.Add(this.lblFaces);
            this.pnlControles.Controls.Add(this.btnFace1);
            this.pnlControles.Controls.Add(this.btnFace2);
            this.pnlControles.Controls.Add(this.btnFace3);
            this.pnlControles.Controls.Add(this.btnFace4);
            this.pnlControles.Controls.Add(this.btnFace5);
            this.pnlControles.Controls.Add(this.btnFace6);
            this.pnlControles.Controls.Add(this.btnFace7);
            this.pnlControles.Controls.Add(this.btnFace8);
            this.pnlControles.Controls.Add(this.btnFace9);
            this.pnlControles.Controls.Add(this.btnFace10);
            this.pnlControles.Controls.Add(this.lblCores);
            this.pnlControles.Controls.Add(this.panelRed);
            this.pnlControles.Controls.Add(this.panelGreen);
            this.pnlControles.Controls.Add(this.panelBlue);
            this.pnlControles.Controls.Add(this.panelYellow);
            this.pnlControles.Controls.Add(this.panelCyan);
            this.pnlControles.Controls.Add(this.panelMagenta);
            this.pnlControles.Controls.Add(this.panelOrange);
            this.pnlControles.Controls.Add(this.panelPurple);
            this.pnlControles.Controls.Add(this.panelBlack);
            this.pnlControles.Controls.Add(this.panelGray);
            this.pnlControles.Controls.Add(this.btnAplicarCores);
            this.pnlControles.Controls.Add(this.lblTransX);
            this.pnlControles.Controls.Add(this.tbTransX);
            this.pnlControles.Controls.Add(this.lblTransY);
            this.pnlControles.Controls.Add(this.tbTransY);
            this.pnlControles.Controls.Add(this.lblScale);
            this.pnlControles.Controls.Add(this.tbScale);
            this.pnlControles.Location = new System.Drawing.Point(836, 12);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(364, 676);
            this.pnlControles.TabIndex = 1;
            //
            // lblFaces
            //
            this.lblFaces.AutoSize = true;
            this.lblFaces.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFaces.Location = new System.Drawing.Point(8, 4);
            this.lblFaces.Name = "lblFaces";
            this.lblFaces.Size = new System.Drawing.Size(133, 17);
            this.lblFaces.TabIndex = 0;
            this.lblFaces.Text = "Faces do icosaedro";
            //
            // btnFace1
            //
            this.btnFace1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace1.Location = new System.Drawing.Point(8, 26);
            this.btnFace1.Name = "btnFace1";
            this.btnFace1.Size = new System.Drawing.Size(64, 44);
            this.btnFace1.TabIndex = 1;
            this.btnFace1.Text = "1";
            this.btnFace1.UseVisualStyleBackColor = true;
            this.btnFace1.Click += new System.EventHandler(this.btnFace1_Click);
            //
            // btnFace2
            //
            this.btnFace2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace2.Location = new System.Drawing.Point(78, 26);
            this.btnFace2.Name = "btnFace2";
            this.btnFace2.Size = new System.Drawing.Size(64, 44);
            this.btnFace2.TabIndex = 2;
            this.btnFace2.Text = "2";
            this.btnFace2.UseVisualStyleBackColor = true;
            this.btnFace2.Click += new System.EventHandler(this.btnFace2_Click);
            //
            // btnFace3
            //
            this.btnFace3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace3.Location = new System.Drawing.Point(148, 26);
            this.btnFace3.Name = "btnFace3";
            this.btnFace3.Size = new System.Drawing.Size(64, 44);
            this.btnFace3.TabIndex = 3;
            this.btnFace3.Text = "3";
            this.btnFace3.UseVisualStyleBackColor = true;
            this.btnFace3.Click += new System.EventHandler(this.btnFace3_Click);
            //
            // btnFace4
            //
            this.btnFace4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace4.Location = new System.Drawing.Point(218, 26);
            this.btnFace4.Name = "btnFace4";
            this.btnFace4.Size = new System.Drawing.Size(64, 44);
            this.btnFace4.TabIndex = 4;
            this.btnFace4.Text = "4";
            this.btnFace4.UseVisualStyleBackColor = true;
            this.btnFace4.Click += new System.EventHandler(this.btnFace4_Click);
            //
            // btnFace5
            //
            this.btnFace5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace5.Location = new System.Drawing.Point(288, 26);
            this.btnFace5.Name = "btnFace5";
            this.btnFace5.Size = new System.Drawing.Size(64, 44);
            this.btnFace5.TabIndex = 5;
            this.btnFace5.Text = "5";
            this.btnFace5.UseVisualStyleBackColor = true;
            this.btnFace5.Click += new System.EventHandler(this.btnFace5_Click);
            //
            // btnFace6
            //
            this.btnFace6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace6.Location = new System.Drawing.Point(8, 76);
            this.btnFace6.Name = "btnFace6";
            this.btnFace6.Size = new System.Drawing.Size(64, 44);
            this.btnFace6.TabIndex = 6;
            this.btnFace6.Text = "6";
            this.btnFace6.UseVisualStyleBackColor = true;
            this.btnFace6.Click += new System.EventHandler(this.btnFace6_Click);
            //
            // btnFace7
            //
            this.btnFace7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace7.Location = new System.Drawing.Point(78, 76);
            this.btnFace7.Name = "btnFace7";
            this.btnFace7.Size = new System.Drawing.Size(64, 44);
            this.btnFace7.TabIndex = 7;
            this.btnFace7.Text = "7";
            this.btnFace7.UseVisualStyleBackColor = true;
            this.btnFace7.Click += new System.EventHandler(this.btnFace7_Click);
            //
            // btnFace8
            //
            this.btnFace8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace8.Location = new System.Drawing.Point(148, 76);
            this.btnFace8.Name = "btnFace8";
            this.btnFace8.Size = new System.Drawing.Size(64, 44);
            this.btnFace8.TabIndex = 8;
            this.btnFace8.Text = "8";
            this.btnFace8.UseVisualStyleBackColor = true;
            this.btnFace8.Click += new System.EventHandler(this.btnFace8_Click);
            //
            // btnFace9
            //
            this.btnFace9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace9.Location = new System.Drawing.Point(218, 76);
            this.btnFace9.Name = "btnFace9";
            this.btnFace9.Size = new System.Drawing.Size(64, 44);
            this.btnFace9.TabIndex = 9;
            this.btnFace9.Text = "9";
            this.btnFace9.UseVisualStyleBackColor = true;
            this.btnFace9.Click += new System.EventHandler(this.btnFace9_Click);
            //
            // btnFace10
            //
            this.btnFace10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFace10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFace10.Location = new System.Drawing.Point(288, 76);
            this.btnFace10.Name = "btnFace10";
            this.btnFace10.Size = new System.Drawing.Size(64, 44);
            this.btnFace10.TabIndex = 10;
            this.btnFace10.Text = "10";
            this.btnFace10.UseVisualStyleBackColor = true;
            this.btnFace10.Click += new System.EventHandler(this.btnFace10_Click);
            //
            // lblCores
            //
            this.lblCores.AutoSize = true;
            this.lblCores.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCores.Location = new System.Drawing.Point(8, 132);
            this.lblCores.Name = "lblCores";
            this.lblCores.Size = new System.Drawing.Size(112, 17);
            this.lblCores.TabIndex = 11;
            this.lblCores.Text = "Paleta de cores";
            //
            // panelRed
            //
            this.panelRed.BackColor = System.Drawing.Color.Red;
            this.panelRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRed.Location = new System.Drawing.Point(8, 154);
            this.panelRed.Name = "panelRed";
            this.panelRed.Size = new System.Drawing.Size(64, 40);
            this.panelRed.TabIndex = 12;
            this.panelRed.Click += new System.EventHandler(this.panelRed_Click);
            //
            // panelGreen
            //
            this.panelGreen.BackColor = System.Drawing.Color.Lime;
            this.panelGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelGreen.Location = new System.Drawing.Point(78, 154);
            this.panelGreen.Name = "panelGreen";
            this.panelGreen.Size = new System.Drawing.Size(64, 40);
            this.panelGreen.TabIndex = 13;
            this.panelGreen.Click += new System.EventHandler(this.panelGreen_Click);
            //
            // panelBlue
            //
            this.panelBlue.BackColor = System.Drawing.Color.Blue;
            this.panelBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBlue.Location = new System.Drawing.Point(148, 154);
            this.panelBlue.Name = "panelBlue";
            this.panelBlue.Size = new System.Drawing.Size(64, 40);
            this.panelBlue.TabIndex = 14;
            this.panelBlue.Click += new System.EventHandler(this.panelBlue_Click);
            //
            // panelYellow
            //
            this.panelYellow.BackColor = System.Drawing.Color.Yellow;
            this.panelYellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelYellow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelYellow.Location = new System.Drawing.Point(218, 154);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(64, 40);
            this.panelYellow.TabIndex = 15;
            this.panelYellow.Click += new System.EventHandler(this.panelYellow_Click);
            //
            // panelCyan
            //
            this.panelCyan.BackColor = System.Drawing.Color.Cyan;
            this.panelCyan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCyan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelCyan.Location = new System.Drawing.Point(288, 154);
            this.panelCyan.Name = "panelCyan";
            this.panelCyan.Size = new System.Drawing.Size(64, 40);
            this.panelCyan.TabIndex = 16;
            this.panelCyan.Click += new System.EventHandler(this.panelCyan_Click);
            //
            // panelMagenta
            //
            this.panelMagenta.BackColor = System.Drawing.Color.Magenta;
            this.panelMagenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMagenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelMagenta.Location = new System.Drawing.Point(8, 200);
            this.panelMagenta.Name = "panelMagenta";
            this.panelMagenta.Size = new System.Drawing.Size(64, 40);
            this.panelMagenta.TabIndex = 17;
            this.panelMagenta.Click += new System.EventHandler(this.panelMagenta_Click);
            //
            // panelOrange
            //
            this.panelOrange.BackColor = System.Drawing.Color.Orange;
            this.panelOrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelOrange.Location = new System.Drawing.Point(78, 200);
            this.panelOrange.Name = "panelOrange";
            this.panelOrange.Size = new System.Drawing.Size(64, 40);
            this.panelOrange.TabIndex = 18;
            this.panelOrange.Click += new System.EventHandler(this.panelOrange_Click);
            //
            // panelPurple
            //
            this.panelPurple.BackColor = System.Drawing.Color.Purple;
            this.panelPurple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPurple.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelPurple.Location = new System.Drawing.Point(148, 200);
            this.panelPurple.Name = "panelPurple";
            this.panelPurple.Size = new System.Drawing.Size(64, 40);
            this.panelPurple.TabIndex = 19;
            this.panelPurple.Click += new System.EventHandler(this.panelPurple_Click);
            //
            // panelBlack
            //
            this.panelBlack.BackColor = System.Drawing.Color.Black;
            this.panelBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBlack.Location = new System.Drawing.Point(218, 200);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(64, 40);
            this.panelBlack.TabIndex = 20;
            this.panelBlack.Click += new System.EventHandler(this.panelBlack_Click);
            //
            // panelGray
            //
            this.panelGray.BackColor = System.Drawing.Color.Gray;
            this.panelGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelGray.Location = new System.Drawing.Point(288, 200);
            this.panelGray.Name = "panelGray";
            this.panelGray.Size = new System.Drawing.Size(64, 40);
            this.panelGray.TabIndex = 21;
            this.panelGray.Click += new System.EventHandler(this.panelGray_Click);
            //
            // btnAplicarCores
            //
            this.btnAplicarCores.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAplicarCores.Location = new System.Drawing.Point(8, 252);
            this.btnAplicarCores.Name = "btnAplicarCores";
            this.btnAplicarCores.Size = new System.Drawing.Size(344, 42);
            this.btnAplicarCores.TabIndex = 22;
            this.btnAplicarCores.Text = "Aplicar cores";
            this.btnAplicarCores.UseVisualStyleBackColor = true;
            this.btnAplicarCores.Click += new System.EventHandler(this.btnAplicarCores_Click);
            //
            // lblTransX
            //
            this.lblTransX.AutoSize = true;
            this.lblTransX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTransX.Location = new System.Drawing.Point(8, 312);
            this.lblTransX.Name = "lblTransX";
            this.lblTransX.Size = new System.Drawing.Size(102, 17);
            this.lblTransX.TabIndex = 23;
            this.lblTransX.Text = "Translação X: 0";
            //
            // tbTransX
            //
            this.tbTransX.Location = new System.Drawing.Point(5, 332);
            this.tbTransX.Maximum = 400;
            this.tbTransX.Minimum = -400;
            this.tbTransX.Name = "tbTransX";
            this.tbTransX.Size = new System.Drawing.Size(350, 45);
            this.tbTransX.TabIndex = 24;
            this.tbTransX.TickFrequency = 50;
            this.tbTransX.ValueChanged += new System.EventHandler(this.tbTransX_ValueChanged);
            //
            // lblTransY
            //
            this.lblTransY.AutoSize = true;
            this.lblTransY.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTransY.Location = new System.Drawing.Point(8, 384);
            this.lblTransY.Name = "lblTransY";
            this.lblTransY.Size = new System.Drawing.Size(102, 17);
            this.lblTransY.TabIndex = 25;
            this.lblTransY.Text = "Translação Y: 0";
            //
            // tbTransY
            //
            this.tbTransY.Location = new System.Drawing.Point(5, 404);
            this.tbTransY.Maximum = 400;
            this.tbTransY.Minimum = -400;
            this.tbTransY.Name = "tbTransY";
            this.tbTransY.Size = new System.Drawing.Size(350, 45);
            this.tbTransY.TabIndex = 26;
            this.tbTransY.TickFrequency = 50;
            this.tbTransY.ValueChanged += new System.EventHandler(this.tbTransY_ValueChanged);
            //
            // lblScale
            //
            this.lblScale.AutoSize = true;
            this.lblScale.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblScale.Location = new System.Drawing.Point(8, 456);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(90, 17);
            this.lblScale.TabIndex = 27;
            this.lblScale.Text = "Escala: 100%";
            //
            // tbScale
            //
            this.tbScale.Location = new System.Drawing.Point(5, 476);
            this.tbScale.Maximum = 250;
            this.tbScale.Minimum = 30;
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(350, 45);
            this.tbScale.TabIndex = 28;
            this.tbScale.TickFrequency = 20;
            this.tbScale.Value = 100;
            this.tbScale.ValueChanged += new System.EventHandler(this.tbScale_ValueChanged);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 700);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.drawPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "Form1";
            this.Text = "Projeto Icosaedro 2D";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTransX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTransY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.Label lblFaces;
        private System.Windows.Forms.Button btnFace1;
        private System.Windows.Forms.Button btnFace2;
        private System.Windows.Forms.Button btnFace3;
        private System.Windows.Forms.Button btnFace4;
        private System.Windows.Forms.Button btnFace5;
        private System.Windows.Forms.Button btnFace6;
        private System.Windows.Forms.Button btnFace7;
        private System.Windows.Forms.Button btnFace8;
        private System.Windows.Forms.Button btnFace9;
        private System.Windows.Forms.Button btnFace10;
        private System.Windows.Forms.Label lblCores;
        private System.Windows.Forms.Panel panelRed;
        private System.Windows.Forms.Panel panelGreen;
        private System.Windows.Forms.Panel panelBlue;
        private System.Windows.Forms.Panel panelYellow;
        private System.Windows.Forms.Panel panelCyan;
        private System.Windows.Forms.Panel panelMagenta;
        private System.Windows.Forms.Panel panelOrange;
        private System.Windows.Forms.Panel panelPurple;
        private System.Windows.Forms.Panel panelBlack;
        private System.Windows.Forms.Panel panelGray;
        private System.Windows.Forms.Button btnAplicarCores;
        private System.Windows.Forms.Label lblTransX;
        private System.Windows.Forms.TrackBar tbTransX;
        private System.Windows.Forms.Label lblTransY;
        private System.Windows.Forms.TrackBar tbTransY;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.TrackBar tbScale;
    }
}
