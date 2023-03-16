using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class RandomExtension
    {
        private static readonly Random Random = new();
        
        public static T GetRandom<T>(this IList<T> list)
        {
            if (list.Count == 0)
                throw new InvalidOperationException("The source sequence is empty.");

            int randomIndex = Random.Next(0, list.Count);
            
            return list.ElementAt(randomIndex);
        }
    }
}