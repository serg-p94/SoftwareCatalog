using System;
using SoftwareCatalog.Core;
using SoftwareCatalog.DAL;

namespace SoftwareCatalog.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var aimp = new SoftInfo
            {
                Name = "Aimp 3",
                Path = @"E:\Soft\aimp_3.55.1355.exe",
                LastUpdateDate = DateTime.Now,
                Version = "3.55.1355"
            };
            var dm = new SoftInfo
            {
                Name = "Download Master",
                Path = @"E:\Soft\dmaster.exe",
                LastUpdateDate = DateTime.Now,
                Version = "Unknown"
            };

            var storage = new SoftInfoStorage
            {
                {aimp.Name, aimp},
                {dm.Name, dm}
            };*/

            var serializer = new SoftInfoSerializer();
            //serializer.Save(storage, "storage.json");
            var installer = new SoftInstallManager();
            var storage = serializer.Load("storage.json");
            installer.InstallAll(storage).Wait();
        }
    }
}
