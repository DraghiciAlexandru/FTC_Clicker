using System;
using System.Collections.Generic;
using System.Text;

namespace FTC_Clicker.Exceptions
{
    public class ClickerException : Exception
    {
        public ClickerException(string? message) : base(message)
        {

        }
    }
}
