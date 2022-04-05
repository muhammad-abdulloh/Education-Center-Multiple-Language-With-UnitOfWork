using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Courses;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationCenterUoW.Service.Extensions;
using TestEducationUow.Service.DTOs.Courses;
using TestEducationUow.Service.Interfaces;

namespace TestEducationUow.Service.Services
{
    public class CourseService : ICourseService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration config;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }


        public async Task<BaseResponse<Course>> CreateAsync(CourseForCreationDto courseDto)
        {
            var response = new BaseResponse<Course>();

            // create after checking success
            var mappedCourse = mapper.Map<Course>(courseDto);

            // save image from dto model to wwwroot
            mappedCourse.CourseImageUrl = await SaveFileAsync(courseDto.CourseImageUrl.OpenReadStream(), courseDto.CourseImageUrl.FileName);

            var result = await unitOfWork.Courses.CreateAsync(mappedCourse);

            result.CourseImageUrl = config.GetSection("FileUrl:ImageUrl").Value + result.CourseImageUrl;

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist student
            var existCourse = await unitOfWork.Courses.GetAsync(expression);
            if (existCourse is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existCourse.Delete();

            await unitOfWork.Courses.UpdateAsync(existCourse);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Course>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Course>>();

            var courses = await unitOfWork.Courses.GetAllAsync(expression => expression.State != ItemState.Deleted);

            response.Data = courses.ToPagedList(@params);

            if (response.Data is null)
            {
                response.Error = new ErrorResponse(404, "Users not found");
            }

            return response;
        }

        public async Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression)
        {
            var response = new BaseResponse<Course>();

            var courses = await unitOfWork.Courses.GetAsync(expression);
            if (courses is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = courses;

            return response;
        }

        public async Task<string> SaveFileAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;
            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");

            FileStream mainFile = File.Create(filePath);
            await file.CopyToAsync(mainFile);
            mainFile.Close();
            return fileName;
        }

        public async Task<BaseResponse<Course>> UpdateAsync(Guid id, CourseForCreationDto courseDto)
        {
            var response = new BaseResponse<Course>();

            // check for exist student
            var course = await unitOfWork.Courses.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (course is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }


            course.Name = courseDto.Name;
            course.Price = courseDto.Price;
            course.Duration = courseDto.Duration;
            course.CourseForId = courseDto.CourseForId;
            course.CourseType = courseDto.CourseType;
            course.CourseAuthor = courseDto.CourseAuthor;
            course.CourseDescription = courseDto.CourseDescription;
            string imagePath = await SaveFileAsync(courseDto.CourseImageUrl.OpenReadStream(), courseDto.CourseImageUrl.FileName);
            course.CourseImageUrl = config.GetSection("FileUrl:ImageUrl").Value + imagePath;
            course.Star = courseDto.Star;
            course.Update();

            var result = await unitOfWork.Courses.UpdateAsync(course);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
