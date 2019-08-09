using Integracao.Data.Interfaces;
using Integracao.Dto;
using Integracao.Models.Entities;
using Integracao.Models.VOs;
using Integracao.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Integracao.Test.Service
{
    public class FuncionarioServiceTest
    {
        private Mock<IFuncionarioRepository> _funcionarioRepositoryMock;
        private Mock<IEmpresaRepository> _empresaRepositoryMock;
        private Mock<ICargoRepository> _cargoRepositoryMock;


        [Fact]
        public void DeveAdicionarUmNovoFuncionario()
        {
            FuncionarioDto funcionario = new FuncionarioDto
            {
                Nome = "Marvin",
                Cpf = "12321025980",
                Inativo = false,
                CargoId = 1, 
                EhHomeOffice = false, 
                EmpresaId = 1
            };
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("87717167000156"));

            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(empresa);

            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(cargo);

            _funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            _funcionarioRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Funcionario>()));

            IFuncionarioService funcionarioService = new FuncionarioService(_empresaRepositoryMock.Object,_cargoRepositoryMock.Object,_funcionarioRepositoryMock.Object);

            var mensagens = funcionarioService.Adicionar(funcionario);

            _funcionarioRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Funcionario>()), Times.Once());
            Assert.Equal(0, mensagens.Count);
        }

        [Fact]
        public void NaoDeveAdicionarUmNovoFuncionarioQuandoNomeInvalido()
        {
            FuncionarioDto funcionario = new FuncionarioDto
            {
                Nome = "",
                Cpf = "12321025980",
                Inativo = false,
                CargoId = 1,
                EhHomeOffice = false,
                EmpresaId = 1
            };
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("87717167000156"));

            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(empresa);

            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(cargo);

            _funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            _funcionarioRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Funcionario>()));

            IFuncionarioService funcionarioService = new FuncionarioService(_empresaRepositoryMock.Object, _cargoRepositoryMock.Object, _funcionarioRepositoryMock.Object);

            var mensagens = funcionarioService.Adicionar(funcionario);

            _funcionarioRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Funcionario>()), Times.Never());
            Assert.Equal(1, mensagens.Count);
        }

        [Fact]
        public void NaoDeveAdicionarUmNovoFuncionarioQuandoCpfInvalido()
        {
            FuncionarioDto funcionario = new FuncionarioDto
            {
                Nome = "Marvin",
                Cpf = "",
                Inativo = false,
                CargoId = 1,
                EhHomeOffice = false,
                EmpresaId = 1
            };
            Cargo cargo = new Cargo("Tester");
            Empresa empresa = new Empresa("Db1", new CNPJ("87717167000156"));

            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(empresa);

            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(cargo);

            _funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            _funcionarioRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Funcionario>()));

            IFuncionarioService funcionarioService = new FuncionarioService(_empresaRepositoryMock.Object, _cargoRepositoryMock.Object, _funcionarioRepositoryMock.Object);

            var mensagens = funcionarioService.Adicionar(funcionario);

            _funcionarioRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Funcionario>()), Times.Never());
            Assert.Equal(1, mensagens.Count);
        }

        [Fact]
        public void NaoDeveAdicionarUmNovoFuncionarioQuandoCargoInvalido()
        {
            FuncionarioDto funcionario = new FuncionarioDto
            {
                Nome = "Marvin",
                Cpf = "12321025980",
                Inativo = false,
                CargoId = 1,
                EhHomeOffice = false,
                EmpresaId = 1
            };
            Empresa empresa = new Empresa("Db1", new CNPJ("87717167000156"));

            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(empresa);

            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns((Cargo)null);

            _funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            _funcionarioRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Funcionario>()));

            IFuncionarioService funcionarioService = new FuncionarioService(_empresaRepositoryMock.Object, _cargoRepositoryMock.Object, _funcionarioRepositoryMock.Object);

            var mensagens = funcionarioService.Adicionar(funcionario);

            _funcionarioRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Funcionario>()), Times.Never());
            Assert.Equal(2, mensagens.Count);
        }

        [Fact]
        public void NaoDeveAdicionarUmNovoFuncionarioQuandoEmpresaInvalido()
        {
            FuncionarioDto funcionario = new FuncionarioDto
            {
                Nome = "Marvin",
                Cpf = "12321025980",
                Inativo = false,
                CargoId = 1,
                EhHomeOffice = false,
                EmpresaId = 1
            };
            Cargo cargo = new Cargo("Tester");

            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns((Empresa) null);

            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(cargo);

            _funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            _funcionarioRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Funcionario>()));

            IFuncionarioService funcionarioService = new FuncionarioService(_empresaRepositoryMock.Object, _cargoRepositoryMock.Object, _funcionarioRepositoryMock.Object);

            var mensagens = funcionarioService.Adicionar(funcionario);

            _funcionarioRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Funcionario>()), Times.Never());
            Assert.Equal(2, mensagens.Count);
        }
    }
}
