using AutoMapper;
using direitoapi.Dto;
using direitoapi.Modelos;
using direitoapi.Repository;

namespace direitoapi.Service;

public class EmpresaService: IEmpresaService
{
    private readonly EmpresaRepository _empresaRepository;
    private readonly IMapper _mapper;

    public EmpresaService(EmpresaRepository empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository ?? throw new ArgumentNullException(nameof(empresaRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public async Task<ICollection<EmpresaResponse>> GetAllEmpresas()
    {
        var models = await _empresaRepository.GetAllEmpresas();
        var response = _mapper.Map<List<EmpresaResponse>>(models);
        return response;
    }

    public async Task AddEmpresa(Empresa empresa)
    {
        var models = await _empresaRepository.AddEmpresas(empresa);
    }
}