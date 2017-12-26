using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
class Program
{
    static void Main(string[] args)
    {
        var accounts = new List<BankAccount>()
        {
            new BankAccount(){ ID = 1, Balance = 15},
            new BankAccount(){ ID = 1, Balance = 20},
            new BankAccount(){ ID = 1, Balance = 3},
            new BankAccount(){ ID = 1, Balance = 5},
        };

        var person = new Person("Pehso", 18, accounts);
        Console.WriteLine(person.GetBalance());

        //var accounts = new Dictionary<int, BankAccount>();
        //string input = string.Empty;

        //while ((input = Console.ReadLine()) != "End")
        //{
        //    var tokens = input.Split();
        //    var command = tokens[0];

        //    switch (command)
        //    {
        //        case "Create":
        //            Create(tokens, accounts);
        //            break;
        //        case "Deposit":
        //            Deposit(tokens, accounts);
        //            break;
        //        case "Withdraw":
        //            Withdraw(tokens, accounts);
        //            break;
        //        case "Print":
        //            Print(tokens, accounts);
        //            break;
        //    }
        //}
    }

    private static void Create(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var account = new BankAccount();
            account.ID = id;
            accounts.Add(id, account);
        }
    }
    private static void Deposit(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);
        var amount = double.Parse(args[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Deposit(amount);
        }
    }
    private static void Withdraw(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);
        var amount = double.Parse(args[2]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else if (accounts[id].Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            accounts[id].Withdraw(amount);
        }
    }
    private static void Print(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);

        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[id]);
        }
    }
}
