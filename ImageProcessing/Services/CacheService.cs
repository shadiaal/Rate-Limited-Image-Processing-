using System.Collections.Concurrent;

namespace ImageProcessingApi.Services
{
    public interface ICacheService
    {
        byte[] Get(string key);
        void Set(string key, byte[] data);
    }

    public class CacheService : ICacheService
    {
        
        private readonly ConcurrentDictionary<string, byte[]> _cache = new();
		public byte[] Get(string key)
		{
			_cache.TryGetValue(key, out var data);
			return data;
		}

		public void Set(string key, byte[] data)
		{
			_cache[key] = data;
		}


	


	}
}