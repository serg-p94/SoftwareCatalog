using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SoftwareCatalog.Core.Interfaces
{
    public interface ISoftInstallManager
    {
        Process StartInstallation(SoftInfo softInfo);
        Task InstallAll(IEnumerable<SoftInfo> soft);
    }
}
