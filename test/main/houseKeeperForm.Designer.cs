namespace test.main
{
    partial class houseKeeperForm
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
            this.btnCleaningRoom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCleaningRoom
            // 
            this.btnCleaningRoom.Location = new System.Drawing.Point(12, 69);
            this.btnCleaningRoom.Name = "btnCleaningRoom";
            this.btnCleaningRoom.Size = new System.Drawing.Size(119, 41);
            this.btnCleaningRoom.TabIndex = 4;
            this.btnCleaningRoom.Text = "Cleaning Room";
            this.btnCleaningRoom.UseVisualStyleBackColor = true;
            this.btnCleaningRoom.Click += new System.EventHandler(this.btnCleaningRoom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Housekeeper";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grand Hotel";
            // 
            // houseKeeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 556);
            this.Controls.Add(this.btnCleaningRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "houseKeeperForm";
            this.Text = "houseKeeperForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCleaningRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}