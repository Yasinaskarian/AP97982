using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A12
{
   public class AppAnalysis
    {
        public List<AppData> Apps=new List<AppData>();
        private AppAnalysis() { }
        public static AppAnalysis AppAnalysisFactory(string csvAddress)
        {
            var appAnalysis = new AppAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    appAnalysis.AppendApp(fields);
                }
            }
            return appAnalysis;
        }

        public void AppendApp(string[] fields)
        {
            AppData a = new AppData(fields);
            Apps.Add(a);
                
        }

        public long AllAppsCount() =>  Apps.Count; 
        public long AppsAboveXRatingCount(double x)
        {
            long l = Apps
                .Where(d => d.Rating >= x).ToList().Count;
            return l;
        }
        public long RecentlyUpdatedCount(DateTime boundary)
        {
            long l = Apps
                 .Where(d => d.LastUpdate >= boundary).ToList().Count;
            return l;
        }
        public string RecentlyUpdatedFreqCat(DateTime boundary)
        {
            string[] str = Apps
                 .Where(d => d.LastUpdate >= boundary)
                 .GroupBy(d => d.Category)
                 .OrderBy(g => g.Count())
                 .Select(g => g.Key)
                 .ToArray();
                return str[str.Length-1];
            
        }
        public List<string> MostRatedCategories(double ratingBoundary,int n)
        {
            List<string> l = Apps
                .Where(d=>d.Rating>ratingBoundary)
                .GroupBy(g=>g.Category)
                .OrderByDescending(g=>g.Count())
                .Select(g=>g.Key)
                .Take(n)
                .ToList();
            return l;
        }
        public double TopQuarterBoundary()
        {
            double[] d = Apps
                .Where(a => a.Category == "PHOTOGRAPHY")
                .OrderByDescending(a=>a.Rating)
                .Select(a=>a.Rating)
                .ToArray();
            return d[d.Length/4];
        }
        public Tuple<string,string> ExtremeMeanUpdateElapse(DateTime today)
        {
            string[] most = Apps
                .Select(d =>
                {
                    return new
                    {
                        t = today - d.LastUpdate,
                        category = d.Category
                    };
                })
                .GroupBy(g => g.category)
                .Select(g => new
                {
                    avg = g.Average(d => (d.t.TotalDays)),
                    cat = g.Key
                })
                .OrderByDescending(d=>d.avg)
                .Select(d => d.cat)
                .ToArray();

            var a = Tuple.Create(most[most.Length - 1], most[0]);

            return a;
        }
        public List<string> XMostProfitables( int x)
        {
            List<string> s =Apps
                .OrderByDescending(d=>(d.Installs*d.Price))
                .Take(x)
                .Select(d=>d.Name)
                .ToList();
            return s;
        }
        public List<string> XCoolestApps( int x,Func<AppData,double> criteria)
        {
            List<string> l = Apps
                 .OrderBy(criteria)
                 .Take(x)
                 .Select(d => d.Name)
                 .ToList();
            return l;
        }

    }
}
