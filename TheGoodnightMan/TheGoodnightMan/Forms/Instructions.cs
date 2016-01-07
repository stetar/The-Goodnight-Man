using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLoopOne.Forms
{
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
            
            this.MinimumSize = new Size(1024, 768);
            this.MaximumSize = new Size(1024, 768);
            this.CenterToScreen();
            WindowState = FormWindowState.Normal;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenuForm.showWarning = false;
            ActiveForm.Dispose();
            new MainMenuForm().Show();
        }
    }
}
