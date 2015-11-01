using System.Threading.Tasks;

namespace SoftwareCatalog.Core.Interfaces
{
    public interface ISoftInfoStorageLoader
    {
        SoftInfoStorage Load(string path);
        Task<SoftInfoStorage> LoadAsync(string path);
    }
}
