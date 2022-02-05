using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FTC_Clicker.Services;
using View.Template;

namespace View.View
{
    class FrmViewPlayer : Form
    {
        private Panel Header;
        private Panel Aside;
        private Panel Main;
        private Label lblHeader;

        private FlowLayoutPanel Content;

        public FrmViewPlayer()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new Panel();
            Content = new FlowLayoutPanel();

            layout();
        }

        public void layout()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            this.Size = Screen.FromHandle(this.Handle).WorkingArea.Size;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(44, 47, 51);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);

            setHeader(Header);
            setAside(Aside);
            setMain(Main);
            setPanelContent(Content);
        }

        public void setHeader(Panel header)
        {
            header.Size = new Size(1920, 75);
            header.Location = new Point(0, 0);
            header.BackColor = Color.FromArgb(114, 137, 218);

            header.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            setSignIn(header);
            setSignUp(header);
            setClose(header);

            this.Controls.Add(header);
        }

        public void setHeaderLoged(Panel header)
        {
            header.Size = new Size(1920, 100);
            header.Location = new Point(0, 0);
            header.BackColor = Color.FromArgb(114, 137, 218);

            header.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            setSignOut(header);
            setClose(header);
            setLblBalance(header);

            this.Controls.Add(header);
        }

        public void setLblBalance(Panel header)
        {
            lblHeader = new Label();

            lblHeader.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            lblHeader.Location = new Point(header.Size.Width / 2 - 250, 10);
            lblHeader.Size = new Size(500, 50);
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;

            lblHeader.ForeColor = Color.White;

            if (PlayerServices.loged != null)
            {
                lblHeader.Text = PlayerServices.loged.Balance.ToString() + "$";
            }

            header.Controls.Add(lblHeader);
        }

        public void setSignOut(Panel header)
        {
            Button btnSignOut = new Button();
            btnSignOut.Name = "btnSignOut";
            btnSignOut.FlatStyle = FlatStyle.Flat;
            btnSignOut.FlatAppearance.BorderSize = 0;
            btnSignOut.Location = new Point(1750, 0);
            btnSignOut.Size = new Size(100, 75);

            btnSignOut.Text = "Sign Out";
            btnSignOut.ForeColor = Color.White;

            btnSignOut.Click += BtnSignOut_Click;

            header.Controls.Add(btnSignOut);
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            Aside.Controls.Clear();
            Main.Controls.Clear();
            setAside(Aside);
            setMain(Main);
            setHeader(Header);
            PlayerServices.loged = null;
            Header.Controls.Remove(sender as Button);
        }

        public void setSignIn(Panel header)
        {
            Button btnSignIn = new Button();
            btnSignIn.Name = "btnSignIn";
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.Location = new Point(1650, 0);
            btnSignIn.Size = new Size(100, 75);

            btnSignIn.Text = "Sign In";
            btnSignIn.ForeColor = Color.White;

            btnSignIn.Click += BtnSignIn_Click;

            header.Controls.Add(btnSignIn);
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            Aside.Visible = false;
            Main.Visible = false;
            ViewLogin view = new ViewLogin();
            view.Location = new Point(0, 75);

            view.BtnSignIn.Click += BtnSignIn_Click1;
            view.BtnCancel.Click += BtnCancel_Click;

            Controls.Add(view);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ViewLogin view = new ViewLogin();
            foreach (Control x in Controls)
            {
                if (x.Name == "viewLogin")
                {
                    view = x as ViewLogin;
                }
            }

            setAside(Aside);
            Aside.Show();
            setMain(Main);
            Main.Visible = true;

            Controls.Remove(view);
        }

        private void BtnSignIn_Click1(object sender, EventArgs e)
        {
            ViewLogin view = new ViewLogin();

            PlayerServices playerServices = new PlayerServices();


            foreach (Control x in Controls)
            {
                if (x.Name == "viewLogin")
                {
                    view = x as ViewLogin;
                }
            }

            if (view.TxtEmail.Text.Trim(' ') != "" && view.TxtPassword.Text.Trim(' ') != "")
            {
                if (playerServices.getByEmail(view.TxtEmail.Text) != null)
                {
                    if (playerServices.getByEmail(view.TxtEmail.Text).Password == view.TxtPassword.Text)
                    {
                        PlayerServices.loged = playerServices.getByEmail(view.TxtEmail.Text);
                        setAsideLoged(Aside);
                        Aside.Show();
                        setMain(Main);
                        Main.Visible = true;
                        Header.Controls.Clear();
                        setHeaderLoged(Header);
                        Controls.Remove(view);
                    }
                }
            }
        }

        public void setSignUp(Panel header)
        {
            Button btnSignUp = new Button();
            btnSignUp.Name = "btnSignUp";
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.Location = new Point(1750, 0);
            btnSignUp.Size = new Size(100, 75);

            btnSignUp.Text = "Sign Up";
            btnSignUp.ForeColor = Color.White;

            header.Controls.Add(btnSignUp);
        }

        public void setClose(Panel header)
        {
            Button btnClose = new Button();
            btnClose.Text = "Exit";
            btnClose.Size = new Size(40, 40);
            btnClose.Location = new Point(1870, 5);

            btnClose.Click += BtnClose_Click;

            header.Controls.Add(btnClose);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setAside(Panel aside)
        {
            aside.Controls.Clear();
            aside.Size = new Size(1920, 250);
            aside.Location = new Point(0, 75);
            aside.BackColor = Color.FromArgb(35, 39, 42);
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);


            this.Controls.Add(aside);
        }

        private void setAsideLoged(Panel aside)
        {
            aside.Controls.Clear();
            aside.Size = new Size(1920, 240);
            aside.Location = new Point(0, 75);
            aside.BackColor = Color.FromArgb(35, 39, 42);
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);

            setBtnShopRobots(aside);
            setBtnShopFields(aside);
            setBtnShopBoost(aside);

            this.Controls.Add(aside);
        }

        private void setMain(Panel main)
        {
            main.Location = new Point(0, 315);
            main.Size = new Size(1920, this.Height - 315);
            main.Padding = new Padding(50);

            this.Controls.Add(main);
        }

        private void setPanelContent(FlowLayoutPanel content)
        {
            content.Size = Main.Size;
            content.Location = new Point(0, 0);
            content.Visible = false;
            content.BackColor = Color.FromArgb(44, 47, 51);

            Main.Controls.Add(content);
        }

        private void setBtnShopRobots(Panel aside)
        {
            Button btnShopRobots = new Button();
            btnShopRobots.Name = "btnShopRobots";
            btnShopRobots.FlatStyle = FlatStyle.Flat;
            btnShopRobots.FlatAppearance.BorderSize = 0;
            btnShopRobots.Location = new Point(0, 0);
            btnShopRobots.Size = new Size(300, 80);


            btnShopRobots.Text = "Robots";
            btnShopRobots.ForeColor = Color.White;

            btnShopRobots.Click += BtnCourses_Click;

            aside.Controls.Add(btnShopRobots);
        }

        private void setBtnShopFields(Panel aside)
        {
            Button btnShopFields = new Button();
            btnShopFields.Name = "btnShopFields";
            btnShopFields.FlatStyle = FlatStyle.Flat;
            btnShopFields.FlatAppearance.BorderSize = 0;
            btnShopFields.Location = new Point(0, 80);
            btnShopFields.Size = new Size(300, 80);


            btnShopFields.Text = "Fileds";
            btnShopFields.ForeColor = Color.White;

            btnShopFields.Click += BtnCourses_Click;

            aside.Controls.Add(btnShopFields);
        }

        private void setBtnShopBoost(Panel aside)
        {
            Button btnShopBoost = new Button();
            btnShopBoost.Name = "btnShopBoost";
            btnShopBoost.FlatStyle = FlatStyle.Flat;
            btnShopBoost.FlatAppearance.BorderSize = 0;
            btnShopBoost.Location = new Point(0, 160);
            btnShopBoost.Size = new Size(300, 80);


            btnShopBoost.Text = "Boost";
            btnShopBoost.ForeColor = Color.White;

            btnShopBoost.Click += BtnCourses_Click;

            aside.Controls.Add(btnShopBoost);
        }

        private void BtnCourses_Click(object sender, EventArgs e)
        {

        }
    }
}
