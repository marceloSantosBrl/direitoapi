using Dapper;
using direitoapi.Modelos;
using Npgsql;

namespace direitoapi.Repository;

public class EmpresaRepository
{
    private string _connection;
    
    public EmpresaRepository(IConfiguration configuration)
    {
        _connection = configuration.GetConnectionString("DefaultConnection") ?? 
                      throw new InvalidOperationException();
    }

    public async Task<ICollection<Empresa>> GetAllEmpresas()
    {
        await using var connection = new NpgsqlConnection(_connection);
        const string query = "SELECT * FROM empresa";
        return (await connection.QueryAsync<Empresa>(query)).ToList();
    }

    public async Task<int> AddEmpresas(Empresa empresa)
    {
        await using var connection = new NpgsqlConnection(_connection);
        const string query = "INSERT INTO empresa VALUES (@Id , @Nome, " +
                             "@Cnpj, @GerenteNome, @Sobrenome, @Endereco, @NaturezaJuridica," +
                             "@AtividadeEconomica, @Telefone, @Email)";
        object[] parameters = { new
        {
            Id = empresa.Id,
            Nome = empresa.Nome, Cnpj = empresa.Cnpj, GerenteNome = empresa.GerenteNome,
            Sobrenome = empresa.Sobrenome, Endereco = empresa.Endereco, NaturezaJuridica = empresa.NaturezaJuridica,
            AtividadeEconomica = empresa.AtividadeEconomica, Telefone = empresa.Telefone, Email = empresa.Email
        } };
        return await connection.ExecuteAsync(query, parameters);
    }
}