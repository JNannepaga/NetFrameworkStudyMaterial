using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace SatteliteAssembly
{
    
    public partial class Form1 : Form
    {
        private const string word1 = "word1";
        ResourceManager resourceManager = 
            new ResourceManager("LangAssembler.MyLangResoures", Assembly.GetExecutingAssembly());
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLang = comboBox1.Text;
            switch (selectedLang)
            {
                case "English":
                    ChangeCulture("en-US");
                    break;

                case "Telugu":
                    ChangeCulture("te-IN");
                    break;

                case "Hindi":
                    ChangeCulture("hi-IN");
                    break;

                case "Kichidi":
                    ResourceManager resourceManager =
             new ResourceManager("SatteliteAssembly.Kichidi", Assembly.GetExecutingAssembly());
                    label1.Text = resourceManager.GetString("word2");
                    break;

                default:
                    break;
            }
        }

        private void ChangeCulture(string sLangCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(sLangCode);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(sLangCode);
            label1.Text = resourceManager.GetString(word1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
