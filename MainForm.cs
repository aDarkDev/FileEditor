using System;
using System.ComponentModel;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox1.Text = location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var openFolderDialog = new FolderBrowserDialog();
            openFolderDialog.ShowDialog();
            string location = openFolderDialog.SelectedPath;
            textBox2.Text = location;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
         
        }

        int saveSplit(string source , string destination , int AllCount)
        {
            int index = 1;
            int FileCount = 1;
            StreamReader reader = new StreamReader(source);
            TextWriter fs2 = new StreamWriter($"{destination}\\result{FileCount}.txt");

            string line;
            while ((line = reader.ReadLine()) != null)
            {

                if (index != AllCount)
                {
                    fs2.WriteLine(line);
                    index++;
                }
                else
                {
                    FileCount++;
                    fs2.Close();
                    fs2 = new StreamWriter($"{destination}\\result{FileCount}.txt");
                    fs2.WriteLine(line);
                    index = 2;
                }

            }
            fs2.Close();
            return FileCount;
        }
        void saveCombine(string first, string second, string saveTo, string JoinWith)
        {
            TextWriter fs2 = new StreamWriter(saveTo);
            StreamReader reader = new StreamReader(first);
            StreamReader reader2 = new StreamReader(second);

            string line;
            string line_2;
            while ((line = reader.ReadLine()) != null)
            {
                line_2 = reader2.ReadLine();
                fs2.WriteLine(line + JoinWith + line_2);
            }
            fs2.Close();

        }

        void saveCredentials(string first, string second, string saveTo, string JoinWith)
        {
            TextWriter fs2 = new StreamWriter(saveTo);
            StreamReader reader = new StreamReader(first);
            

            string line;
            string line_2;
            while ((line = reader.ReadLine()) != null)
            {
                StreamReader reader2 = new StreamReader(second);
                while ((line_2 = reader2.ReadLine()) != null)
                {
                    
                    fs2.WriteLine(line + JoinWith + line_2);
                }
                
            }
            fs2.Close();

        }

        void saveAppend(string first, string saveTo, string JoinWith, bool before)
        {
            TextWriter fs2 = new StreamWriter(saveTo);
            StreamReader reader = new StreamReader(first);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (before)
                {
                    fs2.WriteLine(JoinWith + line);
                }
                else
                {
                    fs2.WriteLine(line + JoinWith);
                }

            }
            fs2.Close();

        }
        double unixTimeStamp()
        {
            double unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTimestamp;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string source = textBox1.Text;
            string destination = textBox2.Text;
            string count = textBox3.Text;
            if (source != "" && destination != "" && int.TryParse(count, out int n))
            {
                int AllCount = Convert.ToInt32(count);
                double unixTimestamp_start = unixTimeStamp();
                int FileCount = saveSplit(source, destination , AllCount);
                double unixTimestamp_end = unixTimeStamp();
                int ping = (int)Math.Round(unixTimestamp_end - unixTimestamp_start, 0);
                string[] name = source.Split(new string[] { "\\" }, StringSplitOptions.None);
                MessageBox.Show(
                    $"Splited Success.\r\nFile: {name[name.Length-1]}\r\nTime Taken: {ping}s\r\nNumber of files created: {FileCount}\r\nBy ConfusedCharacter",
                    "Completed", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                    );
            }
            else
            {
                MessageBox.Show("Please fill all fields.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string first = textBox6.Text;
            string second = textBox7.Text;
            string saveTo = textBox5.Text;
            string Join = textBox4.Text;
            if (first != "" && second != "" && saveTo != "")
            {
                double unixTimestamp_start = unixTimeStamp();
                saveCombine(first, second, saveTo,Join);
                double unixTimestamp_end = unixTimeStamp();
                int ping = (int)Math.Round(unixTimestamp_end - unixTimestamp_start, 0);
                MessageBox.Show(
                    $"Splited Success.\r\nTime Taken: {ping}s\r\nBy ConfusedCharacter",
                    "Completed", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                    );
            }
            else
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox6.Text = location;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox7.Text = location;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox5.Text = location;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox11.Text = location;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox9.Text = location;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox10.Text = location;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string userFile = textBox11.Text;
            string passwordFile = textBox9.Text;
            string saveTo = textBox10.Text;
            string Join = textBox8.Text;
            if (userFile != "" && passwordFile != "" && saveTo != "")
            {
                double unixTimestamp_start = unixTimeStamp();
                saveCredentials(userFile, passwordFile, saveTo, Join);
                double unixTimestamp_end = unixTimeStamp();
                int ping = (int)Math.Round(unixTimestamp_end - unixTimestamp_start, 0);
                MessageBox.Show(
                    $"Splited Success.\r\nTime Taken: {ping}s\r\nBy ConfusedCharacter",
                    "Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            else
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox14.Text = location;
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string location = openFileDialog1.FileName;
            textBox13.Text = location;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string source = textBox14.Text;
            string saveTo = textBox13.Text;
            string Join = textBox12.Text;
            if (source != "" && Join != "" && saveTo != "")
            {
                bool before;
                if (radioButton1.Checked)
                {
                    before = true;
                }
                else
                {
                    before = false;
                }

                double unixTimestamp_start = unixTimeStamp();
                saveAppend(source, saveTo, Join,before);
                double unixTimestamp_end = unixTimeStamp();
                int ping = (int)Math.Round(unixTimestamp_end - unixTimestamp_start, 0);
                MessageBox.Show(
                    $"Splited Success.\r\nTime Taken: {ping}s\r\nBy ConfusedCharacter",
                    "Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            else
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
