using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MlIB.Reply.Tests.Unit.Stubs
{
    class VoidMethods
    {
        internal static Exception EXCEPTION = new InvalidOperationException("ain't hear no song at all but buggy noises.");

        internal static void PlayStaticSound()
        {
            Console.WriteLine("Pretend this is a static sound.");
        }

        internal static void PlayInexistentSound()
        {
            Console.WriteLine("Pretend there is no song here. Well, there isn't.");

            throw EXCEPTION;
        }

        public virtual void PlayCuteSong()
        {
            Console.WriteLine("Pretend this is a cute song.");
        }

        public virtual void PrintLyrics(string lyrics, decimal fontSize)
        {
            Console.WriteLine(
                string.Format("Pretend this is an awesome lyrics: [{0}] ^{1}", lyrics, fontSize)
                );
        }

    }
}
