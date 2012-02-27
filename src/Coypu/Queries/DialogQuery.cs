using System;

namespace Coypu.Queries
{
    internal class HasDialogQuery : Query<bool>
    {
        private readonly Driver driver;
        private readonly string text;
        public object ExpectedResult { get { return true; } }
        public bool Result { get; private set; }
        public TimeSpan Timeout { get; private set; }

        protected internal HasDialogQuery(Driver driver, string text, TimeSpan timeout)
        {
            Timeout = timeout;
            this.driver = driver;
            this.text = text;
        }

        public void Run()
        {
            Result = driver.HasDialog(text);
        }
    }

    internal class HasNoDialogQuery : Query<bool>
    {
        private readonly Driver driver;
        private readonly string text;
        public object ExpectedResult { get { return true; } }
        public bool Result { get; private set; }
        public TimeSpan Timeout { get; private set; }

        protected internal HasNoDialogQuery(Driver driver, string text, TimeSpan timeout)
        {
            Timeout = timeout;
            this.driver = driver;
            this.text = text;
        }

        public void Run()
        {
            Result = !driver.HasDialog(text);
        }
    }
}