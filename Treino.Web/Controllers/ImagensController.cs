//using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
//using SixLabors.ImageSharp;
//using SkiaSharp;
//using Treino.Web.Utilidades;

namespace DemoLogin.Controllers
{
    public class ImagensController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /*
        [HttpGet("imagens/buscar/{mensagem}")]
        public IActionResult BuscarImagem(string mensagem)
        {
            using (var image = CriarImagem(mensagem))
            {
                //var imagemRecortada = ResizeImage.cortarImagePNG(image.ToArray());

                return File(image.ToArray(), "image/jpeg");
            }
        }

        [Route("imagens/criar")]
        [HttpGet]
        public HttpContent Criar()
        {
            using (var image = CriarImagem("SkiaSharp"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(image.ToArray())
                };

                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return response.Content;
            }
        }
        
                [Route("imagens/pegar/{id}")]
                [HttpGet]
                public HttpResponseMessage Criar(string id)
                {
                    using (var image = CriarImagem(id ?? "SkiaSharp"))
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(image.ToArray())
                        };

                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                        return response;
                    }
                }
        */
        /*private SKData CriarImagem(string text)
        {
            // create a surface
            var info = new SKImageInfo(256, 256);
            using (var surface = SKSurface.Create(info))
            {
                // the the canvas and properties
                var canvas = surface.Canvas;

                // make sure the canvas is blank
                canvas.Clear(SKColors.White);

                // draw some text
                var paint = new SKPaint
                {
                    Color = SKColors.Black,
                    IsAntialias = true,
                    Style = SKPaintStyle.Fill,
                    TextAlign = SKTextAlign.Center,
                    TextSize = 24
                };
                var coord = new SKPoint(info.Width / 2, (info.Height + paint.TextSize) / 2);
                canvas.DrawText(text, coord, paint);

                // retrieve the encoded image
                using (var image = surface.Snapshot())
                {
                    return image.Encode(SKEncodedImageFormat.Png, 100);
                }
            }
        }*/
    }
}
