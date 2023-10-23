using AutoMapper;
using direitoapi.Dto;
using direitoapi.Modelos;

namespace direitoapi.MappingProfiles;

public class MainProfile: Profile
{
    public MainProfile()
    {
        CreateMap<Empresa, EmpresaResponse>();
    }
}