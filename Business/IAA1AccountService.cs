using AA1.Models;
namespace AA1.Business
{
    public interface IAA1AccountService
    {
       void RegistrarUsuario(AA1Account nuevoUsuario);
        AA1Account ObtenerUsuarioPorNombre(string username);


    }
}
