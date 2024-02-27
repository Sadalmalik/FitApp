using UnityEngine;

namespace Sadalmelik.FitApp.Main
{
    public struct Interval
    {
        public float Min { get; set; }
        public float Max { get; set; }

        public float Length => Max - Min;

        public Interval(float min, float max)
        {
            Min = Mathf.Min(min, max);
            Max = Mathf.Max(min, max);
        }
        
        public static Interval operator +(Interval a, Interval b)
        {
            return new Interval(a.Min + b.Min, a.Max + b.Max);
        }
        
        public static Interval operator -(Interval a, Interval b)
        {
            return new Interval(a.Min - b.Max, a.Max - b.Min);
        }
        
        public static Interval operator *(Interval a, Interval b)
        {
            float k = a.Min * b.Min;
            float l = a.Min * b.Max;
            float m = a.Max * b.Min;
            float n = a.Max * b.Max;
            return new Interval(
                Mathf.Min(k, l, m, n),
                Mathf.Max(k, l, m, n));
        }
        
        public static Interval operator /(Interval a, Interval b)
        {
            float k = a.Min / b.Min;
            float l = a.Min / b.Max;
            float m = a.Max / b.Min;
            float n = a.Max / b.Max;
            return new Interval(
                Mathf.Min(k, l, m, n),
                Mathf.Max(k, l, m, n));
        }
    }
}