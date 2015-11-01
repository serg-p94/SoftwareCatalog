using System.Threading.Tasks;

namespace SoftwareCatalog.Core.Interfaces
{
    public interface ISoftInfoStorageSaver
    {
        void Save(ISoftInfoStorage storage, string path);
        Task SaveAsync(ISoftInfoStorage storage, string path);
    }
}
