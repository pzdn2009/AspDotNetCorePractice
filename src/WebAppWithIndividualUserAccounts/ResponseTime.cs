using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace WebAppWithIndividualUserAccounts
{
    public class ResponseTime
    {
        RequestDelegate _next;
        public ResponseTime(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();

            await _next(context);

            var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
            if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
            {
                var body = context.Response.Body;

                using (var streamWriter = new StreamWriter(body))
                {
                    var txtHtml = $"<footer><div id='process'>Response Time {sw.ElapsedMilliseconds} milliseconds.</div></footer>";

                    streamWriter.Write(txtHtml);
                }
            }
        }
    }
}
