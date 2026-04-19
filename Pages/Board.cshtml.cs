using DrowingTogether.Models;
using DrowingTogether.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrowingTogether.Pages
{
    public class BoardModel : PageModel
    {
        private readonly BoardService _service;
        private readonly StrokeService _strokeService;

        public List<Stroke> Strokes { get; set; }

        public BoardModel(BoardService service, StrokeService strokeService)
        {
            _service = service;
            _strokeService = strokeService;
        }

        public IActionResult OnGet(Guid id)
        {
            Board = _service.Get(id);
            if (Board == null) return RedirectToPage("Index");

            Strokes = _strokeService.GetByBoard(id);

            return Page();
        }
        public Models.DrawingBoard Board { get; set; }
    }
}
