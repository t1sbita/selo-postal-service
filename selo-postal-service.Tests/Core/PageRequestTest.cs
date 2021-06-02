using NUnit.Framework;
using System;

using selo_postal_service.Core.Domain.Entities;

namespace selo_postal_service.Tests.Core
{
    [TestFixture]
    public class PageRequestTest
    {
        [TestCase(1, 99, 100)]
        [TestCase(1, 11, 20)]
        [TestCase(null, null, 10)]
        [TestCase(3, null, 10)]
        [TestCase(null, 101, 100)]
        public void DeveRetornarPaginacaoCorreta(Nullable<int> number, Nullable<int> limit, int result)
        {
            PageRequest pageResult = PageRequest.Of(number, limit);
            Assert.AreEqual(pageResult.Limit, result);
        }
        //Teste de paginação default
        [TestCase(1, null)]
        [TestCase(null, null)]
        [TestCase(-1, -1)]
        public void DeveRetornarPaginacaoDefault(Nullable<int> number, Nullable<int> limit){
            PageRequest result = PageRequest.Of(number, limit);
            Assert.True(result.Limit == 10);
            Assert.True(result.Number == 1);
        }

    }
}