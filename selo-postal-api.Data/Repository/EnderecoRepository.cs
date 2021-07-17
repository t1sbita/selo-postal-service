using System;
using System.Collections.Generic;
using System.Linq;

using selo_postal_api.Core.Exceptions;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Data.Context;
using Microsoft.EntityFrameworkCore;
using selo_postal_api.Core.Domain.Models;

namespace selo_postal_api.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public readonly PostgresContext _context;

        public EnderecoRepository(PostgresContext context)
        {
            _context = context;
        }


        public IEnumerable<Endereco> GetAll()
        {
            return _context.Endereco
            .Include(c => c.Cidade);
        }

        public Endereco GetById(int id)
        {

            return _context.Endereco
            .Include(c => c.Cidade)
            .FirstOrDefault(e => e.Id == id);
        }

        public Endereco Add(Endereco endereco){
            
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
            return _context.Endereco.OrderBy(a => a.Id).LastOrDefault();
        }

        public Endereco Update(Endereco endereco)
        {
            var enderecoOriginal = GetById(endereco.Id);
            
            _context.Endereco.Attach(enderecoOriginal);

            enderecoOriginal.EnderecoCasa = endereco.EnderecoCasa;
            enderecoOriginal.NumeroCasa = endereco.NumeroCasa;
            enderecoOriginal.CodigoPostal = endereco.CodigoPostal;
            enderecoOriginal.Bairro = endereco.Bairro;
            enderecoOriginal.CidadeId = endereco.CidadeId;
            enderecoOriginal.ModificadoEm = DateTime.Now;

            _context.SaveChanges();

            return enderecoOriginal;
        }


        // public List<Endereco> GetByParameters(SearchEnderecoQueryItem enderecoQueryItem, PageRequest pr)
        // {

        //     IEnumerable<Endereco> resultadoPesquisaEndereco = _context.Endereco
        //         .Include(c => c.Cidade)
        //         .ToList();



        //     if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Estado))
        //     {
        //         resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Cidade.Estado == enderecoQueryItem.Estado);
        //     }

        //     if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Cidade))
        //     {
        //         resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Cidade.Municipio == enderecoQueryItem.Cidade);
        //     }

        //     if (!String.IsNullOrWhiteSpace(enderecoQueryItem.CodigoPostal))
        //     {
        //         resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.CodigoPostal == enderecoQueryItem.CodigoPostal);
        //     }

        //     var page = Pagination<Endereco>.For(resultadoPesquisaEndereco.AsQueryable(), pr).ToList();

        //     return page;

        // }
        public void Remove(int id)
        {
            Endereco endereco = GetById(id);

            if (endereco != null)
            {
                _context.Endereco.Remove(endereco);
                _context.SaveChanges();
            }

        }
    }
}