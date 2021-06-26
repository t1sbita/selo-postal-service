using System.Collections.Generic;

using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Domain.Models;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Services.Interfaces;

namespace selo_postal_api.Core.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public EnderecoModel Add(EnderecoModel endereco)
        {
            Endereco enderecoBanco = _enderecoRepository.Add(endereco);
            EnderecoModel model = new EnderecoModel()
            {
                Nome = enderecoBanco.Nome,
                EnderecoCasa = enderecoBanco.EnderecoCasa,
                NumeroCasa = enderecoBanco.NumeroCasa,
                Bairro = enderecoBanco.Bairro,
                CodigoPostal = enderecoBanco.CodigoPostal,
                Cidade = enderecoBanco.Cidade.Id,
                CriadoEm = enderecoBanco.CriadoEm,
                ModificadoEm = enderecoBanco.ModificadoEm
            };

            return model;
        }

        public List<EnderecoModel> GetByParameters(SearchEnderecoQueryItem searchEnderecoQueryItem, PageRequest pageRequest)
        {
            List<EnderecoModel> listaModel = new List<EnderecoModel>();
            List<Endereco> listaEnderecos = _enderecoRepository.GetByParameters(searchEnderecoQueryItem, pageRequest);

            foreach (Endereco endereco in listaEnderecos)
            {
                listaModel.Add(
                    new EnderecoModel()
                    {
                        Nome = endereco.Nome,
                        EnderecoCasa = endereco.EnderecoCasa,
                        NumeroCasa = endereco.NumeroCasa,
                        Bairro = endereco.Bairro,
                        CodigoPostal = endereco.CodigoPostal,
                        Cidade = endereco.Cidade.Id,
                        CriadoEm = endereco.CriadoEm,
                        ModificadoEm = endereco.ModificadoEm
                    }
                );
            }

            return listaModel;

        }

        public EnderecoModel GetById(int id)
        {
            var endereco = _enderecoRepository.GetById(id);
            return new EnderecoModel()
            {
                Nome = endereco.Nome,
                EnderecoCasa = endereco.EnderecoCasa,
                NumeroCasa = endereco.NumeroCasa,
                Bairro = endereco.Bairro,
                CodigoPostal = endereco.CodigoPostal,
                Cidade = endereco.Cidade.Id,
                CriadoEm = endereco.CriadoEm,
                ModificadoEm = endereco.ModificadoEm
            };
        }

        public EnderecoModel Update(int id, EnderecoModel endereco)
        {
            Endereco enderecoBanco = _enderecoRepository.Update(id, endereco);
            EnderecoModel model = new EnderecoModel()
            {
                Nome = enderecoBanco.Nome,
                EnderecoCasa = enderecoBanco.EnderecoCasa,
                NumeroCasa = enderecoBanco.NumeroCasa,
                Bairro = enderecoBanco.Bairro,
                CodigoPostal = enderecoBanco.CodigoPostal,
                Cidade = enderecoBanco.Cidade.Id,
                CriadoEm = enderecoBanco.CriadoEm,
                ModificadoEm = enderecoBanco.ModificadoEm
            };

            return model;
        }

        public void Remove(int id)
        {
            _enderecoRepository.Remove(id);
        }

    }
}