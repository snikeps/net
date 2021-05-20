using System;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1(5, WorkType.Golf);
            //del2(10, WorkType.GenerateReports);
            //DoWork(del2);

            del1 += del2 + del3;

            int finalHours = del1(10, WorkType.GenerateReports);
            Console.WriteLine($"Final hours are: {finalHours}");

            Console.Read();
        }

        static void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.GoToMeetings);
        }

        static int WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPermormed1 called, hours = {hours}, WorkType = {workType}");

            return hours + 1;
        }

        static int WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed2 called, hours = {hours}, WorkType = {workType}");

            return hours + 2;
        }

        static int WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed3 called, hours = {hours}, WorkType = {workType}");

            return hours + 3;
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
