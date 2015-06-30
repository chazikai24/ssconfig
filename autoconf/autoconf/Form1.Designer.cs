namespace autoconf
{
    partial class Form1
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.内网模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外网模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sS禁用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gFWlist模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大陆白名单模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.游戏模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全局代理模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新状态toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.设置参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SSconfig";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.内网模式ToolStripMenuItem,
            this.外网模式ToolStripMenuItem,
            this.toolStripSeparator1,
            this.sS禁用ToolStripMenuItem,
            this.gFWlist模式ToolStripMenuItem,
            this.大陆白名单模式ToolStripMenuItem,
            this.游戏模式ToolStripMenuItem,
            this.全局代理模式ToolStripMenuItem,
            this.toolStripSeparator4,
            this.刷新状态toolStripMenuItem,
            this.toolStripSeparator2,
            this.设置参数ToolStripMenuItem,
            this.toolStripSeparator3,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 248);
            // 
            // 内网模式ToolStripMenuItem
            // 
            this.内网模式ToolStripMenuItem.Name = "内网模式ToolStripMenuItem";
            this.内网模式ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.内网模式ToolStripMenuItem.Text = "内网模式";
            this.内网模式ToolStripMenuItem.Click += new System.EventHandler(this.内网模式ToolStripMenuItem_Click);
            // 
            // 外网模式ToolStripMenuItem
            // 
            this.外网模式ToolStripMenuItem.Name = "外网模式ToolStripMenuItem";
            this.外网模式ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.外网模式ToolStripMenuItem.Text = "外网模式";
            this.外网模式ToolStripMenuItem.Click += new System.EventHandler(this.外网模式ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // sS禁用ToolStripMenuItem
            // 
            this.sS禁用ToolStripMenuItem.Name = "sS禁用ToolStripMenuItem";
            this.sS禁用ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sS禁用ToolStripMenuItem.Text = "SS禁用";
            this.sS禁用ToolStripMenuItem.Click += new System.EventHandler(this.sS禁用ToolStripMenuItem_Click);
            // 
            // gFWlist模式ToolStripMenuItem
            // 
            this.gFWlist模式ToolStripMenuItem.Name = "gFWlist模式ToolStripMenuItem";
            this.gFWlist模式ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.gFWlist模式ToolStripMenuItem.Text = "GFWlist模式";
            this.gFWlist模式ToolStripMenuItem.Click += new System.EventHandler(this.gFWlist模式ToolStripMenuItem_Click);
            // 
            // 大陆白名单模式ToolStripMenuItem
            // 
            this.大陆白名单模式ToolStripMenuItem.Name = "大陆白名单模式ToolStripMenuItem";
            this.大陆白名单模式ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.大陆白名单模式ToolStripMenuItem.Text = "大陆白名单模式";
            this.大陆白名单模式ToolStripMenuItem.Click += new System.EventHandler(this.大陆白名单模式ToolStripMenuItem_Click);
            // 
            // 游戏模式ToolStripMenuItem
            // 
            this.游戏模式ToolStripMenuItem.Name = "游戏模式ToolStripMenuItem";
            this.游戏模式ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.游戏模式ToolStripMenuItem.Text = "游戏模式";
            this.游戏模式ToolStripMenuItem.Click += new System.EventHandler(this.游戏模式ToolStripMenuItem_Click);
            // 
            // 全局代理模式ToolStripMenuItem
            // 
            this.全局代理模式ToolStripMenuItem.Name = "全局代理模式ToolStripMenuItem";
            this.全局代理模式ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.全局代理模式ToolStripMenuItem.Text = "全局代理模式";
            this.全局代理模式ToolStripMenuItem.Click += new System.EventHandler(this.全局代理模式ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // 刷新状态toolStripMenuItem
            // 
            this.刷新状态toolStripMenuItem.Name = "刷新状态toolStripMenuItem";
            this.刷新状态toolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.刷新状态toolStripMenuItem.Text = "刷新状态";
            this.刷新状态toolStripMenuItem.Click += new System.EventHandler(this.刷新状态toolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // 设置参数ToolStripMenuItem
            // 
            this.设置参数ToolStripMenuItem.Name = "设置参数ToolStripMenuItem";
            this.设置参数ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.设置参数ToolStripMenuItem.Text = "设置参数";
            this.设置参数ToolStripMenuItem.Click += new System.EventHandler(this.设置参数ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "路由器地址";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "http://";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "80";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(152, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 235);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 215);
            this.panel1.TabIndex = 0;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(124, 172);
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '*';
            this.textBox4.Size = new System.Drawing.Size(187, 21);
            this.textBox4.TabIndex = 5;
            this.textBox4.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "密码";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 135);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(187, 21);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "admin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "用户名";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "内网模式",
            "外网模式"});
            this.comboBox1.Location = new System.Drawing.Point(124, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "内外网模式";
            // 
            // Form1
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(401, 311);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sS禁用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gFWlist模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大陆白名单模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 游戏模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全局代理模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置参数ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem 内网模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外网模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 刷新状态toolStripMenuItem;
    }
}

