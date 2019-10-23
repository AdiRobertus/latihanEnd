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
    public partial class Login : Core
    {
        public Login()
        {
            InitializeComponent();
        }

        bool IsValid()
        {
            if (Controls.IsAnyEmpty())
            {
                MessageBox.Show("Don't leave any fields empty");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                return;
            }

            string password = textBox2.Text.ToSha256();

            var employee = db.Employee
                .FirstOrDefault(X =>
                X.Username == textBox1.Text &&
                X.Password == password
                );

            if (employee == null)
            {
                MessageBox.Show("User not found");
                return;
            }

            Hide();
            switch (employee.JobID)
            {
                case 1:
                    new main.frontOfficeForm().ShowDialog();
                    break;
                case 4:
                    new main.houseKeeperForm().ShowDialog();
                    break;
                case 6:
                    new main.supervisiorForm().ShowDialog();
                    break;
                case 7:
                    new main.adminForm().ShowDialog();
                    break;
                default:
                    MessageBox.Show("Job Type not found");
                    break;
            }
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
