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


    public Hotel() { }


    public Hotel(int id, string nombre, string direccion, int calificacion, string descripcion, string telefono)
    {
        ID = id;
        Nombre = nombre;
        Direccion = direccion;
        Calificacion = calificacion;
        Descripcion = descripcion;
        Telefono = telefono;
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
