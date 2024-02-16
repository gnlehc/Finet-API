using Finet.Model;

namespace Finet.Output
{
    public class MsExpenseCategoryOutput : BaseOutput
    {
        public int ECategoryID { get; set; }
        public string ECategoryName { get; set; }
        public string Stsrc { get; set; }
    }

    public class ListExpenseCategoryOutput : BaseOutput
    {
        public List<MsExpenseCategory> Data { get; set; }
        //public int TotalData { get; set; }
        //public int TotalPage { get; set; }
        public ListExpenseCategoryOutput()
        {
            Data = new List<MsExpenseCategory>();
        }
    }
}
