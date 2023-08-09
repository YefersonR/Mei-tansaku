using Core.Application.Dtos.Response;
using Core.Application.DTOS.Account;


namespace Core.Application.Inferfaces.Service
{
    public interface IAccountService
    {
        Task<GenericApiResponse<AuthenticationResponse>> Authentication(AuthenticationRequest request);
        Task<string> ConfirmEmail(string userId, string token);
        Task<GenericResponse> ForgotPassword(ForgotPasswordRequest request, string origin);
        Task<GenericApiResponse<RegisterResponse>> Register(RegisterRequest request, int typeUser);
        //Task<GenericResponse> UpdateUser(string userId, RegisterRequest request);
        Task<GenericResponse> ResetPassword(ResetPasswordRequest request);
        Task SignOut();
    }
}