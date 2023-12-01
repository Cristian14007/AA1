using AA1.Models;
using AA1.Business;
using AA1.Data;
//using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace AA1.Presentation
{
class Program
{
    // Instancias de los repositorios
    static IAA1AccountRepository usuarioRepository = new AA1AccountRepository();
    static IHotelRepository hotelRepository = new HotelRepository();
    static IReservaRepository reservaRepository = new ReservaRepository();

    // Instancias de los servicios
    static AA1AccountService usuarioService = new AA1AccountService(usuarioRepository);
    static HotelService hotelService = new HotelService(hotelRepository);
    static ReservaService reservaService = new ReservaService(reservaRepository, hotelRepository, usuarioRepository);

    static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\nBienvenido a Booking");
            Console.WriteLine("1. Crear un usuario");
            Console.WriteLine("2. Ver hoteles");
            Console.WriteLine("3. Reservar hoteles");
            Console.WriteLine("4. Ver reservas por usuario");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    CrearUsuario();
                    break;
                case "2":
                    VerHoteles();
                    break;
                case "3":
                    ReservarHotel();
                    break;
                case "4":
                    VerReservasPorUsuario();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }

   static void CrearUsuario()
{
    Console.Write("Ingrese nombre de usuario: ");
    string username = Console.ReadLine();
    Console.Write("Ingrese email: ");
    string email = Console.ReadLine();
    Console.Write("Ingrese contraseña: ");
    string password = Console.ReadLine(); // Considera usar métodos seguros para manejar contraseñas

    // Crear el usuario (aquí podrías agregar validaciones adicionales)
    AA1Account nuevoUsuario = new AA1Account
    {
        Username = username,
        Email = email,
        Password = password, // En una aplicación real, la contraseña debe ser encriptada
        CreatedAt = DateTime.Now,
        IsAdmin = false // o determinar basado en la lógica de tu aplicación
    };

    try
    {
        usuarioService.RegistrarUsuario(nuevoUsuario);
        Console.WriteLine("Usuario creado con éxito.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al crear el usuario: {ex.Message}");
    }
}


    static void VerHoteles()
{
    try
    {
        var hoteles = hotelService.GetAllHoteles();
        if (hoteles.Any())
        {
            foreach (var hotel in hoteles)
            {
                Console.WriteLine($"ID: {hotel.ID}, Nombre: {hotel.Nombre}, Dirección: {hotel.Direccion}, Calificación: {hotel.Calificacion}, Teléfono: {hotel.Telefono}");
            }
        }
        else
        {
            Console.WriteLine("No hay hoteles disponibles.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al obtener la lista de hoteles: {ex.Message}");
    }
}


    static void ReservarHotel()
    {
        // Implementa la lógica para reservar un hotel utilizando reservaService
        Console.WriteLine("Reservar hotel (esta funcionalidad aún no está implementada).");
    }

    static void VerReservasPorUsuario()
    {
        // Implementa la lógica para mostrar reservas por usuario utilizando reservaService
        Console.WriteLine("Ver reservas por usuario (esta funcionalidad aún no está implementada).");
    }
}
}