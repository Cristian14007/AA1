using AA1.Models;
using AA1.Data;
using AA1.Business;
using AA1.Presentation;
//using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using Spectre.Console;


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


           


           
            var accounts = new Dictionary<string, AA1Account>();


            string fileName = "AA1Account.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                accounts = JsonSerializer.Deserialize<Dictionary<string, AA1Account>>(jsonString);
            }


            bool salir = false;
            while (!salir)
            {
/* var rule = new Rule("[red]Booking[/]");
AnsiConsole.Write(rule); */


AnsiConsole.Write(
    new FigletText("Booking")
        .Centered()
        .Color(Color.Blue));
                //Console.WriteLine("\nBienvenido a Booking");
                Console.WriteLine("1. Crear una Cuenta");
                Console.WriteLine("2. Ver hoteles");
                Console.WriteLine("3. Reservar hoteles");
                Console.WriteLine("4. Ver reservas por usuario");
                Console.WriteLine("5. Buscar hotel por calificación");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Select an option: ");


                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese nombre de usuario: ");
                        string username = Console.ReadLine();
                        Console.Write("Ingrese email: ");
                        string email = Console.ReadLine();
                        Console.Write("Ingrese contraseña: ");
                        string password = Console.ReadLine();


                        AA1Account newAccount = new AA1Account(username, email, password);
                        accounts.Add(newAccount.ID, newAccount);
                        Console.WriteLine($"Cuenta creada por {username} con contraseña {password}.");
                        SaveAccountsToFile(accounts);
                        //CrearUsuario();
                        break;
                    case "2":
                        Console.WriteLine("Esta es la lista de hoteles.");




                       
                        DisplayHotels();
                        //VerHoteles();
                        break;


                    case "3":
                        MakeReservation();
                        break;


                    case "4":
                        Console.Write("Ingrese el nombre de usuario para ver sus reservas: ");
                        var userName = Console.ReadLine();


                        var users = AA1Account.GetUserAccounts();
                        var user = users.Values.FirstOrDefault(u => u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase));
                        if (user == null)
                        {
                            Console.WriteLine("Usuario no encontrado.");
                            break;
                        }


                        DisplayUserReservations(user.ID);
                        break;


                    case "5":
                        Console.Write("Ingrese la calificación del 1 al 5 deseada para el hotel : ");
                        if (!int.TryParse(Console.ReadLine(), out int calificacionDeseada))
                        {
                            Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
                            break;
                        }


                        DisplayHotelsByRating(calificacionDeseada);
                        break;


                    case "6":
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
            string password = Console.ReadLine();


            // Crear el usuario
            AA1Account nuevoUsuario = new AA1Account
            {
                Username = username,
                Email = email,
                Password = password,
                CreatedAt = DateTime.Now,
                IsAdmin = false
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




        /*static void VerHoteles()
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
        }*/
        private static void DisplayHotels()
        {
            var hoteles = Hotel.GetHotels();


        var table = new Table();
        table.AddColumn("Nombre");
        table.AddColumn("Direccion");
        table.AddColumn("Calificacion");
        table.AddColumn("Descripcion");
        table.AddColumn("Telefono");


        foreach (var hotel in hoteles)
        {
            table.AddRow(
                hotel.Nombre,
                hotel.Direccion,
                hotel.Calificacion.ToString(),
                hotel.Descripcion,
                hotel.Telefono
            );


            table.AddEmptyRow();
        }


        AnsiConsole.Render(table);
        }
        private static void DisplayHotels2()
        {


            var table = new Table();
                table.AddColumn("Nombre");
                table.AddColumn("Direccion");
                table.AddColumn("Calificacion");




            var hotels = Hotel.GetHotels();
            foreach (var hotel in hotels)
            {
                /* Console.WriteLine($"ID: {hotel.ID}, Nombre: {hotel.Nombre}"); */
                table.AddRow(
                   
                hotel.Nombre,
                hotel.Direccion,
                hotel.Calificacion.ToString()
            );


            table.AddEmptyRow();
            }


            AnsiConsole.Render(table);
        }




        private static void MakeReservation()
        {
            Console.Write("Ingrese su nombre de usuario: ");
            var username = Console.ReadLine();


            var users = AA1Account.GetUserAccounts();
            var user = users.Values.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                return;
            }


            DisplayHotels2();
            Console.Write("Seleccione el número del hotel que desea reservar: ");
            if (!int.TryParse(Console.ReadLine(), out int hotelChoice))
            {
                Console.WriteLine("Selección inválida.");
                return;
            }


            var hotels = Hotel.GetHotels();
            if (hotelChoice < 1 || hotelChoice > hotels.Count)
            {
                Console.WriteLine("Selección de hotel inválida.");
                return;
            }
            var existingReservations = Reserva.GetReservas();
            int newReservationId = 0;
            if (existingReservations.Any())
            {
                newReservationId = existingReservations.Max(r => r.ID) + 1;
            }
            var selectedHotel = hotels[hotelChoice - 1];
            var reserva = new Reserva
            {
                ID = newReservationId,
                UserID = int.Parse(user.ID),
                HotelID = selectedHotel.ID,
                FechaReserva = DateTime.Now,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(1)
            };


            Reserva.SaveReservation(reserva);
            var rule = new Rule("[blue]Reserva realizada con éxito[/]");
            AnsiConsole.Write(rule);
        }






        private static void DisplayUserReservations(string userIdString)
        {
            if (!int.TryParse(userIdString, out int userId))
            {
                Console.WriteLine("El ID del usuario no es válido.");
                return;
            }
           
            var reservations = Reserva.GetReservas();
            var userReservations = reservations.Where(r => r.UserID == userId).ToList();


            if (!userReservations.Any())
            {
                Console.WriteLine("No hay reservas para este usuario.");
                return;
            }


            foreach (var reserva in userReservations)
            {
                Console.WriteLine($"Reserva: Hotel: {reserva.HotelID}, Fecha de Reserva: {reserva.FechaReserva}");
             
            }
        }


        private static void DisplayHotelsByRating(int rating)
        {
            var hotels = Hotel.GetHotels();
            var filteredHotels = hotels.Where(hotel => hotel.Calificacion == rating).ToList();


            var table_2 = new Table();
                table_2.AddColumn("Nombre");
                table_2.AddColumn("Calificación");
                table_2.AddColumn("Direccion");
                table_2.AddColumn("Descripcion");


            if (!filteredHotels.Any())
            {
                Console.WriteLine($"No hay hoteles con una calificación de {rating}.");
                return;
            }


            foreach (var hotel in filteredHotels)
            {
                /*Console.WriteLine($"ID: {hotel.ID}, Nombre: {hotel.Nombre}, Calificación: {hotel.Calificacion}");*/
                table_2.AddRow(
                hotel.Nombre,
                hotel.Calificacion.ToString(),
                hotel.Direccion,
                hotel.Descripcion
            );


            table_2.AddEmptyRow();
            }
            AnsiConsole.Render(table_2);
        }


        static void SaveAccountsToFile(Dictionary<string, AA1Account> accounts)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = "AA1Account.json";
            string jsonString = JsonSerializer.Serialize(accounts, options);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
