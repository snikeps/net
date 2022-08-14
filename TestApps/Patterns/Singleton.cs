namespace Patterns
{

    // no thread safe
    public class Singleton
    {
        private Singleton() { }

        public static Singleton Instance { get; } = new Singleton();
    }
}