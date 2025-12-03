using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace FileHandlingDemo
{
    public partial class XMLFileWorking : Form
    {
        public XMLFileWorking()
        {
            InitializeComponent();
        }

        private void XMLFileWorking_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();


            XmlElement root = doc.CreateElement("Students");
            doc.AppendChild(root);

            XmlElement stud1 = doc.CreateElement("Student");
            XmlElement rollno = doc.CreateElement("RollNo");
            rollno.InnerText = "1";
            stud1.AppendChild(rollno);

            XmlElement name = doc.CreateElement("Name");
            name.InnerText = "Ameya";
            stud1.AppendChild(name);

            XmlElement marks = doc.CreateElement("Marks");
            marks.InnerText = "88";
            stud1.AppendChild(marks);

            root.AppendChild(stud1);

            XmlElement stud2 = doc.CreateElement("Student");
            rollno = doc.CreateElement("RollNo");
            rollno.InnerText = "2";
            stud2.AppendChild(rollno);

            name = doc.CreateElement("Name");
            name.InnerText = "Yamini";
            stud2.AppendChild(name);

            marks = doc.CreateElement("Marks");
            marks.InnerText = "90";
            stud2.AppendChild(marks);

            root.AppendChild(stud2);

            doc.Save("Students.xml");
            MessageBox.Show("Created file ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Students.xml");
            XmlNodeList list = doc.GetElementsByTagName("Student");
            foreach (XmlNode item in list)
            {
                int rollno = Convert.ToInt32(item["RollNo"].InnerText);
                string name = item["Name"].InnerText;
                double marks = Convert.ToDouble(item["Marks"].InnerText);
                textBox1.Text += Environment.NewLine + rollno;
                textBox1.Text += Environment.NewLine + name;
                textBox1.Text += Environment.NewLine + marks;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create("schoolStud.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Students");

                writer.WriteStartElement("Student");
                writer.WriteElementString("RollNo", "11");
                writer.WriteElementString("Name", "Gauri");
                writer.WriteElementString("Marks", "80");

                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();

            }




        }

        private void button3_Click(object sender, EventArgs e)
        {

            XmlReader reader = XmlReader.Create("schoolStud.xml");
            while (reader.Read())
            {
                XmlNodeType type = reader.NodeType;
                switch (type)
                {
                    case XmlNodeType.None:
                      //  textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.Element:
                        textBox1.Text += Environment.NewLine + reader.Name;
                        break;
                    case XmlNodeType.Attribute:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.Text:
                        textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.CDATA:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.EntityReference:
                    //    textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.Entity:
                      //  textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.Comment:
                      //  textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.Document:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.DocumentType:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.DocumentFragment:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.Notation:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.Whitespace:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.EndElement:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.EndEntity:
                       // textBox1.Text += Environment.NewLine + reader.Value;
                        break;
                    case XmlNodeType.XmlDeclaration:
                        //textBox1.Text += Environment.NewLine + reader.Value;
                        break;

                }

            }
        }
    }
}
