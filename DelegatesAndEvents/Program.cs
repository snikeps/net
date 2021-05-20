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
            WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);

            //del1(5, WorkType.Golf);
            //del2(10, WorkType.GenerateReports);
            //DoWork(del2);

            del1 += del2;
            del1 += del3; // or del1 += del2 + del3;

            del1(10, WorkType.GenerateReports);

            Console.Read();
        }

        static void DoWork(WorkPerformedHandler del)
        {
            del(5, WorkType.GoToMeetings);
        }

        static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPermormed1 called, hours = {hours}, WorkType = {workType}");
        }

        static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed2 called, hours = {hours}, WorkType = {workType}");
        }

        static void WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine($"WorkPerformed3 called, hours = {hours}, WorkType = {workType}");
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
