namespace _20190626_基于WinForm的仓库管理系统.WinForm
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.产品管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.产品出库入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 


































            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.产品管理ToolStripMenuItem,
            this.产品出库入库ToolStripMenuItem,
            this.查询商品ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";



























































            // 
            // 产品管理ToolStripMenuItem
            // 
            this.产品管理ToolStripMenuItem.Name = "产品管理ToolStripMenuItem";
            this.产品管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.产品管理ToolStripMenuItem.Text = "商品管理";
            this.产品管理ToolStripMenuItem.Click += new System.EventHandler(this.产品管理ToolStripMenuItem_Click);
            // 
            // 产品出库入库ToolStripMenuItem
            // 
































            this.产品出库入库ToolStripMenuItem.Name = "产品出库入库ToolStripMenuItem";
            this.产品出库入库ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.产品出库入库ToolStripMenuItem.Text = "原材料管理";
            this.产品出库入库ToolStripMenuItem.Click += new System.EventHandler(this.产品出库入库ToolStripMenuItem_Click);
            // 
            // 查询商品ToolStripMenuItem
            // 
            this.查询商品ToolStripMenuItem.Name = "查询商品ToolStripMenuItem";
            this.查询商品ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.查询商品ToolStripMenuItem.Text = "车间商品";
            this.查询商品ToolStripMenuItem.Click += new System.EventHandler(this.查询商品ToolStripMenuItem_Click);
            // 































            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 538);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeForm";
            this.Text = "HomeForm";























            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 产品管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产品出库入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询商品ToolStripMenuItem;
    }
}