using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.front
{
    public partial class masterItemForm : Core, ICrud<Item>
    {
        public masterItemForm()
        {
            InitializeComponent();
        }

        public Item Data { get ; set ; }
        public bool IsInserting { get ; set ; }

        public bool IsValid()
        {
            if (Controls.IsAnyEmpty())
            {
                MessageBox.Show("Harap diisi");
                return false;
            }
            if (!txtRequestPrice.Text.IsPositifNumber())
            {
                MessageBox.Show("nilai request price tidak boleh negatif");
                return false;
            }
            if (!txtCompensationPrice.Text.IsPositifNumber())
            {
                if (txtCompensationPrice.Text.Trim() != "")
                {
                    MessageBox.Show("nilai Compensation Price tidak boleh negatif atau kosong");
                    return false;
                }
            }
            return true;
        }

    public void LoadData()
        {

            dgv.DataSource = db.Item
                .Select(X => new
                {
                    X.ID,
                    X.Name,
                    X.RequestPrice,
                    X.CompensationFee
                })
                .ToArray();

            dgv.Columns[0].Visible = false;
            NormalMode();
        }

        public void NormalMode()
        {
            Controls.ChangeState(false);
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
            btnCancel.Enabled = btnSave.Enabled = false;
        }

        public void SaveData()
        {
            if (!IsValid())
            {
                return;
            }
            if (IsInserting)
            {
                Data = new Item();
                db.Item.Add(Data);
            }
            Data.Name = txtName.Text;
            Data.RequestPrice = int.Parse(txtRequestPrice.Text.ToString());
            Data.CompensationFee = txtCompensationPrice.Text.Trim() == "" ? new int?() : int.Parse(txtCompensationPrice.Text.ToString());

            db.SaveChanges();
            LoadData();

        }

        public void SaveMode()
        {
            Controls.ChangeState(true);
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
            btnCancel.Enabled = btnSave.Enabled = true;
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
                MessageBox.Show("diisi woy");
                return;
            }

            IsInserting = false;
            SaveMode();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgv[0, e.RowIndex].Value.ToString());
            Data = db.Item.Find(id);

            txtName.Text = Data.Name;
            txtRequestPrice.Text = Data.RequestPrice.ToString();
            txtCompensationPrice.Text = Data.CompensationFee.ToString();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show("pilih ajg");
                return;
            }
            if (MessageBox.Show("Are you sure ?", "question", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                db.Item.Remove(Data);
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

        private void masterItemForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
