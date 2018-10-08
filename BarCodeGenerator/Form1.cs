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


namespace BarCodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string barcode = textBox1.Text;
            BarCode code39 = new BarCode();
            code39.Symbology = KeepAutomation.Barcode.Symbology.Code39;
            code39.CodeToEncode = barcode;
            code39.generateBarcodeToImageFile("D://code39.png");*/

            //********* Zen Barcode Framework **********

            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            //pictureBox2.Image = barcode.Draw(textBox1.Text, 50);
            var barcodeImage = qrcode.Draw(textBox1.Text, 5);
            var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

            using (var graphics = Graphics.FromImage(resultImage))
            using (var font = new Font("Consolas", 12))
            using (var brush = new SolidBrush(Color.Black))
            using (var format = new StringFormat()
            {
                Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                LineAlignment = StringAlignment.Far
            })
            {
                graphics.Clear(Color.White);
                graphics.DrawImage(barcodeImage, 0, 0);
                graphics.DrawString(textBox1.Text, font, brush, resultImage.Width / 2, resultImage.Height, format);
            }

            pictureBox2.Image = resultImage;
            resultImage.Save("D://qrcode.png");
            //******* QRCoder FrameWork ********

            /*QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("1236512580", QRCodeGenerator.ECCLevel.Q,true,true);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(8);
            pictureBox2.Image = qrCodeImage;*/

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //********* Zen Barcode Framework **********

            Zen.Barcode.BarcodeDraw brcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            var barcodeImage = brcode.Draw(textBox2.Text, 50);
            var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 50); // 20 is bottom padding, adjust to your text

            using (var graphics = Graphics.FromImage(resultImage))
            using (var font = new Font("Consolas", 12))
            using (var brush = new SolidBrush(Color.Black))
            using (var format = new StringFormat()
            {
                Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                LineAlignment = StringAlignment.Far
            })
            {
                graphics.Clear(Color.White);
                graphics.DrawImage(barcodeImage, 10, 20);
                graphics.DrawString(textBox2.Text, font, brush, resultImage.Width / 2, resultImage.Height, format);
            }

            pictureBox1.Image = resultImage;
            resultImage.Save("D://brcode.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
