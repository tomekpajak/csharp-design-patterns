using System;
using System.Collections.Generic;
using System.Linq;

namespace tp.Command
{
    class BankAccountReceiver
    {
        public string AccountName { get; set; }
        private int balance = 0;
        public BankAccountReceiver(string accountName) => this.AccountName = accountName;
        public void Deposit(int amount) => balance += amount;

        public bool Withdraw(int amount)
        {
            bool result = false;
            if (balance - amount >= 0)
            {
                balance -= amount;
                result = true;
            }
            else
                Console.WriteLine("cannot be withdrawn");
            return result;
        }
        public override string ToString() => $"Account: {AccountName}\tCurrent balance: {balance}";
    }
    interface ICommand
    {
        void Execute();
        void Undo();
        bool Success { get; set; }
    }
    abstract class BankAccountCommand : ICommand
    {
        protected BankAccountReceiver account;
        protected int amount;
        public bool Success { get; set; }
        public BankAccountCommand(BankAccountReceiver account, int amount)
        {
            this.account = account;
            this.amount = amount;
        }
        public abstract void Execute();
        public abstract void Undo();
    }
    class DepositCommand : BankAccountCommand
    {
        public DepositCommand(BankAccountReceiver account, int amount)
            : base(account, amount) => Success = true;
        public override void Execute() => account.Deposit(amount);

        public override void Undo()
        {
            if (Success) 
                account.Withdraw(amount);
        }
    }
    class WithdrawCommand : BankAccountCommand
    {
        public WithdrawCommand(BankAccountReceiver account, int amount)
            : base(account, amount)
        {
        }
        public override void Execute() => Success = account.Withdraw(amount);

        public override void Undo()
        {
            if (Success)
                account.Deposit(amount);
        }
    }
    //Composite BankAccountCommand
    class BankAccountTransferCommand : ICommand
    { 
        private BankAccountReceiver from, to;
        private int amount;
        private List<BankAccountCommand> commands = new List<BankAccountCommand>();
        public BankAccountTransferCommand(BankAccountReceiver from, BankAccountReceiver to, int amount)
        {
            this.from = from;
            this.to = to;
            this.amount = amount;
            commands.Add(new WithdrawCommand(from, amount));
            commands.Add(new DepositCommand(to, amount));
        }
        public void Execute()
        {
            var executedCommands = new Stack<ICommand>();
            foreach (var bac in commands)
            {
                bac.Execute();
                if (bac.Success)
                {
                    executedCommands.Push(bac);
                }
                else
                {
                    Undo(executedCommands);
                    break;
                }
            }
        }
        private void Undo(Stack<ICommand> commands) 
        {            
            foreach (var cmd in commands)
                cmd.Undo();
        }
        public void Undo()
        {
            foreach (var bac in ((IEnumerable<BankAccountCommand>)commands).Reverse())
                if (bac.Success)
                    bac.Undo();
        }
        public bool Success
        {
            get => commands.All(bac => bac.Success == true);
            set => commands.ForEach(bac => bac.Success = value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var accountA = new BankAccountReceiver("A");
            var accountB = new BankAccountReceiver("B");

            Console.WriteLine("### Operations on accountA only ###");
            
            var commands = new List<ICommand>()
            {
                new DepositCommand(accountA, 50),
                new DepositCommand(accountA, 100),
                new WithdrawCommand(accountA, 110),
                new WithdrawCommand(accountA, 50)
            };

            Console.WriteLine("### execute... ###");

            foreach (var cmd in commands)
            {
                cmd.Execute();
                Console.WriteLine(accountA);
            }

            Console.WriteLine("### undo... ###");

            foreach (var cmd in Enumerable.Reverse(commands))
            {
                cmd.Undo();
                Console.WriteLine(accountA);
            }

            Console.WriteLine("### Transfer from accountA to accountB ###");

            commands = new List<ICommand>()
            {
                new DepositCommand(accountA, 50),
                new DepositCommand(accountB, 100),

                new BankAccountTransferCommand(accountA, accountB, 50)
            };

            Console.WriteLine("### execute... ###");

            foreach (var cmd in commands)
            {
                cmd.Execute();
                Console.WriteLine(accountA);
                Console.WriteLine(accountB);
            }

            Console.WriteLine("### undo... ###");

            foreach (var cmd in Enumerable.Reverse(commands))
            {
                cmd.Undo();
                Console.WriteLine(accountA);
                Console.WriteLine(accountB);
            }

        }
    }
}
