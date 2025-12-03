using System.Net.Http.Headers;

namespace FileHandlingDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //File.Create("demofile.txt");

            // File.Create(@"C:\Users\user1\Desktop\file2.txt");

            //File.WriteAllText(@"C:\Users\user1\Desktop\file3.txt", "Hello from World ");

            IEnumerable<string> strs = new List<string> { "Ravi", "Ravisha", "Manisha", "Girija" };
            File.WriteAllLines("demo2.txt", strs);
            MessageBox.Show("Created..");

            //catch(Exception ex){ MessageBox.Show(ex.Message);   }

            //Logging exceptions/errors to a file
            //catch(Exception ex){ MessageBox.Show(ex.Message);
            //string s= ex.Message;
            //File.WriteAllText("errorMessage.txt",s);}
            //File.WriteAllText("errorMessage.txt",ex.Message);        }
        }
    }
}
