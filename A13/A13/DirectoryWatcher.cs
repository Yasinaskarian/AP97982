using System;
using System.IO;

namespace A13
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private static FileSystemWatcher Watcher;
        private string FileName { get; set; }
        public Action<string> Createdfile;
        public Action<string> Deletedfile;
        public DirectoryWatcher(string fileName)

        {
            this.FileName = fileName;
            Watcher = new FileSystemWatcher(fileName);
            //Watcher.Path = Path.GetDirectoryName(FileName);
            //Watcher.Filter = Path.GetFileName(FileName);
            Watcher.Changed += OnChanged;
            Watcher.Created += OnChanged;
            Watcher.Deleted += OnChanged;
            //Watcher.NotifyFilter = NotifyFilters.LastAccess
            //         | NotifyFilters.LastWrite
            //         | NotifyFilters.FileName
            //         | NotifyFilters.DirectoryName;
            Watcher.EnableRaisingEvents = true;
        }
        
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
           if(e.ChangeType==WatcherChangeTypes.Created)
                Createdfile(e.FullPath);
            if (e.ChangeType == WatcherChangeTypes.Deleted)
                Deletedfile(e.FullPath);
        }
        public void Register(Action<string> notifyMe, ObserverType create)
        {
            if (create is ObserverType.Create)
                Createdfile += notifyMe;
            else
                Deletedfile += notifyMe;
        }
        public void Unregister(Action<string> notifyMe, ObserverType create)
        {
            if (create is ObserverType.Create)
                Createdfile -= notifyMe;
            else
                Deletedfile -= notifyMe;
        }
        public void Dispose()
        {
            Watcher.Dispose();
        }

        
    }
}