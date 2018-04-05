namespace gezinti_teorisi
{
    partial class Client
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
            this.button1 = new System.Windows.Forms.Button();
            this.gonder = new System.Windows.Forms.Button();
            this.btnBaglantiKes = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnbaglan = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Verileri Çek";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gonder
            // 
            this.gonder.Location = new System.Drawing.Point(436, 266);
            this.gonder.Name = "gonder";
            this.gonder.Size = new System.Drawing.Size(75, 23);
            this.gonder.TabIndex = 13;
            this.gonder.Text = "Gonder";
            this.gonder.UseVisualStyleBackColor = true;
            this.gonder.Click += new System.EventHandler(this.gonder_Click);
            // 
            // btnBaglantiKes
            // 
            this.btnBaglantiKes.Location = new System.Drawing.Point(355, 67);
            this.btnBaglantiKes.Name = "btnBaglantiKes";
            this.btnBaglantiKes.Size = new System.Drawing.Size(75, 23);
            this.btnBaglantiKes.TabIndex = 12;
            this.btnBaglantiKes.Text = "Bağlanti kes";
            this.btnBaglantiKes.UseVisualStyleBackColor = true;
            this.btnBaglantiKes.Click += new System.EventHandler(this.btnBaglantiKes_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(118, 100);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(401, 163);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // btnbaglan
            // 
            this.btnbaglan.Location = new System.Drawing.Point(252, 67);
            this.btnbaglan.Name = "btnbaglan";
            this.btnbaglan.Size = new System.Drawing.Size(75, 23);
            this.btnbaglan.TabIndex = 10;
            this.btnbaglan.Text = "Bağlan";
            this.btnbaglan.UseVisualStyleBackColor = true;
            this.btnbaglan.Click += new System.EventHandler(this.btnbaglan_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(148, 70);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(80, 20);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "8080";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Port:";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gonder);
            this.Controls.Add(this.btnBaglantiKes);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnbaglan);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button gonder;
        private System.Windows.Forms.Button btnBaglantiKes;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnbaglan;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
    }
}