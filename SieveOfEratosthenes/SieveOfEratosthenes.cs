namespace SieveOfEratosthenes
{
    public class SieveOfEratosthenes
    {
        public List<int> runSieve(int maxNumber)
        {
            // N + 1 because 1 is not a prime number, and we want to go up to n.

            if (maxNumber <= 1)
            {
                Console.WriteLine("Number must be greater than 0");
                return null;
            }

            bool[] isPrime = new bool[maxNumber + 1];

            // Set all values in the array to true to prepare them for filtering using the Sieve of Eratosthenes.
            for (int i = 2; i <= maxNumber; i++)
            {
                isPrime[i] = true;
            }

            // Sieve of Eratosthenes algorithm. This filters out all non-prime numbers from the array. cuz prime * 2 equals a non prime.
            for (int i = 2; i * i <= maxNumber; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= maxNumber; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            // This is the list of prime numbers.
            Console.WriteLine("Prime numbers up to " + maxNumber + ":");
            List<int> primes = new List<int>();
            for (int i = 2; i <= maxNumber; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                    Console.Write(i + " ");
                }
            }

            return primes;
        }
    }
}