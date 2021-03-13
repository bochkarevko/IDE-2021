using System;
using System.Linq;
using System.Text;

namespace Tests
{
    public class RandomExprGenerator
    {
        private static readonly Random Rand = new Random();
        private static readonly string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";

        StringBuilder builder = new();

        private void AddOp()
        {
            char op = '.';
            switch (Rand.Next(1, 4))
            {
                case 1:
                    op = '+';
                    break;
                case 2:
                    op = '-';
                    break;
                case 3:
                    op = '*';
                    break;
                case 4:
                    op = '/';
                    break;
            }

            builder.Append(op);
        }

        private static string RandomLiteralOrVariable()
        {
            if (Rand.Next(1, 2) != 2) return Rand.Next(1000).ToString();
            var length = Rand.Next(1, 7);
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[Rand.Next(s.Length)]).ToArray());
        }

        private void Gen(int size)
        {
            var inPar = Rand.Next(0, 2) > 0;
            ;
            if (inPar)
            {
                builder.Append('(');
            }

            int splitSize = Rand.Next(1, size - 1);
            if (splitSize <= 2)
            {
                builder.Append(RandomLiteralOrVariable());
            }
            else
            {
                Gen(splitSize - 1);
            }

            AddOp();
            if (size - splitSize == 1)
            {
                builder.Append(RandomLiteralOrVariable());
            }
            else
            {
                Gen(size - splitSize);
            }

            if (inPar)
            {
                builder.Append(')');
            }
        }


        public string RandomExpr(int size = 20)
        {
            builder.Clear();
            Gen(size);
            return builder.ToString();
        }
    }
}