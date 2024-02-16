using Finet.Context;
using Finet.Model;
using Finet.Model.Requests;
using Finet.Output;

namespace Finet.Helpers
{
    public class MsMethodHelper
    {
        private readonly FinetContext finetContext;
        public MsMethodHelper(FinetContext finetContext)
        {
            this.finetContext = finetContext;
        }

        public BaseOutput AddMethod(MsMethodRequestDTO req) 
        {
            try
            {
                var data = new MsMethod();
                data.Stsrc = "A"; // Active
                data.MethodName = req.MethodName;
                finetContext.MsMethod.Add(data);
                finetContext.SaveChanges();
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
        public BaseOutput DeactivateMethod(MsMethodRequestDTO req)
        {
            try
            {
                var data = finetContext.MsMethod.Where(x =>
                x.MethodName == req.MethodName).FirstOrDefault();
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
                        ErrorMessage = "Account not found"
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
        public BaseOutput RemoveMethod(MsMethodRequestDTO req)
        {
            try
            {
                var data = finetContext.MsMethod.FirstOrDefault(a => 
                a.MethodName.ToLower().Contains(req.MethodName.ToLower()));
                if (data != null)
                {
                    finetContext.Remove(data);
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
                        ErrorMessage = "Account not found"
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
        public ListMethodOutput GetListMethod()
        {
            try
            {
                var data = finetContext.MsMethod.Where(x => 
                x.Stsrc != "D").ToList();
                if (data != null)
                {
                    return new ListMethodOutput()
                    {
                        Data = data,
                        StatusCode = 200,
                        ErrorMessage = "Success"
                    };
                }
                else
                {
                    return new ListMethodOutput()
                    {
                        ErrorMessage = "Method is empty",
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
