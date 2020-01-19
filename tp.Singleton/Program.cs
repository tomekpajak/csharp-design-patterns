using System;

namespace tp.Singleton
{
    //Eager Initialization, Thread Safe (static constructor)
    sealed class Logger1
    {
        private static readonly Logger1 _instance = new Logger1();
        public static Logger1 Instance => _instance;
        static Logger1()
        {
        }
        private Logger1()
        {
        }
        public void Log(String message)
        {
            Console.WriteLine(message);
        }
    }

    //Lazy Initialization, Not Thread Safe
    sealed class Logger2
    {
        private static Logger2 _instance = null;
        public static Logger2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger2();
                }
                return _instance;
            }
        }
        private Logger2()
        {
        }
        public void Log(String message)
        {
            Console.WriteLine(message);
        }
    }

    //Lazy Initialization, Thread Safe
    sealed class Logger3
    {
        private static Logger3 _instance = null;
        private static readonly object lockObject = new Object();
        public static Logger3 Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger3();
                    }
                }
                return _instance;
            }
        }
        private Logger3()
        {
        }
        public void Log(String message)
        {
            Console.WriteLine(message);
        }
    }

    //Lazy Initialization, Thread Safe (uses LazyThreadSafetyMode.ExecutionAndPublication as the thread safety mode for the Lazy<Logger4>)
    sealed class Logger4
    {
        private static readonly Lazy<Logger4> _instance = new Lazy<Logger4>(() => new Logger4());
        public static Logger4 Instance => _instance.Value;
        private Logger4()
        {
        }
        public void Log(String message)
        {
            Console.WriteLine(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger1.Instance.Log("Logger1");
            Logger2.Instance.Log("Logger2");
            Logger3.Instance.Log("Logger3");
            Logger4.Instance.Log("Logger4");
        }
    }

 
}
