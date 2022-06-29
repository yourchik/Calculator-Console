using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZWork
{
    public class Output
    {
        public object Date { get; set; }
        public int Month { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal PercentagePart { get; set; }
        public decimal MainPart { get; set; }
        public decimal BalanceOwed { get; set; }

    }
    public class Outputlist
    {
        public Output Output { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int Month = 0;

            Console.WriteLine("Введите сумму кредита:");
            int CreditSum = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите срок кредита в месяцах:");
            int CreditMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Укажите процентную ставку:");
            decimal InterestRate = decimal.Parse(Console.ReadLine());

            decimal MonthlyRate = InterestRate / 12 / 100;
            decimal TotalRate = (decimal)Math.Pow((double)(1 + MonthlyRate), (double)CreditMonth);
            decimal MonthlyPayment = (CreditSum * MonthlyRate * TotalRate) / (TotalRate - 1);
            decimal BalanceOwed = CreditSum;
            decimal Overpayment = MonthlyPayment * CreditMonth - CreditSum;
            Console.WriteLine("Переплата по кредиту составит: " + Math.Round(Overpayment, 2) + " руб.");
            Console.WriteLine("График кредитных платежей:\n");
            
            DateTime datanow = DateTime.Now;
            var datapay = datanow;

            var values = new List<Output>();

            for (int i = 0; i < CreditMonth; i++)
            {
                decimal PercentagePart = BalanceOwed * MonthlyRate;  //Процентная часть
                decimal MainPart = MonthlyPayment - PercentagePart;  //Основная часть
                BalanceOwed -= MainPart;  // Остаток долга
                Month++;  //Месяца
                datapay = datapay.AddMonths(1);
                Console.WriteLine("Номер платежа: " + Month);
                Console.WriteLine("\tЕжемесячный платеж: " + Math.Round(MonthlyPayment, 2) + " руб.");
                Console.WriteLine("\tПроцентная часть: " + Math.Round(PercentagePart, 2) + " руб.");
                Console.WriteLine("\tОсновная часть: " + Math.Round(MainPart, 2) + " руб.");
                Console.WriteLine("\tОстаток долга: " + Math.Round(BalanceOwed, 2) + " руб." + "\n");
                var output = new Output
                {
                    Date = datapay,
                    Month = Month,
                    MonthlyPayment = Math.Round(MonthlyPayment, 2),
                    PercentagePart = Math.Round(PercentagePart, 2),
                    MainPart = Math.Round(MainPart, 2),
                    BalanceOwed = Math.Round(BalanceOwed, 2)
                };
                values.Add(output);
            }
            Console.ReadLine();
        }
    }
}
