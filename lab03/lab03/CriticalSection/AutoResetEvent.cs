using System;
using System.Threading;

namespace lab03.CriticalSection
{
    class AutoResetEventCS : ICriticalSection, IDisposable
    {
        private int _count = 1;
        private readonly AutoResetEvent _waitHandler = new AutoResetEvent(true);

        public void Enter()
        {
            bool success = false;
            while (!success)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (_waitHandler.WaitOne(10))
                    {
                        return;
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void Leave()
        {
            _waitHandler.Set();
        }

        public void SetSpinCount(int count)
        {
            _count = count;
        }

        public bool TryEnter(int timeout)
        {
            var start = DateTime.UtcNow;
            var success = false;
            while (start.AddMilliseconds(timeout) > DateTime.UtcNow)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (_waitHandler.WaitOne(10))
                    {
                        return !success;
                    }
                    if (start.AddMilliseconds(timeout) <= DateTime.UtcNow)
                    {
                        return success;
                    }                    
                }
                Thread.Sleep(10);
            }
            return success;
        }

        public void Dispose()
        {
            _waitHandler.Dispose();
        }
    }
}
