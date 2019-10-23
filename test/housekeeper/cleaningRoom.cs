using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace test.housekeeper
{
       
    public partial class cleaningRoom : Core
    {
        private Employee employee;
        private List<CleaningRoomDetail> details = new List<CleaningRoomDetail>();
        public cleaningRoom(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var excel = new Excel.Application();
            var workbooks = excel.Workbooks;
            var dialog = new OpenFileDialog
            {
                Title = "Choose location to save",
                Filter = "excel file(*.xlsx)|*.xlsx",
                Multiselect = false
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var workbook = workbooks.Open(dialog.FileName);
            Excel.Worksheet worksheet = workbook.Worksheets[1];
            var cells = worksheet.Cells;
            cells.ClearFormats();

            var range = worksheet.UsedRange;
            var columns = range.Columns;
            var rows = range.Rows;

            Excel.Range range2 = worksheet.Range[worksheet.Cells[5,1], worksheet.Cells[rows.Count, columns.Count]];
            var values = (object[,])range2.Value2;
            string lastRoomNumber = "";

            var cleaningRoom = db.CleaningRoom
                .Where(X => X.EmployeeID == X.Employee.ID)
                .ToArray();

            var cleaningDetail = db.CleaningRoomDetail
                .ToArray()
                .Where(X => cleaningRoom.Select(Y => Y.ID)
                .Contains(X.CleaningRoomID))
                .ToArray();

            var cleaningItem = db.CleaningRoomItem
                .ToArray()
                .Where(X => cleaningDetail.Select(Y => Y.CleaningRoomID)
                .Contains(X.ID))
                .ToArray();

            try{
                db.CleaningRoomItem.RemoveRange(cleaningItem);
                db.SaveChanges();

                db.CleaningRoomDetail.RemoveRange(cleaningDetail);
                db.SaveChanges();

                db.CleaningRoom.RemoveRange(cleaningRoom);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error during deleting");
            }

            string date = cells[1,2].Value2.ToString();
            DateTime date2 = new DateTime();

            try
            {
                date2 = DateTime.ParseExact(date, "dd MM yyyy hh:mm",null);
            }
            catch
            {
                MessageBox.Show("date time in wrong Format");
                date2 = DateTime.Now.Date;
            }

            var cleaning = new CleaningRoom
            {
                Date = date2,
                EmployeeID = employee.ID
            };

            db.CleaningRoom.Add(cleaning);
            db.SaveChanges();

            var detail = new CleaningRoomDetail();
            for (int i = 1; i <= values.GetLength(0); i++)
            {
                bool addingNew = false;
                if (values[i, 1] != null && values[i, 1].ToString() != "")
                {
                    lastRoomNumber = values[i, 1].ToString();
                    addingNew = true;
                }

                if (addingNew)
                {
                    detail.CleaningRoomID = cleaning.ID;
                    detail.RoomID = db.Room.FirstOrDefault(x => x.RoomNumber == lastRoomNumber).ID;
                    if (values[i, 2] == null)
                    {
                        detail.StartDateTime = null;

                    }
                    else
                    {
                        detail.StartDateTime = DateTime.ParseExact(values[i, 2].ToString(), "dd MMMM yyyy hh:mm", CultureInfo.InvariantCulture);

                    }

                    if (values[i, 3] == null)
                    {
                        detail.FinishDateTime = null;

                    }
                    else
                    {
                        detail.FinishDateTime = DateTime.ParseExact(values[i, 3].ToString(), "dd MMMM yyyy hh:mm", CultureInfo.InvariantCulture);

                    }

                    if (values[i, 4] == null)
                    {
                        detail.Note = null;

                    }
                    else
                    {
                        detail.Note = values[i, 4].ToString();

                    }

                    if (values[i, 5] == null)
                    {
                        detail.StatusCleaning = null;

                    }
                    else
                    {
                        detail.StatusCleaning = values[i, 5].ToString();

                    }

                    db.CleaningRoomDetail.Add(detail);
                    db.SaveChanges();
                }
                string name = values[i, 6].ToString();
                int qty = int.Parse(values[i, 7].ToString());
                string status = values[i, 8].ToString();
                var item = db.Item.FirstOrDefault(x => x.Name == name);
                if (item == null)
                {
                    MessageBox.Show($"Item not found at row {i}");
                }
                else
                {
                    var detailItem = new CleaningRoomItem
                    {
                        CleaningRoomDetailID = detail.ID,
                        ItemID = item.ID,
                        Qty = qty,
                        Status = status
                    };

                    db.CleaningRoomItem.Add(detailItem);
                    db.SaveChanges();
                }
            }

            Marshal.ReleaseComObject(range2);
            Marshal.ReleaseComObject(columns);
            Marshal.ReleaseComObject(rows);
            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(cells);
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(excel);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var excel = new Excel.Application();
            var workbooks = excel.Workbooks;
            var workbook = workbooks.Add();
            var worksheets = workbook.Worksheets;
            Excel.Worksheet worksheet = worksheets.Add();

            var cells = worksheet.Cells;
            cells[1, 1].Value2 = "Date";
            cells[2, 1].Value2 = "Employee";
            cells[1, 2].Value2 = DateTime.Now.ToString("dd/MM/yyyy");

            cells[4, 1].Value2 = "RoomNumber";
            cells[4, 2].Value2 = "StartDateTime";
            cells[4, 3].Value2 = "EndDateTime";
            cells[4, 4].Value2 = "Note";
            cells[4, 5].Value2 = "StatusCleaning";
            cells[4, 6].Value2 = "Item";
            cells[4, 7].Value2 = "Qty";
            cells[4, 8].Value2 = "Status";

            int row = 1;
            for (int i = 0; i < details.Count; i++)
            {
                cells[4 + row, 1].Value2 = details[i].Room.RoomNumber;
                if (details[i].StartDateTime == null)
                {
                    cells[4 + row, 2].Value2 = "";

                }
                else
                {
                    cells[4 + row, 2].Value2 = details[i].StartDateTime.Value.ToString("MM/dd/yyyy HH:mm");

                }

                if (details[i].FinishDateTime == null)
                {
                    cells[4 + row, 3].Value2 = "";

                }
                else
                {
                    cells[4 + row, 3].Value2 = details[i].FinishDateTime.Value.ToString("MM/dd/yyyy HH:mm");

                }

                if (details[i].Note == null)
                {
                    cells[4 + row, 4].Value2 = "";

                }
                else
                {
                    cells[4 + row, 4].Value2 = details[i].Note;

                }

                if (details[i].StatusCleaning == null)
                {
                    cells[4 + row, 5].Value2 = "";

                }
                else
                {
                    cells[4 + row, 5].Value2 = details[i].StatusCleaning;

                }

                var items = details[i].CleaningRoomItem.ToArray();
                for (int j = 0; j < items.Length; j++)
                {
                    cells[4 + row, 6].Value2 = items[j].Item.Name;
                    cells[4 + row, 7].Value2 = items[j].Qty;
                    cells[4 + row, 8].Value2 = items[j].Status;
                    if (j != items.Length - 1)
                    {
                        row++;
                    }
                }

                row++;
            }

            cells.ClearFormats();
            var range = worksheet.UsedRange;
            var rows = range.Rows;
            var columns = range.Columns;
            Excel.Range range2 = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[rows.Count, columns.Count]];
            range2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            var dialog = new SaveFileDialog
            {
                Title = "Choose location to save",
                Filter = "excel file(*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var directory = Path.GetDirectoryName(dialog.FileName);
                workbook.SaveAs($@"{directory}\{DateTime.Now.ToString("dd/MM/yyyy")}.xlsx");
            }

            workbook.Close();
            workbooks.Close();
            excel.Quit();

            Marshal.ReleaseComObject(range2);
            Marshal.ReleaseComObject(columns);
            Marshal.ReleaseComObject(rows);
            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(cells);
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(worksheets);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(workbooks);
            Marshal.ReleaseComObject(excel);
        }

        void loadData()
        {
            dgvSchedule.DataSource = details
                .Select(X => new
                {
                    X.ID,
                    X.Room.RoomNumber,
                    X.StartDateTime,
                    EndDateTime = X.FinishDateTime,
                    X.Note,
                    X.StatusCleaning
                })
                .ToArray();

            dgvSchedule.Columns["ID"].Visible = false;
        }

        private void cleaningRoom_Load(object sender, EventArgs e)
        {
            details = db.CleaningRoomDetail
                .ToArray()
                .Where(X => X.CleaningRoom.EmployeeID == employee.ID && X.CleaningRoom.Date.Date == DateTime.Now.Date)
                .ToList();

            loadData();
        }

        private void dgvSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 1)
            {
                return;
            }

            int scheduleID = int.Parse(dgvSchedule["ID", e.RowIndex].Value.ToString());

            dgvDetail.DataSource = db.CleaningRoomItem
                .Where(X => X.CleaningRoomDetailID == scheduleID)
                .Select(X => new
                {
                    item = X.Item.Name,
                    X.Qty,
                    X.Status
                }).ToArray();
        }
    }
}

