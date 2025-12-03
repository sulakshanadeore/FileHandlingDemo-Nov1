using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileHandlingDemo
{
    public partial class WorkingWithBinaryFile : Form
    {
        public WorkingWithBinaryFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("data.bin", FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(10);
            writer.Write(333.32f);
            writer.Write("Hello");
            writer.Flush();
            fs.Flush();
            writer.Close();
            fs.Close();
            writer.Dispose();
            fs.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
            BinaryReader sr = new BinaryReader(fs);
            int i = sr.ReadInt32();
            float v = sr.ReadSingle();
            string s = sr.ReadString();
            textBox1.Text = i.ToString();
            textBox1.Text += Environment.NewLine + v;
            textBox1.Text += Environment.NewLine + s;
            fs.Flush();
            sr.Close();
            fs.Close();
            sr.Dispose();
            fs.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("studdata.bin", FileMode.Create
                , FileAccess.Write);
            List<Student> students = new List<Student>() {
            new Student{Rollno=1,Name="Pratiksha",Marks=90 },
            new Student{Rollno=2,Name="Manisha",Marks=80 },
            new Student{Rollno=3,Name="Diksha",Marks=70 },
                };
            BinaryWriter w;
            using (w = new BinaryWriter(fs))
            {

                foreach (var item in students)
                {
                    w.Write(item.Rollno);
                    w.Write(item.Name);
                    w.Write(item.Marks);
                }

                w.Flush();
                fs.Flush();
                w.Close();
                fs.Close();
                w.Dispose();
                fs.Dispose();

            }






        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("studdata.bin", FileMode.Open, FileAccess.Read);
            BinaryReader r;
            using (r = new BinaryReader(fs))
            {
                while (r.BaseStream.Position < r.BaseStream.Length)
                {
                    int rollno = r.ReadInt32();
                    string name = r.ReadString();
                    double marks = r.ReadDouble();
                    textBox2.Text += Environment.NewLine + rollno.ToString();
                    textBox2.Text += Environment.NewLine + name;
                    textBox2.Text += Environment.NewLine + marks;
                }
                fs.Flush();
                r.Close();
                r.Dispose();

                fs.Close();
                fs.Dispose();
            }


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
