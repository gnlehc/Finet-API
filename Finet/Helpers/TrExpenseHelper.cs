using Finet.Context;
using Finet.Model;
using Finet.Model.Requests;
using Finet.Output;
using Microsoft.EntityFrameworkCore;

namespace Finet.Helpers
{
    public class TrExpenseHelper
    {
        private readonly FinetContext finetContext;

        public TrExpenseHelper(FinetContext finetContext)
        {
            this.finetContext = finetContext;
        }

        public BaseOutput AddExpense(TrExpenseRequestDTO req)
        {
           
            try
            {
                var context = finetContext.TrExpense.Where(t => t.AccountID == req.AccountID && t.CategoryID == req.CategoryID)
                    .Select(t => new TrExpense()
                    {
                        ExpenseID = new Guid(),
                        AccountID = t.AccountID,
                        CategoryID = t.CategoryID,
                        Title = t.Title,
                        Description = t.Description,
                        Stsrc = "A",
                        Time = DateTime.Now
                    }).ToList();
              
                return new BaseOutput()
                {
                    StatusCode = 200,
                    ErrorMessage = "Success"
                };
            }
            catch (Exception ex)
            {
                return new BaseOutput()
                {
                    StatusCode = 500,
                    ErrorMessage = ex.Message
                };
            }
        }

        public TrExpenseOutput GetListExpenses(GetListTrExpenseRequestDTO req)
        {
            if (req.Page == null || req.Take == null)
            {
                throw new Exception("Page and Take is required in the Request Body");
            }
            int page = req.Page.Value;
            int take = req.Take.Value;

            try
            {
                var query = finetContext.TrExpense
                    .Include(e => e.AccountID)
                    .Include(e => e.CategoryID)
                    .OrderBy(e => e.Time)
                    .Skip((page - 1) * take)
                    .Take(take); ;
                var totalData = query.Count();
                var totalPage = totalData / take;
                if (totalData % take != 0)
                {
                    totalPage += 1;
                }
                return new TrExpenseOutput()
                {
                    Expenses = query.ToList(),
                    TotalPage = totalPage,
                    TotalData = totalData,
                    StatusCode = 200,
                    ErrorMessage = "Success"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
