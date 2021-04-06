﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntroLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
            ShowLargeFileWithoutLinq(path);
            Console.WriteLine("*********");
            ShowLargeFileWithLinq(path);
        }

        private static void ShowLargeFileWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,20:N0}");
            }
        }

        private static void ShowLargeFileWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            //foreach(FileInfo file in files)
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i]; 
                Console.WriteLine($"{file.Name, -20} : {file.Length, 20:N0}");
            }
        }

        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
