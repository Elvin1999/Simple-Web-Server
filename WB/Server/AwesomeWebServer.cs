using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace WB.Server
{
   public class AwesomeWebServer
    {
        private readonly HttpListener _httpListener;
        public AwesomeWebServer()
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add("http://127.0.0.1:8084/");
        }
        public void Run()
        {
            _httpListener.Start();

            while (true)
            {
                var context = _httpListener.GetContext();
                Task task = Task.Run(() => {
                Process(context);
                });
            }

        }
        public void Process(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;
            var streamReader = new StreamReader(request.InputStream);
            var streamWriter = new StreamWriter(response.OutputStream);

            var url = request.Url.LocalPath;
            var method = request.HttpMethod;

            try
            {
                if (url == "/books" && method=="GET")
                {
                    var books = new string[] { "Harry Potter","Call of duty" };
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<html><body>");
                    stringBuilder.Append("<h3 style=\"color:red\">All books:</h3>");
                    stringBuilder.Append("<ul>");
                    foreach (var item in books)
                    {
                        stringBuilder.Append($"<li>{item}</li>");
                    }
                    stringBuilder.Append("</ul>");
                    stringBuilder.Append("</body></html>");
                    response.ContentType = "text/html";
                    response.StatusCode = 200;

                    streamWriter.Write(stringBuilder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                    streamWriter.Close();
            }


        }

    }
}

