namespace _20190625_基于WinForm的门店管理系统.WinForm
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnAbout = new CCWin.SkinControl.SkinButton();
            this.textbox1 = new CCWin.SkinControl.SkinTextBox();
            this.btnId = new CCWin.SkinControl.SkinButton();
            this.pnlImgTx = new CCWin.SkinControl.SkinPanel();
            this.btnState = new CCWin.SkinControl.SkinButton();
            this.textbox2 = new CCWin.SkinControl.SkinTextBox();
            this.btnJpPwd = new CCWin.SkinControl.SkinButton();
            this.textbox1.SuspendLayout();
            this.pnlImgTx.SuspendLayout();
            this.textbox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.btnAbout.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAbout.DownBack = null;
            this.btnAbout.Location = new System.Drawing.Point(192, 249);
            this.btnAbout.MouseBack = null;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.NormlBack = null;
            this.btnAbout.Size = new System.Drawing.Size(121, 35);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "登录";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // textbox1
            // 
            this.textbox1.BackColor = System.Drawing.Color.Transparent;
            this.textbox1.Controls.Add(this.btnId);
            this.textbox1.DownBack = null;
            this.textbox1.Icon = null;
            this.textbox1.IconIsButton = false;
            this.textbox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textbox1.IsPasswordChat = '\0';
            this.textbox1.IsSystemPasswordChar = false;
            this.textbox1.Lines = new string[0];
            this.textbox1.Location = new System.Drawing.Point(192, 106);
            this.textbox1.Margin = new System.Windows.Forms.Padding(0);
            this.textbox1.MaxLength = 32767;
            this.textbox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.textbox1.MouseBack = ((System.Drawing.Bitmap)(resources.GetObject("textbox1.MouseBack")));
            this.textbox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textbox1.Multiline = true;
            this.textbox1.Name = "textbox1";
            this.textbox1.NormlBack = ((System.Drawing.Bitmap)(resources.GetObject("textbox1.NormlBack")));
            this.textbox1.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.textbox1.ReadOnly = false;
            this.textbox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textbox1.Size = new System.Drawing.Size(194, 30);
            // 
            // 
            // 
            this.textbox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textbox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textbox1.SkinTxt.Multiline = true;
            this.textbox1.SkinTxt.Name = "BaseText";
            this.textbox1.SkinTxt.Size = new System.Drawing.Size(161, 20);
            this.textbox1.SkinTxt.TabIndex = 0;
            this.textbox1.SkinTxt.Text = "用户名";
            this.textbox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textbox1.SkinTxt.WaterText = "账号";
            this.textbox1.TabIndex = 40;
            this.textbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textbox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textbox1.WaterText = "";
            this.textbox1.WordWrap = true;
            this.textbox1.Enter += new System.EventHandler(this.Textbox_Enter);
            this.textbox1.Leave += new System.EventHandler(this.Textbox_Leave);
            // 
            // btnId
            // 
            this.btnId.BackColor = System.Drawing.Color.White;
            this.btnId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnId.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnId.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnId.DownBack = ((System.Drawing.Image)(resources.GetObject("btnId.DownBack")));
            this.btnId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnId.IsEnabledDraw = false;
            this.btnId.Location = new System.Drawing.Point(170, 3);
            this.btnId.Margin = new System.Windows.Forms.Padding(0);
            this.btnId.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnId.MouseBack")));
            this.btnId.Name = "btnId";
            this.btnId.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnId.NormlBack")));
            this.btnId.Size = new System.Drawing.Size(22, 24);
            this.btnId.TabIndex = 36;
            this.btnId.UseVisualStyleBackColor = false;
            // 
            // pnlImgTx
            // 
            this.pnlImgTx.BackColor = System.Drawing.Color.Transparent;
            this.pnlImgTx.BackgroundImage = global::_20190625_基于WinForm的门店管理系统.Properties.Resources.icon111;
            this.pnlImgTx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlImgTx.Controls.Add(this.btnState);
            this.pnlImgTx.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlImgTx.DownBack = null;
            this.pnlImgTx.Location = new System.Drawing.Point(68, 106);
            this.pnlImgTx.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImgTx.MouseBack = null;
            this.pnlImgTx.Name = "pnlImgTx";
            this.pnlImgTx.NormlBack = null;
            this.pnlImgTx.Radius = 4;
            this.pnlImgTx.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.pnlImgTx.Size = new System.Drawing.Size(80, 80);
            this.pnlImgTx.TabIndex = 41;
            // 
            // btnState
            // 
            this.btnState.BackColor = System.Drawing.Color.Transparent;
            this.btnState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnState.BackRectangle = new System.Drawing.Rectangle(5, 5, 5, 5);
            this.btnState.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnState.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnState.DownBack = ((System.Drawing.Image)(resources.GetObject("btnState.DownBack")));
            this.btnState.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnState.Image = ((System.Drawing.Image)(resources.GetObject("btnState.Image")));
            this.btnState.ImageSize = new System.Drawing.Size(15, 15);
            this.btnState.Location = new System.Drawing.Point(62, 61);
            this.btnState.Margin = new System.Windows.Forms.Padding(0);
            this.btnState.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnState.MouseBack")));
            this.btnState.Name = "btnState";
            this.btnState.NormlBack = null;
            this.btnState.Palace = true;
            this.btnState.Size = new System.Drawing.Size(18, 18);
            this.btnState.TabIndex = 12;
            this.btnState.Tag = "1";
            this.btnState.UseVisualStyleBackColor = false;
            // 
            // textbox2
            // 
            this.textbox2.BackColor = System.Drawing.Color.Transparent;
            this.textbox2.Controls.Add(this.btnJpPwd);
            this.textbox2.DownBack = null;
            this.textbox2.Icon = null;
            this.textbox2.IconIsButton = true;
            this.textbox2.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textbox2.IsPasswordChat = '●';
            this.textbox2.IsSystemPasswordChar = false;
            this.textbox2.Lines = new string[0];
            this.textbox2.Location = new System.Drawing.Point(190, 155);
            this.textbox2.Margin = new System.Windows.Forms.Padding(0);
            this.textbox2.MaxLength = 32767;
            this.textbox2.MinimumSize = new System.Drawing.Size(0, 28);
            this.textbox2.MouseBack = ((System.Drawing.Bitmap)(resources.GetObject("textbox2.MouseBack")));
            this.textbox2.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textbox2.Multiline = true;
            this.textbox2.Name = "textbox2";
            this.textbox2.NormlBack = ((System.Drawing.Bitmap)(resources.GetObject("textbox2.NormlBack")));
            this.textbox2.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.textbox2.ReadOnly = false;
            this.textbox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textbox2.Size = new System.Drawing.Size(194, 30);
            // 
            // 
            // 
            this.textbox2.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox2.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox2.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textbox2.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textbox2.SkinTxt.Multiline = true;
            this.textbox2.SkinTxt.Name = "BaseText";
            this.textbox2.SkinTxt.PasswordChar = '●';
            this.textbox2.SkinTxt.Size = new System.Drawing.Size(161, 20);
            this.textbox2.SkinTxt.TabIndex = 0;
            this.textbox2.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textbox2.SkinTxt.WaterText = "密码";
            this.textbox2.TabIndex = 42;
            this.textbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textbox2.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textbox2.WaterText = "";
            this.textbox2.WordWrap = true;
            this.textbox2.Enter += new System.EventHandler(this.Textbox_Enter);
            this.textbox2.Leave += new System.EventHandler(this.Textbox_Leave);
            // 
            // btnJpPwd
            // 
            this.btnJpPwd.BackColor = System.Drawing.Color.White;
            this.btnJpPwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJpPwd.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(21)))), ((int)(((byte)(26)))));
            this.btnJpPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnJpPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJpPwd.DownBack = ((System.Drawing.Image)(resources.GetObject("btnJpPwd.DownBack")));
            this.btnJpPwd.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnJpPwd.Location = new System.Drawing.Point(172, 6);
            this.btnJpPwd.Margin = new System.Windows.Forms.Padding(0);
            this.btnJpPwd.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnJpPwd.MouseBack")));
            this.btnJpPwd.Name = "btnJpPwd";
            this.btnJpPwd.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnJpPwd.NormlBack")));
            this.btnJpPwd.Size = new System.Drawing.Size(15, 16);
            this.btnJpPwd.TabIndex = 41;
            this.btnJpPwd.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_20190625_基于WinForm的门店管理系统.Properties.Resources.main_7;
            this.ClientSize = new System.Drawing.Size(482, 341);
            this.Controls.Add(this.textbox2);
            this.Controls.Add(this.pnlImgTx);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.btnAbout);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.textbox1.ResumeLayout(false);
            this.textbox1.PerformLayout();
            this.pnlImgTx.ResumeLayout(false);
            this.textbox2.ResumeLayout(false);
            this.textbox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton btnAbout;
        private CCWin.SkinControl.SkinTextBox textbox1;
        private CCWin.SkinControl.SkinButton btnId;
        private CCWin.SkinControl.SkinPanel pnlImgTx;
        private CCWin.SkinControl.SkinButton btnState;
        private CCWin.SkinControl.SkinTextBox textbox2;
        private CCWin.SkinControl.SkinButton btnJpPwd;
    }
}

