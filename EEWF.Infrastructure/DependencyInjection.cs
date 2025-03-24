using EEWF.Application.Interfaces;
using EEWF.Application.Interfaces.Admin;
using EEWF.Infrastructure.Data;
using EEWF.Infrastructure.Services;
using EEWF.Infrastructure.Services.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<ISeedService, SeedService>();
            services.AddTransient<IAboutService, AboutService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryTeacherService, CategoryTeacherService>();
            services.AddTransient<IAppealService, AppealService>();
            services.AddTransient<ICarouselService, CarouselService>();
            services.AddTransient<IGraduateService, GraduateService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ITeacherCategoryService, TeacherCategoryService>();

            services.AddTransient<ILevelService, LevelService>();
            //services.AddTransient<IQuizFormService, QuizFormService>();
            //services.AddTransient<IQuizQuestionService, QuizQuestionService>();

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAppealAnswerService, AppealAnswerService>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddSession();
            services.AddHttpContextAccessor();

            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }
    }
}
