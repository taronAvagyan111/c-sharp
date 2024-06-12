using DebtRepayment;
using System;
using System.Collections.Generic;
using System.Linq;

public class DebtService
{
    private List<Debt> _debts = new List<Debt>();

    public void AddDebt(Debt debt)
    {
        _debts.Add(debt);
    }

    public List<Debt> GetDebts()
    {
        return _debts;
    }

    public List<RepaymentPlan> GetRepaymentPlan()
    {
        List<RepaymentPlan> repaymentPlans = new List<RepaymentPlan>();

        foreach (var debt in _debts)
        {
            decimal remainingBalance = debt.Balance;
            DateTime currentDate = DateTime.Now;

            while (remainingBalance > 0)
            {
                decimal interest = remainingBalance * (debt.InterestRate / 100 / 12);
                decimal principal = debt.MonthlyPayment - interest;
                remainingBalance -= principal;
                if (remainingBalance < 0) remainingBalance = 0;

                repaymentPlans.Add(new RepaymentPlan
                {
                    Date = currentDate,
                    Payment = debt.MonthlyPayment,
                    Principal = principal,
                    Interest = interest,
                    RemainingBalance = remainingBalance
                });

                currentDate = currentDate.AddMonths(1);
            }
        }

        return repaymentPlans;
    }
}
