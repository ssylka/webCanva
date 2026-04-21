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
        private readonly ShapeService _shapeService;
        public List<Stroke> Strokes { get; set; }
        public List<Shape> Shapes { get; set; }

        public BoardModel(BoardService service, StrokeService strokeService, ShapeService shapeService)
        {
            _service = service;
            _strokeService = strokeService;
            _shapeService = shapeService;
        }
        public IActionResult OnGet(Guid id)
        {
            Board = _service.Get(id);
            if (Board == null) return RedirectToPage("Index");
            Strokes = _strokeService.GetByBoard(id);
            Shapes = _shapeService.GetByBoard(id);
            return Page();
        }
        public Models.DrawingBoard Board { get; set; }
    }
}
