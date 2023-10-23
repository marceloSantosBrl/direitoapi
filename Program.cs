using direitoapi.Modelos;
using direitoapi.Repository;
using direitoapi.Service;
using Microsoft.AspNetCore.Mvc;

namespace direitoapi;

internal class DireitoApi
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddScoped<EmpresaRepository>();
        builder.Services.AddScoped<IEmpresaService, EmpresaService>();
        
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        var app = builder.Build();
        app.MapGet("/empresa", async (IEmpresaService service) => await service.GetAllEmpresas());
        app.MapPost("/empresa",  async ([FromServices] IEmpresaService service, [FromBody] Empresa empresa) => await service.AddEmpresa(empresa));
        app.Run();
    }
}
