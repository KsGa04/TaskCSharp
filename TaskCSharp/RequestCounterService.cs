namespace TaskCSharp
{
    public class RequestCounterService
    {
        private readonly SemaphoreSlim _semaphore;

        public RequestCounterService(IConfiguration config)
        {
            int parallelLimit = config.GetValue<int>("Settings:ParallelLimit");
            _semaphore = new SemaphoreSlim(parallelLimit, parallelLimit);
        }

        public async Task<bool> TryAcquireRequestSlot()
        {
            return await _semaphore.WaitAsync(0);
        }

        public void ReleaseRequestSlot()
        {
            _semaphore.Release();
        }
        public int GetSemaphoreCurrentCount()
        {
            return _semaphore.CurrentCount;
        }
    }
}
