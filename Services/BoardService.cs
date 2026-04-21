using DrowingTogether.Data;
using DrowingTogether.Models;
using DrowingTogether.Pages;
using Microsoft.EntityFrameworkCore;

namespace DrowingTogether.Services
{
    public class BoardService
    {
        private readonly AppDbContext _context;

        public BoardService(AppDbContext db)
        {
            _context = db;
        }

        public List<DrawingBoard> GetAll()
        {
            return _context.Boards.ToList();
        }

        public DrawingBoard Create(string name)
        {
            var board = new DrawingBoard
            {
                Name = name
            };

            _context.Boards.Add(board);
            _context.SaveChanges();
            Console.WriteLine(_context.Boards.Count());
            return board;
        }
        public void Delete(Guid id)
        {
            var b = _context.Boards.Find(id);
            if (b != null)
            {
                _context.Boards.Remove(b);
                _context.SaveChanges();
            }
        }

        public void Rename(Guid id, string name)
        {
            var b = _context.Boards.Find(id);
            if (b != null)
            {
                b.Name = name;
                _context.SaveChanges();
            }
        }

        public DrawingBoard? Get(Guid id)
        {
            return _context.Boards.FirstOrDefault(b => b.Id == id);
        }
        public void UpdatePreview(Guid boardId, string base64)
        {
            var board = _context.Boards.Find(boardId);
            if (board != null)
            {
                board.PreviewImage = base64;
                _context.SaveChanges();
            }
        }
    }
}
