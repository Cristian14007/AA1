using System.Text.Json;
using AA1.Models;
using Newtonsoft.Json;



namespace AA1.Data
{
    public class ReservaRepository : IReservaRepository
    {
        private Dictionary<int, Reserva> _reservas = new Dictionary<int, Reserva>();
        private readonly string _filePath = "Reservas.json";

        public ReservaRepository()
        {
            LoadReservasFromFile();
        }
        /*
            public void AddReserva(Reserva reserva)
            {
                if (!_reservas.ContainsKey(reserva.ID))
                {
                    _reservas[reserva.ID] = reserva;
                    SaveReservasToFile();
                }
                else
                {
                    throw new InvalidOperationException("La reserva ya existe.");
                }
            }

            public Reserva FindReservaById(int id)
            {
                if (_reservas.TryGetValue(id, out Reserva reserva))
                {
                    return reserva;
                }

                return null;
            }

            public IEnumerable<Reserva> FindReservasByUserId(int userId)
            {
                return _reservas.Values.Where(r => r.UserID == userId);
            }
        */
        private void LoadReservasFromFile()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _reservas = JsonConvert.DeserializeObject<Dictionary<int, Reserva>>(json) ?? new Dictionary<int, Reserva>();
            }
        }

        private void SaveReservasToFile()
        {
            string json = JsonConvert.SerializeObject(_reservas, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}