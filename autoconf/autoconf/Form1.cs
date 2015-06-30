using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace autoconf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                HiddenForm();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                ShowForm();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HiddenForm();
                notifyIcon1.ShowBalloonTip(0, "通知", "最小化到任务栏！", ToolTipIcon.Info);
            }
            else
            {
 
            }
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Activate();
        }        /// <summary>
        /// 隐藏窗口
        /// </summary>
        private void HiddenForm()
        {
            this.Hide();
        }

        private string In_conf="";
        private string Out_conf="";
        private string InOutMode="";
        private string In_addr="";
        private string Out_addr="";
        private string In_port="";
        private string Out_port="";
        private string In_user="";
        private string Out_user="";
        private string In_pwd="";
        private string Out_pwd="";

        private void Get_Conf()
        {   
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            InOutMode = config.AppSettings.Settings["InOutMode"].Value;
            In_conf = config.AppSettings.Settings["In_conf"].Value;
            Out_conf = config.AppSettings.Settings["Out_conf"].Value;
            In_addr = config.AppSettings.Settings["In_addr"].Value;
            In_port = config.AppSettings.Settings["In_port"].Value;
            In_user = config.AppSettings.Settings["In_user"].Value;
            In_pwd = config.AppSettings.Settings["In_pwd"].Value;
            Out_addr = config.AppSettings.Settings["Out_addr"].Value;
            Out_port = config.AppSettings.Settings["Out_port"].Value;
            Out_user = config.AppSettings.Settings["Out_user"].Value;
            Out_pwd = config.AppSettings.Settings["Out_pwd"].Value;
            if (InOutMode == "In")
            {
                if (In_port == "80")
                {
                    login_url = In_addr + "/login.cgi";
                    state_url = In_addr + "/state.js";
                    SS_URL = In_addr + "/Main_Ss_Content.asp";
                    ss_conf_url = In_addr + "/ss_conf";
                    ss_setting_url = In_addr + "/applyss.cgi";
                }
                else
                {
                    login_url = In_addr + ":" + In_port + "/login.cgi";
                    state_url = In_addr + ":" + In_port + "/state.js";
                    SS_URL = In_addr + ":" + In_port + "/Main_Ss_Content.asp";
                    ss_conf_url = In_addr + ":" + In_port + "/ss_conf";
                    ss_setting_url = In_addr + ":" + In_port + "/applyss.cgi";
                }

                login_authorization = Base64.base64encode(In_user + ":" + In_pwd);
            }
            else if (InOutMode == "Out")
            {
                login_url = Out_addr + ":" + Out_port + "/login.cgi";
                state_url = Out_addr + ":" + Out_port + "/state.js";
                SS_URL = Out_addr + ":" + Out_port + "/Main_Ss_Content.asp";
                ss_conf_url = Out_addr + ":" + Out_port + "/ss_conf";
                ss_setting_url = Out_addr + ":" + Out_port + "/applyss.cgi";
                login_authorization = Base64.base64encode(Out_user + ":" + Out_pwd);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("SSconfig.exe.config"))
            {
                MessageBox.Show("不存在配置文件！");
                notifyIcon1.Visible = false;
                System.Environment.Exit(0);
            }
            comboBox1.SelectedIndex = 0;

            Get_Conf();

            if (InOutMode == "In" && In_conf == "1")
            {
                Inhaveconf = true;
            }
            else if (InOutMode == "Out" && Out_conf == "1")
            {
                Outhaveconf = true;
            }

            if (InOutMode == "In")
            {
                comboBox1.SelectedIndex = 0;
                textBox1.Text = In_addr;
                textBox2.Text = In_port;
                textBox3.Text = In_user;
                textBox4.Text = In_pwd;
            }
            else if (InOutMode == "Out")
            {
                comboBox1.SelectedIndex = 1;
                textBox1.Text = Out_addr;
                textBox2.Text = Out_port;
                textBox3.Text = Out_user;
                textBox4.Text = Out_pwd;
            }


            if (Inhaveconf)
            {
                login_url = In_addr + ":" + In_port + "/login.cgi";
                state_url = In_addr + ":" + In_port + "/state.js";
                SS_URL = In_addr + ":" + In_port + "/Main_Ss_Content.asp";
                ss_conf_url = In_addr + ":" + In_port + "/ss_conf";
                ss_setting_url = In_addr + ":" + In_port + "/applyss.cgi";
                login_authorization = Base64.base64encode(In_user + ":" + In_pwd);
                int now_mode = int.Parse(get_ss_mode());
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                Notic_mode(now_mode, InOutMode);
            }
            else if (Outhaveconf)
            {
                login_url = Out_addr + ":" + Out_port + "/login.cgi";
                state_url = Out_addr + ":" + Out_port + "/state.js";
                SS_URL = Out_addr + ":" + Out_port + "/Main_Ss_Content.asp";
                ss_conf_url = Out_addr + ":" + Out_port + "/ss_conf";
                ss_setting_url = Out_addr + ":" + Out_port + "/applyss.cgi";
                login_authorization = Base64.base64encode(Out_user + ":" + Out_pwd);
                int now_mode = int.Parse(get_ss_mode());
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                Notic_mode(now_mode, InOutMode);
            }
            else
            {
                textBox1.Text = "http://";
                textBox2.Text = "80";
                textBox3.Text = "admin";
                textBox4.Text = "";
                ShowForm();
                MessageBox.Show("请先设置参数！");
            }
        }

        private void Notic_mode(int now_mode,string InOutmode)
        {
            if (InOutmode == "In")
            {
                内网模式ToolStripMenuItem.Checked = true;
                外网模式ToolStripMenuItem.Checked = false;
            }
            else if (InOutmode == "Out")
            {
                内网模式ToolStripMenuItem.Checked = false;
                外网模式ToolStripMenuItem.Checked = true;
            }

            if (now_mode == 0)
            {
                sS禁用ToolStripMenuItem.Checked = true;
                gFWlist模式ToolStripMenuItem.Checked = false;
                大陆白名单模式ToolStripMenuItem.Checked = false;
                游戏模式ToolStripMenuItem.Checked = false;
                全局代理模式ToolStripMenuItem.Checked = false;
                notifyIcon1.ShowBalloonTip(0, "当前模式", "sS禁用！", ToolTipIcon.Info);
            }
            else if (now_mode == 1)
            {
                sS禁用ToolStripMenuItem.Checked = false;
                gFWlist模式ToolStripMenuItem.Checked = true;
                大陆白名单模式ToolStripMenuItem.Checked = false;
                游戏模式ToolStripMenuItem.Checked = false;
                全局代理模式ToolStripMenuItem.Checked = false;
                notifyIcon1.ShowBalloonTip(0, "当前模式", "gFWlist模式！", ToolTipIcon.Info);
            }
            else if (now_mode == 2)
            {
                sS禁用ToolStripMenuItem.Checked = false;
                gFWlist模式ToolStripMenuItem.Checked = false;
                大陆白名单模式ToolStripMenuItem.Checked = true;
                游戏模式ToolStripMenuItem.Checked = false;
                全局代理模式ToolStripMenuItem.Checked = false;
                notifyIcon1.ShowBalloonTip(0, "当前模式", "大陆白名单模式！", ToolTipIcon.Info);
            }
            else if (now_mode == 3)
            {
                sS禁用ToolStripMenuItem.Checked = false;
                gFWlist模式ToolStripMenuItem.Checked = false;
                大陆白名单模式ToolStripMenuItem.Checked = false;
                游戏模式ToolStripMenuItem.Checked = true;
                全局代理模式ToolStripMenuItem.Checked = false;
                notifyIcon1.ShowBalloonTip(0, "当前模式", "游戏模式！", ToolTipIcon.Info);
            }
            else if (now_mode == 4)
            {
                sS禁用ToolStripMenuItem.Checked = false;
                gFWlist模式ToolStripMenuItem.Checked = false;
                大陆白名单模式ToolStripMenuItem.Checked = false;
                游戏模式ToolStripMenuItem.Checked = false;
                全局代理模式ToolStripMenuItem.Checked = true;
                notifyIcon1.ShowBalloonTip(0, "当前模式", "全局代理模式！", ToolTipIcon.Info);
            }
        }

        private Hashtable ht = new Hashtable();

        private void get_cookie()
        {
 
        }

        private string get_ss_mode()
        {
            //获取登陆cookie
            WebAutoLogin.PostLogin(login_url, login_authorization);

            //请求ss配置
            WebAutoLogin.GetPage(ss_conf_url);

            string strDoc = WebAutoLogin.ResultHtml;
            if (strDoc.IndexOf("error") > -1)
            {
                return "-1";
            }
            else
            {
                strDoc = strDoc.Replace("\"", "");
                strDoc = strDoc.Replace(",", "");
                Regex status = new Regex(@"(?is)var ss={]*.*?}");
                MatchCollection mc_status = status.Matches(strDoc);
                strDoc = mc_status[0].ToString();

                string[] ss = strDoc.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                string[] sss;
                foreach (string s in ss)
                {
                    sss = s.Split(':');
                    if (sss.Length > 1)
                    {
                        if (sss[0].ToString() == "mode")
                        {
                            mode = sss[1].ToString();
                        }
                    }
                }
                return mode;
            }
        }

        private string mode = "";
        private bool Inhaveconf = false;
        private bool Outhaveconf = false;
        private string login_url = "";
        private string state_url = "";
        private string SS_URL = "";
        private string ss_conf_url = "";
        private string ss_setting_url = "";
        private string login_authorization = "";

        private bool change_ss_mode(string mode)
        {
            try
            {
                ht.Clear();
                System.GC.Collect();

                //获取登陆cookie
                //WebAutoLogin.PostLogin(login_url, login_authorization);

                //请求ss配置
                WebAutoLogin.GetPage(ss_conf_url);

                string strDoc = WebAutoLogin.ResultHtml;
                strDoc = strDoc.Replace("\"", "");
                strDoc = strDoc.Replace(",", "");
                Regex status = new Regex(@"(?is)var ss={]*.*?}");
                MatchCollection mc_status = status.Matches(strDoc);
                strDoc = mc_status[0].ToString();

                string[] ss = strDoc.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                string[] sss;
                foreach (string s in ss)
                {
                    sss = s.Split(':');
                    if (sss.Length > 1)
                    {
                        ht.Add(sss[0], sss[1]);
                    }
                }

                if(mode == ht["mode"].ToString())
                {
                    return true;
                }

                //请求系统配置状态信息
                //WebAutoLogin.GetPage1(state_url, SS_URL);
                WebAutoLogin.GetPage(state_url);
                strDoc = WebAutoLogin.ResultHtml;
                status = new Regex(@"(?is)var firmver = ']*.*?'");
                mc_status = status.Matches(strDoc);
                strDoc = mc_status[0].ToString();
                ss = strDoc.Split('\'');
                ht.Add("firmver", ss[1]);

                strDoc = WebAutoLogin.ResultHtml;
                status = new Regex(@"(?is)name=""preferred_lang\"" value=]*.*?>");
                mc_status = status.Matches(strDoc);
                strDoc = mc_status[0].ToString();
                strDoc = strDoc.Replace("\"", "");
                ss = strDoc.Split(' ');
                int startindex = ss[1].IndexOf("=") + 1;
                int lenth = ss[1].IndexOf(">") - startindex;
                ht.Add("preferred_lang", ss[1].Substring(startindex, lenth));



                //设置ss
                string postdata = "current_page=Main_Ss_Content.asp&next_page=Main_Ss_Content.asp&group_id=&modified=0&action_mode=+Refresh+&action_script=&action_wait=&first_time=&preferred_lang="
                    + ht["preferred_lang"].ToString() + "&SystemCmd=ssconfig+basic&firmver="
                    //+ "&SystemCmd=ssconfig+basic&firmver=3.0.0.4&ss_mode="
                    //+ "&SystemCmd=ssconfig+basic&ss_mode="
                    + ht["firmver"].ToString() + "&ss_mode="
                    + mode
                    + "&ss_server="
                    + ht["server"].ToString() + "&ss_port="
                    + ht["port"].ToString() + "&ss_password="
                    + ht["password"].ToString() + "&ss_method="
                    + ht["method"].ToString() + "&ss_chromecast="
                    + ht["chromecast"].ToString();
                WebAutoLogin.PostSetSS(ss_setting_url, postdata);

                if (WebAutoLogin.ResultHtml.IndexOf("您的网络登录名和密码仍然是默认设置") >-1)
                {
                    return true;
                    //MessageBox.Show("切换成功！");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("切换失败！");
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString().Trim() == ""||textBox2.Text.ToString().Trim() == ""||textBox3.Text.ToString().Trim() == ""||textBox4.Text.ToString().Trim() == "")
            {
                MessageBox.Show("必须填写所有项目！");
                return;
            }
            if (textBox1.Text.ToString().Trim().ToUpper().IndexOf("HTTP") < 0)
            {
                MessageBox.Show("路由器地址必须带http://");
                return;
            }
            else if (textBox1.Text.ToString().Trim().ToUpper().Replace("HTTP://", "").Length == 0)
            {
                MessageBox.Show("路由器地址异常，请检查");
                return;
            }
            string login_url1 = textBox1.Text.ToString() + ":" + textBox2.Text.ToString() + "/login.cgi";
            string login_authorization1 = Base64.base64encode(textBox3.Text + ":" + textBox4.Text);

            //获取登陆cookie
            string str = "";
            if (WebAutoLogin.PostLogin(login_url1, login_authorization1))
            {
                str = WebAutoLogin.CookiesString;
            }



            if (str.IndexOf("asus_token") < 0||str == "")
            {
                MessageBox.Show("请检查地址与端口是否正确");
            }
            else
            {
                //MessageBox.Show("登陆成功！");
                if (comboBox1.SelectedIndex == 0)
                {
                    //config.AppSettings.Settings["In_conf"].Value = "1";
                    config.AppSettings.Settings["InOutMode"].Value = "In";
                    config.AppSettings.Settings["In_addr"].Value = textBox1.Text.ToString().Trim();
                    config.AppSettings.Settings["In_port"].Value = textBox2.Text.ToString().Trim();
                    config.AppSettings.Settings["In_user"].Value = textBox3.Text.ToString().Trim();
                    config.AppSettings.Settings["In_pwd"].Value = textBox4.Text.ToString().Trim();
                    config.Save();
                    System.Configuration.ConfigurationManager.RefreshSection("appSettings");

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    //config.AppSettings.Settings["Out_conf"].Value = "1";
                    config.AppSettings.Settings["InOutMode"].Value = "Out";
                    config.AppSettings.Settings["Out_addr"].Value = textBox1.Text.ToString().Trim();
                    config.AppSettings.Settings["Out_port"].Value = textBox2.Text.ToString().Trim();
                    config.AppSettings.Settings["Out_user"].Value = textBox3.Text.ToString().Trim();
                    config.AppSettings.Settings["Out_pwd"].Value = textBox4.Text.ToString().Trim();
                    config.Save();
                    System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                    
                }
                Get_Conf();
                int now_mode = int.Parse(get_ss_mode());

                if (now_mode == -1)
                {
                    MessageBox.Show("Merlin固件貌似没有集成SS！");
                }
                else
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        config.AppSettings.Settings["In_conf"].Value = "1";
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        config.AppSettings.Settings["Out_conf"].Value = "1";
                    }
                    config.Save();
                    System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                    Get_Conf();
                    Notic_mode(now_mode, InOutMode);

                    this.WindowState = FormWindowState.Minimized;
                    HiddenForm();
                }
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = In_addr;
                textBox2.Text = In_port;
                textBox3.Text = In_user;
                textBox4.Text = In_pwd;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = Out_addr;
                textBox2.Text = Out_port;
                textBox3.Text = Out_user;
                textBox4.Text = Out_pwd;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 取消关闭窗体
            e.Cancel = true;

            // 将窗体变为最小化
            this.WindowState = FormWindowState.Minimized;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出程序？", "警告", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
            {
                notifyIcon1.Visible = false;
                System.Environment.Exit(0);
            }
            
        }

        private Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private string ss_mode = "";
        private void sS禁用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ss_mode = "0";
            if(change_ss_mode(ss_mode))
            {
                Notic_mode(int.Parse(ss_mode.ToString()), InOutMode);
            }
            else
            {
                notifyIcon1.ShowBalloonTip(0, "警告", "切换失败！", ToolTipIcon.Info);
            }
        }

        private void gFWlist模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ss_mode = "1";
            if (change_ss_mode(ss_mode))
            {
                Notic_mode(int.Parse(ss_mode.ToString()), InOutMode);
            }
            else
            {
                notifyIcon1.ShowBalloonTip(0, "警告", "切换失败！", ToolTipIcon.Info);
            }
        }

        private void 大陆白名单模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ss_mode = "2";
            if (change_ss_mode(ss_mode))
            {
                Notic_mode(int.Parse(ss_mode.ToString()), InOutMode);
            }
            else
            {
                notifyIcon1.ShowBalloonTip(0, "警告", "切换失败！", ToolTipIcon.Info);
            }
        }

        private void 游戏模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ss_mode = "3";
            if (change_ss_mode(ss_mode))
            {
                Notic_mode(int.Parse(ss_mode.ToString()), InOutMode);
            }
            else
            {
                notifyIcon1.ShowBalloonTip(0, "警告", "切换失败！", ToolTipIcon.Info);
            }
        }

        private void 全局代理模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ss_mode = "4";
            if (change_ss_mode(ss_mode))
            {
                Notic_mode(int.Parse(ss_mode.ToString()), InOutMode);
            }
            else
            {
                notifyIcon1.ShowBalloonTip(0, "警告", "切换失败！", ToolTipIcon.Info);
            }
        }

        private void 设置参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void 内网模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InOutMode == "Out")
            {
                if (In_conf == "1")
                {
                    int now_mode = int.Parse(get_ss_mode());
                    if(now_mode == -1)
                    {
                        MessageBox.Show("确定您所在的状态为内网模式？");
                        return;
                    }
                    config.AppSettings.Settings["InOutMode"].Value = "In";
                    config.Save();
                    System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                    Get_Conf();
                    now_mode = int.Parse(get_ss_mode());
                    Notic_mode(now_mode, InOutMode);

                }
                else
                {
                    MessageBox.Show("请检查内网模式配置！");
                }
            }
        }

        private void 外网模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InOutMode == "In")
            {
                if (Out_conf == "1")
                {
                    int now_mode = int.Parse(get_ss_mode());
                    if (now_mode == -1)
                    {
                        MessageBox.Show("确定您所在的状态为内网模式？");
                        return;
                    }
                    config.AppSettings.Settings["InOutMode"].Value = "Out";
                    config.Save();
                    System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                    Get_Conf();
                    now_mode = int.Parse(get_ss_mode());
                    Notic_mode(now_mode, InOutMode);

                }
                else
                {
                    MessageBox.Show("请检查外网模式配置！");
                }
            }
        }

        private void 刷新状态toolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.GC.Collect();
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            Get_Conf();

            if (In_conf == "0" && Out_conf == "0")
            {
                MessageBox.Show("请先配置后再使用此功能！");
                return;
            }


            //获取登陆cookie
            //WebAutoLogin.PostLogin(login_url, login_authorization);

            //请求ss配置
            WebAutoLogin.GetPage(ss_conf_url);

            string strDoc = WebAutoLogin.ResultHtml;
            strDoc = strDoc.Replace("\"", "");
            strDoc = strDoc.Replace(",", "");
            Regex status = new Regex(@"(?is)var ss={]*.*?}");
            MatchCollection mc_status = status.Matches(strDoc);
            strDoc = mc_status[0].ToString();

            string[] ss = strDoc.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] sss;
            int now_mode = -1;
            foreach (string s in ss)
            {
                sss = s.Split(':');
                if (sss[0].ToString() == "mode")
                {
                    now_mode = int.Parse(sss[1].ToString());
                }
            }

            if (now_mode != -1)
            {
                Notic_mode(now_mode, InOutMode);
            }
            else
            {
                MessageBox.Show("刷新失败！");
            }
        }
    }
}
