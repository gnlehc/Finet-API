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
                /*var query = from m in finetContext.MsMethod
                            join e in finetContext.TrExpense
                            on m.MethodID equals e.MethodID
                            join c in finetContext.MsExpenseCategory
                            on e.ECategoryID equals c.ECategoryID
                            where m.MethodID == req.MethodID && c.ECategoryID == req.ECategoryID
                            select new TrExpense()
                            {
                                ExpenseID = Guid.NewGuid(),
                                MethodID = req.MethodID,
                                ECategoryID = req.ECategoryID,
                                Amount = req.Amount,
                                Title = req.Title,
                                Description = req.Description,
                                Stsrc = "A",
                                Time = DateTime.Now,
                            };*/
                /*foreach (var expense in query)
                {
                    finetContext.TrExpense.Add(expense);
                }
                finetContext.SaveChanges();*/


                // cek if request MethodID dan ECategoryID exists
                var methodExists = finetContext.MsMethod.Any(m => m.MethodID == req.MethodID);
                var categoryExists = finetContext.MsExpenseCategory.Any(c => c.ECategoryID == req.ECategoryID);
                if (!methodExists || !categoryExists)
                {
                    return new BaseOutput()
                    {
                        StatusCode = 400, // Bad Request
                        ErrorMessage = "MethodID or ECategoryID not found"
                    };
                }
                else
                {
                    var newExpense = new TrExpense()
                    {
                        ExpenseID = Guid.NewGuid(),
                        MethodID = req.MethodID,
                        ECategoryID = req.ECategoryID,
                        Amount = req.Amount,
                        Title = req.Title,
                        Description = req.Description,
                        Stsrc = "A",
                        Time = DateTime.Now,
                    };

                    finetContext.TrExpense.Add(newExpense);
                    finetContext.SaveChanges();
                    return new BaseOutput()
                    {
                        StatusCode = 200,
                        ErrorMessage = "Success"
                    };
                }
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
                    .Include(e => e.MethodID)
                    .Include(e => e.ECategoryID)
                    .OrderBy(e => e.Time)
                    .Skip((page - 1) * take)
                    .Take(take);
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
