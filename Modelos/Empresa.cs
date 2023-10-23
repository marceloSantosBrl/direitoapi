namespace direitoapi.Modelos;

public class Empresa
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Cnpj { get; set; }
    public required string GerenteNome { get; set; }
    public required string Sobrenome { get; set; }
    public required string Endereco { get; set; }
    public required string NaturezaJuridica { get; set; }
    public required string AtividadeEconomica { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
}