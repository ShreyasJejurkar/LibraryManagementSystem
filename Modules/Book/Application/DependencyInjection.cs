using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Book.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BookApplicationService).Assembly);
            services.AddScoped<IBookApplicationService, BookApplicationService>();
        }
    }
}