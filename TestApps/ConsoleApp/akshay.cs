using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
namespace ReaderWriterLockSlim_class
{
    class akshay
    {
        static ReaderWriterLockSlim rw = new ReaderWriterLockSlim();
        static List<int> items = new List<int>();
        static Random rand = new Random();
        static Stopwatch sw = new Stopwatch();

        //static void Main()
        //{
        //    //new Thread(Read).Start();
        //    //new Thread(Read).Start();
        //    new Thread(Read).Start();
        //    new Thread(Write).Start("A");
        //    new Thread(Write).Start("B");
        //    Console.Read();
        //}
        //static void Read()
        //{
        //    while (true)
        //    {
        //        rw.EnterReadLock();
        //        foreach (int i in items) Thread.Sleep(500);
        //        rw.ExitReadLock();
        //    }
        //}
        //static void Write(object threadID)
        //{
        //    while (true)
        //    {
        //        sw.Stop();
        //        var msec = sw.ElapsedMilliseconds;
        //        sw.Start();
        //        int newNumber = GetRandNum(50);
        //        rw.EnterWriteLock();
        //        items.Add(newNumber);
        //        rw.ExitWriteLock();
        //        Console.WriteLine("Thread " + threadID + " added " + newNumber + $". Milliseconds = {msec}");
        //        Thread.Sleep(500);
        //    }
        //}
        //static int GetRandNum(int max)
        //{
        //    lock (rand)
        //        return rand.Next(max);
        //}
    }
}