using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.admin
{
    public partial class masterEmployeeForm : Core, ICrud<Employee>
    {
        public masterEmployeeForm()
        {
            InitializeComponent();
        }

        public Employee Data { get ; set ; }
        public bool IsInserting { get ; set ; }

        public bool IsValid()
        {
            if (Controls.IsAnyEmpty())
            {
                MessageBox.Show("harap semua diisi");
                return false;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("pasword tidak sama");
                return false;
            }
            if (!txtEmail.Text.IsEmail())
            {
                MessageBox.Show("Email Salah");
                return false;
            }
            if (dtpDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("tanggal salah");
                return false;
            }
            return true;
        }

        public void LoadData()
        {
            dgv.DataSource = db.Employee
                .ToArray()
            .Select(X => new
            {
                X.ID,
                X.Username,
                X.Name,
                X.Email,
                DateOfBirth = X.DateOfBirth.ToString("dd/MM/yyyy"),
                Job = X.Job.Name
            })
            .ToArray();

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
        }

        public void SaveData()
        {
            if (!IsValid())
            {
                return;
            }

            if (IsInserting)
            {
                Data = new Employee();
                db.Employee.Add(Data);
            }

            Data.Username = txtUsername.Text;
            Data.Password = txtPassword.Text.ToSha256();
            Data.Name = txtName.Text;
            Data.Email = txtEmail.Text;
            Data.DateOfBirth = dtpDate.Value.Date;
            Data.JobID = int.Parse(cbJob.SelectedValue.ToString());
            Data.Address = txtAddress.Text;

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

        private void masterEmployeeForm_Load(object sender, EventArgs e)
        {
            cbJob.DataSource = db.Job
                .Select(X => new
                {
                    X.ID,
                    X.Name
                })
                .ToArray();

            cbJob.DisplayMember = "Name";
            cbJob.ValueMember = "ID";
            LoadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgv[0, e.RowIndex].Value.ToString());
            Data = db.Employee.Find(id);
            txtUsername.Text = Data.Username;
            txtName.Text = Data.Name;
            txtEmail.Text = Data.Email;
            dtpDate.Value = Data.DateOfBirth.Date;
            cbJob.Text = Data.Job.Name;
            txtAddress.Text = Data.Address;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show("select data");
                return;
            }
            IsInserting = false;
            SaveMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Data == null)
            {
                MessageBox.Show("select data first");
                return;
            }
            db.Employee.Remove(Data);
            db.SaveChanges();
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NormalMode();
        }

        private void btnMasterEmployee_Click(object sender, EventArgs e)
        {
            Hide();
            new masterEmployeeForm().ShowDialog();
        }
    }
}
