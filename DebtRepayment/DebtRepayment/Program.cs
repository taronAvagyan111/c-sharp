using System;
using System.Collections.Generic;

namespace DebtRepayment
{
    internal class Program
    {
        private static DebtService debtService = new DebtService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Debt Repayment Planner");
                Console.WriteLine("1. Add Debt");
                Console.WriteLine("2. View Debts");
                Console.WriteLine("3. View Repayment Plan");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddDebt();
                        break;
                    case "2":
                        ViewDebts();
                        break;
                    case "3":
                        ViewRepaymentPlan();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddDebt()
        {
            Console.Write("Enter debt name: ");
            string name = Console.ReadLine();

            Console.Write("Enter balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            Console.Write("Enter interest rate (annual): ");
            decimal interestRate = decimal.Parse(Console.ReadLine());

            Console.Write("Enter monthly payment: ");
            decimal monthlyPayment = decimal.Parse(Console.ReadLine());

            var debt = new Debt
            {
                Name = name,
                Balance = balance,
                InterestRate = interestRate,
                MonthlyPayment = monthlyPayment
            };

            debtService.AddDebt(debt);

            Console.WriteLine("Debt added successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ViewDebts()
        {
            Console.WriteLine("Current Debts:");
            foreach (var debt in debtService.GetDebts())
            {
                Console.WriteLine($"Name: {debt.Name}, Balance: {debt.Balance}, Interest Rate: {debt.InterestRate}%, Monthly Payment: {debt.MonthlyPayment}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ViewRepaymentPlan()
        {
            Console.WriteLine("Repayment Plan:");
            foreach (var plan in debtService.GetRepaymentPlan())
            {
                Console.WriteLine($"Date: {plan.Date.ToShortDateString()}, Payment: {plan.Payment}, Principal: {plan.Principal}, Interest: {plan.Interest}, Remaining Balance: {plan.RemainingBalance}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
