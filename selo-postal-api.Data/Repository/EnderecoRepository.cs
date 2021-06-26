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

        public List<Endereco> GetByParameters(SearchEnderecoQueryItem enderecoQueryItem, PageRequest pr)
        {

            IEnumerable<Endereco> resultadoPesquisaEndereco = _context.Endereco
                .Include(c => c.Cidade)
                .ToList();



            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Estado))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Cidade.Estado == enderecoQueryItem.Estado);
            }

            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.Cidade))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.Cidade.Municipio == enderecoQueryItem.Cidade);
            }

            if (!String.IsNullOrWhiteSpace(enderecoQueryItem.CodigoPostal))
            {
                resultadoPesquisaEndereco = resultadoPesquisaEndereco.Where(x => x.CodigoPostal == enderecoQueryItem.CodigoPostal);
            }

            var page = Pagination<Endereco>.For(resultadoPesquisaEndereco.AsQueryable(), pr).ToList();

            return page;

        }

        public Endereco GetById(int id)
        {
            try
            {
                return _context.Endereco
                .Include(c => c.Cidade)
                .FirstOrDefault(e => e.Id == id)
                ;
            }
            catch (NotFoundException e)
            {

                throw new NotFoundException("Id de endereço não encontrado", e);
            }
            
        }

        public Endereco Add(EnderecoModel endereco)
        {
            var cidade = _context.Cidade.FirstOrDefault(c => c.Id == endereco.Cidade);
            var novoEndereco = new Endereco(
                nome: endereco.Nome,
                enderecoCasa: endereco.EnderecoCasa,
                numeroCasa: endereco.NumeroCasa,
                codigoPostal: endereco.CodigoPostal,
                bairro: endereco.Bairro,
                cidade: cidade
                );
            _context.Endereco.Add(novoEndereco);
            _context.SaveChanges();
            return novoEndereco;
        }

        public Endereco Update(int id, EnderecoModel endereco)
        {
            var enderecoOriginal = _context.Endereco.FirstOrDefault(e => e.Id == id);
            var cidadeNova = _context.Cidade.FirstOrDefault(c => c.Id == endereco.Cidade);

            if (enderecoOriginal == null)
            {
                throw new NotFoundException("Id do endereco incorreto");
            }

            if (cidadeNova == null)
            {
                throw new NotFoundException("Cidade não encontrada");
            }

            _context.Endereco.Attach(enderecoOriginal);

            enderecoOriginal.EnderecoCasa = endereco.EnderecoCasa;
            enderecoOriginal.NumeroCasa = endereco.NumeroCasa;
            enderecoOriginal.CodigoPostal = endereco.CodigoPostal;
            enderecoOriginal.Bairro = endereco.Bairro;
            enderecoOriginal.Cidade = cidadeNova;
            enderecoOriginal.ModificadoEm = DateTime.Now;

            _context.SaveChanges();

            return enderecoOriginal;
        }

        
        public void Remove(int id)
        {
            Endereco endereco = GetById(id);

            if (endereco != null)
            {
                _context.Endereco.Remove(endereco);
                _context.SaveChanges();
            }
            else
            {
                throw new NotFoundException("Endereço não encontrado!");
            }
        }
    }
}