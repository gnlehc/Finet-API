using Finet.Context;
using Finet.Model.Requests;
using Finet.Model.Responses;
using Finet.Output;
using Finet.Model;
using Microsoft.IdentityModel.Tokens;

namespace Finet.Helpers
{
    public class MsUserHelper
    {
        private readonly FinetContext _userContext;

        public MsUserHelper(FinetContext userContext)
        {
            _userContext = userContext;
        }

        public BaseOutput RegisterHelper(RegisterRequestDTO request)
        {
            BaseOutput response = new BaseOutput();
            try
            {

                if (request == null)
                {
                    response.StatusCode = 400;
                    response.ErrorMessage = "Invalid Request.";
                    return response;
                }
                if(string.IsNullOrEmpty(request.Username))
                {
                    response.StatusCode = 400;
                    response.ErrorMessage = "Username is Required.";
                    return response;
                }
                if (string.IsNullOrEmpty(request.Email))
                {
                    response.StatusCode = 400;
                    response.ErrorMessage = "Email is Required.";
                    return response;
                }
                if (string.IsNullOrEmpty(request.Password))
                {
                    response.StatusCode = 400;
                    response.ErrorMessage = "Password is Required.";
                    return response;
                }
                if(_userContext.MsUser.Any(u => u.Username == request.Username))
                {
                    response.StatusCode = 400;
                    response.ErrorMessage = "Account already Exists.";
                    return response;
                }
                else
                {
                    var user = new MsUser();
                    user.UserID = Guid.NewGuid();
                    user.Username = request.Username;
                    user.Email = request.Email;
                    user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    /*   string email = request.Email;
                    string[] parts = email.Split('@');
                    string temporaryName = parts[0];*/

                    _userContext.MsUser.Add(user);
                    _userContext.SaveChanges();

                    response.StatusCode = 200;
                    response.ErrorMessage = "Success.";
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user: " + ex.Message);
            }
        }

        public LoginResponseDTO LoginHelper(LoginRequestDTO request)
        {
            LoginResponseDTO response = new LoginResponseDTO();
            try
            {
                if (request == null)
                {
                    response.StatusCode = 400;
                    response.ErrorMessage = "Invalid Request.";
                    return response;
                }

                var user = _userContext.MsUser.FirstOrDefault(u => u.Email == request.Email);

                if (user == null)
                {
                    response.StatusCode = 404;
                    response.ErrorMessage = "User not found.";
                    return response;
                }

                if (BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {
                    response.StatusCode = 200;
                    response.ErrorMessage = "Log in Successful.";
                    response.Id = user.UserID;
                    response.Username = user.Username;
                }
                else
                {
                    response.StatusCode = 401;
                    response.ErrorMessage = "Incorrect password.";
                }

                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while login the user: " + ex.Message);
            }
        }
    }
}
