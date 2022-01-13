using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace APITestProject
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        string url = "https://dog.ceo/api/breeds/image/random";
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            button1.Click += async (o, e) =>
            {
                string stringData = await _httpClient.GetStringAsync(url);
                ProcessAPIData(stringData);
            };
        }

        void ProcessAPIData(string str)
        {
            string[] strArray = str.Split(',');
            string tempString;
            listBox1.Items.Clear();
            foreach(string strEntry in strArray)
            {
                tempString = strEntry;
                tempString = tempString.Replace('"', ' ').Replace('{', ' ').Replace('}', ' ').Replace("success", "poggers").Trim();
                listBox1.Items.Add(tempString);

                if (tempString.Contains("message :"))
                {
                    tempString = tempString.Remove(0,9).Replace("\\","").Trim();
                    listBox1.Items.Add(tempString);
                    var request = WebRequest.Create(tempString);

                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        pictureBox1.Image = Bitmap.FromStream(stream);
                    }
                }
            }

            //pictureBox1.ImageLocation = ;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
