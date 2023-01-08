using System.Net;
using System.Text;
using System.Text.Json;

namespace SnipeIT_bPAC
{
    public static class HttpListenerContextExtension
    {
        public static void SendJson(this HttpListenerContext ctx, object? data)
        {
            var resp = ctx.Response;
            resp.StatusCode = 200;
            resp.ContentType = "application/json";

            resp.AppendHeader("Access-Control-Allow-Origin", "*");
            resp.AppendHeader("Access-Control-Allow-Headers", "authorization");

            if (data != null)
            {
                resp.OutputStream.Write(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)));
            }
            resp.OutputStream.Close();
        }
    }
}
