using System;

namespace lab03.PIIntegration
{
    public class IntegrationRules
    {
        public long _left;
        public long _right;
        public double _step;
        public Action _enter;
        public Action _leave;

        public IntegrationRules(long left, long right, double step, Action enter, Action leave)
        {
            _left = left;
            _right = right;
            _step = step;
            _enter = enter;
            _leave = leave;
        }
    }
}
