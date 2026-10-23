using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class frmSchoolMain : Form
    {
        public frmSchoolMain()
        {
            InitializeComponent();
        }

        private void ShowMdiChild<T>() where T : Form, new()
        {
            var openForm = this.MdiChildren.OfType<T>().FirstOrDefault();
            if (openForm != null)
            {
                openForm.Activate();
                if (openForm.WindowState == FormWindowState.Minimized)
                    openForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                var newForm = new T
                {
                    MdiParent = this,
                    StartPosition = FormStartPosition.CenterScreen
                };
                newForm.Show();
            }
        }

        private void menuStudentList_Click(object sender, EventArgs e) => ShowMdiChild<frmStudentList>();
        private void menuCourseList_Click(object sender, EventArgs e) => ShowMdiChild<frmCourseList>();

        private void menuCascade_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.Cascade);
        private void menuTileHorizontal_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.TileHorizontal);
        private void menuTileVertical_Click(object sender, EventArgs e) => this.LayoutMdi(MdiLayout.TileVertical);
        private void menuCloseAll_Click(object sender, EventArgs e)
        {
            foreach (var child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void menuLogout_Click(object sender, EventArgs e) => this.Close();
        private void menuExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}