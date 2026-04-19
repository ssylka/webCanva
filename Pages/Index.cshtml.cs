using DrowingTogether.Models;
using DrowingTogether.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrowingTogether.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BoardService _service;
        [BindProperty]
        public string Name { get; set; }
        public List<DrawingBoard> Boards { get; set; }

        public IndexModel(BoardService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Boards = _service.GetAll();
        }

        public IActionResult OnPostCreate()
        {
            _service.Create(Name);
            return RedirectToPage();
        }
    }
}