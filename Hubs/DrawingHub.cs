
using DrowingTogether.Services;
using Microsoft.AspNetCore.SignalR;

namespace DrowingTogether.Hubs
{
    public class DrawingHub : Hub
    {
        private readonly StrokeService _strokeService;

        public DrawingHub(StrokeService strokeService)
        {
            _strokeService = strokeService;
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
    }
}