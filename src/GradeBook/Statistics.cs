using System;
//using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        //private double average;
        private double high;
        private double low;
        private char letter;
        private double sum;
        private double count;


        public Statistics()
        {
            this.high = double.MinValue;
            this.low = double.MaxValue;

            this.Sum = 0.0;
            this.Count = 0.0;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);

        }

        public double Average { get => this.Sum / this.Count; }
        public double High { get => high; set => high = value; }
        public double Low { get => low; set => low = value; }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }

            }
        }

        public double Sum { get => sum; set => sum = value; }
        public double Count { get => count; set => count = value; }
    
  
    }

}