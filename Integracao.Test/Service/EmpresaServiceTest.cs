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
    public class EmpresaServiceTest
    {
        private Mock<IEmpresaRepository> _empresaRepositoryMock;

        [Fact]
        public void DeveAdicionarNovaEmpresa()
        {
            EmpresaDto empresaDto = new EmpresaDto{
                Nome = "Db1",
                CNPJ = "87717167000156",
                Inativo = false
            };
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Empresa>()));
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Adicionar(empresaDto);

            _empresaRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Empresa>()), Times.Once());
            Assert.Equal(0, mensagens.Count);
        }

        [Fact]
        public void NaoDeveAdicionarEmpresaComNomeInvalido()
        {
            EmpresaDto empresaDto = new EmpresaDto
            {
                Nome = "",
                CNPJ = "87717167000156",
                Inativo = false
            };
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Empresa>()));
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Adicionar(empresaDto);

            _empresaRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Empresa>()), Times.Never());
            Assert.Equal(1, mensagens.Count);
            Assert.Equal("Empresa invalida", mensagens[0]);
        }

        [Fact]
        public void NaoDeveAdicionarEmpresaComCPFInvalido()
        {
            EmpresaDto empresaDto = new EmpresaDto
            {
                Nome = "Db1",
                CNPJ = "",
                Inativo = false
            };
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Empresa>()));
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Adicionar(empresaDto);

            _empresaRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Empresa>()), Times.Never());
            Assert.Equal(1, mensagens.Count);
            Assert.Equal("Empresa invalida", mensagens[0]);
        }

        [Fact]
        public void DeveAtualizarEmpresa()
        {
            EmpresaDto empresaDto = new EmpresaDto
            {
                Nome = "Db1",
                CNPJ = "87717167000156",
                Inativo = false
            };
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Atualizar(It.IsAny<Empresa>()));
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Atualizar(empresaDto, 1);

            _empresaRepositoryMock.Verify(mock => mock.Atualizar(It.IsAny<Empresa>()), Times.Once());
            Assert.Equal(0, mensagens.Count);
        }

        [Fact]
        public void NaoDeveAtualizarEmpresaComNomeInvalido()
        {
            EmpresaDto empresaDto = new EmpresaDto
            {
                Nome = "",
                CNPJ = "87717167000156",
                Inativo = false
            };
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Atualizar(It.IsAny<Empresa>()));
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Atualizar(empresaDto, 1);

            _empresaRepositoryMock.Verify(mock => mock.Atualizar(It.IsAny<Empresa>()), Times.Never());
            Assert.Equal(1, mensagens.Count);
            Assert.Equal("Empresa invalida", mensagens[0]);
        }

        [Fact]
        public void NaoDeveAtualizarEmpresaComCNPJInvalido()
        {
            EmpresaDto empresaDto = new EmpresaDto
            {
                Nome = "Db1",
                CNPJ = "",
                Inativo = false
            };
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Atualizar(It.IsAny<Empresa>()));
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Atualizar(empresaDto, 1);

            _empresaRepositoryMock.Verify(mock => mock.Atualizar(It.IsAny<Empresa>()), Times.Never());
            Assert.Equal(1, mensagens.Count);
            Assert.Equal("Empresa invalida", mensagens[0]);
        }

        [Fact]
        public void NaoDeveAtualizarQuandoEmpresaNaoExistir()
        {
            EmpresaDto empresaDto = new EmpresaDto
            {
                Nome = "Db1",
                CNPJ = "87717167000156",
                Inativo = false
            };
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Atualizar(It.IsAny<Empresa>())).Throws<Exception>();
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Atualizar(empresaDto, 1);

            _empresaRepositoryMock.Verify(mock => mock.Atualizar(It.IsAny<Empresa>()), Times.Once());
            Assert.Equal(1, mensagens.Count);
        }

        [Fact]
        public void DeveInativarEmpresa()
        {
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Inativar(It.IsAny<int>()));
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Inativar(1);

            _empresaRepositoryMock.Verify(mock => mock.Inativar(It.IsAny<int>()), Times.Once());
            Assert.Equal(0, mensagens.Count);
        }

        [Fact]
        public void NaoDeveInativarQuandoEmpresaNaoExistir()
        {
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.Inativar(It.IsAny<int>())).Throws<Exception>();
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var mensagens = empresaService.Inativar(1);

            _empresaRepositoryMock.Verify(mock => mock.Inativar(It.IsAny<int>()), Times.Once());
            Assert.Equal(1, mensagens.Count);
        }

        [Fact]
        public void DeveObterEmpresaPorId()
        {
            Empresa empresa = new Empresa("Db1", new CNPJ("87717167000156"));
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(empresa);
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var empresaRecebida = empresaService.ObterPorId(1);

            _empresaRepositoryMock.Verify(mock => mock.ObterPorId(It.IsAny<int>()), Times.Once());
            Assert.Equal(empresa, empresaRecebida);
        }

        [Fact]
        public void DeveRetornarVazioQuandoNaoEncontraEmpresa()
        {
            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns((Empresa)null);
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var cargoRecebido = empresaService.ObterPorId(1);

            _empresaRepositoryMock.Verify(mock => mock.ObterPorId(It.IsAny<int>()), Times.Once());
            Assert.Null(cargoRecebido);
        }

        [Fact]
        public void DeveRetornarTodosCargos()
        {
            IList<Empresa> listaCargos = new List<Empresa>();
            listaCargos.Add(new Empresa("DB1",new CNPJ("87717167000156")));
            listaCargos.Add(new Empresa("BeBlue",new CNPJ("87717167000156")));

            _empresaRepositoryMock = new Mock<IEmpresaRepository>();
            _empresaRepositoryMock.Setup(mock => mock.ObterTodos()).Returns(listaCargos);
            IEmpresaService empresaService = new EmpresaService(_empresaRepositoryMock.Object);

            var cargoRecebido = empresaService.ObterTodos();

            _empresaRepositoryMock.Verify(mock => mock.ObterTodos(), Times.Once());
            Assert.NotNull(cargoRecebido);
            Assert.Equal(2, cargoRecebido.Count);
        }
    }
}
