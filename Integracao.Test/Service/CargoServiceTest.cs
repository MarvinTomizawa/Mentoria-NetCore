using Integracao.Data.Interfaces;
using Integracao.Models.Entities;
using Integracao.Services;
using Integracao.Utils;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Integracao.Test.Service
{
    public class CargoServiceTest
    {
        private Mock<ICargoRepository> _cargoRepositoryMock;

        [Fact]
        public void DeveAdicionarNovoCargo()
        {
            Cargo cargo = new Cargo("Tester");
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Cargo>()));
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var mensagens = cargoService.Adicionar(cargo.Mapear());

            _cargoRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Cargo>()), Times.Once());
            Assert.Equal(0, mensagens.Count);
        }

        [Fact]
        public void NaoDeveAdicionarCargoInvalido()
        {
            Cargo cargo = new Cargo("");
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.Adicionar(It.IsAny<Cargo>()));
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var mensagens = cargoService.Adicionar(cargo.Mapear());

            _cargoRepositoryMock.Verify(mock => mock.Adicionar(It.IsAny<Cargo>()), Times.Never());
            Assert.Equal(1, mensagens.Count);
            Assert.Equal("Cargo invalido", mensagens[0]);
        }

        [Fact]
        public void DeveAtualizarCargo()
        {
            Cargo cargo = new Cargo("Tester");
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.Atualizar(It.IsAny<Cargo>()));
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var mensagens = cargoService.Atualizar(cargo.Mapear(), cargo.Id);

            _cargoRepositoryMock.Verify(mock => mock.Atualizar(It.IsAny<Cargo>()), Times.Once());
            Assert.Equal(0, mensagens.Count);
        }

        [Fact]
        public void NaoDeveAtualizarCargoInvalido()
        {
            Cargo cargo = new Cargo("");
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.Atualizar(It.IsAny<Cargo>()));
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var mensagens = cargoService.Atualizar(cargo.Mapear(), cargo.Id);

            _cargoRepositoryMock.Verify(mock => mock.Atualizar(It.IsAny<Cargo>()), Times.Never());
            Assert.Equal(1, mensagens.Count);
            Assert.Equal("Cargo invalido", mensagens[0]);
        }

        [Fact]
        public void NaoDeveAtualizarQuandoCargoNaoExistir()
        {
            Cargo cargo = new Cargo("Tester");
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.Atualizar(It.IsAny<Cargo>())).Throws<Exception>();
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var mensagens = cargoService.Atualizar(cargo.Mapear(), cargo.Id);

            _cargoRepositoryMock.Verify(mock => mock.Atualizar(It.IsAny<Cargo>()), Times.Once());
            Assert.Equal(1, mensagens.Count);
        }

        [Fact]
        public void DeveInativarCargo()
        {
            Cargo cargo = new Cargo("Tester");
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.Inativar(It.IsAny<int>()));
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var mensagens = cargoService.Inativar(cargo.Id);

            _cargoRepositoryMock.Verify(mock => mock.Inativar(It.IsAny<int>()), Times.Once());
            Assert.Equal(0, mensagens.Count);
        }

        [Fact]
        public void NaoDeveInativarQuandoCargoNaoExistir()
        {
            Cargo cargo = new Cargo("Tester");
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.Inativar(It.IsAny<int>())).Throws<Exception>();
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var mensagens = cargoService.Inativar(cargo.Id);

            _cargoRepositoryMock.Verify(mock => mock.Inativar(It.IsAny<int>()), Times.Once());
            Assert.Equal(1, mensagens.Count);
        }

        [Fact]
        public void DeveObterCargoPorId()
        {
            Cargo cargo = new Cargo("Tester");
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns(cargo);
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var cargoRecebido = cargoService.ObterPorId(cargo.Id);

            _cargoRepositoryMock.Verify(mock => mock.ObterPorId(It.IsAny<int>()), Times.Once());
            Assert.Equal(cargo, cargoRecebido);
        }

        [Fact]
        public void DeveRetornarVazioQuandoNaoEncontraCargo()
        {
            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.ObterPorId(It.IsAny<int>())).Returns((Cargo) null);
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var cargoRecebido = cargoService.ObterPorId(1);

            _cargoRepositoryMock.Verify(mock => mock.ObterPorId(It.IsAny<int>()), Times.Once());
            Assert.Null(cargoRecebido);
        }

        [Fact]
        public void DeveRetornarTodosCargos()
        {
            IList<Cargo> listaCargos = new List<Cargo>();
            listaCargos.Add(new Cargo("Tester"));
            listaCargos.Add(new Cargo("Dev"));

            _cargoRepositoryMock = new Mock<ICargoRepository>();
            _cargoRepositoryMock.Setup(mock => mock.ObterTodos()).Returns(listaCargos);
            ICargoService cargoService = new CargoService(_cargoRepositoryMock.Object);

            var cargoRecebido = cargoService.ObterTodos();

            _cargoRepositoryMock.Verify(mock => mock.ObterTodos(), Times.Once());
            Assert.NotNull(cargoRecebido);
            Assert.Equal(2, cargoRecebido.Count);
        }

    }
}
