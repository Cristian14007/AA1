using AA1.Models; // Asegúrate de incluir el espacio de nombres correcto
using AA1.Data;
namespace AA1.Business
{
public class ReservaService
{
    private readonly IReservaRepository _reservaRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IAA1AccountRepository _usuarioRepository;

    public ReservaService(IReservaRepository reservaRepository, IHotelRepository hotelRepository, IAA1AccountRepository usuarioRepository)
    {
        _reservaRepository = reservaRepository;
        _hotelRepository = hotelRepository;
        _usuarioRepository = usuarioRepository;
    }

   public void CrearReserva(Reserva nuevaReserva, string username)
{
    // Validar que el usuario exista
    var usuario = _usuarioRepository.FindUsuarioByUsername(username);
    if (usuario == null)
    {
        throw new InvalidOperationException("Usuario no encontrado.");
    }

        // Validar que el hotel exista
        var hotel = _hotelRepository.FindHotelById(nuevaReserva.HotelID);
        if (hotel == null)
        {
            throw new InvalidOperationException("Hotel no encontrado.");
        }

        // Validar fechas de la reserva, etc.

        // Agregar la reserva
        _reservaRepository.AddReserva(nuevaReserva);
    }

    public Reserva ObtenerReservaPorId(int id)
    {
        return _reservaRepository.FindReservaById(id);
    }

    public IEnumerable<Reserva> ObtenerReservasPorUsuario(int userId)
    {
        return _reservaRepository.FindReservasByUserId(userId);
    }

    // Aquí puedes añadir más métodos según tus necesidades, como:
    // - Actualizar una reserva
    // - Cancelar una reserva
    // - etc.
}
}