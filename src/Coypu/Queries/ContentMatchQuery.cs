using System;
using System.Text.RegularExpressions;

namespace Coypu.Queries
{
    internal abstract class ContentMatchQuery : Query<bool>
    {
        private readonly Driver driver;
        private readonly DriverScope scope;
        private readonly Regex text;
        public abstract object ExpectedResult { get; }
        public bool Result { get; private set; }

        public TimeSpan Timeout
        {
            get { return scope.IndividualTimeout; }
        }

        protected ContentMatchQuery(Driver driver, DriverScope scope, Regex text)
        {
            this.driver = driver;
            this.scope = scope;
            this.text = text;
        }

        public void Run()
        {
            Result = driver.HasContentMatch(text, scope) == (bool) ExpectedResult;
        }
    }
}