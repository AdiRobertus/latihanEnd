using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.main
{
    public partial class frontOfficeForm : Form
    {
        public frontOfficeForm()
        {
            InitializeComponent();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            new master.reservationForm().ShowDialog();
        }

        private void btnMasterRoomType_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().ShowDialog();
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
