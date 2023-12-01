public class Hotel
{
    // Identificador único del hotel
    public int ID { get; set; }

    // Nombre del hotel
    public string Nombre { get; set; }

    // Dirección del hotel
    public string Direccion { get; set; }

    // Calificación del hotel (por ejemplo, en estrellas)
    public int Calificacion { get; set; }

    // Descripción breve del hotel
    public string Descripcion { get; set; }

    // Número de teléfono para contactar al hotel
    public string Telefono { get; set; }

    // Constructor vacío
    public Hotel() { }

    // Constructor con todos los campos
    public Hotel(int id, string nombre, string direccion, int calificacion, string descripcion, string telefono)
    {
        ID = id;
        Nombre = nombre;
        Direccion = direccion;
        Calificacion = calificacion;
        Descripcion = descripcion;
        Telefono = telefono;
    }

    // Métodos adicionales y lógica del negocio pueden ser agregados aquí
}
