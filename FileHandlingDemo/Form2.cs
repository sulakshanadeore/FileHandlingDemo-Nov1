using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace FileHandlingDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\user1\\Desktop\\demofile.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                sw.Write(richTextBox1.Text);
                MessageBox.Show("File Created");
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Flush();
                fs.Flush();
                sw.Close();
                fs.Close();
                sw.Dispose();
                fs.Dispose();
            }







        }

        private void button2_Click(object sender, EventArgs e)
        {

            FileStream fs = new FileStream("C:\\Users\\user1\\Desktop\\demofile.txt", FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(fs);

            try
            {
                richTextBox1.Text = sr.ReadToEnd();


                
              DialogResult dr=  MessageBox.Show("Have you completed reading the file? Y/N","User Confirmation",MessageBoxButtons.YesNo);
                if (dr==DialogResult.Yes)
                {
                    DialogResult dr1=MessageBox.Show("Should I clear the textbox now?","User Input",MessageBoxButtons.YesNo);

                    if (dr1==DialogResult.Yes)
                    {
                        richTextBox1.Clear();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                fs.Flush();
                sr.Close();
                fs.Close();
                sr.Dispose();
                fs.Dispose();


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\user1\\Desktop\\demofile.txt", FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.Write(richTextBox1.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Flush();
                fs.Flush();
                sw.Close();
                fs.Close();
                sw.Dispose();
                fs.Dispose();


            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\user1\\Desktop\\demofile.txt", FileMode.Open, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.Write(richTextBox1.Text);
                MessageBox.Show("File Editted");
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Flush();
                fs.Flush();
                sw.Close();
                fs.Close();
                sw.Dispose();
                fs.Dispose();


            }



        }
    }
}
