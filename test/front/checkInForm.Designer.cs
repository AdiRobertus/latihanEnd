namespace test.master
{
    partial class checkInForm
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
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnCheckin = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBookingCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMasterItem = new System.Windows.Forms.Button();
            this.btnMasterRoom = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnMasterRoomType = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnReservation = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbCustomer.SuspendLayout();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.rbFemale);
            this.gbCustomer.Controls.Add(this.rbMale);
            this.gbCustomer.Controls.Add(this.txtNIK);
            this.gbCustomer.Controls.Add(this.label8);
            this.gbCustomer.Controls.Add(this.txtAge);
            this.gbCustomer.Controls.Add(this.label7);
            this.gbCustomer.Controls.Add(this.label6);
            this.gbCustomer.Controls.Add(this.txtEmail);
            this.gbCustomer.Controls.Add(this.label5);
            this.gbCustomer.Controls.Add(this.txtName);
            this.gbCustomer.Controls.Add(this.label4);
            this.gbCustomer.Controls.Add(this.txtPhoneNumber);
            this.gbCustomer.Controls.Add(this.label3);
            this.gbCustomer.Location = new System.Drawing.Point(543, 87);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(397, 272);
            this.gbCustomer.TabIndex = 5;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Customer";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(226, 111);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 4;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(135, 111);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 3;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // txtNIK
            // 
            this.txtNIK.Location = new System.Drawing.Point(135, 160);
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(165, 20);
            this.txtNIK.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "NIK";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(135, 134);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(165, 20);
            this.txtAge.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Age";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Gender";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(135, 82);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(165, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(135, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 20);
            this.txtName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(135, 30);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(165, 20);
            this.txtPhoneNumber.TabIndex = 0;
            this.txtPhoneNumber.TextChanged += new System.EventHandler(this.txtPhoneNumber_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phone Number";
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.dgv);
            this.gbDetails.Location = new System.Drawing.Point(140, 87);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(397, 272);
            this.gbDetails.TabIndex = 11;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Room Details";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(6, 19);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(385, 247);
            this.dgv.TabIndex = 3;
            // 
            // btnCheckin
            // 
            this.btnCheckin.Location = new System.Drawing.Point(839, 365);
            this.btnCheckin.Name = "btnCheckin";
            this.btnCheckin.Size = new System.Drawing.Size(101, 53);
            this.btnCheckin.TabIndex = 8;
            this.btnCheckin.Text = "Check In";
            this.btnCheckin.UseVisualStyleBackColor = true;
            this.btnCheckin.Click += new System.EventHandler(this.btnCheckin_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(414, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBookingCode
            // 
            this.txtBookingCode.Location = new System.Drawing.Point(243, 46);
            this.txtBookingCode.Name = "txtBookingCode";
            this.txtBookingCode.Size = new System.Drawing.Size(165, 20);
            this.txtBookingCode.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Booking Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Front Office";
            // 
            // btnMasterItem
            // 
            this.btnMasterItem.Location = new System.Drawing.Point(12, 365);
            this.btnMasterItem.Name = "btnMasterItem";
            this.btnMasterItem.Size = new System.Drawing.Size(119, 41);
            this.btnMasterItem.TabIndex = 24;
            this.btnMasterItem.Text = "Master Item";
            this.btnMasterItem.UseVisualStyleBackColor = true;
            // 
            // btnMasterRoom
            // 
            this.btnMasterRoom.Location = new System.Drawing.Point(12, 318);
            this.btnMasterRoom.Name = "btnMasterRoom";
            this.btnMasterRoom.Size = new System.Drawing.Size(119, 41);
            this.btnMasterRoom.TabIndex = 23;
            this.btnMasterRoom.Text = "Master Room";
            this.btnMasterRoom.UseVisualStyleBackColor = true;
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(12, 177);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(119, 41);
            this.btnRequest.TabIndex = 18;
            this.btnRequest.Text = "Request Additional Item(s)";
            this.btnRequest.UseVisualStyleBackColor = true;
            // 
            // btnMasterRoomType
            // 
            this.btnMasterRoomType.Location = new System.Drawing.Point(12, 271);
            this.btnMasterRoomType.Name = "btnMasterRoomType";
            this.btnMasterRoomType.Size = new System.Drawing.Size(119, 41);
            this.btnMasterRoomType.TabIndex = 22;
            this.btnMasterRoomType.Text = "Master Room Type";
            this.btnMasterRoomType.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 41);
            this.button1.TabIndex = 17;
            this.button1.Text = "Check in";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(12, 224);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(119, 41);
            this.btnCheckOut.TabIndex = 19;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // btnReservation
            // 
            this.btnReservation.Location = new System.Drawing.Point(12, 83);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(119, 41);
            this.btnReservation.TabIndex = 16;
            this.btnReservation.Text = "Reservations";
            this.btnReservation.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Front Office";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Grand Hotel";
            // 
            // checkInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 484);
            this.Controls.Add(this.btnMasterItem);
            this.Controls.Add(this.btnMasterRoom);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.btnMasterRoomType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnReservation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gbCustomer);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.btnCheckin);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBookingCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "checkInForm";
            this.Text = "checkInForm";
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnCheckin;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBookingCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMasterItem;
        private System.Windows.Forms.Button btnMasterRoom;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnMasterRoomType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}