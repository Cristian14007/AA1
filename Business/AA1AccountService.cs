using AA1.Data;
using AA1.Models;

namespace AA1.Business
{
   public class AA1AccountService : IAA1AccountService
{
    private readonly IAA1AccountRepository _usuarioRepository;

    public AA1AccountService(IAA1AccountRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

        public void RegistrarUsuario(AA1Account nuevoUsuario)
    {
        // Aquí puedes añadir lógica para validar el nuevo usuario
        // Por ejemplo, verificar que el nombre de usuario no esté ya en uso
        var usuarioExistente = _usuarioRepository.FindUsuarioByUsername(nuevoUsuario.Username);
        if (usuarioExistente != null)
        {
            throw new InvalidOperationException("El nombre de usuario ya está en uso.");
        }

        // Agregar más validaciones según sea necesario

        _usuarioRepository.AddUsuario(nuevoUsuario);
    }

    public AA1Account ObtenerUsuarioPorNombre(string username)
    {
        return _usuarioRepository.FindUsuarioByUsername(username);
    }

    // Aquí puedes añadir más métodos según tus necesidades, como:
    // - Actualizar información del usuario
    // - Eliminar un usuario
    // - Validar credenciales del usuario
    // - etc.
}
}