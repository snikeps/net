using System;

namespace DelegatesAndEvents
{
    public delegate void WorkPerformedHandler(int hours, WorkType workType);
    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

            del1(5, WorkType.Golf);
            del2(10, WorkType.GenerateReports);

            Console.Read();
        }

        static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPermormed1 called");
        }

        static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerformed2 called");
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
