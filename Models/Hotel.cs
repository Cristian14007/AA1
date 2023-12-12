namespace AA1.Models;

using System.Text;
using System.Text.Json;

public class Hotel
{

    public int ID { get; set; }


    public string Nombre { get; set; }


    public string Direccion { get; set; }


    public int Calificacion { get; set; }


    public string Descripcion { get; set; }


    public string Telefono { get; set; }

    public string FechaDisponible { get; set; }

    public string FechaDisponible_2 { get; set; }


    public Hotel() { }


    public Hotel(int id, string nombre, string direccion, int calificacion, string descripcion, string telefono, string fechadisponible, string fechadisponible_2)
    {
        ID = id;
        Nombre = nombre;
        Direccion = direccion;
        Calificacion = calificacion;
        Descripcion = descripcion;
        Telefono = telefono;
        FechaDisponible = fechadisponible;
        FechaDisponible_2 = fechadisponible_2;
    }

    public static List<Hotel> GetHotels()
    {
        string fileName = "Hotel.json";
        if (File.Exists(fileName))
        {
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Hotel>>(jsonString);
        }
        else
        {
            return new List<Hotel>();
        }
    }
}
