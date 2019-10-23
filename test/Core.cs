using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace test
{
    public partial class Core : Form
    {
        protected PC_XXEntities db = new PC_XXEntities();
        public Core()
        {
            InitializeComponent();
        }
    }

    public static class Extension
    {
        private static Random random = new Random();
        private static readonly string characters = "QWERTYUIOPASDFGHJKLZXCVBNM123456789";

        public static bool IsAnyEmpty(this Control.ControlCollection controls, params Control[] exceptions)
        {
            foreach (Control control in controls)
            {
                if (!exceptions.Contains(control) && control is TextBox && control.Text.Trim() == "")
                {
                    return true;
                }
            }
            return false;
        }

        public static string ToSha256(this string text)
        {
            SHA256 sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public static bool IsNumber(this string text)
        {
            if(text.All(char.IsNumber) && text.Trim() != "")
            {
                return true;
            }
            return false;
        }
        public static bool IsPositifNumber(this string text)
        {
            int number = int.Parse(text);
            if (number > 0)
            {
                return true;
            }
            return false;
        }
        public static void ChangeState(this Control.ControlCollection controls, bool state, params Control[] exceptions)
        {
            foreach (Control control in controls)
            {
                if (!exceptions.Contains(control) && (control is TextBox || control is NumericUpDown || control is ComboBox || control is DateTimePicker || control is RadioButton))
                {
                    control.Enabled = state;
                }
            }
        }
        public static void ClearFields(this Control.ControlCollection controls, params Control[] exceptions)
        {
            foreach (Control control in controls)
            {
                if (!exceptions.Contains(control) && control is TextBox)
                {
                    control.Text = "";
                }
            }
        }
        public static bool IsEmail(this string text)
        {
            var email = new EmailAddressAttribute();
            if (email.IsValid(text))
            {
                return true;
            }
            return false;
        }
        public static bool IsPhone(this string text)
        {
            var split = text.Split('-');
            if (split.Length != 3)
            {
                return false;
            }

            if (split[0].Length != 3 || split[1].Length != 3 || split[2].Length != 4)
            {
                return false;
            }

            if (!split[0].IsNumber() || !split[1].IsNumber() || !split[2].IsNumber())
            {
                return false;
            }

            return true;
        }
        public static string GenerateRandomText(int length)
        {
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }

            return result.ToString();
        }

    }

    
}
