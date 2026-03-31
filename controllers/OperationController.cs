using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeFixes;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal GET(decimal a,decimal b)
        {
            return a + b;
        }
        [HttpPost]
        public decimal Add(Numbers numbers, [FromHeader] string Host, [FromHeader(Name="content-length")] string content,
        [FromHeader(Name="X-Some")] string some)
        {
            System.Console.WriteLine($"Host: {Host}");
            System.Console.WriteLine($"Content-Length: {content}");
            System.Console.WriteLine($"Some: {some}");
            return numbers.A - numbers.B;
        }

        [HttpPut]
        public decimal Edit(decimal a,decimal b)
        {
            return a * b;
        }
        [HttpDelete]
        public decimal Delete(decimal a,decimal b)
        {
            return a / b;
        }
    }


    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }

}
