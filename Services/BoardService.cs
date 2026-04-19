using DrowingTogether.Data;
using DrowingTogether.Models;
using DrowingTogether.Pages;

namespace DrowingTogether.Services
{
    public class BoardService
    {
        private readonly AppDbContext _db;

        public BoardService(AppDbContext db)
        {
            _db = db;
        }

        public List<DrawingBoard> GetAll()
        {
            return _db.Boards.ToList();
        }

        public DrawingBoard Create(string name)
        {
            var board = new DrawingBoard
            {
                Name = name
            };

            _db.Boards.Add(board);
            _db.SaveChanges();
            Console.WriteLine(_db.Boards.Count());
            return board;
        }

        public DrawingBoard? Get(Guid id)
        {
            return _db.Boards.FirstOrDefault(b => b.Id == id);
        }
    }
}
