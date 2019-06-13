using System;
using System.IO;

namespace A13
{

    public class SingleFileWatcher : IDisposable
    {
        private static FileSystemWatcher Watcher=new FileSystemWatcher();
        private string FileName { get; set; }
        public Action Singlefile;

        public SingleFileWatcher(string fileName)
        {
            this.FileName = fileName;
            Watcher.Path = Path.GetDirectoryName(FileName);
            Watcher.Filter = Path.GetFileName(FileName);
            Watcher.Changed += new FileSystemEventHandler(OnChanged);
            Watcher.EnableRaisingEvents = true;
            
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Singlefile();
        }

        public void Register(Action a)
        {
            Singlefile += a;
        }
        public void Unregister(Action a)
        {
            Singlefile -= a;
        }
        public void Dispose()
        {
            FileSystemEventHandler callback = (sender, arg) =>
            {
                Watcher.Dispose();
            };
        }
    }
}