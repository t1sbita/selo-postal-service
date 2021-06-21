using System;

namespace selo_postal_service.Application.Controller.Interface
{
    public interface IEnderecoController
    {
        string Search(string cidade, string estado, string codigoPostal, Nullable<int> number, Nullable<int> limit);
    }
}