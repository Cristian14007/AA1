namespace AA1.Models;

using System.Text;
using System.Text.Json;
public class Reserva
{

    public int ID { get; set; }


    public int UserID { get; set; }


    public int HotelID { get; set; }


    public DateTime FechaReserva { get; set; }


    public string FechaInicio { get; set; }

    public string FechaFin { get; set; }


    public Reserva() { }


    public Reserva(int id, int userID, int hotelID, DateTime fechaReserva, string fechaInicio, string fechaFin)
    {
        ID = id;
        UserID = userID;
        HotelID = hotelID;
        FechaReserva = fechaReserva;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
    }

    public static void SaveReservation(Reserva reserva)
    {
        var reservas = GetReservas();
        reservas.Add(reserva);
        string jsonString = JsonSerializer.Serialize(reservas, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("reserva.json", jsonString);
    }
    public static List<Reserva> GetReservas()
    {
        string fileName = "reserva.json";
        if (File.Exists(fileName) && new FileInfo(fileName).Length > 0)
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Reserva>>(jsonString) ?? new List<Reserva>();
        }
        else
        {
            return new List<Reserva>();
        }
    }




}