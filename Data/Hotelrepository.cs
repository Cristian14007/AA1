using System.Text.Json;
using AA1.Models;

namespace AA1.Data
{
    public class HotelRepository : IHotelRepository
    {
        private Dictionary<int, Hotel> _hoteles = new Dictionary<int, Hotel>();
        private readonly string _filePath = "Hotel.json";

        public HotelRepository()
        {
            LoadHotelesFromFile();
        }

        /*
            public void AddHotel(Hotel hotel)
            {
                if (!_hoteles.ContainsKey(hotel.ID))
                {
                    _hoteles[hotel.ID] = hotel;
                    SaveHotelesToFile();
                }
                else
                {
                    throw new InvalidOperationException("El hotel ya existe.");
                }
            }

            public Hotel FindHotelById(int id)
            {
                if (_hoteles.TryGetValue(id, out Hotel hotel))
                {
                    return hotel;
                }

                return null;
            }

            /*public IEnumerable<Hotel> GetAllHoteles()
            {
                return _hoteles.Values;
            }
        */
        private void LoadHotelesFromFile()
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                _hoteles = JsonSerializer.Deserialize<Dictionary<int, Hotel>>(jsonString) ?? new Dictionary<int, Hotel>();
            }
        }

        private void SaveHotelesToFile()
        {
            string jsonString = JsonSerializer.Serialize(_hoteles, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonString);
        }



    }
}