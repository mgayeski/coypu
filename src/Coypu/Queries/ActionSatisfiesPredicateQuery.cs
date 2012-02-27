using System;
using Coypu.Actions;
using Coypu.Predicates;

namespace Coypu.Queries
{
    internal class ActionSatisfiesPredicateQuery : Query<bool>
    {
        private readonly DriverAction tryThis;
        private readonly Predicate until;
        private readonly TimeSpan waitBeforeRetry;

        public TimeSpan Timeout { get; private set; }

        internal ActionSatisfiesPredicateQuery(DriverAction tryThis, Predicate until, TimeSpan waitBeforeRetry, TimeSpan overallTimeout)
        {
            this.tryThis = tryThis;
            this.until = until;
            this.waitBeforeRetry = waitBeforeRetry;
            Timeout = overallTimeout;
        }

        public void Run()
        {
            tryThis.Act();
            var outerTimeout = Configuration.Timeout;
            try
            {
                Configuration.Timeout = waitBeforeRetry;
                Result = until.Satisfied();
            }
            finally
            {
                Configuration.Timeout = outerTimeout;
            }
        }

        public object ExpectedResult
        {
            get { return true; }
        }

        public bool Result { get; private set; }
    }
}