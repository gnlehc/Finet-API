using Finet.Context;
using Finet.Model;
using Finet.Model.Requests;
using Finet.Output;

namespace Finet.Helpers
{
    public class MsAccountHelper
    {
        private readonly FinetContext finetContext;
        public MsAccountHelper(FinetContext finetContext)
        {
            this.finetContext = finetContext;
        }

        public BaseOutput AddAccount(MsAccountRequestDTO req) 
        {
            try
            {
                var data = new MsAccount();
                data.Stsrc = "A"; // Active
                data.AccountName = req.AccountName;
                finetContext.MsAccount.Add(data);
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

        public BaseOutput RemoveAccount(string AccountName)
        {
            try
            {
                var data = finetContext.MsAccount.FirstOrDefault(a => a.AccountName.ToLower().Contains(AccountName.ToLower()));
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
    }
}
