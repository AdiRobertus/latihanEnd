namespace test.main
{
    partial class frontOfficeForm
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
            this.btnMasterItem = new System.Windows.Forms.Button();
            this.btnMasterRoom = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnMasterRoomType = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnReservation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMasterItem
            // 
            this.btnMasterItem.Location = new System.Drawing.Point(12, 352);
            this.btnMasterItem.Name = "btnMasterItem";
            this.btnMasterItem.Size = new System.Drawing.Size(119, 41);
            this.btnMasterItem.TabIndex = 15;
            this.btnMasterItem.Text = "Master Item";
            this.btnMasterItem.UseVisualStyleBackColor = true;
            this.btnMasterItem.Click += new System.EventHandler(this.btnMasterItem_Click);
            // 
            // btnMasterRoom
            // 
            this.btnMasterRoom.Location = new System.Drawing.Point(12, 305);
            this.btnMasterRoom.Name = "btnMasterRoom";
            this.btnMasterRoom.Size = new System.Drawing.Size(119, 41);
            this.btnMasterRoom.TabIndex = 14;
            this.btnMasterRoom.Text = "Master Room";
            this.btnMasterRoom.UseVisualStyleBackColor = true;
            this.btnMasterRoom.Click += new System.EventHandler(this.btnMasterRoom_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(12, 164);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(119, 41);
            this.btnRequest.TabIndex = 9;
            this.btnRequest.Text = "Request Additional Item(s)";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnMasterRoomType
            // 
            this.btnMasterRoomType.Location = new System.Drawing.Point(12, 258);
            this.btnMasterRoomType.Name = "btnMasterRoomType";
            this.btnMasterRoomType.Size = new System.Drawing.Size(119, 41);
            this.btnMasterRoomType.TabIndex = 13;
            this.btnMasterRoomType.Text = "Master Room Type";
            this.btnMasterRoomType.UseVisualStyleBackColor = true;
            this.btnMasterRoomType.Click += new System.EventHandler(this.btnMasterRoomType_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(12, 117);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(119, 41);
            this.btnCheckIn.TabIndex = 8;
            this.btnCheckIn.Text = "Check in";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(12, 211);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(119, 41);
            this.btnCheckOut.TabIndex = 10;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnReservation
            // 
            this.btnReservation.Location = new System.Drawing.Point(12, 70);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(119, 41);
            this.btnReservation.TabIndex = 7;
            this.btnReservation.Text = "Reservations";
            this.btnReservation.UseVisualStyleBackColor = true;
            this.btnReservation.Click += new System.EventHandler(this.btnReservation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Front Office";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Grand Hotel";
            // 
            // frontOfficeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 431);
            this.Controls.Add(this.btnMasterItem);
            this.Controls.Add(this.btnMasterRoom);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.btnMasterRoomType);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnReservation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frontOfficeForm";
            this.Text = "frontOfficeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMasterItem;
        private System.Windows.Forms.Button btnMasterRoom;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnMasterRoomType;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}