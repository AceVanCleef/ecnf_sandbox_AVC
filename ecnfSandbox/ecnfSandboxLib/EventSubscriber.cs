using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    public class EventSubscriber
    {



        public void ReceiveEvent(EventPublisher sender, StringEventArgs args)
        {
            Console.WriteLine($"{sender._aSentence} {args.V}");
        }

        public void IEatEventsTwo(EventPublisher sender, StringEventArgs args)
        {
            Console.WriteLine($"{sender._aSentence} and consumed by a 2nd Eventhandler.");
        }

    }
}
