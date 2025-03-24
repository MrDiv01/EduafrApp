using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AboutConfiguration());
            modelBuilder.ApplyConfiguration(new AppealConfiguration());
            modelBuilder.ApplyConfiguration(new CarouselConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LevelConfiguration());
            modelBuilder.ApplyConfiguration(new EducationConfiguration());
            modelBuilder.ApplyConfiguration(new GraduateConfiguration());
            modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new VariantConfiguration());
            //modelBuilder.ApplyConfiguration(new LevelConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Appeal> Appeals { get; set; }
        public virtual DbSet<Carousel> Carousels { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Graduate> Graduates { get; set; }
        public virtual DbSet<SocialMedia> SocialMedias { get; set; }
        public virtual DbSet<TeacherCategory> TeacherCategories { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        public virtual DbSet<CategoryTeacher> CategoryTeachers { get; set; }

        public virtual DbSet<QuizForm> QuizForms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<AppealAnswer> AppealAnswers { get; set; }

    }
}
