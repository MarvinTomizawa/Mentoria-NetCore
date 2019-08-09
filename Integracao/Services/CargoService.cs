using Integracao.Data.Interfaces;
using Integracao.Dto;
using Integracao.Models.Entities;
using Integracao.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private IList<string> mensagens;
        public CargoService(ICargoRepository  cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public IList<string> Adicionar(CargoDto obj)
        {
            mensagens = new List<string>();

            var cargo = CargoAdapter.Mapear(obj);

            if (!cargo.Validar())
            {
                mensagens.Add("Cargo invalido");
            }

            try
            {
                if (mensagens.Count.Equals(0))
                {
                    _cargoRepository.Adicionar(cargo);
                }
            }catch(Exception e)
            {
                mensagens.Add(e.Message);
            }
            

            return mensagens;
        }

        public IList<string> Atualizar(CargoDto obj, int id)
        {
            mensagens = new List<string>();

            var cargo = CargoAdapter.Mapear(obj, id);

            if (!cargo.Validar())
            {
                mensagens.Add("Cargo invalido");
            }

            try
            {
                if (mensagens.Count.Equals(0))
                {
                    _cargoRepository.Atualizar(cargo);
                }
            }catch(Exception e)
            {
                mensagens.Add(e.Message);
            }

            return mensagens;
        }

        public IList<string> Inativar(int id)
        {
            mensagens = new List<string>();
            try
            {
                _cargoRepository.Inativar(id);
            }
            catch (Exception e)
            {
                mensagens.Add(e.Message);
            }

            return mensagens;

        }

        public Cargo ObterPorId(int id)
        {
            return _cargoRepository.ObterPorId(id);
        }

        public IList<Cargo> ObterTodos()
        {
            return _cargoRepository.ObterTodos().ToList();
        }
    }
}
