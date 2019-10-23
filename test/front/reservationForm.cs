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
    public partial class reservationForm : Core
    {
        List<Room> selectedRooms = new List<Room>();
        List<ReservationRequestItem> items = new List<ReservationRequestItem>();
        Customer selectedCustomer;
        Room room1;
        Room room2;
        int numberOfNights;
        DateTime startDateTime;
        int roomTypeId;
        private readonly Employee employee;

        public reservationForm()
        {
            InitializeComponent();
        }

        void loadData()
        {
            var departureDate = dtpStartDate.Value.Date.AddDays(numberOfNights);
            var arrivalDate = dtpStartDate.Value.Date;

            var useds = db.ReservationRoom
                .ToArray()
                .Where(x =>
                    departureDate > x.StartDateTime.Date &&
                    arrivalDate <= x.StartDateTime.Date.AddDays(x.DurationNights)
                )
                .Select(x => x.RoomID)
                .ToArray();

            dgvAvailable.DataSource = db.Room
                .ToArray()
                .Where(x =>
                    !selectedRooms.Select(y => y.ID).Contains(x.ID) &&
                    !useds.Contains(x.ID) &&
                    x.RoomTypeID == roomTypeId
                )
                .Select(x => new
                {
                    x.ID,
                    x.RoomNumber,
                    x.RoomFloor,
                    x.Description
                })
                .ToArray();

            dgvAvailable.Columns["ID"].Visible = false;

            dgvSelected.DataSource = selectedRooms
                .Select(x => new
                {
                    x.ID,
                    x.RoomNumber,
                    x.RoomFloor,
                    x.Description
                })
                .ToArray();

            dgvSelected.Columns["ID"].Visible = false;
        }

        private void reservationForm_Load(object sender, EventArgs e)
        {
            cbRoomType.ValueMember = "ID";
            cbRoomType.DisplayMember = "Name";
            cbRoomType.DataSource = db.RoomType
                .Select(x => new
                {
                    x.ID,
                    x.Name
                })
                .ToArray();

            cbItem.ValueMember = "ID";
            cbItem.DisplayMember = "Name";
            cbItem.DataSource = db.Item
                .Select(x => new
                {
                    x.ID,
                    x.Name
                })
                .ToArray();

            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            dgvSearch.DataSource = db.Customer
                .Where(x => x.Name.Contains(txtSearch.Text))
                .ToArray()
                .Select(x => new
                {
                    x.ID,
                    Choose = selectedCustomer == null ? false : x.ID == selectedCustomer.ID,
                    x.Name,
                    x.Email,
                    x.Gender,
                    x.PhoneNumber,
                    x.Age
                })
                .ToArray();

            dgvSearch.Columns["ID"].Visible = false;
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvAvailable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            int roomId = int.Parse(dgvAvailable["ID", e.RowIndex].Value.ToString());
            room1 = db.Room.Find(roomId);
        }

        private void btnToSelected_Click(object sender, EventArgs e)
        {
            if (room1 == null)
            {
                MessageBox.Show("Select Available Room first");
                return;
            }

            selectedRooms.Add(room1);
            room1 = null;
            loadData();
            SetTotal();
        }

        private void SetTotal()
        {
            int night = int.Parse(txtNumberOfNights.Text);
            int roomSum = selectedRooms.Sum(x => x.RoomType.RoomPrice * night);
            int itemSum = items.Sum(x => x.Item.RequestPrice * x.Qty);

            labelTotal.Text = $"Total Price: Rp. {roomSum + itemSum}";
        }

        private void dgvSelected_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            int roomId = int.Parse(dgvSelected["ID", e.RowIndex].Value.ToString());
            room2 = selectedRooms.FirstOrDefault(x => x.ID == roomId);
            selectedRooms.Remove(selectedRooms.FirstOrDefault(x => x.ID == roomId));
        }

        private void btnToAvailable_Click(object sender, EventArgs e)
        {
            if (room2 == null)
            {
                MessageBox.Show("Select Selected Room first");
                return;
            }

            selectedRooms.Remove(room2);
            room2 = null;
            loadData();
            SetTotal();
        }

        bool IsValid()
        {
            if (!txtNumberOfNights.Text.IsNumber())
            {
                MessageBox.Show("Number of Nights must be number");
                return false;
            }

            if (int.Parse(txtNumberOfNights.Text) < 1)
            {
                MessageBox.Show("Minimal Number of Night is 1");
                return false;
            }

            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                return;
            }

            numberOfNights = int.Parse(txtNumberOfNights.Text);
            roomTypeId = int.Parse(cbRoomType.SelectedValue.ToString());
            startDateTime = dtpStartDate.Value.Date;
            selectedRooms.Clear();
            loadData();
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (dgvSearch.Columns[e.ColumnIndex].HeaderText == "Choose")
            {
                int customerId = int.Parse(dgvSearch["ID", e.RowIndex].Value.ToString());
                selectedCustomer = db.Customer.FirstOrDefault(x => x.ID == customerId);
                LoadCustomerData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int itemId = int.Parse(cbItem.SelectedValue.ToString());
            var item = db.Item.Find(itemId);
            var request = items
                .FirstOrDefault(x => x.ItemID == itemId);

            if (request == null)
            {
                request = new ReservationRequestItem()
                {
                    ItemID = itemId,
                    Qty = (int)nudQty.Value,
                    Item = item,
                    TotalPrice = (int)nudQty.Value * item.RequestPrice
                };

                items.Add(request);
            }
            else
            {
                int index = items.IndexOf(request);
                items[index].Qty += (int)nudQty.Value;
                items[index].TotalPrice = items[index].Qty * item.RequestPrice;
            }

            LoadItem();
        }

        private void LoadItem()
        {
            dgvRequest.Columns.Clear();
            dgvRequest.DataSource = items.Select(x => new
            {
                x.ID,
                x.Item.Name,
                x.Qty,
                Price = x.TotalPrice,
            })
            .ToArray();

            var column = new DataGridViewButtonColumn
            {
                UseColumnTextForButtonValue = true,
                Text = "Remove",
                HeaderText = "Remove",
                Name = "Remove"
            };

            dgvRequest.Columns.Add(column);
            dgvRequest.Columns["ID"].Visible = false;
            SetTotal();
        }
        bool IsSubmitValid()
        {
            if (selectedRooms.Count == 0)
            {
                MessageBox.Show("Please select at least 1 rooms");
                return false;
            }

            if (panelAddNew.Controls.IsAnyEmpty())
            {
                MessageBox.Show("Please don't leave any fields empty");
                return false;
            }
            if (!txtPhoneNumber.Text.IsPhone())
            {
                MessageBox.Show("Phone number format is incorrect");
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (!IsSubmitValid())
            //{
            //    return;
            //}

            if (selectedCustomer == null)
            {
                selectedCustomer = new Customer
                {
                    Name = txtName.Text,
                    PhoneNumber = txtPhoneNumber.Text
                };

                var customer = db.Customer.FirstOrDefault(x => x.PhoneNumber == selectedCustomer.PhoneNumber);
                if (customer != null)
                {
                    MessageBox.Show("Phone Number already exist");
                    return;
                }

                db.Customer.Add(selectedCustomer);
                db.SaveChanges();
            }

            var reservation = new Reservation
            {
                EmployeeID = employee.ID,
                DateTime = DateTime.Now,
                CustomerID = selectedCustomer.ID,
                Code = Extension.GenerateRandomText(6)
            };

            db.Reservation.Add(reservation);
            db.SaveChanges();

            var reservationRooms = new List<ReservationRoom>();
            foreach (var room in selectedRooms)
            {
                reservationRooms.Add(new ReservationRoom
                {
                    ReservationID = reservation.ID,
                    RoomID = room.ID,
                    StartDateTime = startDateTime,
                    DurationNights = numberOfNights,
                    RoomPrice = room.RoomType.RoomPrice * numberOfNights
                });
            }

            db.ReservationRoom.AddRange(reservationRooms);
            db.SaveChanges();

            var reservationItems = new List<ReservationRequestItem>();
            foreach (var item in items)
            {
                foreach (var room in reservationRooms)
                {
                    reservationItems.Add(new ReservationRequestItem
                    {
                        ReservationRoomID = room.ID,
                        ItemID = item.ItemID,
                        Qty = item.Qty,
                        TotalPrice = item.TotalPrice
                    });
                }
            }

            db.ReservationRequestItem.AddRange(reservationItems);
            db.SaveChanges();

            MessageBox.Show($"Success at booking!\nBooking Code is: {reservation.Code}");
            Close();
        }

        private void rbAddNnew_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAddNnew.Checked)
            {
                panelAddNew.Visible = true;
                txtSearch.Visible = false;
                lblSearch.Visible = false;
            }else if(Search.Checked) {
                panelAddNew.Visible = false;
                txtSearch.Visible = true;
                lblSearch.Visible = true;
            }
        }

        private void Search_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
