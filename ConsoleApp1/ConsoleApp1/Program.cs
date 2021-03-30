using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            F8 d = new F8();
            d.tstart = DateTime.Now;
            d.provM();
            d.tfinish = DateTime.Now;
            d.TimePoisk();
            Console.ReadKey();
        }
         class F8
        {
            public DateTime tstart, tfinish;
            public byte[] p = new byte[9];
            public void provP()
            {
                bool b1, b2, b3;
                for (byte j1 = 1; j1 < 8; j1++)
                    for (byte j2 = (byte)(j1 + 1); j2 <= 8; j2++)
                    {
                        b1 = (p[j1] != p[j2]);
                        b2 = (p[j2] - p[j1]) != (j2 - j1);
                        b3 = (p[j1] + j1) != (p[j2] + j2);
                        if (b1 && b2 && b3)
                            p[0]++;
                    }
            }

            public bool provG()
            {
                bool b = false;
                for (int i = 1; i <= 8; i++)
                {
                    if ((i == p[i]) | ((i + p[i]) == 9))
                        b = true;
                    if (b)
                        break;
                }
                return b;
            }
            public void provM()
            {
                int count = 0;
                for (byte j1 = 1; j1 <= 8; j1++)
                {
                    p[1] = j1;
                    for (byte j2 = 1; j2 <= 8; j2++)
                    {
                        p[2] = j2;
                        for (byte j3 = 1; j3 <= 8; j3++)
                        {
                            p[3] = j3;
                            for (byte j4 = 1; j4 <= 8; j4++)
                            {
                                p[4] = j4;
                                for (byte j5 = 1; j5 <= 8; j5++)
                                {
                                    p[5] = j5;
                                    for (byte j6 = 1; j6 <= 8; j6++)
                                    {
                                        p[6] = j6;
                                        for (byte j7 = 1; j7 <= 8; j7++)
                                        {
                                            p[7] = j7;
                                            for (byte j8 = 1; j8 <= 8; j8++)
                                            {
                                                p[8] = j8;
                                                p[0] = 0;
                                                provP();
                                                if (p[0] == 28)
                                                {
                                                    bool b = provG();
                                                    b = false;
                                                    if (!b)
                                                    {
                                                        count++;
                                                        Console.Write("{0}): ", count);
                                                        for (int i = 1; i <= 8; i++)
                                                            Console.Write(" {0} ", p[i]);
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Всего расстановок - {0}", count);
            }
            public void TimePoisk()
            {
                int dt, ds, dm, dh;
                dt = tfinish.Hour * 3600 + tfinish.Minute * 60 + tfinish.Second - tstart.Hour * 3600 - tstart.Minute * 60 - tstart.Second;
                dh = dt / 3600;
                dm = (dt - dh * 3600) / 60;
                ds = (dt - dh * 3600 - dm * 60);
                if (dt < 60)
                    Console.WriteLine("Время поиска: секунд - {0}", ds);
                else if (dt < 3600)
                    Console.WriteLine("Время поиска: минут - {0], секунд - {1}", dm, ds);
                else
                    Console.WriteLine("Время поиска: часов - {0}, минут - {1}, секунл - {2}", dh, dm, ds);
            }
        }
    }
}
