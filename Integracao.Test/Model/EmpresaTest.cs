using Integracao.Data.Interfaces;
using Integracao.Models.Entities;
using Integracao.Models.VOs;
using Integracao.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Integracao.Test
{
    public class EmpresaTest
    {
        [Fact]
        public void DeveCriarUmaEmpresaValida()
        {
            Empresa empresa = new Empresa("Db1", new CNPJ("17809980000170"));
            Assert.True(empresa.Validar());
            Assert.Equal("Db1", empresa.Nome);
            Assert.Equal("17809980000170", empresa.Cnpj.Numero);
        }

        [Fact]
        public void NaoDeveCriarUmaEmpresaInvalidaSemCnpj()
        {
            Empresa empresa = new Empresa("Db1", new CNPJ(""));
            Assert.False(empresa.Validar());
        }

        [Fact]
        public void NaoDeveCriarUmaEmpresaInvalidaNomeCurto()
        {
            Empresa empresa = new Empresa("", new CNPJ("17809980000170"));
            Assert.False(empresa.Validar());
        }

        [Fact]
        public void DeveCriarUmaEmpresaInvalidaNomeLongoDemais()
        {
            Empresa empresa = new Empresa("1234567890123456789012345678901234567890", new CNPJ("17809980000170"));
            Assert.False(empresa.Validar());
        }
    }
}
