using System;
using System.Collections.Generic;
using System.Text;

namespace CallerInfoAttributes
{
    internal class InfoProcesser
    {
        private readonly MessageLogger messageLogger = new MessageLogger();

        public void ProcessInfo()
        {

            //Calling Logger
            messageLogger.LogMessage("Something happened.");
        }

    }
}
