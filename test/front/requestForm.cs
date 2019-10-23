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
    public partial class requestForm : Core
    {
        List<ReservationRequestItem> items = new List<ReservationRequestItem>();
        public requestForm()
        {
            InitializeComponent();
        }

        private void requestForm_Load(object sender, EventArgs e)
        {
            cbRoomNumber.ValueMember = "ID";
            cbRoomNumber.DisplayMember = "RoomNumber";
            cbRoomNumber.DataSource = db.ReservationRoom
                .Where(X => X.CheckInDateTime != null && X.CheckOutDateTime != null)
                .Select(X => new
                {
                    X.ID,
                    X.Room.RoomNumber
                })
                .ToArray();

            cbItem.ValueMember = "ID";
            cbItem.DisplayMember = "Name";
            cbItem.DataSource = db.Item
                .Select(X => new
                {
                    X.ID,
                    X.Name
                })
                .ToArray();

            dgv.DataSource = items.Select(X => new
            {
                X.ID,
                X.Item,
                X.Qty
            });
        }

        void loadItem()
        {
            var q = items.Select(X => new
            {
                X.ID,
                Item = X.Item.Name,
                X.Qty,
                TotalPrice = X.Item.RequestPrice * X.Qty
            })
            .ToArray();
            labelTotal.Text = $"Total Charge : Rp. {q.Sum(X => X.Qty * X.TotalPrice)}";

            dgv.Columns.Clear();
            dgv.DataSource = q;
            var column = new DataGridViewButtonColumn {
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

            int reservationID = int.Parse(cbRoomNumber.SelectedValue.ToString());
            var reservation = db.ReservationRoom.Find(reservationID);

            var item2 = items.FirstOrDefault(X => X.ItemID == X.Item.ID);

            if (item2 == null)
            {
                items.Add(new ReservationRequestItem
                {
                    ReservationRoomID = reservationID,
                    ItemID = itemID,
                    Qty = (int)nudQty.Value,
                    TotalPrice = item.RequestPrice * (int)nudQty.Value
                });
            }
            else
            {
                int index = items.IndexOf(item2);
                items[index].Qty += (int)nudQty.Value;
                items[index].TotalPrice = item.RequestPrice * items[index].Qty;
            }
            loadItem();
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
                loadItem();
            }
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (items.Count == 0)
            {
                MessageBox.Show("Select item first");
                return;
            }
            foreach (ReservationRequestItem i in items)
            {
                var _item = db.ReservationRequestItem
                    .FirstOrDefault(X => X.ItemID == i.ItemID && X.ReservationRoomID == i.ReservationRoomID);

                if (_item == null)
                {
                    db.ReservationRequestItem.Add(i);
                }
                else
                {
                    _item.Qty += i.Qty;
                    _item.TotalPrice = _item.Qty * _item.Item.RequestPrice;
                }
            }
            db.SaveChanges();
            reset();
        }

        private void reset()
        {
            items.Clear();
            loadItem();
        }
    }
}
