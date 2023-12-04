using AA1.Models;
using AA1.Data;
namespace AA1.Business
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        /* public IEnumerable<Hotel> GetAllHoteles()
       {
           return _hotelRepository.GetAllHoteles();
       }

       public void AgregarHotel(Hotel nuevoHotel)
       {
           // Aquí puedes añadir lógica para validar el nuevo hotel
           // Por ejemplo, verificar que el ID del hotel no esté ya en uso
           var hotelExistente = _hotelRepository.FindHotelById(nuevoHotel.ID);
           if (hotelExistente != null)
           {
               throw new InvalidOperationException("El ID del hotel ya está en uso.");
           }

           // Agregar más validaciones según sea necesario

           _hotelRepository.AddHotel(nuevoHotel);
       }

       public Hotel ObtenerHotelPorId(int id)
       {
           return _hotelRepository.FindHotelById(id);
       }*/


    }
}