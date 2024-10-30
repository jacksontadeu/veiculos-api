using Veiculos.Dominio.DTOs;

namespace Veiculos.Dominio.Validacao;

public class ValidaVeiculo
{
    public MensagemDeErro ValidaDTO(VeiculoDTO veiculoDTO)
    {
        var validacao = new MensagemDeErro
        {
            Mensagens = new List<string>()
        };
        
        if (string.IsNullOrEmpty(veiculoDTO.Nome))
            validacao.Mensagens.Add("O nome não pode ser vazio");
        if (string.IsNullOrEmpty(veiculoDTO.Nome))
            validacao.Mensagens.Add("A marca não pode ser em branco");
        DateTime ano = DateTime.Now;
        
        if (ano.Year < veiculoDTO.Ano || ano.Year < 1950)
            validacao.Mensagens.Add("O ano de fabricação do veiculo é inválido, deve ser maior que 1950 ou igual ou maior que o ano atual");

        return validacao;

    }
}