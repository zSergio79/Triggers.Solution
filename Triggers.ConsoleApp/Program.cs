namespace Triggers.ConsoleApp
{
    using Triggers;
    using Triggers.Conditions;

    internal class Program
    {
        static object lockObject = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!".WithTime());

            int currentY = 1;

            Timer timer = new(ShowTime, null, 0, 1000);

            DateTime nowPlus10sek = DateTime.Now.AddSeconds(13);
            DateTime nowPlus20sek = DateTime.Now.AddSeconds(25);

            //IConditionTrigger trigger = new ConditionTrigger(isStart: false)
            //    .And(() => DateTime.Now >= nowPlus10sek)
            //    .And(() => DateTime.Now <= nowPlus20sek);

            ITrigger trigger = new DateTimePeriodTrigger(nowPlus10sek, nowPlus20sek, period:20);

            //trigger.Or(() => DateTime.Now.DayOfWeek == DayOfWeek.Friday);

            trigger.TriggerStateChange += (o, e) =>
            {
                var message = e.State switch
                {
                    TriggerState.On => "TRIGGER IS On!!!!",
                    TriggerState.Off => "trigger is off....",
                    _ => "what is it?"
                };
                
                var t = o as ITrigger;
                if (t != null)
                {
                    if (t.State == TriggerState.On)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                }
                lock (lockObject)
                {
                    Console.SetCursorPosition(0, currentY++);
                    Console.WriteLine(message.WithTime());
                    Console.ResetColor();
                }
            };

            trigger.StartListening();

            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static void ShowTime(object? state)
        {
            lock (lockObject)
            {
                var oldPosition = Console.GetCursorPosition();
                Console.SetCursorPosition(Console.WindowWidth - 12, Console.WindowTop);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{DateTime.Now:HH:mm:ss}");
                Console.ResetColor();
                Console.SetCursorPosition(oldPosition.Left, oldPosition.Top);
            }
        }

    }

    public static class StringExtensions
    {
        public static string WithTime(this string message) => $"{DateTime.Now:HH:mm:ss.ffff} - {message}";
    }
}
