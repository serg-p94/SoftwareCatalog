using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SoftwareCatalog.Core;
using SoftwareCatalog.Core.Interfaces;

namespace SoftwareCatalog.DAL
{
    public class SoftInfoSerializer : ISoftInfoStorageSaver, ISoftInfoStorageLoader
    {
        private readonly JsonSerializer _serializer;

        public SoftInfoSerializer()
        {
            _serializer = JsonSerializer.Create();
        }

        public void Save(ISoftInfoStorage storage, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                _serializer.Serialize(writer, storage);
            }
        }

        public Task SaveAsync(ISoftInfoStorage storage, string path)
        {
            return Task.Run(() => Save(storage, path));
        }

        public SoftInfoStorage Load(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return _serializer.Deserialize(reader, typeof(SoftInfoStorage)) as SoftInfoStorage;
            }
        }

        public Task<SoftInfoStorage> LoadAsync(string path)
        {
            return Task.Run(() => Load(path));
        }
    }
}
