using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDataBaseInterface
{
    public class ListBoxItem
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public object Tag { get; set; }
        public ListBoxItem(string text, string description, object tag)
        {
            Text = text;
            Description = description;
            Tag = tag;
        }
        public override string ToString()
        {
            return $"{Text} (id = {Tag.ToString()})";
        }
    }
    public class ColorData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public Bitmap Monochrome_Color { get; set; } // Bitmap для хранения изображения
    }
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Tag { get; set; }

        public ComboBoxItem(string text, object tag)
        {
            Text = text;
            Tag = tag;
        }

        public override string ToString()
        {
            return $"{Text} (id = {Tag.ToString()})";
        }
    }

    public class Category
    {
        public string Text { get; set; }
        public string Type { get; set; }
        public object Tag { get; set; }

        public Category(string text, string type, object tag)
        {
            Text = text;
            Type = type;
            Tag = tag;
        }

        public override string ToString()
        {
            return $"{Text} (Тип: {Type}) (id = {Tag.ToString()})";
        }
    }
}
