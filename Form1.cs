using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //This function is called when the exit menu item is selected
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app was created by Tens Hanzo");
        }

        // On click of this button the web control will display the page requested
        private void button1_Click(object sender, EventArgs e)
        {
            // Translations: Navigate to what is written in the textbox1 object
            navigateToPage();
        }

        // This is the core function that will perform all navigation and post processing
        private void navigateToPage()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            toolStripStatusLabel1.Text = "Navigation has started";
            webBrowser1.Navigate(textBox1.Text);
        }

        // This function will fire everytime a key is pushed and released
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the keystroke was enter then do this
            if(e.KeyChar == (char)ConsoleKey.Enter)
            {
                navigateToPage();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation complete";

            //Changes every picture on the webpage to the one specified 
            foreach (HtmlElement image in webBrowser1.Document.Images)
            {
                image.SetAttribute("src", "http://img.humorsharing.com/media/images/1208/i_hilarious_google_suggestions_50223ffdb36b5.jpg");
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if(e.CurrentProgress > 0 && e.MaximumProgress > 0)
            toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
        }
    }
}
