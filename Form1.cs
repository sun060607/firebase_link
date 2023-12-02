using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace firebase_link
{
    public partial class Form1 : Form
    {
        private const string BasePath = "https://test-esp32-612ef-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const string FirebaseSecrct = "AGVBGvOyjfvORBXnfROrpn7W33hGNnJnAhAu3NVU";
        private static FirebaseClient _client;
        public Form1()
        {
            InitializeComponent();

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = FirebaseSecrct,
                BasePath = BasePath
            };
            _client = new FirebaseClient(config);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await _client.GetAsync("humi");
            String humi = response.ResultAs<string>();
            MessageBox.Show(humi);
        }
    }
}
