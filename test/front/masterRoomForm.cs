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
    public partial class masterRoomForm : Core, ICrud<Room>
    {
        public masterRoomForm()
        {
            InitializeComponent();
        }

        public Room Data { get; set; }
        public bool IsInserting { get ; set ; }

        public bool IsValid()
        {
            if (Controls.IsAnyEmpty())
            {
                MessageBox.Show("Don't leave any empty");
                return false;
            }
            if (!txtRoomNumber.Text.IsNumber())
            {
                MessageBox.Show("Room Number must be number");
                return false;
            }

            if (!txtRoomFloor.Text.IsNumber())
            {
                MessageBox.Show("Room Floor must be number");
                return false;
            }
            return true;
        }

        public void LoadData()
        {
            dgv.DataSource = db.Room
                .Select(X => new
                {
                    X.ID,
                    X.RoomNumber,
                    RoomType = X.RoomType.Name,
                    X.RoomFloor,
                    X.Description
                }).ToArray();

            dgv.Columns[0].Visible = false;
            NormalMode();
        }

        public void NormalMode()
        {

            Controls.ChangeState(false);
            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            Controls.ClearFields();
            Data = null;
        }

        public void SaveData()
        {
            if (!IsValid())
            {
                return;
            }
            if (IsInserting)
            {
                Data = new Room();
                db.Room.Add(Data);
            }

            Data.RoomNumber = txtRoomNumber.Text;
            Data.RoomTypeID = int.Parse(cbRoomType.SelectedValue.ToString());
            Data.RoomFloor = txtRoomFloor.Text;
            Data.Description = txtDescription.Text == "" ? null : txtDescription.Text;

           

            db.SaveChanges();
            LoadData();
        }

        public void SaveMode()
        {
            Controls.ChangeState(true);
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void masterRoomForm_Load(object sender, EventArgs e)
        {
            cbRoomType.DisplayMember = "Name";
            cbRoomType.ValueMember = "ID";
            cbRoomType.DataSource = db.RoomType
                .Select(x => new
                {
                    x.ID,
                    x.Name
                })
                .ToArray();

            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            IsInserting = true;
            Controls.ClearFields();
            SaveMode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show("Invalid");
                return;
            }
            IsInserting = false;
            SaveMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show("Select Data first");
                return;
            }

            if (db.Room.Count(x => x.RoomTypeID == Data.ID) != 0)
            {
                MessageBox.Show("Please delete or update data in Room with this RoomType first");
                return;
            }
            if (MessageBox.Show("are you sure?", "Question", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                db.Room.Remove(Data);
                db.SaveChanges();
                LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NormalMode();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            new master.reservationForm().ShowDialog();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new master.checkInForm().ShowDialog();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            this.Hide();
            new master.requestForm().ShowDialog();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            new master.checkOutForm().ShowDialog();
        }

        private void btnMasterRoomType_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
        }

        private void btnMasterRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            new master.masterRoomForm().ShowDialog();
        }

        private void btnMasterItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new front.masterItemForm().ShowDialog();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

                int id = int.Parse(dgv[0, e.RowIndex].Value.ToString());
                Data = db.Room.Find(id);
                txtRoomNumber.Text = Data.RoomNumber;
                cbRoomType.Text = Data.RoomType.Name;
                txtRoomFloor.Text = Data.RoomFloor;
                txtDescription.Text = Data.Description;
        }
    }
}
