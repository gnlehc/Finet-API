﻿using Finet.Context;
using Finet.Model.Requests;
using Finet.Model.Responses;
using Finet.Output;
using Finet.Model;

namespace Finet.Helpers
{
    public class UserHelper
    {
        private readonly FinetContext _userContext;

        public UserHelper(FinetContext userContext)
        {
            _userContext = userContext;
        }

        public BaseOutput RegisterHelper(RegisterRequest request)
        {
            BaseOutput response = new BaseOutput();
            try
            {

                if (request == null)
                {
                    response.statusCode = 400;
                    response.message = "Invalid Request";
                    response.success = false;
                    return response;
                }

                var user = new UserModel();
                user.Id = Guid.NewGuid();
                string email = request.Email;
                string[] parts = email.Split('@');
                string temporaryName = parts[0];

                user.Name = temporaryName;
                user.Email = request.Email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);


                _userContext.Users.Add(user);
                _userContext.SaveChanges();

                response.statusCode = 200;
                response.message = "Success";
                response.success = true;

                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user: " + ex.Message);
            }
        }

        public LoginResponse LoginHelper(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {

                if (request == null)
                {
                    response.statusCode = 400;
                    response.message = "Invalid Request";
                    response.success = false;
                    return response;
                }

                var user = _userContext.Users.FirstOrDefault(u => u.Email == request.Email);

                if (user == null)
                {
                    response.statusCode = 404;
                    response.message = "User not found.";
                    response.success = false;
                    return response;
                }

                if (BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {

                    response.statusCode = 200;
                    response.success = true;
                    response.message = "User logged in!";
                    response.Id = user.Id;
                    response.Name = user.Name;

                }
                else
                {
                    response.statusCode = 401;
                    response.message = "Incorrect password.";
                    response.success = false;
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
