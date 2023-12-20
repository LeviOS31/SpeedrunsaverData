using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net.WebSockets;
using System.Text;

namespace WebsocketttestAPI.Controllers
{
    [ApiController]
    public class WebsocketController : Controller
    {
        private static List<WebSocket> _sockets = new List<WebSocket>();

        [Route("/ws")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var ws = await HttpContext.WebSockets.AcceptWebSocketAsync();

                _sockets.Add(ws);

                while (true)
                {
/*                  var message = "Hello from the server!";
                    var bytes = Encoding.UTF8.GetBytes(message);
                    var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
                    if (ws.State == WebSocketState.Open)
                    {
                        await ws.SendAsync(arraySegment,
                                        WebSocketMessageType.Text,
                                        true,
                                        CancellationToken.None);
                    }*/
                    if (ws.State == WebSocketState.Closed || ws.State == WebSocketState.Aborted)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }

                _sockets.Remove(ws);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        public static async Task SendToAll(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);

            // Send the message to all connected clients
            foreach (var socket in _sockets)
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
