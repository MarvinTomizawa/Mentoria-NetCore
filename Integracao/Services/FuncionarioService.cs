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
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IEmpresaRepository _empresaRepository;

        private readonly ICargoRepository _cargoRepository;

        private readonly IFuncionarioRepository _funcionarioRepository;

        private IList<string> mensagens;

        public FuncionarioService(IEmpresaRepository empresaRepository, ICargoRepository cargoRepository, IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
            _empresaRepository = empresaRepository;
        }

        public IList<string> Adicionar(FuncionarioDto obj)
        {
            mensagens = new List<string>();
            Funcionario funcionario;
            try
            {
                Cargo cargo = obterCargo(obj.CargoId);
                Empresa empresa = obterEmpresa(obj.EmpresaId);

                funcionario = FuncionarioAdapter.Mapear(obj, cargo, empresa);
                if (!funcionario.Validar())
                {
                    mensagens.Add("Funcionario invalido");
                }

                if (mensagens.Count == 0)
                {
                    _funcionarioRepository.Adicionar(funcionario);
                }
            }
            catch (Exception e)
            {
                mensagens.Add(e.Message);
            }

            return mensagens;
        }

        public IList<string> Atualizar(FuncionarioDto obj, int id)
        {
            mensagens = new List<string>();
            try
            {
                Cargo cargo = obterCargo(obj.CargoId);
                Empresa empresa = obterEmpresa(obj.EmpresaId);

                Funcionario funcionario = FuncionarioAdapter.Mapear(obj, cargo, empresa, id);

                if (!funcionario.Validar())
                {
                    mensagens.Add("Funcionario invalido");
                }

                if (mensagens.Count == 0)
                {
                    _funcionarioRepository.Atualizar(funcionario);
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
                _funcionarioRepository.Inativar(id);
            }catch(Exception e)
            {
                mensagens.Add(e.Message);
            }
            return mensagens;
        }

        public Funcionario ObterPorId(int id)
        {
            return _funcionarioRepository.ObterComCargoEEmpresaPorId(id);
        }

        public IList<Funcionario> ObterTodos()
        {
            return _funcionarioRepository.ObterTodosComCargoEEmpresa().ToList();
        }

        private Cargo obterCargo(int id)
        {
            Cargo cargo = _cargoRepository.ObterPorId(id);
            if (cargo != null)
            {
                return cargo;
            }
            mensagens.Add("Cargo não encontrado.");
            return null;
        }
        private Empresa obterEmpresa(int id)
        {
            Empresa empresa = _empresaRepository.ObterPorId(id);
            if (empresa != null)
            {
                return empresa;
            }
            mensagens.Add("Empresa não encontrado.");
            return null;
        }
    }
}
