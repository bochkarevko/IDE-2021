using System;
using System.Text;

namespace Tests
{
    public class PascalGen
    {
        private static readonly Random Rand = new();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_";
        private static readonly StringBuilder Builder = new();

        public static string Gen(int size)
        {
            Builder.Clear();
            for (var i = 0; i < size; ++i)
            {
                switch (Rand.Next(0, 4))
                {
                    case 0:
                        GenNumber();
                        Builder.Append(' ');
                        break;
                    case 1:
                        GenComment();
                        Builder.Append(' ');
                        break;
                    case 2:
                        GenIdentifier();
                        Builder.Append(' ');
                        break;
                    case 3:
                        GenCharString();
                        Builder.Append(' ');
                        break;
                    default:
                        GenNumber();
                        Builder.Append(' ');
                        break;
                }
            }

            return Builder.ToString();
        }

        private static void AddHex()
        {
            Builder.Append('$');
            var size = Rand.Next(1, 10);
            for (var i = 0; i < size; ++i)
            {
                var toAdd = Rand.Next(0, 16);
                if (toAdd > 9)
                {
                    Builder.Append(Chars[Rand.Next(0, 6)]);
                }
                else
                {
                    Builder.Append(toAdd);
                }
            }
        }

        private static void AddDigitSeq(int bound)
        {
            var size = Rand.Next(1, 10);
            for (var i = 0; i < size; ++i)
            {
                Builder.Append(Rand.Next(0, bound));
            }
        }

        private static void AddRealPart()
        {
            Builder.Append('.');
            AddDigitSeq(10);
        }

        private static void AddExponent()
        {
            Builder.Append('E');
            AddSign();
            AddDigitSeq(10);
        }

        private static void AddOctal()
        {
            Builder.Append('$');
            AddDigitSeq(8);
        }

        private static void AddBin()
        {
            Builder.Append('%');
            AddDigitSeq(2);
        }

        private static void AddSign()
        {
            if (Rand.Next(0, 2) > 0)
            {
                Builder.Append('+');
            }
            else
            {
                Builder.Append('-');
            }
        }

        private static void AddReal()
        {
            AddSign();
            AddDigitSeq(10);
            if (Rand.Next(0, 2) > 0)
            {
                AddRealPart();
            }
            if (Rand.Next(0, 2) > 0)
            {
                AddExponent();
            }
        }
        
        private static void AddInt()
        {
            AddDigitSeq(10);
        }
        
        private static void GenNumber()
        {
            var type = Rand.Next(0, 5);
            switch (type)
            {
                case 0:
                    AddInt();
                    break;
                case 1:
                    AddReal();
                    break;
                case 2:
                    AddHex();
                    break;
                case 3:
                    AddBin();
                    break;
                case 4:
                    AddOctal();
                    break;
                default:
                    AddInt();
                    break;
                
            }
        }
        

        private static void GenIdentifier()
        {
            Builder.Append(Chars[Rand.Next(0, Chars.Length - 1)]);
            var size = Rand.Next(1, 10);
            for (var i = 0; i < size; ++i)
            {
                Builder.Append(Chars[Rand.Next(0, Chars.Length)]);
            }
        }
        
        private static void GenComment(int depth = 0)
        {
            if (depth > 2 || (depth > 0 && Rand.Next(0, 2) == 0))
            {
                return;
            }

            var which = Rand.Next(0, 2);
            if (which > 0)
            {
                Builder.Append("(*");
            }
            else
            {
                Builder.Append('{');
            }
            Builder.Append(" some text ");
            GenComment(depth + 1);
            Builder.Append(" more text ");
            if (which > 0)
            {
                Builder.Append("*)");
            }
            else
            {
                Builder.Append('}');
            }
        }

        private static void GenCharString()
        {
            var size = Rand.Next(1, 15);
            Builder.Append('\'');
            for (var i = 0; i < size; ++i)
            {
                Builder.Append(Chars[Rand.Next(0, Chars.Length)]);
            }
            Builder.Append('\'');
        }
    }
}