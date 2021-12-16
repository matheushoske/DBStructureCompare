
namespace DBStructureCompare
{
    partial class frmStructureCorrector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStructureCorrector));
            this.btnCompare = new System.Windows.Forms.Button();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblComparando = new System.Windows.Forms.Label();
            this.lblTabelasCorrigidas = new System.Windows.Forms.Label();
            this.lblColunasCorrigidas = new System.Windows.Forms.Label();
            this.txtRefProvider = new System.Windows.Forms.TextBox();
            this.txtRefDatabase = new System.Windows.Forms.TextBox();
            this.txtTargDatabase = new System.Windows.Forms.TextBox();
            this.txtTargProvider = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblQuantidadeErros = new System.Windows.Forms.Label();
            this.txtRefUser = new System.Windows.Forms.TextBox();
            this.txtRefPass = new System.Windows.Forms.TextBox();
            this.txtTargPass = new System.Windows.Forms.TextBox();
            this.txtTargUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxTipoBanco = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(267, 294);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 0;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(89, 252);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(425, 23);
            this.pgbProgress.TabIndex = 1;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(101, 278);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(24, 13);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "0/0";
            // 
            // lblComparando
            // 
            this.lblComparando.AutoSize = true;
            this.lblComparando.Location = new System.Drawing.Point(244, 232);
            this.lblComparando.Name = "lblComparando";
            this.lblComparando.Size = new System.Drawing.Size(0, 13);
            this.lblComparando.TabIndex = 3;
            // 
            // lblTabelasCorrigidas
            // 
            this.lblTabelasCorrigidas.AutoSize = true;
            this.lblTabelasCorrigidas.Location = new System.Drawing.Point(456, 284);
            this.lblTabelasCorrigidas.Name = "lblTabelasCorrigidas";
            this.lblTabelasCorrigidas.Size = new System.Drawing.Size(105, 13);
            this.lblTabelasCorrigidas.TabIndex = 4;
            this.lblTabelasCorrigidas.Text = "Tabelas corrigidas: 0";
            // 
            // lblColunasCorrigidas
            // 
            this.lblColunasCorrigidas.AutoSize = true;
            this.lblColunasCorrigidas.Location = new System.Drawing.Point(457, 307);
            this.lblColunasCorrigidas.Name = "lblColunasCorrigidas";
            this.lblColunasCorrigidas.Size = new System.Drawing.Size(105, 13);
            this.lblColunasCorrigidas.TabIndex = 5;
            this.lblColunasCorrigidas.Text = "Colunas corrigidas: 0";
            // 
            // txtRefProvider
            // 
            this.txtRefProvider.Location = new System.Drawing.Point(104, 69);
            this.txtRefProvider.Name = "txtRefProvider";
            this.txtRefProvider.Size = new System.Drawing.Size(100, 20);
            this.txtRefProvider.TabIndex = 6;
            this.txtRefProvider.Text = "localhost";
            // 
            // txtRefDatabase
            // 
            this.txtRefDatabase.Location = new System.Drawing.Point(104, 95);
            this.txtRefDatabase.Name = "txtRefDatabase";
            this.txtRefDatabase.Size = new System.Drawing.Size(100, 20);
            this.txtRefDatabase.TabIndex = 7;
            // 
            // txtTargDatabase
            // 
            this.txtTargDatabase.Location = new System.Drawing.Point(414, 95);
            this.txtTargDatabase.Name = "txtTargDatabase";
            this.txtTargDatabase.Size = new System.Drawing.Size(100, 20);
            this.txtTargDatabase.TabIndex = 9;
            // 
            // txtTargProvider
            // 
            this.txtTargProvider.Location = new System.Drawing.Point(414, 69);
            this.txtTargProvider.Name = "txtTargProvider";
            this.txtTargProvider.Size = new System.Drawing.Size(100, 20);
            this.txtTargProvider.TabIndex = 8;
            this.txtTargProvider.Text = "localhost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Database Reference";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Database to correct";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(263, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "-- Provider --";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "-- DB Name --";
            // 
            // lblQuantidadeErros
            // 
            this.lblQuantidadeErros.AutoSize = true;
            this.lblQuantidadeErros.Location = new System.Drawing.Point(485, 327);
            this.lblQuantidadeErros.Name = "lblQuantidadeErros";
            this.lblQuantidadeErros.Size = new System.Drawing.Size(43, 13);
            this.lblQuantidadeErros.TabIndex = 14;
            this.lblQuantidadeErros.Text = "Erros: 0";
            // 
            // txtRefUser
            // 
            this.txtRefUser.Location = new System.Drawing.Point(104, 121);
            this.txtRefUser.Name = "txtRefUser";
            this.txtRefUser.Size = new System.Drawing.Size(100, 20);
            this.txtRefUser.TabIndex = 15;
            // 
            // txtRefPass
            // 
            this.txtRefPass.Location = new System.Drawing.Point(104, 147);
            this.txtRefPass.Name = "txtRefPass";
            this.txtRefPass.PasswordChar = '*';
            this.txtRefPass.Size = new System.Drawing.Size(100, 20);
            this.txtRefPass.TabIndex = 16;
            // 
            // txtTargPass
            // 
            this.txtTargPass.Location = new System.Drawing.Point(414, 147);
            this.txtTargPass.Name = "txtTargPass";
            this.txtTargPass.PasswordChar = '*';
            this.txtTargPass.Size = new System.Drawing.Size(100, 20);
            this.txtTargPass.TabIndex = 17;
            // 
            // txtTargUser
            // 
            this.txtTargUser.Location = new System.Drawing.Point(414, 121);
            this.txtTargUser.Name = "txtTargUser";
            this.txtTargUser.Size = new System.Drawing.Size(100, 20);
            this.txtTargUser.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(277, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "-- User --";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(259, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "-- Password --";
            // 
            // cbxTipoBanco
            // 
            this.cbxTipoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoBanco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxTipoBanco.FormattingEnabled = true;
            this.cbxTipoBanco.Items.AddRange(new object[] {
            "MySQL"});
            this.cbxTipoBanco.Location = new System.Drawing.Point(268, 12);
            this.cbxTipoBanco.Name = "cbxTipoBanco";
            this.cbxTipoBanco.Size = new System.Drawing.Size(74, 21);
            this.cbxTipoBanco.TabIndex = 21;
            // 
            // frmStructureCorrector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 351);
            this.Controls.Add(this.cbxTipoBanco);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTargUser);
            this.Controls.Add(this.txtTargPass);
            this.Controls.Add(this.txtRefPass);
            this.Controls.Add(this.txtRefUser);
            this.Controls.Add(this.lblQuantidadeErros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTargDatabase);
            this.Controls.Add(this.txtTargProvider);
            this.Controls.Add(this.txtRefDatabase);
            this.Controls.Add(this.txtRefProvider);
            this.Controls.Add(this.lblColunasCorrigidas);
            this.Controls.Add(this.lblTabelasCorrigidas);
            this.Controls.Add(this.lblComparando);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.btnCompare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStructureCorrector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Structure Correction";
            this.Load += new System.EventHandler(this.frmStructureCorrector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblComparando;
        private System.Windows.Forms.Label lblTabelasCorrigidas;
        private System.Windows.Forms.Label lblColunasCorrigidas;
        private System.Windows.Forms.TextBox txtRefProvider;
        private System.Windows.Forms.TextBox txtRefDatabase;
        private System.Windows.Forms.TextBox txtTargDatabase;
        private System.Windows.Forms.TextBox txtTargProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblQuantidadeErros;
        private System.Windows.Forms.TextBox txtRefUser;
        private System.Windows.Forms.TextBox txtRefPass;
        private System.Windows.Forms.TextBox txtTargPass;
        private System.Windows.Forms.TextBox txtTargUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxTipoBanco;
    }
}

