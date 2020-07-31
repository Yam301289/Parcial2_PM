using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleApplication1{
    class Program{
        static void Main(string[] args){
            string path = ("image_prueba.jpg");
            Bitmap img = new Bitmap(path);
            string[,,] pixelarray = new string[img.Width, img.Height, 3];

            Console.WriteLine("La imagen contiene " + (img.Height * img.Width) + " pixeles.");
            Console.WriteLine(img.Width + (" ancho de pixeles ") + img.Height + (" alto de pixeles"));
            Console.WriteLine("Presione cualquier tecla para iniciar");
            Console.ReadKey();
            int total = (img.Height * img.Width);
            Console.WriteLine("Processing");
            for (int i = 0; i < img.Width; i++){
                for (int j = 0; j < img.Height; j++){
                    Color pixel = img.GetPixel(i, j);
                    pixelarray[i, j, 0] = Convert.ToString(pixel.R);
                    pixelarray[i, j, 1] = Convert.ToString(pixel.G);
                    pixelarray[i, j, 2] = Convert.ToString(pixel.B);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Procesamiento terminado");
            Console.WriteLine("Presione 1. para procesar la imagen, Presione 2. para salir");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1){
                try{
                    StreamWriter sw = new StreamWriter("pixels.txt");
                    for (int i = 0; i < img.Width; i++){
                        for (int j = 0; j < img.Height; j++){
                            sw.WriteLine(Convert.ToString(i) + (" ") + Convert.ToString(j) + " " + pixelarray[i, j, 0] + (" ") + pixelarray[i, j, 1] + (" ") + pixelarray[i, j, 2]);
                        }
                    }
                    sw.Close();
                }
                catch (Exception e){
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            int[,,] ContrastArray = new int[img.Width, img.Height, 1];
            for (int i = 1; i < img.Width - 2; i = i + 2){
                for (int j = 1; j < img.Height - 2; j = j + 2){
                    int theshold = 30;
                    int brightness1 = (Convert.ToInt32(pixelarray[i, j, 0]) + Convert.ToInt32(pixelarray[i, j, 1]) + Convert.ToInt32(pixelarray[i, j, 2]));
                    int brightness2 = (Convert.ToInt32(pixelarray[i, j + 1, 0]) + Convert.ToInt32(pixelarray[i, j + 1, 1]) + Convert.ToInt32(pixelarray[i, j + 1, 2]));
                    int total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold){
                        ContrastArray[i, j, 0] = total1;
                    }
                    brightness2 = (Convert.ToInt32(pixelarray[i, j - 1, 0]) + Convert.ToInt32(pixelarray[i, j - 1, 1]) + Convert.ToInt32(pixelarray[i, j - 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold){
                        if (total1 > ContrastArray[i, j, 0]){
                            ContrastArray[i, j, 0] = total1;
                        }
                    }
                    brightness2 = (Convert.ToInt32(pixelarray[i + 1, j + 1, 0]) + Convert.ToInt32(pixelarray[i + 1, j + 1, 1]) + Convert.ToInt32(pixelarray[i + 1, j + 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold){
                        if (total1 > ContrastArray[i, j, 0]){
                            ContrastArray[i, j, 0] = total1;
                        }
                    }
                    brightness2 = (Convert.ToInt32(pixelarray[i - 1, j - 1, 0]) + Convert.ToInt32(pixelarray[i - 1, j - 1, 1]) + Convert.ToInt32(pixelarray[i - 1, j - 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold){
                        if (total1 > ContrastArray[i, j, 0]){
                            ContrastArray[i, j, 0] = total1;
                        }
                    }
                    brightness2 = (Convert.ToInt32(pixelarray[i - 1, j, 0]) + Convert.ToInt32(pixelarray[i - 1, j, 1]) + Convert.ToInt32(pixelarray[i - 1, j, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold){
                        if (total1 > ContrastArray[i, j, 0]){
                            ContrastArray[i, j, 0] = total1;
                        }
                    }
                    brightness2 = (Convert.ToInt32(pixelarray[i - 1, j + 1, 0]) + Convert.ToInt32(pixelarray[i - 1, j + 1, 1]) + Convert.ToInt32(pixelarray[i - 1, j + 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold){
                        if (total1 > ContrastArray[i, j, 0]){
                            ContrastArray[i, j, 0] = total1;
                        }
                    }
                    brightness2 = (Convert.ToInt32(pixelarray[i + 1, j, 0]) + Convert.ToInt32(pixelarray[i + 1, j, 1]) + Convert.ToInt32(pixelarray[i + 1, j, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold){
                        if (total1 > ContrastArray[i, j, 0]){
                            ContrastArray[i, j, 0] = total1;
                        }
                    }
                    brightness2 = (Convert.ToInt32(pixelarray[i + 1, j - 1, 0]) + Convert.ToInt32(pixelarray[i + 1, j - 1, 1]) + Convert.ToInt32(pixelarray[i + 1, j - 1, 2]));
                    total1 = (Math.Abs(brightness1 - brightness2)) / 3;
                    if (total1 > theshold){
                        if (total1 > ContrastArray[i, j, 0]){
                            ContrastArray[i, j, 0] = total1;
                        }
                    }
                }
            }
            Console.WriteLine("Proceso de conversion terminado, Presione 1. Para guardar la imagen, Presione 2. Para salir");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1) {
                try {
                    StreamWriter sw = new StreamWriter("contrast.txt");
                    for (int i = 0; i < img.Width; i++){
                        for (int j = 0; j < img.Height; j++){
                            if (ContrastArray[i, j, 0] != 0){
                                sw.WriteLine(Convert.ToString(i) + (" ") + Convert.ToString(j) + " " + ContrastArray[i, j, 0]);
                            }
                        }
                    }
                    sw.WriteLine(img.Width + " " + img.Height);
                    sw.Close();
                } catch (Exception e) {
                    Console.WriteLine("Exception: " + e.Message);
                } finally {
                    Console.WriteLine("File was saved successfully.");
                }
            }
            Console.WriteLine("Procesando el contraste");
            Bitmap image = new Bitmap(img.Width, img.Height);
            SolidBrush brush = new SolidBrush(Color.Empty);
            using (Graphics g = Graphics.FromImage(image)){
                for (int x = 0; x < image.Width; x++){
                    for (int y = 0; y < image.Height; y++){
                        if (ContrastArray[x, y, 0] != 0){
                            int r = Convert.ToInt32(pixelarray[x, y, 0]);
                            int g1 = Convert.ToInt32(pixelarray[x, y, 1]);
                            int b = Convert.ToInt32(pixelarray[x, y, 2]);
                            brush.Color = Color.FromArgb(255, r, g1, b);
                            g.FillRectangle(brush, x, y, 1, 1);
                        }
                        if (ContrastArray[x, y, 0] == 0){
                            brush.Color = Color.FromArgb(255, 0, 0, 0);
                            g.FillRectangle(brush, x, y, 1, 1);
                        }
                    }
                }
            }
            string SavePath = "image_salida.jpg";
            image.Save(SavePath, ImageFormat.Jpeg);
            Console.WriteLine("");
            Console.WriteLine("Imagen generada exitosamente");
            Console.ReadKey();
        }
    }
}
