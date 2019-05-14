using System;
using System.Collections.Generic;
using System.Threading;
using lab03.CriticalSection;

namespace lab03.PIIntegration
{
    class ThreadIntegration
    {
        private const int THREADS = 8;

        private static double _pi = 0;

        private readonly int _iterationNumber;
        private readonly int _timeout;
        private readonly CSType _csType;
        private readonly ICriticalSection _cs;

        public ThreadIntegration(int iterationNumber, int timeout, int Сount, CSType csType)
        {
            _iterationNumber = iterationNumber;
            _timeout = timeout;
            _csType = csType;
            _cs = new AutoResetEventCS();
            _cs.SetSpinCount(Сount);
        }

        public double Integrate()
        {
            _pi = 0;
            Action enterToCS = () => _cs.Enter();
            void leaveCS() => _cs.Leave();
            if (_csType == CSType.TryEnter)
            {
                enterToCS = () => { while (!_cs.TryEnter(_timeout)) { } };
            }

            BeginIntegrate(_iterationNumber, enterToCS, leaveCS);

            return _pi;
        }

        private void BeginIntegrate(int IterationNumber, Action EnterToCS, Action LeaveCS)
        {
            var workers = new List<Thread>();
            int iterationNumberPerThread = IterationNumber / THREADS;
            double step = 1.0 / IterationNumber;

            for (int i = 0; i < THREADS; i++)
            {
                var newThread = new Thread(IntegratePI);
                newThread.Start(new IntegrationRules(i * iterationNumberPerThread, (i + 1) * iterationNumberPerThread, step, EnterToCS, LeaveCS));

                workers.Add(newThread);
            }

            foreach (Thread worker in workers)
            {
                worker.Join();
            }
        }

        private static void IntegratePI(object integrationRules)
        {
            var integrationRulesObj = (IntegrationRules)integrationRules;
            for (long i = integrationRulesObj._left; i < integrationRulesObj._right; i++)
            {
                double x = (i + 0.5) * integrationRulesObj._step;
                double sum = 4.0 / (1.0 + x * x);

                integrationRulesObj._enter();
                _pi += sum * integrationRulesObj._step;
                integrationRulesObj._leave();
            }
        }
    }
}
