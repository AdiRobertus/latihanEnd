using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.master
{
    public partial class checkInForm : Core
    {
        ReservationRoom[] Rooms;
        Customer Customer;
        public checkInForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgv.DataSource = null;
            Rooms = null;

            Rooms = db.ReservationRoom
                .Where(X => X.Reservation.Code == txtBookingCode.Text)
                .ToArray();

            if (Rooms.Length == 0)
            {
                MessageBox.Show("Boking code not found");
                return;
            }

            dgv.DataSource = Rooms
                .Select(X => new
                {
                    X.Room.RoomNumber,
                    X.Room.RoomFloor,
                    RoomType = X.Room.RoomType.Name,
                    startdate = X.StartDateTime.ToString("yy/MM/yyy"),
                    X.DurationNights
                }).ToArray();   
        }
        bool IsValid()
        {
            if (!txtPhoneNumber.Text.IsPhone())
            {
                MessageBox.Show("format penulisan nomor hp salah");
                return false;
            }
            if (Rooms == null || Rooms.Length == 0)
            {
                MessageBox.Show("search Boking code first");
                return false;
            }
            if (!txtEmail.Text.IsEmail())
            {
                MessageBox.Show("format penulisan email salah");
                return false;
            }
            if (gbCustomer.Controls.IsAnyEmpty())
            {
                MessageBox.Show("jangan ada yang dikosongkan");
                return false;
            }
            if (!txtAge.Text.IsNumber())
            {
                MessageBox.Show("format penulisan umur salah");
            }
            if (!txtNIK.Text.IsNumber() || txtNIK.Text.Length != 16)
            {
                MessageBox.Show("NIK harus angka berjumlah 16");
                return false;
            }
            return true;
        }

        private void btnCheckin_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                return;
            }

            bool newCustomer = false;
            if (Customer == null)
            {
                Customer = new Customer();
                newCustomer = true;
            }
            Customer.Name = txtName.Text;
            Customer.NIK = txtNIK.Text;
            Customer.PhoneNumber = txtPhoneNumber.Text;
            Customer.Email = txtEmail.Text;
            Customer.Gender = rbMale.Checked ? "M" : "F";
            Customer.Age = int.Parse(txtAge.Text.ToString());

            if (newCustomer == true)
            {
                db.Customer.Add(Customer);
                db.SaveChanges();
            }
            var reservation = db.Reservation.Find(Rooms[0].ReservationID);
            reservation.CustomerID = Customer.ID;

            for (int i = 0; i < Rooms.Length; i++)
            {
                Rooms[i].CheckInDateTime = DateTime.Now.Date;
            }
            db.SaveChanges();
            Reset();
        }
        void Reset()
        {
            gbCustomer.Controls.ClearFields();
            txtBookingCode.Text = "";
            dgv.DataSource = null;
            Rooms = null;
            Customer = null;
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            Customer = db.Customer
                .FirstOrDefault(X =>
                X.PhoneNumber == txtPhoneNumber.Text
                );

            if (Customer == null)
            {
                return;
            }
            txtName.Text = Customer.Name;
            txtEmail.Text = Customer.Email;
            if (Customer.Gender == "M")
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            txtAge.Text = Customer.Age.ToString();
            txtNIK.Text = Customer.NIK;
        }
    }
}
