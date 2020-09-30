using System;
using SortableDemo.Core;

namespace SortableDemo.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SortableArrayList myPupilList = new SortableArrayList();
            Pupil p1 = new Pupil();
            p1.LastName = "Maier";
            p1.FirstName = "Franz";
            p1.BirthDate = new DateTime(1993, 3, 30);
            Pupil p2 = new Pupil();
            p2.LastName = "Allinger";
            p2.FirstName = "Franziska";
            p2.BirthDate = new DateTime(1990, 5, 6);
            Pupil p3 = new Pupil();
            p3.LastName = "Ehrmann";
            p3.FirstName = "Heide";
            p3.BirthDate = new DateTime(1920, 8, 8);

            myPupilList.Add(p1);
            myPupilList.Add(p2);
            myPupilList.Add(p3);

            Console.WriteLine("===========Schüler Unsortiert=======================");
            for (int i = 0; i < myPupilList.Count(); i++)
            {
                Console.WriteLine($"{(myPupilList[i] as Pupil).FirstName} {(myPupilList[i] as Pupil).LastName}");
            }

            myPupilList.Sort();
            Console.WriteLine("===========Schüler Sortierte Ausgabe================");
            for (int i = 0; i < myPupilList.Count(); i++)
            {
                Console.WriteLine($"{(myPupilList[i] as Pupil).FirstName} {(myPupilList[i] as Pupil).LastName}");
            }
        }
    }
}