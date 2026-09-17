namespace Assignment_4._3
{
    internal class Program
    {
        #region Electric Bill Method
        static void CheckElectricBill()
        {
            int id;
            string name;
            float units;


            Console.WriteLine("Welcome to your electric company! Enter your information to check your bill!\n");

            Console.Write("Enter Your Customer Id: ");
            id = int.Parse(Console.ReadLine());

            Console.Write("Enter Your Name: ");
            name = Console.ReadLine();

            Console.Write("Enter the Amount of Units You Used: ");
            units = float.Parse(Console.ReadLine());

            ElectircBill bill = new ElectircBill(id, name, units);
            bill.StartBilling();
            Console.WriteLine("\n" + bill.ToString());

        }
        #endregion

        #region Frequency Check Method
        static int[] AssignArray(int size)
        {
            int[] array = new int[size];

            Console.WriteLine($"Input {size} elemets in the array:");

            for (int i = 0; i < array.Length; i++)
            {
                bool IsVal = false;
                int val = 0;
                while (!IsVal)
                {
                    Console.Write($"element - {i}: ");
                    IsVal = int.TryParse(Console.ReadLine(), out val);
                }

                array[i] = val;
            }

            return array;
        }

        static Dictionary<int, int> Frequency(int[] array)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();

            foreach (int val in array)
            {
                if (!temp.ContainsKey(val))
                {
                    temp.Add(val, 1);
                }
                else
                {
                    temp[val]++;
                }


            }

            return temp;
        }

        static void PrintResults(Dictionary<int, int> temp)
        {
            foreach (int x in temp.Keys)
            {
                Console.WriteLine($"{x} occurs {temp[x]} times");
            }
        }

        static void ArrayFrequency()
        {
            Console.Write("\n\nInput the number of the elements to be stored in the array: ");
            int assignSize = int.Parse(Console.ReadLine());
            int[] array = AssignArray(assignSize);
            Dictionary<int, int> FrequencyDictionary = Frequency(array);
            Console.WriteLine("Frequency of all elements of array:");
            PrintResults(FrequencyDictionary);

        } 
        #endregion

        static int UniqueElements(int[] array)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();

            if (array.Length == 0) return 0;

            foreach(int val in array)
            {
                if (!temp.ContainsKey(val)) temp.Add(val, 1);
                else temp[val]++;
            }
            

            int total = 0;

            foreach (int val in temp.Keys)
            {
                total = temp[val] == 1 ? val : total;
            }

            return total;
            
        }

        static void UniqueElements()
        {
            Console.Write("\n\nInput the number of the elements to be stored in the array: ");
            int size = int.Parse(Console.ReadLine());
            int[] array = AssignArray(size);
            Console.WriteLine($"The unique elements found in the array are: {UniqueElements(array)}");
        }

        static void Main(string[] args)
        {
            CheckElectricBill();
            ArrayFrequency();
            UniqueElements();
        }
    }
}
