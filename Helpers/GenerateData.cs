using FileExplorer.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FileExplorer.Helpers
{
    internal static class GenerateData
    {
        public static void GenerateAndSaveProducts()
        {
            Test[] products =
            {
                new Test(1, "product1", "No description"),
                new Test(2, "product2", "No description"),
                new Test(3, "product3", "No description"),
                new Test(4, "product4", "No description"),
                new Test(5, "product5", "No description"),
                new Test(6, "product6", "No description"),
                new Test(7, "product7", "No description"),
                new Test(8, "product8", "No description"),
                new Test(9, "product9", "No description")
            };

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Сохранить файл как";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = "data.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                XmlSerializer xmlserializer = new XmlSerializer(typeof(Product[]));

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    xmlserializer.Serialize(fs, products);
                }
                MessageBox.Show("Файл сохранён по пути:\n" + filePath);
            }
        }

    }
}
