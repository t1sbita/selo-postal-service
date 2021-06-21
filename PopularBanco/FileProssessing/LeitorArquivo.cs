using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularBanco.FileProssessing
{
    public class LeitorArquivo
    {
        private char Separator = ';';
        private const int ExpectedFieldLength = 10;

        private const int PosicaoNome = 4;
        private const int PosicaoUF = 3;
        
        // ConcatUF+Mun;IBGE;IBGE7;UF;Municipio;Região;População 2010;Porte;Capital;
        public string Source { get; }
        public string[] SourceFields { get; }

        public string Municipio { get => SourceFields[PosicaoNome]; }
        public string UF { get => SourceFields[PosicaoUF]; }

        
        public LeitorArquivo(string source)
        {

            this.Source = source;

            SourceFields = this.Source.Split(Separator);

        }


    }
}
