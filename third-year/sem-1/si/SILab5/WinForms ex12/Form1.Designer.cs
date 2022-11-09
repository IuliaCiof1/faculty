namespace WinForms_ex12
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Empty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C1024 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C2028 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C3072 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C4096 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRsa = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDSA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empty,
            this.C1024,
            this.C2028,
            this.C3072,
            this.C4096});
            this.dataGridView1.Location = new System.Drawing.Point(61, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(543, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Empty
            // 
            this.Empty.HeaderText = "";
            this.Empty.Name = "Empty";
            // 
            // C1024
            // 
            this.C1024.HeaderText = "1024";
            this.C1024.Name = "C1024";
            // 
            // C2028
            // 
            this.C2028.HeaderText = "2028";
            this.C2028.Name = "C2028";
            // 
            // C3072
            // 
            this.C3072.HeaderText = "3072";
            this.C3072.Name = "C3072";
            // 
            // C4096
            // 
            this.C4096.HeaderText = "4096";
            this.C4096.Name = "C4096";
            // 
            // btnRsa
            // 
            this.btnRsa.Location = new System.Drawing.Point(234, 229);
            this.btnRsa.Name = "btnRsa";
            this.btnRsa.Size = new System.Drawing.Size(132, 37);
            this.btnRsa.TabIndex = 1;
            this.btnRsa.Text = "Load RSA Time";
            this.btnRsa.UseVisualStyleBackColor = true;
            this.btnRsa.Click += new System.EventHandler(this.btnRsa_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridView2.Location = new System.Drawing.Point(638, 57);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(543, 150);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "512";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "640";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "768";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "1024";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // btnDSA
            // 
            this.btnDSA.Location = new System.Drawing.Point(851, 229);
            this.btnDSA.Name = "btnDSA";
            this.btnDSA.Size = new System.Drawing.Size(132, 37);
            this.btnDSA.TabIndex = 3;
            this.btnDSA.Text = "Load DSA Time";
            this.btnDSA.UseVisualStyleBackColor = true;
            this.btnDSA.Click += new System.EventHandler(this.btnDSA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 450);
            this.Controls.Add(this.btnDSA);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnRsa);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empty;
        private System.Windows.Forms.DataGridViewTextBoxColumn C1024;
        private System.Windows.Forms.DataGridViewTextBoxColumn C2028;
        private System.Windows.Forms.DataGridViewTextBoxColumn C3072;
        private System.Windows.Forms.DataGridViewTextBoxColumn C4096;
        private System.Windows.Forms.Button btnRsa;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnDSA;
    }
}

