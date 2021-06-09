using System;
using System.Text;

namespace Service.Common.RandomEx
{
    public static class RandomExtension
    {
        private static string Seed = "1234567890qwertyuiopasdfghjklzxcvbnm";

        public static string NextString(this Random rand, int size)
        {
            int seedLength = Seed.Length;
            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                strBuilder.Append(Seed[rand.Next(0, seedLength - 1)]);
            }

            return strBuilder.ToString();
        }
    }
}
