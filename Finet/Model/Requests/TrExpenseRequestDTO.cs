namespace Finet.Model.Requests
{
    public class TrExpenseRequestDTO
    {
        public int MethodID { get; set; }
        public int ECategoryID { get; set;}
        public string Title { get; set;}
        public string? Description { get; set;}
        public int Amount { get; set;}
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
