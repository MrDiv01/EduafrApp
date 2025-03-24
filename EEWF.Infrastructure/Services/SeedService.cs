using EEWF.Application.Interfaces;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EEWF.Infrastructure.Services
{
    public class SeedService /*: ISeedService*/
    {

        public readonly ApplicationDbContext _context;
        public SeedService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        //    async Task ISeedService.SeedService()
        //    {
        //        //await _context.Database.BeginTransactionAsync();
        //        try
        //        {
        //            //if (!await _context.Abouts.AnyAsync())
        //            //{
        //            //    About about = new About
        //            //    {
        //            //        Title = "Titl",
        //            //        Description = "Titil ID 1",
        //            //        Image = "~/",
        //            //        //EducationId = 1,
        //            //    };
        //            //    await _context.Abouts.AddAsync(about);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Appeals.AnyAsync())
        //            //{
        //            //    Appeal appeal = new Appeal
        //            //    {
        //            //        Name = "Nurlan",
        //            //        Surname = "Mammadov",
        //            //        Email = "Test@gmail.com",
        //            //        Subject = "SunjectTest",
        //            //        Message = "MesajTest"
        //            //    };
        //            //    await _context.Appeals.AddAsync(appeal);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Carousels.AnyAsync())
        //            //{
        //            //    Carousel carousel = new Carousel
        //            //    {
        //            //        Title = "TestTitl",
        //            //        Description = "TestDescription",
        //            //        Image = "",
        //            //        Url = "#",
        //            //        ButtonText = "Click"
        //            //    };
        //            //    await _context.Carousels.AddAsync(carousel);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Categories.AnyAsync())
        //            //{
        //            //    Category category = new Category
        //            //    {
        //            //        Name = "Test",
        //            //        Icon = "Test",
        //            //        Description = "TestDescription"
        //            //    };
        //            //    await _context.Categories.AddAsync(category);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Contacts.AnyAsync())
        //            //{
        //            //    Contact contact = new Contact
        //            //    {
        //            //        Location = "Narimanov",
        //            //        Phone = "0000000",
        //            //        Mail = "Test@gmail.com"
        //            //    };
        //            //    await _context.Contacts.AddAsync(contact);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Educations.AnyAsync())
        //            //{
        //            //    Education education = new Education
        //            //    {
        //            //        Name = "Test",
        //            //        Description = "DescriptionTest",
        //            //        Image = "",
        //            //        //ButtonText = "TestText",

        //            //    };
        //            //    await _context.Educations.AddAsync(education);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Graduates.AnyAsync())
        //            //{
        //            //    Graduate graduate = new Graduate
        //            //    {
        //            //        Name = "Test",
        //            //        Degree = "Test",
        //            //        Comment = "TestComment",
        //            //        Image = ""
        //            //    };
        //            //    await _context.Graduates.AddAsync(graduate);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Questions.AnyAsync())
        //            //{
        //            //    Question question = new Question
        //            //    {
        //            //        Query = "TestQuery",
        //            //        Point = 20,
        //            //        LevelId = 1,
        //            //    };
        //            //    await _context.Questions.AddAsync(question);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Levels.AnyAsync())
        //            //{
        //            //    Level level = new Level
        //            //    {
        //            //        Name = "Test",
        //            //    };
        //            //    await _context.Levels.AddAsync(level);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.SocialMedias.AnyAsync())
        //            //{
        //            //    SocialMedia socialMedia = new SocialMedia
        //            //    {
        //            //        Name = "Test",
        //            //        Icon = "",
        //            //        URL = "#"
        //            //    };
        //            //    await _context.SocialMedias.AddAsync(socialMedia);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Teachers.AnyAsync())
        //            //{
        //            //    Teacher teacher = new Teacher
        //            //    {
        //            //        Name = "Test",
        //            //        Surname = "Test",
        //            //        Description = "Test",
        //            //        Image = "Test",
        //            //        //TeacherCategoryId = 1
        //            //    };
        //            //    await _context.Teachers.AddAsync(teacher);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.TeacherCategories.AnyAsync())
        //            //{
        //            //    TeacherCategory teacherCategory = new TeacherCategory
        //            //    {
        //            //        Name = "Test"
        //            //    };
        //            //    await _context.TeacherCategories.AddAsync(teacherCategory);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            //if (!await _context.Variants.AnyAsync())
        //            //{
        //            //    Variant variant = new Variant
        //            //    {
        //            //        IsCorrect = true,
        //            //        Name = "Test",
        //            //        Description = "DescriptionTest",
        //            //        QuestionId = 1,
        //            //    };
        //            //    await _context.Variants.AddAsync(variant);
        //            //    await _context.SaveChangesAsync();
        //            //}
        //            await _context.Database.CommitTransactionAsync();
        //        }

        //        catch (Exception exp)
        //        {
        //            //await _context.Database.RollbackTransactionAsync();
        //        }
        //        return;
        //    }
    };
};

