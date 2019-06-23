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
                // pulls file content into main text box
                textBoxFilePath.Text = openFileDialog1.FileName;
                textBoxFileContent.Text = File.ReadAllText(openFileDialog1.FileName);

                // save content of imported string for global use
                Global.TheString = File.ReadAllText(openFileDialog1.FileName);

                // selects range of text to pull into corresponding text boxes
                var dateTime = File.ReadAllText(openFileDialog1.FileName); ;
                textBoxDateTime.Text = dateTime.Substring(11, 12);

                var dollarAmount = File.ReadAllText(openFileDialog1.FileName);
                textBoxDollarAmount.Text = dollarAmount.Substring(29, 10);

                var individualId = File.ReadAllText(openFileDialog1.FileName);
                textBoxIndividualId.Text = individualId.Substring(45, 15);

                var customerName = File.ReadAllText(openFileDialog1.FileName);
                textBoxCustomerName.Text = customerName.Substring(64, 21);

                var returnReasonCode = File.ReadAllText(openFileDialog1.FileName);
                textBoxReturnReasonCode.Text = returnReasonCode.Substring(92, 3);

                var trace = File.ReadAllText(openFileDialog1.FileName);
                textBoxTrace.Text = trace.Substring(105, 14);


                // pulls file content into preview text box.
                textBoxPreviewContent.Text = openFileDialog1.FileName;
                textBoxPreviewContent.Text = File.ReadAllText(openFileDialog1.FileName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // pull text from form and assign to variables.
            var newDateTime = textBoxDateTime.Text;

            var newDollarAmount = textBoxDollarAmount.Text;
            var newDollarAmountPadded = newDollarAmount.PadLeft(10);

            var newIndividualId = textBoxIndividualId.Text;

            var newCustomerName = textBoxCustomerName.Text;
            var newCustomerNamePadded = newCustomerName.PadLeft(21);

            var newReturnReasonCode = textBoxReturnReasonCode.Text;

            var newTrace = textBoxTrace.Text;


            // pull in original string
            var theString = Global.TheString;
            var aStringBuilder = new StringBuilder(theString);

            // replace original string values with new values.

            // new datetime
            aStringBuilder.Remove(11, 12);
            aStringBuilder.Insert(11, newDateTime);

            // new dollar amount
            aStringBuilder.Remove(29, 10);
            aStringBuilder.Insert(29, newDollarAmountPadded);

            // new individual id
            aStringBuilder.Remove(45, 15);
            aStringBuilder.Insert(45, newIndividualId);

            // new customer name
            aStringBuilder.Remove(64, 21);
            aStringBuilder.Insert(64, newCustomerNamePadded);

            // new return reason code
            aStringBuilder.Remove(92, 3);
            aStringBuilder.Insert(92, newReturnReasonCode);

            // new trace
            aStringBuilder.Remove(105, 14);
            aStringBuilder.Insert(105, newTrace);

            theString = aStringBuilder.ToString();

            var dateTime = DateTime.Now.ToString("yyyyddMHHmmss");

            var extension = ".ach";

            System.IO.File.WriteAllText(@"C:\SF.Code\AchFileCreator\_AchFileExports\ACHA" + dateTime + extension, theString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxDateTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPreviewContent.Text != "")
            {
                string previewText = textBoxPreviewContent.Text;
                StringBuilder sb = new StringBuilder(previewText);

                var dateTime = textBoxReturnReasonCode.Text;
                var dateTimePadded = dateTime.PadRight(3);

                sb.Remove(11, 12);
                sb.Insert(11, dateTimePadded);

                previewText = sb.ToString();
                textBoxPreviewContent.Text = previewText.ToString();

            }
        }
        private void textBoxReasonCode_TextChanged(object sender, EventArgs e)
        {

            if (textBoxPreviewContent.Text != "")
            {
                string previewText = textBoxPreviewContent.Text;
                StringBuilder sb = new StringBuilder(previewText);

                var reasonCode = textBoxReturnReasonCode.Text;
                var reasonCodePadded = reasonCode.PadRight(3);

                sb.Remove(92, 3);
                sb.Insert(92, reasonCodePadded);

                previewText = sb.ToString();
                textBoxPreviewContent.Text = previewText.ToString();

            }
        }

      
    }
}
