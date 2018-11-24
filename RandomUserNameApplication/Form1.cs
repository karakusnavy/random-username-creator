using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//@karakusnavy

namespace RandomUserNameApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //@karakusnavy
        List<string> name_list = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(openFileDialog1.FileName);
                string list = read.ReadLine();
                while (list != null){
                    name_list.Add(list);
                    list = read.ReadLine();
                }
            }
            label1.Text = "Names: "+name_list.Count.ToString();
            button2.Enabled = true;
            button1.Enabled = false;
        }
        List<string> username_list = new List<string>();
        Random rnd = new Random();
        int count = 1;
        //@karakusnavy
        void create_username()
        {
            comehereman:
            for (int i = 0; i < name_list.Count; i++)
            {
                username_list.Add(name_list[i]+rnd.Next(555,9999).ToString()+name_list[rnd.Next(0,name_list.Count)]);
            }
            if (count != 100)                
            {
                count++;
                create_username();//@karakusnavy
            }            
            label3.Text = "Usernames: "+username_list.Count.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            create_username();
            button3.Enabled = true;
            button2.Enabled = false;
        }
        //@karakusnavy
        private void button3_Click(object sender, EventArgs e)
        {
            String[] usernamesbaby = new String[username_list.Count];
            username_list.CopyTo(usernamesbaby, 0);
            System.IO.File.WriteAllLines("usernames.txt", usernamesbaby);
            System.Diagnostics.Process.Start(Application.StartupPath);            
            button3.Enabled = false;
            label4.Text = "Succesfully !";
            MessageBox.Show("Exporting the Application Startup Path");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }//@karakusnavy
    }
}
