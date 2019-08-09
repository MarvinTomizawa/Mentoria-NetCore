using Integracao.Models.Entities;
using Integracao.Models.VOs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Integracao.Test
{
    public class FuncionarioTest
    {
        [Fact]
        public void DeveCriarUmFuncionarioValido()
        {
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("17809980000170"));

            Funcionario funcionario = new Funcionario("Teste", false, new CPF("12321025980"), cargo, empresa);
            Assert.True(funcionario.Validar());
            Assert.Equal("Teste", funcionario.Nome);
            Assert.False(funcionario.ÉHomeOffice);
            Assert.Equal(empresa, funcionario.Empresa);
            Assert.Equal(cargo, funcionario.Cargo);
        }

        [Fact]
        public void NaoDeveCriarUmFuncionarioComCargoInvalido()
        {
            Cargo cargo = new Cargo("");
            Empresa empresa = new Empresa("Db1", new CNPJ("17809980000170"));

            Funcionario funcionario = new Funcionario("Teste", false, new CPF("12321025980"), cargo, empresa);
            Assert.False(funcionario.Validar());
        }
        [Fact]
        public void NaoDeveCriarUmFuncionarioComEmpresaInvalida()
        {
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("", new CNPJ("17809980000170"));

            Funcionario funcionario = new Funcionario("Teste", false, new CPF("12321025980"), cargo, empresa);
            Assert.False(funcionario.Validar());
        }
        [Fact]
        public void NaoDeveCriarUmFuncionarioComNomeCurto()
        {
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("17809980000170"));

            Funcionario funcionario = new Funcionario("", false, new CPF("12321025980"), cargo, empresa);
            Assert.False(funcionario.Validar());
        }
        [Fact]
        public void NaoDeveCriarUmFuncionarioComNomeMuitoLongo()
        {
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("17809980000170"));

            Funcionario funcionario = new Funcionario("123456789012345678901234567890123456789012345678901234567890", false, new CPF("12321025980"), cargo, empresa);
            Assert.False(funcionario.Validar());
        }
        [Fact]
        public void NaoDeveCriarUmFuncionarioComCpfInvalido()
        {
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("17809980000170"));

            Funcionario funcionario = new Funcionario("Teste", false, new CPF(""), cargo, empresa);
            Assert.False(funcionario.Validar());
        }
        [Fact]
        public void NaoDeveCriarUmFuncionarioSemCargo()
        {
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("17809980000170"));

            Funcionario funcionario = new Funcionario("Teste", false, new CPF(""), null, empresa);
            Assert.False(funcionario.Validar());
        }
        [Fact]
        public void NaoDeveCriarUmFuncionarioSemEmpresa()
        {
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("17809980000170"));

            Funcionario funcionario = new Funcionario("Teste", false, new CPF(""), cargo, null);
            Assert.False(funcionario.Validar());
        }
    }
}
