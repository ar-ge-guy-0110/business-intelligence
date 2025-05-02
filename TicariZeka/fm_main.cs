using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace TicariZeka
{
    public partial class fm_main : Form
    {
        //Alanlar
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        //Constructor
        public fm_main()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(10, 170, 140);
            public static Color color8 = Color.FromArgb(240, 55, 65);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left Border Button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                //Title Current Child Form
                lbTitleChildForm.Text = currentBtn.Text;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTitleChildForm.Text = childForm.Text;
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lbTitleChildForm.Text = "Ana Sayfa";
        }
        private void fm_main_Load(object sender, EventArgs e)
        {

        }

        private void btnSermaye_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new main_anatanimlar());
        }

        private void btnTedarik_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new main_tedarikciler());
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new main_urunler());
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new main_musteriler());
        }

        private void btnAlim_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            OpenChildForm(new main_alim());
        }

        private void btnSatim_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            OpenChildForm(new main_satim());
        }

        private void btnTicari_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            OpenChildForm(new main_iszekasi());
        }
        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            OpenChildForm(new main_grafikler());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }
        //Drag Form
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragformclass.ReleaseCapture();
                dragformclass.SendMessage(Handle, dragformclass.WM_NCLBUTTONDOWN, dragformclass.HT_CAPTION, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.IconColor = Color.FromArgb(113, 75, 190);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.IconColor = Color.MediumPurple;
        }

        private void btnMaximize_MouseEnter(object sender, EventArgs e)
        {
            btnMaximize.IconColor = Color.FromArgb(113, 75, 190);
        }

        private void btnMaximize_MouseLeave(object sender, EventArgs e)
        {
            btnMaximize.IconColor = Color.MediumPurple;
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.IconColor = Color.FromArgb(113, 75, 190);
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.IconColor = Color.MediumPurple;
        }


    }
}
