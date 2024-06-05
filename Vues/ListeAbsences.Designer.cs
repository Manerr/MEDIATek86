namespace MEDIATEK86.Vues
{
    partial class ListeAbsences
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListeAbsences));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDABSENCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatedeDebut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatedeFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Motif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFermerAbsences = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonsuppr = new System.Windows.Forms.Button();
            this.buttonmodifier = new System.Windows.Forms.Button();
            this.buttonajouter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.motifentry = new System.Windows.Forms.ComboBox();
            this.datefin = new System.Windows.Forms.DateTimePicker();
            this.datedebut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDABSENCE,
            this.DatedeDebut,
            this.DatedeFin,
            this.Motif});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 2);
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.Height = 38;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(702, 536);
            this.dataGridView1.TabIndex = 0;
            // 
            // IDABSENCE
            // 
            this.IDABSENCE.HeaderText = "IDABSENCE";
            this.IDABSENCE.MinimumWidth = 6;
            this.IDABSENCE.Name = "IDABSENCE";
            this.IDABSENCE.ReadOnly = true;
            this.IDABSENCE.Visible = false;
            this.IDABSENCE.Width = 135;
            // 
            // DatedeDebut
            // 
            this.DatedeDebut.HeaderText = "Date de Début";
            this.DatedeDebut.MinimumWidth = 6;
            this.DatedeDebut.Name = "DatedeDebut";
            this.DatedeDebut.ReadOnly = true;
            this.DatedeDebut.Width = 147;
            // 
            // DatedeFin
            // 
            this.DatedeFin.HeaderText = "Date de fin";
            this.DatedeFin.MinimumWidth = 6;
            this.DatedeFin.Name = "DatedeFin";
            this.DatedeFin.ReadOnly = true;
            this.DatedeFin.Width = 120;
            // 
            // Motif
            // 
            this.Motif.HeaderText = "Motif";
            this.Motif.MinimumWidth = 6;
            this.Motif.Name = "Motif";
            this.Motif.ReadOnly = true;
            this.Motif.Width = 75;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.537F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.463F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonFermerAbsences, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.83728F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.162717F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 542);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonFermerAbsences
            // 
            this.buttonFermerAbsences.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonFermerAbsences.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold);
            this.buttonFermerAbsences.Location = new System.Drawing.Point(744, 500);
            this.buttonFermerAbsences.Name = "buttonFermerAbsences";
            this.buttonFermerAbsences.Size = new System.Drawing.Size(210, 33);
            this.buttonFermerAbsences.TabIndex = 1;
            this.buttonFermerAbsences.Text = "Fermer absences";
            this.buttonFermerAbsences.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonsuppr);
            this.panel1.Controls.Add(this.buttonmodifier);
            this.panel1.Controls.Add(this.buttonajouter);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.motifentry);
            this.panel1.Controls.Add(this.datefin);
            this.panel1.Controls.Add(this.datedebut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(730, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 432);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonsuppr
            // 
            this.buttonsuppr.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonsuppr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonsuppr.Location = new System.Drawing.Point(14, 346);
            this.buttonsuppr.Name = "buttonsuppr";
            this.buttonsuppr.Size = new System.Drawing.Size(210, 30);
            this.buttonsuppr.TabIndex = 6;
            this.buttonsuppr.Text = "Supprimer";
            this.buttonsuppr.UseVisualStyleBackColor = true;
            // 
            // buttonmodifier
            // 
            this.buttonmodifier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonmodifier.Font = new System.Drawing.Font("Bahnschrift Light", 11.8F);
            this.buttonmodifier.Location = new System.Drawing.Point(14, 292);
            this.buttonmodifier.Name = "buttonmodifier";
            this.buttonmodifier.Size = new System.Drawing.Size(210, 30);
            this.buttonmodifier.TabIndex = 5;
            this.buttonmodifier.Text = "Modifier";
            this.buttonmodifier.UseVisualStyleBackColor = true;
            // 
            // buttonajouter
            // 
            this.buttonajouter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonajouter.Font = new System.Drawing.Font("Bahnschrift Light", 11.8F);
            this.buttonajouter.Location = new System.Drawing.Point(14, 256);
            this.buttonajouter.Name = "buttonajouter";
            this.buttonajouter.Size = new System.Drawing.Size(210, 30);
            this.buttonajouter.TabIndex = 4;
            this.buttonajouter.Text = "Ajouter";
            this.buttonajouter.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Motif";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Début";
            // 
            // motifentry
            // 
            this.motifentry.FormattingEnabled = true;
            this.motifentry.Items.AddRange(new object[] {
            "vacances",
            "maladie",
            "motif familial",
            "congé parental"});
            this.motifentry.Location = new System.Drawing.Point(14, 198);
            this.motifentry.Name = "motifentry";
            this.motifentry.Size = new System.Drawing.Size(210, 24);
            this.motifentry.TabIndex = 3;
            this.motifentry.Text = "vacances";
            this.motifentry.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // datefin
            // 
            this.datefin.Location = new System.Drawing.Point(14, 130);
            this.datefin.Name = "datefin";
            this.datefin.Size = new System.Drawing.Size(210, 22);
            this.datefin.TabIndex = 2;
            this.datefin.Value = new System.DateTime(2024, 6, 6, 0, 0, 0, 0);
            // 
            // datedebut
            // 
            this.datedebut.Location = new System.Drawing.Point(14, 62);
            this.datedebut.Name = "datedebut";
            this.datedebut.Size = new System.Drawing.Size(210, 22);
            this.datedebut.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 10.8F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter/Modifier absences";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ListeAbsences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListeAbsences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListeAbsences";
            this.Load += new System.EventHandler(this.ListeAbsences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button buttonFermerAbsences;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox motifentry;
        public System.Windows.Forms.DateTimePicker datefin;
        public System.Windows.Forms.DateTimePicker datedebut;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button buttonajouter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button buttonsuppr;
        public System.Windows.Forms.Button buttonmodifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDABSENCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatedeDebut;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatedeFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Motif;
    }
}