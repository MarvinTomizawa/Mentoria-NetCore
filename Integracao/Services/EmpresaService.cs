using Integracao.Data.Interfaces;
using Integracao.Dto;
using Integracao.Models.Entities;
using Integracao.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integracao.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        IList<string> mensagens;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public IList<string> Adicionar(EmpresaDto obj)
        {
            mensagens = new List<string>();

            Empresa empresa = EmpresaAdapter.Mapear(obj);

            if (!empresa.Validar())
            {
                mensagens.Add("Empresa invalida");
            }

            try
            {
                if (mensagens.Count == 0){
                    _empresaRepository.Adicionar(empresa);
                }
            }
            catch (Exception e)
            {
                mensagens.Add(e.Message);
            }

            return mensagens;

        }

        public IList<string> Atualizar(EmpresaDto obj, int id)
        {
            mensagens = new List<string>();

            Empresa empresa = EmpresaAdapter.Mapear(obj, id);

            if (!empresa.Validar())
            {
                mensagens.Add("Empresa invalida");
            }

            try
            {
                if (mensagens.Count == 0)
                {
                    _empresaRepository.Atualizar(empresa);
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
                _empresaRepository.Inativar(id);
            }catch(Exception e)
            {
                mensagens.Add(e.Message);
            }

            return mensagens;

        }

        public Empresa ObterPorId(int id)
        {
            return _empresaRepository.ObterPorId(id);
        }

        public IList<Empresa> ObterTodos()
        {
            return _empresaRepository.ObterTodos().ToList();
        }
    }
}
