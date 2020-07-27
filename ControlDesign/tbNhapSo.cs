﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlDesign
{
    public class tbNhapSo : TextBox
    {
        public tbNhapSo()
        {
            KeyPress += TbNhapSo_KeyPress;
        }

        private void TbNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}