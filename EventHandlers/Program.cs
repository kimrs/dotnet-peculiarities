using System.Security.Cryptography.X509Certificates;

namespace EventHandlers;

public delegate void EventHandler(object? sender, EventArgs e);

internal class FooCounter
{
    private int _total = 0;
    public void Add()
    {
        _total++;
        if (_total % 2 == 0)
        {
            OnFoo(EventArgs.Empty);
        }
    }

    private void OnFoo(EventArgs e)
    {
        var handler = FooHappened;

        handler(this, e);
    }

    public event EventHandler<EventArgs> FooHappened;

}

class Program
{
    static void Main(string[] args)
    {
        var fooCounter = new FooCounter();
        fooCounter.FooHappened += (x, y) => { Console.WriteLine("Foo happened"); };
        var range = Enumerable.Range(0, 100);
        foreach (var integer in range)
        {
            fooCounter.Add();
        }
    }
}
