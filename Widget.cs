using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWidgets {
    public partial class Widget : Form {
        public string FilePath;

        public Widget(string imagePath) {
            InitializeComponent();
            pictureBox1.BackgroundImage = new Bitmap(imagePath);
            
            FilePath = imagePath;
        }

        public void setStyle() {
            this.FormBorderStyle = FormBorderStyle.None;
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.None;
            button1.Visible = false;
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            button1.Visible = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
