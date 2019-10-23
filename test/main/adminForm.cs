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
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
        }

        private void btnMasterEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            new admin.masterEmployeeForm().ShowDialog();
        }
    }
}
