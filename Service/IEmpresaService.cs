using direitoapi.Dto;
using direitoapi.Modelos;

namespace direitoapi.Service;

public interface IEmpresaService
{
    Task<ICollection<EmpresaResponse>> GetAllEmpresas();
    Task AddEmpresa(Empresa empresa);
}