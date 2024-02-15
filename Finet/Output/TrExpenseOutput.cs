using Finet.Model;

namespace Finet.Output
{
    public class TrExpenseOutput : BaseOutput
    {
        public List<TrExpense> Expenses = new List<TrExpense>();
        public int TotalData { get; set; }
        public int TotalPage { get; set; }
        public TrExpenseOutput()
        {
            Expenses = new List<TrExpense>();
        }
    }
}
