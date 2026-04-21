using DrowingTogether.Services;
using Microsoft.AspNetCore.Mvc;

namespace DrowingTogether.Controllers
{
    [ApiController]
    [Route("api/preview")]
    public class PreviewController : ControllerBase
    {
        private readonly BoardService _boardService;

        public PreviewController(BoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost]
        public IActionResult SavePreview([FromBody] PreviewDto dto)
        {
            _boardService.UpdatePreview(dto.BoardId, dto.Image);
            return Ok();
        }
    }

    public class PreviewDto
    {
        public Guid BoardId { get; set; }
        public string Image { get; set; }
    }
}