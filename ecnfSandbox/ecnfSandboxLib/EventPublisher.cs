using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecnfSandboxLib
{
    public class EventPublisher
    {
        public string _aSentence;

        //delegate/event definition
        public delegate void PublisherEvent(EventPublisher sender, StringEventArgs argument);
        public event PublisherEvent eventSent;

        public EventPublisher()
        {
            _aSentence = "I am a broadcast";
        }

        /// <summary>
        /// wenn ein oder mehrere Eventhandler registriert (via +=),
        /// dann führt eventSent(...) alle aus.
        /// </summary>
        public void Publish()
        {
            if (eventSent == null)
            {
                Console.WriteLine("NullReferenceException: no MethodReferences for eventSent :(");
            }
            eventSent(this, new StringEventArgs("and customly defined event!"));
        }

        public void SaySomething(EventPublisher sender, StringEventArgs args)
        {
            Console.WriteLine("I'm wondering what will happen.");
        }


        /********************* Predefined Event API **************************/

        //Note: base class "EventArgs" doesn't provide constructor with parameters
        public event EventHandler<StringEventArgs> ApiEvent;

        public void PublishApiEvent()
        {
            if (ApiEvent == null)
            {
                Console.WriteLine("Oops, ApiEvent has no registered EventHandlerMethod(s)");
            }
            ApiEvent(this, new StringEventArgs("and used the EventApi to save 'public delegate void..."));
        }
    }
}
