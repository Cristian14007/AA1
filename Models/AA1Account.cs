namespace AA1.Models;

using System.Text;
public class AA1Account
{
    // Identificador único del usuario
    public int ID { get; set; }

    // Nombre de usuario
    public string Username { get; set; }

    // Correo electrónico del usuario
    public string Email { get; set; }

    // Contraseña del usuario (en una aplicación real, debería estar encriptada)
    public string Password { get; set; }

    // Fecha de creación de la cuenta
    public DateTime CreatedAt { get; set; }

    // Indica si el usuario tiene privilegios administrativos
    public bool IsAdmin { get; set; }

    // Constructor vacío
    public AA1Account() { }

    // Constructor con todos los campos
    public AA1Account(int id, string username, string email, string password, DateTime createdAt, bool isAdmin)
    {
        ID = id;
        Username = username;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        IsAdmin = isAdmin;
    }

    // Métodos adicionales como validaciones, etc., pueden ser agregados aquí
}
