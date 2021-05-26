using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using selo_postal_service.Dados;

namespace selo_postal_service.Core
{
    public class GeradorArquivo
    {
        List<Etiquetas> enderecos = new List<Etiquetas>();

        /// <summary>
        /// Cria um arquivo .tsv com o resultado da query
        /// </summary>
        public void CriarArquivo()
        {
            string gerarNomeArquivo = DateTime.Now.ToString("u").Replace(":", "");

            string novoArquivo = @"..\..\TSV\Pesquisa " + gerarNomeArquivo + ".tsv";

            using (FileStream fluxoDeArquivo = new FileStream(novoArquivo, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                byte[] buffer = new byte[1024];
                writer.WriteLine($"quantidadePorPagina\tPaginaAtual\tQuantidadePaginas\tTotalRegistros");
                writer.WriteLine($"Nome\tEndereco\tNumero\tCódigo Postal\tBairro\tCidade\tEstado\tQRCodeRef");
                writer.Flush();
                
                foreach (Etiquetas item in enderecos)
                {
                    writer.WriteLine(item.ToString());
                    writer.Flush();

                }
            }
        }
    }
}