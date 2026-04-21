using DrowingTogether.Data;
using DrowingTogether.Models;
using System.Text.Json;

namespace DrowingTogether.Services
{
    public class ShapeService
    {
        private readonly AppDbContext _context;

        public ShapeService(AppDbContext context)
        {
            _context = context;
        }

        public void Save(Guid boardId, string type, string color, int size, object data)
        {
            var shape = new Shape
            {
                Id = Guid.NewGuid(),
                BoardId = boardId,
                Type = type,
                Color = color,
                Size = size,
                DataJson = JsonSerializer.Serialize(data)
            };

            _context.Shapes.Add(shape);
            _context.SaveChanges();
        }

        public List<Shape> GetByBoard(Guid boardId)
        {
            return _context.Shapes.Where(s => s.BoardId == boardId).ToList();
        }
    }
}