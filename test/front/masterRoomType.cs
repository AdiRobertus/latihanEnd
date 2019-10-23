using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Core, ICrud<RoomType>
    {
        public Form1()
        {
            InitializeComponent();
        }

        public RoomType Data { get ; set; }
        public bool IsInserting { get ; set; }

        public bool IsValid()
        {
            if (Controls.IsAnyEmpty())
            {
                MessageBox.Show("harap diisi");
                return false;
            }
            if (!txtRoomPrice.Text.IsPositifNumber())
            {
                MessageBox.Show("harga tidak boleh negatif");
                return false;
            }
            return true;
        }

        public void LoadData()
        {
            dgv.DataSource = db.RoomType
                .Select(X => new
                {
                    X.ID,
                    X.Name,
                    X.Capacity,
                    X.RoomPrice
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
                return ;
            }

            if (IsInserting)
            {
                Data = new RoomType();
                db.RoomType.Add(Data);
            }

            Data.Name = txtName.Text;
            Data.Capacity = (int)nudCapacity.Value;
            Data.RoomPrice = int.Parse(txtRoomPrice.Text);

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

            if (MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.RoomType.Remove(Data);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            int id = int.Parse(dgv[0, e.RowIndex].Value.ToString());
            Data = db.RoomType.Find(id);
            txtName.Text = Data.Name;
            nudCapacity.Value = Data.Capacity;
            txtRoomPrice.Text = Data.RoomPrice.ToString();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new master.checkInForm().ShowDialog();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            new master.reservationForm().ShowDialog();
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
    }
}
