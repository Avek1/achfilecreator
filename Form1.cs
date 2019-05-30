using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Global Global = new Global();
        private void btnImportFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog1.FileName;
                textBoxFileContent.Text = File.ReadAllText(openFileDialog1.FileName);


                Global.TheString = File.ReadAllText(openFileDialog1.FileName);

                var reasonCode = File.ReadAllText(openFileDialog1.FileName);
                textBoxReasonCode.Text = reasonCode.Substring(5, 3);

                var date = File.ReadAllText(openFileDialog1.FileName); ;
                textBoxDate.Text = date.Substring(12, 12);

                var creditAccount = File.ReadAllText(openFileDialog1.FileName);
                textBoxCreditAccount.Text = creditAccount.Substring(28, 16);

                var bank = File.ReadAllText(openFileDialog1.FileName);
                textBoxBank.Text = bank.Substring(48, 20);

                var customerName = File.ReadAllText(openFileDialog1.FileName);
                textBoxCustomerName.Text = customerName.Substring(72, 26);

                var tracer = File.ReadAllText(openFileDialog1.FileName);
                textBoxTracer.Text = tracer.Substring(102, 7);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // pull text from form and assign to variables.
            var newReasonCode = textBoxReasonCode.Text;

            var newDate = textBoxDate.Text;

            var newCreditAccount = textBoxCreditAccount.Text;

            var newBank = textBoxBank.Text;
            var newPaddedBank = newBank.PadLeft(20);

            var newCustomerName = textBoxCustomerName.Text;
            var newPaddedCustomerName = newCustomerName.PadLeft(26);

            var newTracer = textBoxTracer.Text;


            // pull in original string
            var theString = Global.TheString;
            var aStringBuilder = new StringBuilder(theString);

            // replace original string values with new values.
            // new reason code
            aStringBuilder.Remove(5, 3);
            aStringBuilder.Insert(5, newReasonCode);
            // new date
            aStringBuilder.Remove(12, 12);
            aStringBuilder.Insert(12, newDate);
            // new credit account
            aStringBuilder.Remove(28, 16);
            aStringBuilder.Insert(28, newCreditAccount);
            // new bank
            aStringBuilder.Remove(48, 20);
            aStringBuilder.Insert(48, newPaddedBank);
            // new customer name
            aStringBuilder.Remove(72, 26);
            aStringBuilder.Insert(72, newPaddedCustomerName);
            // new tracer
            aStringBuilder.Remove(102, 7);
            aStringBuilder.Insert(102, newTracer);

            theString = aStringBuilder.ToString();

            //var dateTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            var dateTime = DateTime.Now.ToString("yyyyddMHHmmss");

            var extension = ".ach";

            System.IO.File.WriteAllText(@"C:\SF.Code\AchFileCreator\_AchFileExports\ACHA" + dateTime + extension, theString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }
    }
}
