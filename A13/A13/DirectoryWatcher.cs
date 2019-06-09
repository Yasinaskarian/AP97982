using System;
using System.IO;

namespace A13
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private static FileSystemWatcher Watcher = new FileSystemWatcher();
        private string FileName { get; set; }
        public Action<string> Singlefile { get; private set; }

        public DirectoryWatcher(string fileName)
        {
            this.FileName = fileName;
            Watcher.Path = Path.GetDirectoryName(FileName);
            Watcher.Filter = Path.GetFileName(FileName);
            Watcher.Changed += OnChanged;
            Watcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Singlefile(e.Name);
        }

        public void Register(Action<string> notifyMe, ObserverType create)
        {
            Singlefile += notifyMe;
        }
        public void Unregister(Action<string> notifyMe, ObserverType create)
        {
            Singlefile -= notifyMe;
        }
        public void Dispose()
        {
            Watcher.Dispose();
        }

        
    }
}