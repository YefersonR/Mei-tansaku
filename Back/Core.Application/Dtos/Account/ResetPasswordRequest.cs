﻿namespace Core.Application.DTOS.Account
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
