namespace Ram;
class Program
{
    public static double GetTotalEMI(Loan[] loans)
    {
        double emiTotal = 0;
        foreach (var loan in loans)
        {
            emiTotal += (double)loan.GetEMI();
        }
        return emiTotal;
    }

 public static double GetTotalTax(Loan[] loans)
    {
        double taxTotal = 0;
        foreach (var loan in loans)
        {
            if (loan is ITaxable taxableLoan)
            {
                taxTotal += taxableLoan.GetTax();
            }
        }
        return taxTotal;
    }
     public static double GetTotaldiscount(Loan[] loans)
    {
        double Totaldisc = 0;
        foreach (var loan in loans)
        {
            if (loan is IDiscountable disc)
            {
                Totaldisc += disc.GetDiscount();
            }
        }
        return Totaldisc;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("test");
        Loan[] loans = new Loan[4];
        loans[0] = new PersonalLoan();
        loans[0].SetPrinciple(100000);
        loans[0].SetPeriod(9);
        loans[1] = new HomeLoan();
        loans[1].SetPrinciple(5000000);
        loans[1].SetPeriod(5);
         loans[2] = new PersonalLoan();
        loans[2].SetPrinciple(200000);
        loans[2].SetPeriod(7);
        loans[3] = new HomeLoan();
        loans[3].SetPrinciple(500000);
        loans[3].SetPeriod(2);

        foreach (var loan in loans)
        {
            Console.WriteLine("The loan amount is {0} and the period is {1}", loan.GetPrinciple(), loan.GetPeriod());
        }
         foreach (var loan in loans)
        {
           // Console.WriteLine("The loan amount is {0} and the period is {1}", loan.GetPrinciple(), loan.GetPeriod());
            Console.WriteLine("The  EMI of loan is {0:0.00}", loan.GetEMI());
        }
        
        // Console.WriteLine("The  EMI of personalloan is {0}", loans[0].GetEMI());
         //Console.WriteLine("The EMI of homeloan  is {0}",loans[1].GetEMI());
        Console.WriteLine("The total EMI is {0:0.00}", GetTotalEMI(loans));
        Console.WriteLine("the total tax for personal loan is {0:0.00}",GetTotalTax(loans));
         Console.WriteLine("the total discount for homeloan loan is {0:0.00}",GetTotaldiscount(loans));
    }
}

