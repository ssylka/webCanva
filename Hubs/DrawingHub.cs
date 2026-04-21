
using DrowingTogether.Services;
using Microsoft.AspNetCore.SignalR;

namespace DrowingTogether.Hubs
{
    public class DrawingHub : Hub
    {
        private readonly StrokeService _strokeService;
        private readonly BoardService _boardService;
        private readonly ShapeService _shapeService;

        public DrawingHub(StrokeService strokeService, BoardService boardService, ShapeService shapeService)
        {
            _strokeService = strokeService;
            _boardService = boardService;
            _shapeService = shapeService;
        }

        public async Task SendStroke(string boardId, string color, int size, List<Data.Dto.PointDto> points)
        {
            var guid = Guid.Parse(boardId);

            _strokeService.SaveStroke(guid, color, size, points);

            await Clients.OthersInGroup(boardId)
                .SendAsync("ReceiveStroke", color, size, points);
        }
        public async Task JoinBoard(string boardId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, boardId);
        }
        public async Task SendShape(string boardId, string type, string color, int size, object data)
        {
            var guid = Guid.Parse(boardId);

            _shapeService.Save(guid, type, color, size, data);

            await Clients.OthersInGroup(boardId)
                .SendAsync("ReceiveShape", type, color, size, data);
        }

        public async Task SendStart(string boardId, double x, double y)
        {
            await Clients.OthersInGroup(boardId)
                .SendAsync("ReceiveStart", x, y);
        }

        public async Task SendDraw(string boardId, double x, double y, string color, int size)
        {
            await Clients.OthersInGroup(boardId)
                .SendAsync("ReceiveDraw", x, y, color, size);
        }
        public async Task SavePreview(string boardId, string image)
        {
            var guid = Guid.Parse(boardId);
            _boardService.UpdatePreview(guid, image);
        }
    }
}