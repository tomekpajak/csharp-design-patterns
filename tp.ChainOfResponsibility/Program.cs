using System;

namespace tp.ChainOfResponsibility
{
    //helper
    class RandomBool
    {
        public static bool Get()
        {
            Random r = new Random();
            return r.NextDouble() >= 0.5;
        }
    }
    //generic
    interface IHandler<T>
    {
        void HandleRequest(T request);
        IHandler<T> SetNextHandler(IHandler<T> handler);
    }
    abstract class Handler<T> : IHandler<T>
    {
        private IHandler<T> next;
        public virtual void HandleRequest(T request)
        {
            if (next != null)
            {
                next.HandleRequest(request);
            }
        }
        public IHandler<T> SetNextHandler(IHandler<T> handler)
        {
            next = handler;
            return next;
        }
    }

    //case of holiday form
    interface IHolidayFormRequest
    {
        void SetAcceptByReplacingPerson();
        void SetAcceptByManager();
        void SetAcceptByHR();
        bool IsHolidayFormAccepted();
    }
    class HolidayFormRequest : IHolidayFormRequest
    {
        public bool acceptedByReplacingPerson = false;
        public bool acceptedByManager = false;
        public bool acceptedByHR = false;
        public bool IsHolidayFormAccepted() => acceptedByReplacingPerson && acceptedByManager && acceptedByHR;
        public void SetAcceptByHR() => acceptedByHR = true;
        public void SetAcceptByManager() => acceptedByManager = true;
        public void SetAcceptByReplacingPerson() => acceptedByReplacingPerson = true;
    }
    class ReplacingPersonHandler : Handler<IHolidayFormRequest>
    {
        public override void HandleRequest(IHolidayFormRequest request)
        {
            if (RandomBool.Get())
            {
                Console.WriteLine("ReplacingPerson: Yes, of course!");
                request.SetAcceptByReplacingPerson();
                base.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("ReplacingPerson: Sorry Man... I can not replace you then...");
            }
        }
    }
    class ManagerHandler : Handler<IHolidayFormRequest>
    {
        public override void HandleRequest(IHolidayFormRequest request)
        {
            if (RandomBool.Get())
            {
                Console.WriteLine("Manager: Yes, I'm accepting.");
                request.SetAcceptByManager();
                base.HandleRequest(request);
            }   
            else
            {
                Console.WriteLine("Manager: Sorry... I can not accept your request because we have a lot to work in...");
            }
        }
    }
    class HRHandler : Handler<IHolidayFormRequest>
    {
        public override void HandleRequest(IHolidayFormRequest request)
        {
            if (RandomBool.Get())
            {
                Console.WriteLine("HR: Yes, we are accepting.");
                request.SetAcceptByHR();
                base.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("HR: Sorry, you have already used up your entire period for holiday.");
            }   
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var replacingPerson = new ReplacingPersonHandler();
            var manager = new ManagerHandler();
            var HR = new HRHandler();

            replacingPerson.SetNextHandler(manager)
                           .SetNextHandler(HR);
            
            var holidayForm = new HolidayFormRequest();

            Console.WriteLine("Can I go to holiday?");

            replacingPerson.HandleRequest(holidayForm);

            Console.WriteLine(holidayForm.IsHolidayFormAccepted() ? "yeaah!!!" : ";-(");
        }
    }
}
