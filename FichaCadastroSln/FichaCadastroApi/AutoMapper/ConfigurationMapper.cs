using AutoMapper;
using FichaCadastroApi.DTO.Ficha;
using FichaCadastroApi.Model;

namespace FichaCadastroApi.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            CreateMap<FichaModel, FichaReadDTO>()
                 .ForMember(dest => dest.PrimeiroNome, opt => opt.MapFrom(src => src.Nome.Split(' ', StringSplitOptions.None)[0]))
                 .ForMember(dest => dest.SegundoNome, opt => opt.MapFrom(src => src.Nome.Split(' ', StringSplitOptions.None)[1]))
                 .ForMember(dest => dest.FichaComDetalhes, opt => opt.MapFrom(src => src.Detalhes));

            CreateMap<FichaCreateDTO, FichaModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeCompleto))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailInformado.ToLower()))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataDeNascimento));

            CreateMap<FichaUpdateDTO, FichaModel>();

            CreateMap<DetalheModel, FichaDetalheReadDTO>()
                .ForMember(dest => dest.Numero, origem => origem.MapFrom(src => src.Nota));
        }
    }
}
