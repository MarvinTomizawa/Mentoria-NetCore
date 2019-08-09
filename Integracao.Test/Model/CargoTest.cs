using Integracao.Models.Entities;
using System;
using Xunit;

namespace Integracao.Test
{
    public class CargoTest
    {
        [Fact]
        public void DeveCriarUmCargoValido()
        {
            Cargo cargo = new Cargo("Tester");

            Assert.True(cargo.Validar());
            Assert.Equal("Tester", cargo.Descricao);
            Assert.False(cargo.Inativo);
        }

        [Fact]
        public void NaoDeveCriarUmCargoInvalidoCurto()
        {
            Cargo cargo = new Cargo("");

            Assert.False(cargo.Validar());
        }

        [Fact]
        public void NaoDeveCriarUmCargoInvalidoLongo()
        {
            Cargo cargo = new Cargo("12345678901234567890");

            Assert.False(cargo.Validar());
        }

    }
}
