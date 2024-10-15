using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class MiniServer
    {
        private static readonly string url = "http://localhost:8080/";

        static async Task Main(string[] args)
        {
            // Start the HTTP listener
            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(url);
                listener.Start();
                Console.WriteLine($"Listening on {url}");

                while (true)
                {
                    // Wait for a client request
                    HttpListenerContext context = await listener.GetContextAsync();
                    HttpListenerRequest request = context.Request;

                    // Handle the request
                    Console.WriteLine($"Received request for {request.Url}");

                    // Respond with the contents of index.html
                    HttpListenerResponse response = context.Response;
                    string filePath = "index.html";

                    if (File.Exists(filePath))
                    {
                        // Read the HTML file and write it to the response
                        byte[] buffer = File.ReadAllBytes(filePath);
                        response.ContentLength64 = buffer.Length;
                        response.ContentType = "text/html";
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        // If the file doesn't exist, return a 404 error
                        response.StatusCode = 404;
                        byte[] errorBuffer = System.Text.Encoding.UTF8.GetBytes("404 - Not Found");
                        response.ContentLength64 = errorBuffer.Length;
                        await response.OutputStream.WriteAsync(errorBuffer, 0, errorBuffer.Length);
                    }

                    // Close the response
                    response.OutputStream.Close();
                }
            }
        }
    }

