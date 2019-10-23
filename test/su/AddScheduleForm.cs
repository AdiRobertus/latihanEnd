using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.su
{
    public partial class AddScheduleForm : Core
    {
        public AddScheduleForm()
        {
            InitializeComponent();
        }
        public bool IsValid()
        {
            if (dtpDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("gak bisa balik ke masa lalu woy");
                return false;
            }

            int idEmployee = int.Parse(cbHousekeeper.SelectedValue.ToString());
            var detail = db.CleaningRoomDetail
                .FirstOrDefault(X =>
                    X.CleaningRoom.Date == dtpDate.Value.Date &&
                    X.CleaningRoom.EmployeeID == idEmployee &&
                    X.Room.RoomNumber == cbRoomNumber.Text
                );

            if (detail != null)
            {
                MessageBox.Show("udah ada");
                return false;
            }
            return true;
        }

        public void saveData()
        {
            if (!IsValid())
            {
                return;
            }
            int idEmployee = int.Parse(cbHousekeeper.SelectedValue.ToString());

            var cleaning = db.CleaningRoom
                .FirstOrDefault(X => 
                X.Date == dtpDate.Value.Date && 
                X.EmployeeID == idEmployee);

            if (cleaning == null)
            {
                cleaning = new CleaningRoom
                {
                    Date = dtpDate.Value.Date,
                    EmployeeID = idEmployee

                };
                db.CleaningRoom.Add(cleaning);
                db.SaveChanges();
            }

            int idRoom = int.Parse(cbRoomNumber.SelectedValue.ToString());
            db.CleaningRoomDetail.Add(new CleaningRoomDetail
            {
                CleaningRoomID = cleaning.ID,
                RoomID = idRoom
            });
            db.SaveChanges();
            loadData();
        }

        public void loadData()
        {
            int id = int.Parse(cbHousekeeper.SelectedValue.ToString());

            dgv.Columns.Clear();
            dgv.DataSource = db.CleaningRoomDetail
                .Where(x =>
                    x.CleaningRoom.EmployeeID == id
                )
                .Select(x => new
                {
                    x.ID,
                    x.CleaningRoom.Date,
                    Housekeeper = x.CleaningRoom.Employee.Name,
                    x.Room.RoomNumber
                })
                .ToArray();

            var column = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "Remove",
                Text = "Remove",
                UseColumnTextForButtonValue = true
            };

            dgv.Columns.Add(column);
            dgv.Columns["ID"].Visible = false;

        }
        private void AddScheduleForm_Load(object sender, EventArgs e)
        {
            cbHousekeeper.ValueMember = "ID";
            cbHousekeeper.DisplayMember = "Name";
            cbHousekeeper.DataSource = db.Employee
                .Where(X => X.JobID == 4)
                .Select(X => new
                {
                    X.ID,
                    X.Name
                })
                .ToArray();

            cbRoomNumber.ValueMember = "ID";
            cbRoomNumber.DisplayMember = "RoomNumber";
            cbRoomNumber.DataSource = db.Room
                .Select(X => new
                {
                    X.ID,
                    X.RoomNumber
                })
                .ToArray();
            loadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].HeaderText == "Remove")
            {
                int id = int.Parse(dgv["ID", e.RowIndex].Value.ToString());
                var detail = db.CleaningRoomDetail.Find(id);
                db.CleaningRoomDetail.Remove(detail);
                db.SaveChanges();
                loadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cbHousekeeper_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
