namespace Redes.TrocaMensagens.Comunicacao.Dtos;

public class UsuariosDto
{
    public IEnumerable<UsuarioDto> Usuarios { get; set; }

    public UsuariosDto(string retorno)
    {
        var usuariosString = retorno.Split(':');
        var usuarios = new List<UsuarioDto>();
        
        for (int i = 0; i < usuariosString.Length / 3; i++)
        {
            var dados = usuariosString.Skip(i * 3).Take(3).ToArray();

            usuarios.Add(new UsuarioDto
            {
                UserId = dados[0],
                Username = dados[1],
            });
        }

        Usuarios = usuarios;
    }
}