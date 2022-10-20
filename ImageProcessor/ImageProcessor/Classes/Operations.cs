using System;
using System.Drawing;
using System.Text;

namespace ImageProcessor.Classes
{
    static class Operations
    {
        public static Bitmap ToGrayScale(Bitmap inputImage)
        {
            var result = new Bitmap(inputImage.Width, inputImage.Height);

            for (int i = 0; i < inputImage.Height; i++)
            {
                for (int j = 0; j < inputImage.Width; j++)
                {
                    var pixelColor = inputImage.GetPixel(j, i);
                    var grayScale = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    var grayColor = Color.FromArgb(pixelColor.A, grayScale, grayScale, grayScale);
                   
                    result.SetPixel(j, i, grayColor);
                }
            }

            return result;
        }
    }
}