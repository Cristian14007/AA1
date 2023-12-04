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

            var usuarioExistente = _usuarioRepository.FindUsuarioByUsername(nuevoUsuario.Username);
            if (usuarioExistente != null)
            {
                throw new InvalidOperationException("El nombre de usuario ya está en uso.");
            }



            _usuarioRepository.AddUsuario(nuevoUsuario);
        }

        public AA1Account ObtenerUsuarioPorNombre(string username)
        {
            return _usuarioRepository.FindUsuarioByUsername(username);
        }


    }
}