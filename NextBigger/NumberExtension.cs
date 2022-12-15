namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number; return -1 if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer; return -1 if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int NextBiggerThan(int number)
        {
            if (number == int.MaxValue)
            {
                return -1;
            }
            else if (number < 0)
            {
                throw new ArgumentException($"Value of {nameof(number)} cannot be less zero.", nameof(number));
            }

            int a = number % 10;
            int rests = 0;
            for (double i = 0; number > 0; i++)
            {
                int b = number % 10;
                if (b < a)
                {
                    break;
                }
                else
                {
                    rests += b * (int)Math.Pow(10, i);
                    a = b;
                    number /= 10;
                }
            }

            if (number == 0)
            {
                return -1;
            }
            else
            {
                var itemToChange = number % 10;
                int itemForChange = NumberExtensionHelpers.GetBiggerThan(itemToChange, rests);
                number = ((number / 10) * 10) + itemForChange;
                rests = NumberExtensionHelpers.SortNumbers(NumberExtensionHelpers.SwapDigitToLess(itemToChange, rests), -1);

                return NumberExtensionHelpers.AppendNumbers(number, rests);
            }
        }
    }
}
