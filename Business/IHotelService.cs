namespace AA1.Business
{
    public interface IHotelService
    {
      void AgregarHotel(Hotel nuevoHotel);
       public Hotel ObtenerHotelPorId(int id);
       IEnumerable<Hotel> GetAllHoteles();


    }
}
