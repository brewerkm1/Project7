namespace StudentRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> roster = new();

            Stack<List<Student>> rosterHistory = new();

            Dictionary<string, dynamic> menuActions = new();

            bool isRunning = true;

            menuActions["exit"] = new Action(() => { isRunning = false; });
            menuActions["print"] = new Action(() => { PrintRoster(roster); Console.WriteLine("Press Enter/Return to continue..."); Console.ReadLine(); });
            menuActions["add"] = new Action<string, string>((first, last) => {rosterHistory.Push(roster.ToList()); roster.Add(new Student(first, last)); });
            menuActions["delete"] = new Action<string, string>((first, last) => { rosterHistory.Push(roster.ToList()); roster.Remove(roster.Find(x => x.FirstName == first && x.LastName == last)); });
            menuActions["undo"] = new Action(() => rosterHistory.TryPop(out roster));

            while (isRunning) 
            {
                // Display a menu options
                Console.Clear();
                Console.WriteLine("Add [firstName] [lastName]");
                Console.WriteLine("Delete [firstName] [lastName]");
                Console.WriteLine("Grade");
                Console.WriteLine("Print");
                Console.WriteLine("Undo");
                Console.WriteLine("Exit");

                // Ask for menu option
                // Get menu option
                string[] inputs = Console.ReadLine().Split(" ");
                inputs[0] = inputs[0].ToLower();

                // Do menu option
                if (menuActions.ContainsKey(inputs[0]))
                {
                    if(inputs.Length == 1) 
                        menuActions[inputs[0]]();
                    if (inputs.Length == 3) 
                        menuActions[inputs[0]](inputs[1], inputs[2]);
                }
            }
        }

        static void PrintRoster(List<Student> roster) 
        {
            ConsoleColor oldbg, oldfg;
            oldbg = Console.BackgroundColor;
            oldfg = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (var item in roster)
            {
                Console.WriteLine(item.FullName);
            }
            Console.BackgroundColor = oldbg;
            Console.ForegroundColor = oldfg;
        }
    }
}