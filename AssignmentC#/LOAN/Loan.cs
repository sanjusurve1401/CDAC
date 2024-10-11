using System;

namespace Ram;
    public abstract class Loan
    {
        protected decimal principle;
        protected int period;

        public decimal GetPrinciple() => principle;

        public void SetPrinciple(decimal pri)
        {
            principle = pri;
        }

        public int GetPeriod() => period;

        public void SetPeriod(int p)
        {
            period = p;
        }

        public abstract float GetRate();
        
        public decimal GetEMI()
        {
            float r = GetRate();
            decimal EMI = principle * (1 + (decimal)r * period / 100) / (12 * period);
            return EMI;
        }
    }

    public interface ITaxable
    {
        double GetTax();
    }

    public interface IDiscountable
    {
        double GetDiscount();
    }

    public class HomeLoan : Loan, IDiscountable
    {
        // For HomeLoan (up to 20 lakhs is 10%, above 20 lakhs 11%)
        public override float GetRate()
        {
            return principle < 2000000 ? 0.1f : 0.11f;
        }

        public double GetDiscount()
        {
            double emi = (double)GetEMI();
            return emi * 0.05;
        }
    }

    public class PersonalLoan : Loan, ITaxable
    {
        // For PersonalLoan (up to 5 lakhs is 15%, above 5 lakhs 16%)
        public override float GetRate()
        {
            return GetPrinciple() <= 500000 ? 0.15f : 0.16f;
        }

        public double GetTax()
        {
            double emi = (double)GetEMI();
            return emi * 0.10;
        }
    }

