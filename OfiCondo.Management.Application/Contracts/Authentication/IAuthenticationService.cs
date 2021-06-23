﻿namespace OfiCondo.Management.Application.Contracts.Authentication
{
    using OfiCondo.Management.Application.Models.Authentication;
    using System.Threading.Tasks;
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}