using System;
using System.Collections.Generic;
using System.Text;

namespace SortableDemo.Core
{
    public class Rational : IComparable
    {
        private int _numerator;  // Zähler
        private int _denominator; // Nenner

        public Rational(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Nenner des Bruchs.
        /// </summary>
        public int Denominator
        {
            get { return _denominator; }
            set
            {
                _denominator = value;
                normalize();
            }
        }

        /// <summary>
        /// Zähler
        /// </summary>
        public int Numerator
        {
            get { return _numerator; }
            set
            {
                _numerator = value;
                normalize();
            }
        }

        /// <summary>
        /// Liefert den Zahlenwert des Bruchs. Ist der Nenner gleich 0
        /// wird als Zahlenwert double.MaxValue mit dem richtigen Vorzeichen
        /// zurückgegeben
        /// </summary>
        public double DoubleValue
        {
            get
            {
                if (_denominator == 0)  // Fehlerfall
                {
                    return double.MaxValue * (_numerator / Math.Abs(_numerator));
                }
                else
                {
                    return ((double)_numerator) / _denominator;
                }
            }
        }

        /// <summary>
        /// Bruch so weit es geht kürzen
        /// </summary>
        private void normalize()
        {
            if (_denominator == 0)
            {
                return;
            }
            int teiler = ggt(_numerator, _denominator);
            if (teiler != 1)
            {
                _numerator /= teiler;
                _denominator /= teiler;
            }
        }

        /// <summary>
        /// GGT von a und b nicht rekursiv gelöst.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>ggt(a,b)</returns>
        private static int ggt(int a, int b)
        {
            int x = Math.Abs(a);
            int y = Math.Abs(b);
            // wenn a < b x und y umtauschen, sodass immer x >= y gilt
            if (x < y)
            {
                x = Math.Abs(b);
                y = Math.Abs(a);
            }
            int c = 1;  // ggt(a,b) == ggt(b, Rest(a,b)) wenn a >= b
            while (c != 0)
            {
                c = x % y;
                x = y;
                y = c;
            }
            return x;
        }

        public int CompareTo(object obj)
        {
            return this.DoubleValue.CompareTo((obj as Rational).DoubleValue);
        }
    }
}