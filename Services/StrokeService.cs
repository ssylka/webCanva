using DrowingTogether.Data;
using DrowingTogether.Models;
using System.Text.Json;

namespace DrowingTogether.Services
{
    public class StrokeService
    {
        private readonly AppDbContext _db;

        public StrokeService(AppDbContext db)
        {
            _db = db;
        }

        public void SaveStroke(Guid boardId, string color, int size, List<Data.Dto.PointDto> points)
        {
            var stroke = new Stroke
            {
                BoardId = boardId,
                Color = color,
                Size = size,
                PointsJson = JsonSerializer.Serialize(points)
            };

            _db.Strokes.Add(stroke);
            _db.SaveChanges();
        }

        public List<Stroke> GetByBoard(Guid boardId)
        {
            return _db.Strokes.Where(s => s.BoardId == boardId).ToList();
        }
    }
}
