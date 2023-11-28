namespace AA1.Models;

public class Transaction
{
    // Identificador único de la transacción
    public int ID { get; set; }

    // Identificador del usuario que realiza la reserva
    public int UserID { get; set; }

    // Identificador del hotel reservado
    public int HotelID { get; set; }

    // Fecha en que se realiza la reserva
    public DateTime FechaReserva { get; set; }

    // Fecha de inicio de la estadía
    public DateTime FechaInicio { get; set; }

    // Fecha de fin de la estadía
    public DateTime FechaFin { get; set; }

    // Constructor vacío
    public Transaction() { }

    // Constructor con todos los campos
    public Transaction(int id, int userID, int hotelID, DateTime fechaReserva, DateTime fechaInicio, DateTime fechaFin)
    {
        ID = id;
        UserID = userID;
        HotelID = hotelID;
        FechaReserva = fechaReserva;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
    }

    public override string ToString()
    {
        return $"Transaction ID: {ID}\n" +
               $"User ID: {UserID}\n" +
               $"Hotel ID: {HotelID}\n" +
               $"Fecha de Reserva: {FechaReserva.ToString("dd/MM/yyyy")}\n" +
               $"Fecha de Inicio: {FechaInicio.ToString("dd/MM/yyyy")}\n" +
               $"Fecha de Fin: {FechaFin.ToString("dd/MM/yyyy")}";
    }

}
