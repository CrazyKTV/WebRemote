using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace crazyKTV
{
    public partial class transparentButton : TransparentControl, Button
    {
        public transparentButton()
        {
            InitializeComponent();
        }

        public transparentButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
