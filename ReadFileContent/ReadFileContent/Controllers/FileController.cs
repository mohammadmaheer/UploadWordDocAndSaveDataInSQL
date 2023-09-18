using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReadFileContent.Context;
using ReadFileContent.Models;
using Xceed.Words.NET;

namespace ReadFileContent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public FileController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("get-file")]
        public async Task<IActionResult> GetFile(string filename)
        { 
            var path = "C:\\Users\\Transviti\\Desktop\\Test 18 Sept";
            var filepath = Path.Combine(path, filename);

            using(DocX doc= DocX.Load(filepath))
            {
                var data = doc.Text;
                var content = JsonConvert.DeserializeObject<IEnumerable<FileContents>>(data);
                foreach (var item in content)
                {
                   await _dbContext.FileContents.AddAsync(item);
                    await _dbContext.SaveChangesAsync();
                }
                return Ok(content);
            }
        }
    }
}
