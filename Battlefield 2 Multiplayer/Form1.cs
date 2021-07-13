using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows.Forms;
namespace Battlefield_2_Multiplayer
{

    //TODO: Add custom path of BF2 to config file for later easy launch!
    public partial class Form1 : Form
    {
        bool mouseDown;
        private Point offset;
        private readonly string Version = "1.4";
        [DllImport("WinInet.dll", PreserveSig = true, SetLastError = true)]
        public static extern void DeleteUrlCacheEntry(string url);
        public Form1()
        {
            InitializeComponent();
            GetSetVersion();
            GetIPS();
            GetServerHistory();
            CheckforUpdate();
        }

        private void GetServerHistory()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("serverhistory.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    server_address_field.AutoCompleteCustomSource.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Done adding history");
            }
        }

        private void GetIPS()
        {
            server_address_field.AutoCompleteCustomSource.Add(Environment.MachineName); // ADD machine hostname
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            server_address_field.AutoCompleteCustomSource.Add(ip.Address.ToString());
                        }
                    }
                }
            }

        }

        public string GetSetVersion()
        {
            version_label.Text = "Version: " + Version;
            return Version;

        }

        private void CheckforUpdate()
        {
            //initialize variables.
            string URL = "https://raw.githubusercontent.com/CLStrike/bf2mplauncher/main/";
            string AppName = "BF2";
            string ServerVersion;
            string serverVersionName = "Update.txt";
            DeleteUrlCacheEntry(URL + serverVersionName);
            //setting up policies
            HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
            HttpWebRequest.DefaultCachePolicy = policy;
            WebRequest req = WebRequest.Create(URL + serverVersionName);
            HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            req.CachePolicy = noCachePolicy;
            WebResponse res = req.GetResponse();
            Stream str = res.GetResponseStream();
            StreamReader tr = new StreamReader(str);
            ServerVersion = tr.ReadLine();


            if (GetSetVersion() != ServerVersion)
            {
                //Update
                string appnameversion = AppName + "-" + ServerVersion + ".zip";
                System.Console.WriteLine(appnameversion);
                DialogResult dialogResult =  MessageBox.Show("There is an update available!\n Do you want to download it?", "BF2 MP Launcher - Auto Updater", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    WebClient client = new WebClient();
                    byte[] appdata = client.DownloadData(URL + appnameversion);
                    using (FileStream fs = System.IO.File.Create(appnameversion))
                    {
                        fs.Write(appdata, 0, appdata.Length);
                    }

                    if(System.IO.File.Exists(Path.Combine(Path.GetTempPath(), "Battlefield 2 Multiplayer Launcher.exe")))
                    {
                        System.IO.File.Delete(Path.Combine(Path.GetTempPath(), "Battlefield 2 Multiplayer Launcher.exe"));

                    }
                    System.IO.Compression.ZipFile.ExtractToDirectory(appnameversion, Path.GetTempPath()); 
                    System.IO.File.Copy(Path.Combine(Path.GetTempPath(), "Battlefield 2 Multiplayer Launcher.exe"), Path.Combine(Directory.GetCurrentDirectory(), "Battlefield 2 Multiplayer Launcher1.exe"), true);

                    var p = new Process();
                    p.StartInfo.FileName = "startupdate.bat";  // startupdatebat and kill own process.
                    p.Start();

                } else if (dialogResult == DialogResult.No)
                {
                    // nothing
                }

            }
            else
            {
                if (System.IO.File.Exists("Battlefield 2 Multiplayer Launcher1.exe"))
                {
                    System.Console.WriteLine("Just done update, Cleaning up directory!");
                    System.IO.File.Delete("Battlefield 2 Multiplayer Launcher1.exe");
                    System.IO.File.Delete("BF2-1.4.zip");
                }
                else
                {
                    MessageBox.Show("No Update is Available!", "Auto Updater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }
            private void DragPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;

        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);

                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void DragPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private string Find_installationPath()
        {
            string[] defaultprogramlist = { "c:\\2\\BF2.exe", "c:\\3\\BF2.exe", "C:\\Program Files (x86)\\Bull3t\\BFHD\\BF2.exe" };
            foreach (string i in defaultprogramlist)
            {

                if (System.IO.File.Exists(i))
                {
                    System.Console.WriteLine("File exists... " + i);
                    // Doing input validation
                    return i;

                }
                else
                {
                    System.Console.WriteLine("File not found: " + i);
                }
            }
            System.Console.WriteLine("Nothing found!!");
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Default program locations:
            string[] defaultprogramlist = {  "c:\\2\\BF2.exe", "c:\\3\\BF2.exe" , "C:\\Program Files (x86)\\Bull3t\\BFHD\\BF2.exe" };
            string[] serveraddressport;
            string serverport;
            string serveraddr;
            char delim = ':';
            string chosen_execpath;
            string workingdirectory;
            bool filefound = false;


            foreach ( string i in defaultprogramlist){ 

                if (System.IO.File.Exists(i))
                {
                    System.Console.WriteLine("File exists... " + i);
                    filefound = true;
                    // Doing input validation
                    chosen_execpath = i;

                    if (server_address_field.Text.Contains(delim))
                    {
                        serveraddressport = server_address_field.Text.Split(':');
                        serveraddr = serveraddressport[0];
                        serverport = serveraddressport[1];
                    }
                    else
                    {
                        serveraddr = server_address_field.Text;
                        serverport = "16567";
                    }

                    WriteServerAddrToFile(serveraddr);
                    // Connect to server
                    workingdirectory = chosen_execpath.Replace("BF2.exe", "");
                    Process runbf2 = new Process();
                    runbf2.StartInfo.FileName = chosen_execpath;
                    runbf2.StartInfo.Arguments = " +joinServer " + serveraddr + " +port " + serverport;
                    runbf2.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    runbf2.StartInfo.WorkingDirectory = workingdirectory;
                    System.Console.WriteLine("DEBUG - Selected Working directory: " + workingdirectory);
                    System.Console.WriteLine("DEBUG - command used: " + chosen_execpath + " +joinServer " + serveraddr + " +port " + serverport);

                    runbf2.Start();
                }
                else
                {
                    System.Console.WriteLine("File not found: " + i);
                }
            }
            if(filefound == false) {

                System.Console.WriteLine("Nothing found!");
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.InitialDirectory = @"C:\";
                openfile.Title = "Select BF2.exe";
                openfile.DefaultExt = ".exe";
                openfile.CheckFileExists = true;
                openfile.CheckPathExists = true;
                openfile.ShowDialog();

                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    chosen_execpath = openfile.FileName;
                    if (server_address_field.Text.Contains(delim))
                    {
                        serveraddressport = server_address_field.Text.Split(':');
                        serveraddr = serveraddressport[0];
                        serverport = serveraddressport[1];
                    }
                    else
                    {
                        serveraddr = server_address_field.Text;
                        serverport = "16567";
                    }

                    // Connect to server
                    workingdirectory = chosen_execpath.Replace("BF2.exe", "");
                    Process runbf2 = new Process();
                    runbf2.StartInfo.FileName = chosen_execpath;
                    runbf2.StartInfo.Arguments = " +joinServer " + serveraddr + " +port " + serverport;
                    runbf2.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    runbf2.StartInfo.WorkingDirectory = workingdirectory;
                    System.Console.WriteLine("DEBUG - Selected Working directory: " + workingdirectory);
                    System.Console.WriteLine("DEBUG - command used: " + chosen_execpath + " +joinServer " + serveraddr + " +port " + serverport);

                    runbf2.Start();
                }

            }


        }

        private void WriteServerAddrToFile(string serveraddr)
        {
            try
            {
                if (System.IO.File.Exists("serverhistory.txt")){


                    StreamWriter sw = new StreamWriter("serverhistory.txt", true);
                    //Write a line of text
                    sw.WriteLine(serveraddr);
                    //Write a second line of text
                    //Close the file
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new StreamWriter("serverhistory.txt");
                    //Write a line of text
                    sw.WriteLine(serveraddr);
                    //Write a second line of text
                    //Close the file
                    sw.Close();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void shorcut_btn_Click(object sender, EventArgs e)
        {
            string[] serveraddressport;
            string serverport;
            string serveraddr;
            string Shortcut_name;
            string ROOTPATH;
            string targetPath;
            string command;
            string targetcommand;


            char delim = ':';
            if (server_address_field.Text.Contains(delim))
            {
                serveraddressport = server_address_field.Text.Split(':');
                serveraddr = serveraddressport[0];
                serverport = serveraddressport[1];
            }
            else
            {
                serveraddr = server_address_field.Text;
                serverport = "16567";
            }
            // System.Console.WriteLine(server_address); //For troubleshooting purposes.
            ROOTPATH = Find_installationPath().Replace("BF2.exe ", "");
            Shortcut_name = "BF2 MP " + serveraddr;
            targetPath = ROOTPATH;
            command = " +joinServer " + serveraddr + " +port " + serverport;
            targetcommand = targetPath;


            CreateShortcut(Shortcut_name, Environment.GetFolderPath(Environment.SpecialFolder.Desktop), targetcommand, command, ROOTPATH);
            System.Console.WriteLine("Shortcut created " + Shortcut_name);
        }
        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string Arguments, string Workdir)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            string targetPath = startupPath + "Resources\\";
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "BF2 Shortcut to Server";   // The description of the shortcut
            shortcut.IconLocation = targetPath + "BF2 MP icon.ico";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Arguments = Arguments;
            shortcut.WorkingDirectory = Workdir.Replace("BF2.exe", " ");
            shortcut.Save();                                    // Save the shortcut
        }

        private void server_address_field_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    button1_Click(this, new EventArgs());
            //}
        }

        private void server_address_field_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && !char.IsLetter(e.KeyChar)
               && e.KeyChar != ':' && e.KeyChar != '-' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
            e.Handled = false;
            return;
        }
    }
}
