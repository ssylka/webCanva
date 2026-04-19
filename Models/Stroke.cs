using System.Text.Json;

namespace DrowingTogether.Models
{
    public class Stroke
    {
        public Guid Id { get; set; }
        public Guid BoardId { get; set; }

        public string Color { get; set; }
        public int Size { get; set; }
        public string PointsJson { get; set; }
    }
}