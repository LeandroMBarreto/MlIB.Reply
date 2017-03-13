using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MlIB.Reply.Tests.Unit.Stubs
{
    public class FunctionMethods
    {
        internal static Exception GetSomething()
        {
            return new Exception("some logged exception or something");
        }

        internal static int TryQuerySomething()
        {
            throw new InvalidOperationException("Pretend this is an invalid operation... Well, it is...");
        }

        internal static bool Authenticate(string username, int password)
        {
            if (username == "Christ"
                || username == "LeandroMBarreto")
                if (password == 777)
                    return true; //Amem

            return false;
        }
    }
}
