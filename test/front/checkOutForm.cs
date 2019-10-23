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
    public partial class checkOutForm : Core
    {
        List<ReservationCheckOut> items = new List<ReservationCheckOut>();
        public checkOutForm()
        {
            InitializeComponent();
        }

        private void checkOutForm_Load(object sender, EventArgs e)
        {
            cbItem.ValueMember = "ID";
            cbItem.DisplayMember = "Name";
            cbItem.DataSource = db.Item
                .Select(X => new {
                    X.ID,
                    X.Name
                })
                .ToArray();


            cbRoomNumber.ValueMember = "ID";
            cbRoomNumber.DisplayMember = "RoomNumber";
            cbRoomNumber.DataSource = db.ReservationRoom
                .Where(X => X.CheckInDateTime != null && X.CheckOutDateTime != null)
                .Select(X => new
                {
                    X.ID,
                    X.Room.RoomNumber
                }).ToArray();


            cbItemStatus.ValueMember = "ID";
            cbItemStatus.DisplayMember = "Name";
            cbItemStatus.DataSource = db.ItemStatus
                .Select(X => new
                {
                    X.ID,
                    X.Name
                })
                .ToArray();
        }

        void LoadItem()
        {
            var q = items.Select(x => new
            {
                x.ItemID,
                Item = x.Item.Name,
                x.Qty,
                Price = x.Item.RequestPrice * x.Qty,
                Status = x.ItemStatus.Name
            })
            .ToArray();
            labelTotal.Text = $"Total Charge : Rp. {q.Sum(x => x.Qty * x.Price)}";

            dgv.Columns.Clear();
            dgv.DataSource = q;
            var column = new DataGridViewButtonColumn
            {
                HeaderText = "Remove",
                Name = "Remove",
                UseColumnTextForButtonValue = true,
                Text = "Remove"
            };

            dgv.Columns.Add(column);
            dgv.Columns["ItemID"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int itemID = int.Parse(cbItem.SelectedValue.ToString());
            var item = db.Item.Find(itemID);

            int statusID = int.Parse(cbItemStatus.SelectedValue.ToString());
            var status = db.ItemStatus.Find(statusID);

            int reservationID = int.Parse(cbRoomNumber.SelectedValue.ToString());
            var reservation = db.ReservationRoom.Find(reservationID);
            var item2 = items.FirstOrDefault(X => X.ItemID == X.Item.ID);
            if (item2 == null)
            {
                items.Add(new ReservationCheckOut
                {
                    ReservationRoomID = reservationID, 
                    ReservationRoom = reservation,
                    ItemID = itemID,
                    Item = item,
                    ItemStatusID = statusID,
                    ItemStatus = status,
                    Qty = (int)nudQty.Value,
                    TotalCharge = item.CompensationFee ?? 0 * (int)nudQty.Value
                });
            }
            else {
                item2 = items.FirstOrDefault(x => x.ItemID == item.ID && x.ItemStatusID == statusID);
                if (item2 == null)
                {
                    items.Add(new ReservationCheckOut
                    {
                        ReservationRoomID = reservationID,
                        ReservationRoom = reservation,
                        ItemID = itemID,
                        Item = item,
                        Qty = (int)nudQty.Value,
                        TotalCharge = item.CompensationFee ?? 0 * (int)nudQty.Value,
                        ItemStatusID = int.Parse(cbItemStatus.SelectedValue.ToString()),
                        ItemStatus = status
                    });
                }
                else
                {
                    int index = items.IndexOf(item2);
                    items[index].Qty += (int)nudQty.Value;
                }
            }
            LoadItem();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (dgv.Columns[e.ColumnIndex].HeaderText == "Remove")
            {
                int id = int.Parse(dgv["itemID", e.RowIndex].Value.ToString());
                items.Remove(items.FirstOrDefault(x => x.ItemID == id));
                LoadItem();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (items.Count == 0)
            {
                MessageBox.Show("Add item first");
                return;
            }

            foreach (ReservationCheckOut i in items)
            {
                var room = db.ReservationRoom.Find(i.ReservationRoomID);
                room.CheckOutDateTime = DateTime.Now;

                var _item = db.ReservationCheckOut
                    .FirstOrDefault(X => X.ItemID == i.ItemID && X.ReservationRoomID == i.ReservationRoomID);

                if (_item == null)
                {
                    db.ReservationCheckOut.Add(i);
                }
                else
                {
                    int statusID = int.Parse(cbItemStatus.SelectedValue.ToString());
                    int itemID = _item.ItemID;

                    _item = db.ReservationCheckOut
                        .FirstOrDefault(X => X.ItemID == i.ItemID && X.ItemStatus == i.ItemStatus && X.ReservationRoomID == i.ReservationRoomID);
                    if (_item == null)
                    {
                        db.ReservationCheckOut.Add(i);
                    }
                    else
                    {
                        _item.Qty += i.Qty;
                        _item.TotalCharge = _item.Qty * _item.Item.CompensationFee ?? 0;
                    }
                }
            }
            db.SaveChanges();
            reset();
        }

        private void reset()
        {
            items.Clear();
            LoadItem();
        }

        private void cbRoomNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int reservationID = int.Parse(cbRoomNumber.SelectedValue.ToString());
            var reservation = db.ReservationRoom.Find(reservationID);

            for (int i = 0; i < items.Count; i++)
            {
                items[i].ReservationRoomID = reservationID;
                items[i].ReservationRoom = reservation;
            }
        }
    }
}
