namespace NextBiggerTask
{
    internal static class NumberExtensionHelpers
    {
        public static int AppendNumbers(int number1, int number2)
        {
            while (number2 > 0)
            {
                number1 = (number1 * 10) + (number2 % 10);
                number2 /= 10;
            }

            return number1;
        }

        public static int SwapDigitToLess(int itemToChange, int number)
        {
            int rest = 0;
            while (number > 0)
            {
                int c = number % 10;
                if (c > itemToChange)
                {
                    number = ((number / 10) * 10) + itemToChange;
                    break;
                }

                rest = (rest * 10) + c;
                number /= 10;
            }

            while (rest > 0)
            {
                number = (number * 10) + (rest % 10);
                rest /= 10;
            }

            return number;
        }

        public static int GetBiggerThan(int itemToChange, int number)
        {
            int itemForChange = 0;
            var sortedRests = SortNumbers(number, -1);
            while (sortedRests > 0)
            {
                int c = sortedRests % 10;
                if (c > itemToChange)
                {
                    itemForChange = c;
                    break;
                }

                sortedRests /= 10;
            }

            return itemForChange;
        }

        public static int SortNumbers(int x, int v)
        {
            var input = x;
            int output = 0;
            bool sorted = true;
            if (x < 10)
            {
                return x;
            }

            while (sorted)
            {
                int mod = 1;
                sorted = false;

                while (input > 10)
                {
                    var digit1 = input % 10;
                    var digit2 = (input / 10) % 10;

                    if (digit1 != digit2 && Math.Sign(digit1 - digit2) != Math.Sign(v))
                    {
                        sorted = true;
                        input = ((input / 100) * mod * 100) + (output % mod) + (digit1 * mod * 10) + (digit2 * mod);
                        break;
                    }
                    else
                    {
                        output = (output % mod) + (digit2 * mod * 10) + (digit1 * mod);
                    }

                    input = input / 10;
                    mod *= 10;
                }
            }

            return output;
        }
    }
}
