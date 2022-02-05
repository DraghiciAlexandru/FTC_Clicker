using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FTC_Clicker.Services;

namespace View.Template
{
    class ViewLogin : Panel
    {
        private PlayerServices playerServices;

        private TextBox txtEmail;
        private TextBox txtPassword;

        private Button btnSignIn;
        private Button btnCancel;

        public Button BtnSignIn
        {
            get { return btnSignIn; }
        }
        public Button BtnCancel
        {
            get { return btnCancel; }
        }

        public TextBox TxtEmail
        {
            get { return txtEmail; }
        }

        public TextBox TxtPassword
        {
            get { return txtPassword; }
        }

        public ViewLogin()
        {
            playerServices = new PlayerServices();
            layout();
        }

        public void layout()
        {
            this.Size = new Size(1920, 945);
            this.BackColor = Color.FromArgb(44, 47, 51);
            this.Name = "viewLogin";

            setLbl();
            setLblEmail();
            setLblPassword();
            setTxtEmail();
            setTxtPassword();
            setSignIn();
            setCancel();
        }

        private void setLbl()
        {
            Label lblTitlu = new Label();

            lblTitlu.AutoSize = false;
            lblTitlu.Size = new Size(300, 70);
            lblTitlu.Text = "Sign in";
            lblTitlu.Location = new Point(800, 150);

            lblTitlu.Font = new Font("Microsoft Sans Serif", 24, FontStyle.Regular);
            lblTitlu.ForeColor = Color.White;

            Controls.Add(lblTitlu);
        }

        private void setLblEmail()
        {
            Label lblEmail = new Label();

            lblEmail.AutoSize = false;
            lblEmail.Size = new Size(200, 40);
            lblEmail.Text = "Email Address";
            lblEmail.Location = new Point(800, 250);

            lblEmail.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            lblEmail.ForeColor = Color.White;

            Controls.Add(lblEmail);
        }

        private void setLblPassword()
        {
            Label lblPassword = new Label();

            lblPassword.AutoSize = false;
            lblPassword.Size = new Size(200, 40);
            lblPassword.Text = "Password";
            lblPassword.Location = new Point(800, 350);

            lblPassword.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            lblPassword.ForeColor = Color.White;

            Controls.Add(lblPassword);
        }

        private void setTxtEmail()
        {
            txtEmail = new TextBox();
            txtEmail.BackColor = Color.FromArgb(44, 47, 51);
            txtEmail.ForeColor = Color.White;

            txtEmail.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            txtEmail.Size = new Size(400, 40);
            txtEmail.Location = new Point(805, 290);

            Controls.Add(txtEmail);
        }

        private void setTxtPassword()
        {
            txtPassword = new TextBox();
            txtPassword.BackColor = Color.FromArgb(44, 47, 51);
            txtPassword.ForeColor = Color.White;

            txtPassword.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            txtPassword.Size = new Size(400, 40);
            txtPassword.Location = new Point(805, 400);

            txtPassword.PasswordChar = '●';

            Controls.Add(txtPassword);
        }

        public void setSignIn()
        {
            btnSignIn = new Button();
            btnSignIn.Name = "btnSign";
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.Location = new Point(825, 450);
            btnSignIn.Size = new Size(150, 50);

            btnSignIn.Text = "Sign In";
            btnSignIn.ForeColor = Color.White;

            btnSignIn.BackColor = Color.FromArgb(114, 137, 218);

            btnSignIn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            Controls.Add(btnSignIn);
        }

        public void setCancel()
        {
            btnCancel = new Button();
            btnCancel.Name = "btnCancel";
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.Location = new Point(1030, 450);
            btnCancel.Size = new Size(150, 50);

            btnCancel.Text = "Cancel";
            btnCancel.ForeColor = Color.FromArgb(114, 137, 218);

            btnCancel.BackColor = Color.FromArgb(44, 47, 51);

            btnCancel.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            Controls.Add(btnCancel);
        }
    }
}
