using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Infrastructure.Context
{
    public class WriteWebApplication1MSContext : DataContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WriteWebApplication1MSContext(
            DbContextOptions<WriteWebApplication1MSContext> options)
             : base(options)
        {
        }
    }
}