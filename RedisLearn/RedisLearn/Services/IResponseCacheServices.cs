﻿namespace RedisLearn.Services
{
    public interface IResponseCacheServices
    {
        Task SetCacheResponseAsync(string cacheKey, object response, TimeSpan timeOut);

        Task<string> GetCacheResponseAsync(string cacheKey);
    }
}
