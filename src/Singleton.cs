using System;

namespace Abstraction.src
{
    public sealed class Singleton
    {
        // Lazy ensures thread-safe, lazy initialization
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

        // Public accessor for the single instance
        public static Singleton Instance => _instance.Value;

        // Private constructor prevents external instantiation
        private Singleton()
        {
        }
    }

    public sealed class SingletonTwo
    {
        private static SingletonTwo? _instance = null;
        private static readonly Lock _lock = new();
        public static SingletonTwo Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new SingletonTwo();

                    }
                }
                return _instance;
            }
        }
        private SingletonTwo()
        {
        }
    }

    public sealed class SingletonThree
    {
        public static readonly SingletonThree Instance;
        static SingletonThree()
        {
            Instance = new SingletonThree();
        }
    }
}
