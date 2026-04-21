using System.Text.Json;

namespace DrowingTogether.Models
{
    public class Shape
    {
        public Guid Id { get; set; }
        public Guid BoardId { get; set; }

        public string Type { get; set; } // pen, rect, circle, square, text
        public string Color { get; set; }
        public int Size { get; set; }

        public string DataJson { get; set; } // универсальные данные
    }
}