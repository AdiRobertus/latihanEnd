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
                    X.Room,
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
                return;
            }

            if (IsInserting)
            {
                Data = new RoomType();
            }

            Data.Name = txtName.Text;
            Data.Capacity = (int)nudCapacity.Value;
            Data.RoomPrice = int.Parse(txtRoomPrice.Text);

            if (IsInserting)
            {
                db.RoomType.Add(Data);
            }

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
    }
}
