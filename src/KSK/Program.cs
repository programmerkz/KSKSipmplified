using System;
using KSKSimplified.KSK.Models;


namespace KSKSimplified.KSK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KSK User class demonstration.");

            if (args.Length == 0)
            {
                Console.WriteLine("Supported params:");
                Console.WriteLine("\t--new <login> <password> - create user object with login and password parameters");
            }
            else if ((args.Length == 3) && (args[0] == "--new"))
            {
                User user_01 = null;

                try
                {
                    user_01 = new User(args[1], args[2]);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Can't create a user object with params: <login>={args[1]}, <passwprd>={2}");
                    Console.WriteLine(e);
                }

                if (user_01 != null)
                    Console.WriteLine($"A user object with params: <login>={args[1]}, <passwprd>={2} successfuly created!");
            }
        }
    }
}
