using Finet.Context;
using Finet.Model;
using Finet.Model.Requests;
using Finet.Output;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Finet.Helpers
{
    public class MsExpenseCategoryHelper
    {
        private readonly FinetContext finetContext;

        public MsExpenseCategoryHelper(FinetContext finetContext){
            this.finetContext = finetContext;
        }

        public BaseOutput AddECategory(MsExpenseCategoryRequestDTO req)
        {
            try
            {
                if (string.IsNullOrEmpty(req.ECategoryName))
                {
                    return new BaseOutput()
                    {
                        StatusCode = 404,
                        ErrorMessage = "Category name is required"
                    };
                }
                var data = new MsExpenseCategory();
                data.ECategoryName = req.ECategoryName;
                data.Stsrc = "A"; // Active
                finetContext.MsExpenseCategory.Add(data);
                finetContext.SaveChanges();
                return new BaseOutput()
                {
                    StatusCode = 200,
                    ErrorMessage = "Success"
                };
            }
            catch(Exception ex)
            {
                return new BaseOutput()
                {
                    StatusCode = 500,
                    ErrorMessage = ex.Message
                };
            }
        }

        public BaseOutput DeactivateECategory(MsExpenseCategoryRequestDTO req)
        {
            try
            {
                var data = finetContext.MsExpenseCategory.FirstOrDefault(c =>
                c.ECategoryName.ToLower().Contains(req.ECategoryName.ToLower()));
                if(data != null)
                {
                    data.Stsrc = "D";
                    finetContext.SaveChanges();
                    return new BaseOutput()
                    {
                        StatusCode = 200,
                        ErrorMessage = "Success"
                    };
                }
                else
                {
                    return new BaseOutput()
                    {
                        StatusCode = 404,
                        ErrorMessage = "Category not found"
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

        public BaseOutput RemoveECategory(MsExpenseCategoryRequestDTO req)
        {
            try
            {
                var data = finetContext.MsExpenseCategory.FirstOrDefault(c => 
                c.ECategoryName.ToLower().Contains(req.ECategoryName.ToLower()));
                if (data != null)
                {
                    finetContext.MsExpenseCategory.Remove(data);
                    finetContext.SaveChanges();
                    return new BaseOutput()
                    {
                        StatusCode = 200,
                        ErrorMessage = "Success"
                    };
                }
                else
                {
                    return new BaseOutput()
                    {
                        StatusCode = 404,
                        ErrorMessage = "Category not found"
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

        public ListExpenseCategoryOutput GetListExpenseCategory()
        {
            try
            {
                var data = finetContext.MsExpenseCategory.Where(x =>
                x.Stsrc != "D").ToList();

                if (data != null)
                {
                    return new ListExpenseCategoryOutput()
                    {
                        Data = data,
                        ErrorMessage = "Success",
                        StatusCode = 200,
                    };
                }
                else
                {
                    return new ListExpenseCategoryOutput()
                    {
                        ErrorMessage = "Expense Category is empty",
                        StatusCode = 404,
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
