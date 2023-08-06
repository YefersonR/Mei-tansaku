using Core.Application.Dtos.Response;
using Core.Application.DTOS.Account;
using Core.Application.ViewModels.User;

namespace Core.Application.Inferfaces.Service
{
    public interface IUserService
    {
        Task<GenericApiResponse<AuthenticationResponse>> Login(LoginViewModel login);
        Task SignOut();
        Task<GenericApiResponse<RegisterResponse>> Regiter(UserSaveViewModel viewModel, string origin);
        //Task UpdateUser(string Id, UserSaveViewModel viewModel);
        Task<string> EmailConfirm(string userId, string token);
        Task<GenericResponse> ForgotPassword(ForgotPasswordViewModel request, string origin);
        Task<GenericResponse> ResetPassword(ResetPasswordViewModel request);
    }
}
