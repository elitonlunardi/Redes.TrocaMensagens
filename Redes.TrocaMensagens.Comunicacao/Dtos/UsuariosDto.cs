namespace Redes.TrocaMensagens.Comunicacao.Dtos;

public class UsuariosDto
{
    public IEnumerable<UsuarioDto> Usuarios { get; set; }

    public UsuariosDto(string retorno)
    {
        var usuariosString = retorno.Split('\n');

        var usuarios = usuariosString.Select(x =>
        {
            var dados = x.Split(':');

            return new UsuarioDto
            {
                UserId = dados[0],
                Username = dados[1]
            };
        });

        Usuarios = usuarios;
    }
}