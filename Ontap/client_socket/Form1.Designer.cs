
namespace client_socket
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
            this.txt_ViewChat = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_ViewChat
            // 
            this.txt_ViewChat.Location = new System.Drawing.Point(48, 222);
            this.txt_ViewChat.Multiline = true;
            this.txt_ViewChat.Name = "txt_ViewChat";
            this.txt_ViewChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ViewChat.Size = new System.Drawing.Size(1052, 474);
            this.txt_ViewChat.TabIndex = 13;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(549, 161);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(87, 33);
            this.btn_Send.TabIndex = 12;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(48, 172);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(457, 22);
            this.txt_Input.TabIndex = 11;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(380, 58);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(105, 22);
            this.txt_Port.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Port";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(549, 54);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(87, 33);
            this.btn_Connect.TabIndex = 16;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 745);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.txt_ViewChat);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ViewChat;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Connect;
    }
}

