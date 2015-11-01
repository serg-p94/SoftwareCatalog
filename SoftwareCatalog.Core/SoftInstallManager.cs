using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SoftwareCatalog.Core.Interfaces;

namespace SoftwareCatalog.Core
{
    public class SoftInstallManager : ISoftInstallManager
    {
        public Process StartInstallation(SoftInfo softInfo)
        {
            return Process.Start(softInfo.Path);
        }

        public Task InstallAll(IEnumerable<SoftInfo> soft)
        {
            return Task.Run(() =>
            {
                foreach (var softInfo in soft)
                {
                    using (var process = StartInstallation(softInfo))
                    {
                        process.WaitForExit();
                    }
                }
            });
        }
    }
}
