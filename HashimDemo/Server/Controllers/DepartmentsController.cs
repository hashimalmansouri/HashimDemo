using HashimDemo.Server.Data;
using HashimDemo.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HashimDemo.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Department department)
        {
            await _context.AddAsync(department);
            int i = await _context.SaveChangesAsync();
            return i > 0 ? "تمت الإضافة بنجاح" : "حدث خطأ";
        }
    }
}
