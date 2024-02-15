using Finet.Context;
using Finet.Model;
using Finet.Model.Requests;
using Finet.Output;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;

namespace Finet.Helpers
{
    public class MsCategoryHelper
    {
        private readonly FinetContext finetContext;

        public MsCategoryHelper(FinetContext finetContext){
            this.finetContext = finetContext;
        }

        public BaseOutput AddCategory(MsCategoryRequestDTO req)
        {
            try
            {
                if (string.IsNullOrEmpty(req.CategoryName))
                {
                    return new BaseOutput()
                    {
                        StatusCode = 404,
                        ErrorMessage = "Category name is required"
                    };
                }
                var data = new MsCategory();
                data.CategoryName = req.CategoryName;
                data.Stsrc = "A"; // Active
                finetContext.MsCategory.Add(data);
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

        public BaseOutput RemoveCategory(string CategoryName)
        {
            try
            {
                var data = finetContext.MsCategory.FirstOrDefault(c => c.CategoryName.ToLower().Contains(CategoryName.ToLower()));
                if (data != null)
                {
                    finetContext.MsCategory.Remove(data);
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
    }
}
