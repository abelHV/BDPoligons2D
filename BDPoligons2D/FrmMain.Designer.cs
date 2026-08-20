namespace BDPoligons2D
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.btPerimetreSeleccio = new System.Windows.Forms.Button();
            this.btPerimetreTotal = new System.Windows.Forms.Button();
            this.rdOctogon = new System.Windows.Forms.RadioButton();
            this.rdHexagon = new System.Windows.Forms.RadioButton();
            this.rdHeptàgon = new System.Windows.Forms.RadioButton();
            this.rdPentagon = new System.Windows.Forms.RadioButton();
            this.rdRombe = new System.Windows.Forms.RadioButton();
            this.rdEllipse = new System.Windows.Forms.RadioButton();
            this.rdCercle = new System.Windows.Forms.RadioButton();
            this.rdRectangle = new System.Windows.Forms.RadioButton();
            this.rdTriangleEquilater = new System.Windows.Forms.RadioButton();
            this.rdTriangleIsosceles = new System.Windows.Forms.RadioButton();
            this.btDelTots = new System.Windows.Forms.Button();
            this.btDelSeleccio = new System.Windows.Forms.Button();
            this.btAreaTotal = new System.Windows.Forms.Button();
            this.btAreaSeleccio = new System.Windows.Forms.Button();
            this.chkInterior = new System.Windows.Forms.CheckBox();
            this.pnlColorInterior = new System.Windows.Forms.Panel();
            this.nupHeight = new System.Windows.Forms.NumericUpDown();
            this.lbAltura = new System.Windows.Forms.Label();
            this.nupWidth = new System.Windows.Forms.NumericUpDown();
            this.lbAmple = new System.Windows.Forms.Label();
            this.rdTriangleRectangle = new System.Windows.Forms.RadioButton();
            this.rdQuadrat = new System.Windows.Forms.RadioButton();
            this.lbEstat = new System.Windows.Forms.Label();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlConfig
            // 
            this.pnlConfig.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConfig.Controls.Add(this.btPerimetreSeleccio);
            this.pnlConfig.Controls.Add(this.btPerimetreTotal);
            this.pnlConfig.Controls.Add(this.rdOctogon);
            this.pnlConfig.Controls.Add(this.rdHexagon);
            this.pnlConfig.Controls.Add(this.rdHeptàgon);
            this.pnlConfig.Controls.Add(this.rdPentagon);
            this.pnlConfig.Controls.Add(this.rdRombe);
            this.pnlConfig.Controls.Add(this.rdEllipse);
            this.pnlConfig.Controls.Add(this.rdCercle);
            this.pnlConfig.Controls.Add(this.rdRectangle);
            this.pnlConfig.Controls.Add(this.rdTriangleEquilater);
            this.pnlConfig.Controls.Add(this.rdTriangleIsosceles);
            this.pnlConfig.Controls.Add(this.btDelTots);
            this.pnlConfig.Controls.Add(this.btDelSeleccio);
            this.pnlConfig.Controls.Add(this.btAreaTotal);
            this.pnlConfig.Controls.Add(this.btAreaSeleccio);
            this.pnlConfig.Controls.Add(this.chkInterior);
            this.pnlConfig.Controls.Add(this.pnlColorInterior);
            this.pnlConfig.Controls.Add(this.nupHeight);
            this.pnlConfig.Controls.Add(this.lbAltura);
            this.pnlConfig.Controls.Add(this.nupWidth);
            this.pnlConfig.Controls.Add(this.lbAmple);
            this.pnlConfig.Controls.Add(this.rdTriangleRectangle);
            this.pnlConfig.Controls.Add(this.rdQuadrat);
            this.pnlConfig.Location = new System.Drawing.Point(2, 2);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(235, 716);
            this.pnlConfig.TabIndex = 14;
            // 
            // btPerimetreSeleccio
            // 
            this.btPerimetreSeleccio.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btPerimetreSeleccio.BackColor = System.Drawing.Color.Orange;
            this.btPerimetreSeleccio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPerimetreSeleccio.ForeColor = System.Drawing.Color.Black;
            this.btPerimetreSeleccio.Location = new System.Drawing.Point(12, 446);
            this.btPerimetreSeleccio.Name = "btPerimetreSeleccio";
            this.btPerimetreSeleccio.Size = new System.Drawing.Size(199, 37);
            this.btPerimetreSeleccio.TabIndex = 27;
            this.btPerimetreSeleccio.Text = "Perimetre selecció";
            this.btPerimetreSeleccio.UseVisualStyleBackColor = false;
            this.btPerimetreSeleccio.Click += new System.EventHandler(this.btPerimetreSeleccio_Click);
            // 
            // btPerimetreTotal
            // 
            this.btPerimetreTotal.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btPerimetreTotal.BackColor = System.Drawing.Color.Yellow;
            this.btPerimetreTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPerimetreTotal.ForeColor = System.Drawing.Color.Black;
            this.btPerimetreTotal.Location = new System.Drawing.Point(12, 489);
            this.btPerimetreTotal.Name = "btPerimetreTotal";
            this.btPerimetreTotal.Size = new System.Drawing.Size(199, 37);
            this.btPerimetreTotal.TabIndex = 26;
            this.btPerimetreTotal.Text = "Perimetre Total";
            this.btPerimetreTotal.UseVisualStyleBackColor = false;
            this.btPerimetreTotal.Click += new System.EventHandler(this.btPerimetreTotal_Click);
            // 
            // rdOctogon
            // 
            this.rdOctogon.AutoSize = true;
            this.rdOctogon.Location = new System.Drawing.Point(13, 309);
            this.rdOctogon.Name = "rdOctogon";
            this.rdOctogon.Size = new System.Drawing.Size(101, 24);
            this.rdOctogon.TabIndex = 16;
            this.rdOctogon.Text = "Octògon";
            this.rdOctogon.UseVisualStyleBackColor = true;
            this.rdOctogon.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdHexagon
            // 
            this.rdHexagon.AutoSize = true;
            this.rdHexagon.Location = new System.Drawing.Point(13, 255);
            this.rdHexagon.Name = "rdHexagon";
            this.rdHexagon.Size = new System.Drawing.Size(105, 24);
            this.rdHexagon.TabIndex = 25;
            this.rdHexagon.Text = "Hexàgon";
            this.rdHexagon.UseVisualStyleBackColor = true;
            this.rdHexagon.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdHeptàgon
            // 
            this.rdHeptàgon.AutoSize = true;
            this.rdHeptàgon.Location = new System.Drawing.Point(13, 285);
            this.rdHeptàgon.Name = "rdHeptàgon";
            this.rdHeptàgon.Size = new System.Drawing.Size(113, 24);
            this.rdHeptàgon.TabIndex = 15;
            this.rdHeptàgon.Text = "Heptàgon";
            this.rdHeptàgon.UseVisualStyleBackColor = true;
            this.rdHeptàgon.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdPentagon
            // 
            this.rdPentagon.AutoSize = true;
            this.rdPentagon.Location = new System.Drawing.Point(13, 231);
            this.rdPentagon.Name = "rdPentagon";
            this.rdPentagon.Size = new System.Drawing.Size(110, 24);
            this.rdPentagon.TabIndex = 24;
            this.rdPentagon.Text = "Pentàgon";
            this.rdPentagon.UseVisualStyleBackColor = true;
            this.rdPentagon.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdRombe
            // 
            this.rdRombe.AutoSize = true;
            this.rdRombe.Location = new System.Drawing.Point(13, 201);
            this.rdRombe.Name = "rdRombe";
            this.rdRombe.Size = new System.Drawing.Size(90, 24);
            this.rdRombe.TabIndex = 23;
            this.rdRombe.Text = "Rombe";
            this.rdRombe.UseVisualStyleBackColor = true;
            this.rdRombe.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdEllipse
            // 
            this.rdEllipse.AutoSize = true;
            this.rdEllipse.Location = new System.Drawing.Point(13, 177);
            this.rdEllipse.Name = "rdEllipse";
            this.rdEllipse.Size = new System.Drawing.Size(86, 24);
            this.rdEllipse.TabIndex = 22;
            this.rdEllipse.Text = "Ellipse";
            this.rdEllipse.UseVisualStyleBackColor = true;
            this.rdEllipse.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdCercle
            // 
            this.rdCercle.AutoSize = true;
            this.rdCercle.Location = new System.Drawing.Point(13, 147);
            this.rdCercle.Name = "rdCercle";
            this.rdCercle.Size = new System.Drawing.Size(83, 24);
            this.rdCercle.TabIndex = 21;
            this.rdCercle.Text = "Cercle";
            this.rdCercle.UseVisualStyleBackColor = true;
            this.rdCercle.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdRectangle
            // 
            this.rdRectangle.AutoSize = true;
            this.rdRectangle.Location = new System.Drawing.Point(13, 123);
            this.rdRectangle.Name = "rdRectangle";
            this.rdRectangle.Size = new System.Drawing.Size(115, 24);
            this.rdRectangle.TabIndex = 20;
            this.rdRectangle.Text = "Rectangle";
            this.rdRectangle.UseVisualStyleBackColor = true;
            this.rdRectangle.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdTriangleEquilater
            // 
            this.rdTriangleEquilater.AutoSize = true;
            this.rdTriangleEquilater.Location = new System.Drawing.Point(13, 93);
            this.rdTriangleEquilater.Name = "rdTriangleEquilater";
            this.rdTriangleEquilater.Size = new System.Drawing.Size(180, 24);
            this.rdTriangleEquilater.TabIndex = 19;
            this.rdTriangleEquilater.Text = "Triangle Equilàter";
            this.rdTriangleEquilater.UseVisualStyleBackColor = true;
            this.rdTriangleEquilater.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdTriangleIsosceles
            // 
            this.rdTriangleIsosceles.AutoSize = true;
            this.rdTriangleIsosceles.Location = new System.Drawing.Point(13, 69);
            this.rdTriangleIsosceles.Name = "rdTriangleIsosceles";
            this.rdTriangleIsosceles.Size = new System.Drawing.Size(182, 24);
            this.rdTriangleIsosceles.TabIndex = 18;
            this.rdTriangleIsosceles.Text = "Triangle Isòsceles";
            this.rdTriangleIsosceles.UseVisualStyleBackColor = true;
            this.rdTriangleIsosceles.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // btDelTots
            // 
            this.btDelTots.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btDelTots.BackColor = System.Drawing.Color.DarkRed;
            this.btDelTots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelTots.ForeColor = System.Drawing.Color.White;
            this.btDelTots.Location = new System.Drawing.Point(13, 661);
            this.btDelTots.Name = "btDelTots";
            this.btDelTots.Size = new System.Drawing.Size(199, 37);
            this.btDelTots.TabIndex = 17;
            this.btDelTots.Text = "Eliminar tots";
            this.btDelTots.UseVisualStyleBackColor = false;
            this.btDelTots.Click += new System.EventHandler(this.btDelTots_Click);
            // 
            // btDelSeleccio
            // 
            this.btDelSeleccio.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btDelSeleccio.BackColor = System.Drawing.Color.Red;
            this.btDelSeleccio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelSeleccio.ForeColor = System.Drawing.Color.White;
            this.btDelSeleccio.Location = new System.Drawing.Point(13, 618);
            this.btDelSeleccio.Name = "btDelSeleccio";
            this.btDelSeleccio.Size = new System.Drawing.Size(199, 37);
            this.btDelSeleccio.TabIndex = 16;
            this.btDelSeleccio.Text = "Eliminar selecció";
            this.btDelSeleccio.UseVisualStyleBackColor = false;
            this.btDelSeleccio.Click += new System.EventHandler(this.btDelSeleccio_Click);
            // 
            // btAreaTotal
            // 
            this.btAreaTotal.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btAreaTotal.BackColor = System.Drawing.Color.ForestGreen;
            this.btAreaTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAreaTotal.ForeColor = System.Drawing.Color.Black;
            this.btAreaTotal.Location = new System.Drawing.Point(13, 575);
            this.btAreaTotal.Name = "btAreaTotal";
            this.btAreaTotal.Size = new System.Drawing.Size(199, 37);
            this.btAreaTotal.TabIndex = 15;
            this.btAreaTotal.Text = "Àrea total";
            this.btAreaTotal.UseVisualStyleBackColor = false;
            this.btAreaTotal.Click += new System.EventHandler(this.btAreaTotal_Click);
            // 
            // btAreaSeleccio
            // 
            this.btAreaSeleccio.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btAreaSeleccio.BackColor = System.Drawing.Color.LimeGreen;
            this.btAreaSeleccio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAreaSeleccio.ForeColor = System.Drawing.Color.Black;
            this.btAreaSeleccio.Location = new System.Drawing.Point(13, 532);
            this.btAreaSeleccio.Name = "btAreaSeleccio";
            this.btAreaSeleccio.Size = new System.Drawing.Size(199, 37);
            this.btAreaSeleccio.TabIndex = 14;
            this.btAreaSeleccio.Text = "Àrea selecció";
            this.btAreaSeleccio.UseVisualStyleBackColor = false;
            this.btAreaSeleccio.Click += new System.EventHandler(this.btAreaSeleccio_Click);
            // 
            // chkInterior
            // 
            this.chkInterior.AutoSize = true;
            this.chkInterior.Checked = true;
            this.chkInterior.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInterior.Location = new System.Drawing.Point(62, 407);
            this.chkInterior.Name = "chkInterior";
            this.chkInterior.Size = new System.Drawing.Size(96, 24);
            this.chkInterior.TabIndex = 12;
            this.chkInterior.Text = "Interior";
            this.chkInterior.UseVisualStyleBackColor = true;
            this.chkInterior.CheckedChanged += new System.EventHandler(this.chkInterior_CheckedChanged);
            // 
            // pnlColorInterior
            // 
            this.pnlColorInterior.BackColor = System.Drawing.Color.Orange;
            this.pnlColorInterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColorInterior.Location = new System.Drawing.Point(20, 403);
            this.pnlColorInterior.Name = "pnlColorInterior";
            this.pnlColorInterior.Size = new System.Drawing.Size(26, 26);
            this.pnlColorInterior.TabIndex = 11;
            this.pnlColorInterior.Click += new System.EventHandler(this.pnlColorInterior_Click);
            // 
            // nupHeight
            // 
            this.nupHeight.Location = new System.Drawing.Point(87, 363);
            this.nupHeight.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nupHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupHeight.Name = "nupHeight";
            this.nupHeight.Size = new System.Drawing.Size(59, 28);
            this.nupHeight.TabIndex = 7;
            this.nupHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nupHeight.Visible = false;
            // 
            // lbAltura
            // 
            this.lbAltura.AutoSize = true;
            this.lbAltura.Location = new System.Drawing.Point(87, 346);
            this.lbAltura.Name = "lbAltura";
            this.lbAltura.Size = new System.Drawing.Size(66, 20);
            this.lbAltura.TabIndex = 6;
            this.lbAltura.Text = "Alçada";
            this.lbAltura.Visible = false;
            // 
            // nupWidth
            // 
            this.nupWidth.Location = new System.Drawing.Point(12, 363);
            this.nupWidth.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nupWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupWidth.Name = "nupWidth";
            this.nupWidth.Size = new System.Drawing.Size(59, 28);
            this.nupWidth.TabIndex = 5;
            this.nupWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lbAmple
            // 
            this.lbAmple.AutoSize = true;
            this.lbAmple.Location = new System.Drawing.Point(12, 346);
            this.lbAmple.Name = "lbAmple";
            this.lbAmple.Size = new System.Drawing.Size(85, 20);
            this.lbAmple.TabIndex = 4;
            this.lbAmple.Text = "Amplada";
            // 
            // rdTriangleRectangle
            // 
            this.rdTriangleRectangle.AutoSize = true;
            this.rdTriangleRectangle.Location = new System.Drawing.Point(13, 39);
            this.rdTriangleRectangle.Name = "rdTriangleRectangle";
            this.rdTriangleRectangle.Size = new System.Drawing.Size(188, 24);
            this.rdTriangleRectangle.TabIndex = 3;
            this.rdTriangleRectangle.Text = "Triangle Rectangle";
            this.rdTriangleRectangle.UseVisualStyleBackColor = true;
            this.rdTriangleRectangle.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // rdQuadrat
            // 
            this.rdQuadrat.AutoSize = true;
            this.rdQuadrat.Checked = true;
            this.rdQuadrat.Location = new System.Drawing.Point(13, 15);
            this.rdQuadrat.Name = "rdQuadrat";
            this.rdQuadrat.Size = new System.Drawing.Size(99, 24);
            this.rdQuadrat.TabIndex = 0;
            this.rdQuadrat.TabStop = true;
            this.rdQuadrat.Text = "Quadrat";
            this.rdQuadrat.UseVisualStyleBackColor = true;
            this.rdQuadrat.CheckedChanged += new System.EventHandler(this.rdTriangleRectangle_CheckedChanged);
            // 
            // lbEstat
            // 
            this.lbEstat.AutoSize = true;
            this.lbEstat.Location = new System.Drawing.Point(252, 621);
            this.lbEstat.Name = "lbEstat";
            this.lbEstat.Size = new System.Drawing.Size(1043, 20);
            this.lbEstat.TabIndex = 13;
            this.lbEstat.Text = "Tria la figura que vulguis i fes doble clic on vols que surti. Si fas clic en una" +
    " figura en canviarà el color interior (si en té)\r\n";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 730);
            this.Controls.Add(this.lbEstat);
            this.Controls.Add(this.pnlConfig);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BD Polígons 2D";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.DoubleClick += new System.EventHandler(this.FrmMain_DoubleClick);
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Button btAreaTotal;
        private System.Windows.Forms.Button btAreaSeleccio;
        private System.Windows.Forms.CheckBox chkInterior;
        private System.Windows.Forms.Panel pnlColorInterior;
        private System.Windows.Forms.NumericUpDown nupHeight;
        private System.Windows.Forms.Label lbAltura;
        private System.Windows.Forms.NumericUpDown nupWidth;
        private System.Windows.Forms.Label lbAmple;
        protected System.Windows.Forms.RadioButton rdTriangleRectangle;
        private System.Windows.Forms.RadioButton rdQuadrat;
        private System.Windows.Forms.Label lbEstat;
        private System.Windows.Forms.Button btDelTots;
        private System.Windows.Forms.Button btDelSeleccio;
        protected System.Windows.Forms.RadioButton rdOctogon;
        protected System.Windows.Forms.RadioButton rdHexagon;
        private System.Windows.Forms.RadioButton rdHeptàgon;
        private System.Windows.Forms.RadioButton rdPentagon;
        protected System.Windows.Forms.RadioButton rdRombe;
        private System.Windows.Forms.RadioButton rdEllipse;
        protected System.Windows.Forms.RadioButton rdCercle;
        private System.Windows.Forms.RadioButton rdRectangle;
        protected System.Windows.Forms.RadioButton rdTriangleEquilater;
        private System.Windows.Forms.RadioButton rdTriangleIsosceles;
        private System.Windows.Forms.Button btPerimetreSeleccio;
        private System.Windows.Forms.Button btPerimetreTotal;
    }
}

