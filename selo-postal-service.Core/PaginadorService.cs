using System;
using System.Collections.Generic;
using System.Linq;

using selo_postal_service.Dados;

namespace selo_postal_service.Core
{
    public class PaginadorService
    {
        public List<Etiquetas> Paginador(List<Etiquetas> lista, string itemPorPagina, string qualPagina)
        {
            int qtdPorPagina = int.Parse(itemPorPagina);
            int paginaDesejada = int.Parse(qualPagina);
            return lista.OrderBy(x => x.Nome)
                        .Skip((paginaDesejada -1) * qtdPorPagina)
                        .Take(qtdPorPagina).ToList();
        }
    }
}