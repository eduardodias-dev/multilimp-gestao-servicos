using AutoMapper;
using GestaoServicos.Domain.Entities;
using GestaoServicos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoServicos.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CriarMapeamentos();
        }

        public void CriarMapeamentos()
        {
            CreateMap<Cliente, CriarClienteModel>();
            CreateMap<CriarClienteModel, Cliente>();
            CreateMap<AtualizarClienteModel, Cliente>();
            CreateMap<Cliente, AtualizarClienteModel>();

            CreateMap<OrdemServico, CriarOrdemServicoModel>();
            CreateMap<CriarOrdemServicoModel, OrdemServico>();

            CreateMap<Telefone, CriarTelefoneModel>();
            CreateMap<CriarTelefoneModel, Telefone>();

            CreateMap<CriarEnderecoModel, Endereco>();

            CreateMap<OrdemServico, VisualizarOrdemServicoModel>()
                    .ForMember(x => x.Telefone, x => x.MapFrom(y => y.Cliente.Telefone))
                    .ForMember(x => x.Endereco, x => x.MapFrom(y => y.Cliente.Endereco));

            CreateMap<Telefone, VisualizarTelefoneModel>();
            CreateMap<Endereco, VisualizarEnderecoModel>();


        }
    }
}
