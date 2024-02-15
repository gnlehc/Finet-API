namespace Finet.Model.Requests
{
    public class TrExpenseRequestDTO
    {
        public int AccountID { get; set; }
        public int CategoryID { get; set;}
        public string Title { get; set;}
        public string? Description { get; set;}
        //public int? Page { get; set; }
        //public int? Take { get; set; }
    }
    public class GetListTrExpenseRequestDTO 
    {
        public int? Page { get; set; }
        public int? Take { get; set; }
    }
    public class GetDetailExpenseRequestDTO 
    {
        public Guid ExpenseID { get; set; }
        public int? Page { get; set; }
        public int? Take { get; set; }
    }

}
