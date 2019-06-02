using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A12
{
    public static class ExtMethod
    {
        public static string Clean(this string str) =>
            str.Trim(' ', '"', 'M', '+','K','$');
       
    }
    public class AppData
    {
        public string Name;
        public string Category;
        public double Rating;
        public long Reviews;
        public string Size;
        public long Installs;
        public string IsFree;
        public double Price;
        public string ContentRating;
        public string Genres;
        public DateTime LastUpdate;
        public string CurrentVersion;
        public string AndroidVersion;
        public AppData(string[] fields)
        {
            Name = fields[0];
            Category = fields[1];
            Rating = double.Parse(fields[2]);
            Reviews = long.Parse(fields[3]);
            Size = fields[4];
            Installs = long.Parse(fields[5].Replace(",","").Clean());
            IsFree = fields[6];
            Price = double.Parse(fields[7].Clean());
            ContentRating = fields[8];
            Genres=fields[9];
            LastUpdate = DateTime.Parse(fields[10]);
            CurrentVersion = fields[11];
            AndroidVersion = fields[12];
        }
    }
}
