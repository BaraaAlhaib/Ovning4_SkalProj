
namespace Ovning4_SkalProj
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Välkommen till huvudmenyn!");
                Console.WriteLine("1. Hur fungerar stacken och heapen?");
                Console.WriteLine("2. Övning 1: ExamineList()");
                Console.WriteLine("3. Övning 2: ExamineQueue()");
                Console.WriteLine("4. Övning 3: ExamineStack()");
                Console.WriteLine("5. Övning 4: CheckParenthesis()");
                Console.WriteLine("0. Avsluta programmet");
                Console.WriteLine("Ange ett nummer för att välja ett alternativ:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Felaktig input. Var god ange en siffra.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        running = false;
                        Console.WriteLine("Programmet avslutas.");
                        break;
                    case 1:
                        Person person1 = new Person();
                        person1.Name = "John";
                        person1.Age = 25;

                        Person person2 = new Person();
                        person2.Name = "Baraa";
                        person2.Age = 30;

                        LäggTillPerson(person1);

                        LäggTillPerson(person2);
                        Console.WriteLine("___________");

                        break;
                    case 2:
                        ExamineList();
                        Console.WriteLine("___________");
                        break;
                    case 3:
                        ExamineQueue();
                        Console.WriteLine("___________");
                        break;
                    case 4:
                        ReverseText();
                        Console.WriteLine("___________");
                        break;
                    case 5:
                        Console.Write("Ange en sträng för att kontrollera om den är välformad: ");
                        string input = Console.ReadLine();
                        bool result = CheckParentheses(input);
                        if (result)
                            Console.WriteLine("Strängen är välformad.");
                        else
                            Console.WriteLine("Strängen är inte välformad.");
                        Console.WriteLine("___________");
                        break;
                    default:
                        Console.WriteLine("Felaktigt input: Skriva mellan 1 till 4");
                        break;
                }
            }
        }

        public static void LäggTillPerson(Person person)
        {
            Console.WriteLine($"Namn: {person.Name}, Ålder: {person.Age}");
        }

        public static void ExamineList()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Initial Capacity: " + numbers.Capacity);

            for (int i = 0; i < 16; i++)
            {
                numbers.Add(i);
                Console.WriteLine($"Count: {numbers.Count}, Capacity: {numbers.Capacity}");
            }

            for (int i = 0; i < 5; i++)
            {
                numbers.RemoveAt(numbers.Count - 1);
                Console.WriteLine($"Count: {numbers.Count}, Capacity: {numbers.Capacity}");
            }
        }

        public static void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();

            Console.WriteLine("ICA öppnar, kön är tom.");

            queue.Enqueue("Kalle");
            Console.WriteLine("Kalle ställer sig i kön.");

            queue.Enqueue("Greta");
            Console.WriteLine("Greta ställer sig i kön.");

            Console.WriteLine($"{queue.Dequeue()} blir expedierad och lämnar kön.");

            queue.Enqueue("Stina");
            Console.WriteLine("Stina ställer sig i kön.");

            Console.WriteLine($"{queue.Dequeue()} blir expedierad och lämnar kön.");

            queue.Enqueue("Olle");
            Console.WriteLine("Olle ställer sig i kön.");

            while (queue.Count > 0)
            {
                Console.WriteLine($"{queue.Dequeue()} blir expedierad och lämnar kön.");
            }

            Console.WriteLine("Kön är nu tom igen.");
        }

        public static void ReverseText()
        {
            Console.Write("Ange en textsträng att vända: ");
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                stack.Push(ch);
            }

            Console.Write("Den omvända textsträngen är: ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        public static bool CheckParentheses(string input)
        {
            Stack<char> stack = new Stack<char>();

            Dictionary<char, char> parenthesesPairs = new Dictionary<char, char>()
            {
                {')', '('},
                {'}', '{'},
                {']', '['}
            };

            foreach (char c in input)
            {
                if (parenthesesPairs.ContainsValue(c))
                {
                    stack.Push(c);
                }
                else if (parenthesesPairs.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Peek() != parenthesesPairs[c])
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
    }
}
