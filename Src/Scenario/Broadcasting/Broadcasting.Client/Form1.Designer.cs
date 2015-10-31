namespace Broadcasting.Client
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
            this.button1 = new System.Windows.Forms.Button();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SendEvent = new System.Windows.Forms.Button();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_OhterClientMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Register Client";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ClientName.Location = new System.Drawing.Point(15, 35);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(313, 20);
            this.txt_ClientName.TabIndex = 1;
            this.txt_ClientName.Text = "Frank";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client Name";
            // 
            // btn_SendEvent
            // 
            this.btn_SendEvent.Location = new System.Drawing.Point(26, 143);
            this.btn_SendEvent.Name = "btn_SendEvent";
            this.btn_SendEvent.Size = new System.Drawing.Size(222, 23);
            this.btn_SendEvent.TabIndex = 0;
            this.btn_SendEvent.Text = "Send Event";
            this.btn_SendEvent.UseVisualStyleBackColor = true;
            this.btn_SendEvent.Click += new System.EventHandler(this.btn_SendEvent_Click);
            // 
            // txt_message
            // 
            this.txt_message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_message.Location = new System.Drawing.Point(12, 117);
            this.txt_message.Name = "txt_message";
            this.txt_message.Size = new System.Drawing.Size(316, 20);
            this.txt_message.TabIndex = 1;
            this.txt_message.Text = "Hello! Everyone.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Event Message:";
            // 
            // txt_OhterClientMessage
            // 
            this.txt_OhterClientMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_OhterClientMessage.Location = new System.Drawing.Point(12, 191);
            this.txt_OhterClientMessage.Multiline = true;
            this.txt_OhterClientMessage.Name = "txt_OhterClientMessage";
            this.txt_OhterClientMessage.Size = new System.Drawing.Size(332, 100);
            this.txt_OhterClientMessage.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Message From other clients";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 303);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_OhterClientMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SendEvent);
            this.Controls.Add(this.txt_ClientName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SendEvent;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_OhterClientMessage;
        private System.Windows.Forms.Label label3;
    }
}

