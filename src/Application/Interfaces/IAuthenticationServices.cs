using Application.Models.Request;

namespace Application.Interfaces;

public interface IAuthenticationServices
{
    string Autenticar(AuthenticationRequest authenticationRequest);
}; 