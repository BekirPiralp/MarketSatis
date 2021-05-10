
namespace MarketSatis
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonGiris = new System.Windows.Forms.Button();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.textBoxTc = new System.Windows.Forms.TextBox();
            this.buttonHakkinda = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hoşgeldiniz";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.buttonGiris);
            this.groupBox1.Controls.Add(this.textBoxSifre);
            this.groupBox1.Controls.Add(this.textBoxTc);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 126);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "TC :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre:";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(366, 67);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Şifreyi Göster";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonGiris
            // 
            this.buttonGiris.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGiris.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonGiris.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGiris.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonGiris.Location = new System.Drawing.Point(187, 94);
            this.buttonGiris.Name = "buttonGiris";
            this.buttonGiris.Size = new System.Drawing.Size(150, 23);
            this.buttonGiris.TabIndex = 2;
            this.buttonGiris.Text = "Giriş";
            this.buttonGiris.UseVisualStyleBackColor = false;
            this.buttonGiris.Click += new System.EventHandler(this.buttonGiris_Click);
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSifre.Location = new System.Drawing.Point(71, 65);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(285, 23);
            this.textBoxSifre.TabIndex = 1;
            this.textBoxSifre.Text = "Şifrenizi giriniz";
            this.textBoxSifre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSifre.Click += new System.EventHandler(this.sifreHover);
            this.textBoxSifre.Enter += new System.EventHandler(this.sifreHover);
            this.textBoxSifre.MouseHover += new System.EventHandler(this.sifreHover);
            // 
            // textBoxTc
            // 
            this.textBoxTc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTc.Location = new System.Drawing.Point(71, 22);
            this.textBoxTc.Name = "textBoxTc";
            this.textBoxTc.Size = new System.Drawing.Size(408, 23);
            this.textBoxTc.TabIndex = 1;
            this.textBoxTc.Text = "Lütfen Tc Kimlik numaranızı giriniz";
            this.textBoxTc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTc.Enter += new System.EventHandler(this.tcHover);
            this.textBoxTc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTc_KeyPress);
            this.textBoxTc.MouseHover += new System.EventHandler(this.tcHover);
            // 
            // buttonHakkinda
            // 
            this.buttonHakkinda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHakkinda.BackColor = System.Drawing.SystemColors.Control;
            this.buttonHakkinda.Location = new System.Drawing.Point(226, 201);
            this.buttonHakkinda.Name = "buttonHakkinda";
            this.buttonHakkinda.Size = new System.Drawing.Size(75, 23);
            this.buttonHakkinda.TabIndex = 3;
            this.buttonHakkinda.Text = "Hakkında";
            this.buttonHakkinda.UseVisualStyleBackColor = false;
            this.buttonHakkinda.Click += new System.EventHandler(this.buttonHakkinda_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 236);
            this.Controls.Add(this.buttonHakkinda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(529, 279);
            this.MinimumSize = new System.Drawing.Size(529, 279);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Market Satış Uygulaması";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGiris;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.TextBox textBoxTc;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonHakkinda;
    }
}

