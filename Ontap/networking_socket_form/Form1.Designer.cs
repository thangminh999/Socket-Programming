
namespace networking_socket_form
{
    partial class frm_Server
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_End = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_ViewChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(40, 24);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(87, 33);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_End
            // 
            this.btn_End.Location = new System.Drawing.Point(181, 24);
            this.btn_End.Name = "btn_End";
            this.btn_End.Size = new System.Drawing.Size(87, 33);
            this.btn_End.TabIndex = 1;
            this.btn_End.Text = "End";
            this.btn_End.UseVisualStyleBackColor = true;
            this.btn_End.Click += new System.EventHandler(this.btn_End_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(450, 32);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(100, 22);
            this.txt_Port.TabIndex = 3;
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(40, 148);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(457, 22);
            this.txt_Input.TabIndex = 4;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(541, 137);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(87, 33);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txt_ViewChat
            // 
            this.txt_ViewChat.Location = new System.Drawing.Point(40, 198);
            this.txt_ViewChat.Multiline = true;
            this.txt_ViewChat.Name = "txt_ViewChat";
            this.txt_ViewChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ViewChat.Size = new System.Drawing.Size(1052, 481);
            this.txt_ViewChat.TabIndex = 6;
            // 
            // frm_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 706);
            this.Controls.Add(this.txt_ViewChat);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_End);
            this.Controls.Add(this.btn_Start);
            this.Name = "frm_Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_End;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_ViewChat;
    }
}

