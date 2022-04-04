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
using TestEducationCenterUoW.Domain.Entities.Teachers;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationCenterUoW.Service.Extensions;
using TestEducationCenterUoW.Service.Helpers;
using TestEducationUow.Service.DTOs.Teachers;
using TestEducationUow.Service.Interfaces;

namespace TestEducationUow.Service.Services
{
    public class TeacherService : ITeacherService
    {


        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration config;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }


        public async Task<BaseResponse<Teacher>> CreateAsync(TeacherForCreationDto teachertDto)
        {
            var response = new BaseResponse<Teacher>();

            // create after checking success
            var mappedTeacher = mapper.Map<Teacher>(teachertDto);

            // save image from dto model to wwwroot
            mappedTeacher.Image = await SaveFileAsync(teachertDto.Image.OpenReadStream(), teachertDto.Image.FileName);

            var result = await unitOfWork.Teachers.CreateAsync(mappedTeacher);

            result.Image = "https://localhost:5001/Images/" + result.Image;

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist student
            var existTeacher = await unitOfWork.Teachers.GetAsync(expression);
            if (existTeacher is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existTeacher.Delete();

            await unitOfWork.Teachers.UpdateAsync(existTeacher);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Teacher>>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Teacher>>();

            var teachers = await unitOfWork.Teachers.GetAllAsync(expression => expression.State != ItemState.Deleted);

            response.Data = teachers.ToPagedList(@params);

            if (response.Data is null)
            {
                response.Error = new ErrorResponse(404, "Users not found");
            }

            return response;
        }

        public async Task<BaseResponse<Teacher>> GetAsync(Expression<Func<Teacher, bool>> expression)
        {
            var response = new BaseResponse<Teacher>();

            var teacher = await unitOfWork.Teachers.GetAsync(expression);
            if (teacher is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = teacher;

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

        public static async Task<string> SaveFileAsync(this Stream file, string fileName, IWebHostEnvironment env, IConfiguration config)
        {
            string hostUrl = HttpContextHelper.Context?.Request?.Scheme + "://" + HttpContextHelper.Context?.Request?.Host.Value;


            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;

            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);

            string webUrl = $@"{hostUrl}/{storagePath}/{fileName}";


            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return webUrl;
        }




        public async Task<BaseResponse<Teacher>> UpdateAsync(Guid id, TeacherForCreationDto teachertDto)
        {
            var response = new BaseResponse<Teacher>();

            // check for exist teacher
            var teacher = await unitOfWork.Teachers.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (teacher is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            teacher.FirstName = teachertDto.FirstName;
            teacher.LastName = teachertDto.LastName;
            teacher.Email = teachertDto.Email;
            teacher.PhoneNumber = teachertDto.PhoneNumber;

            string imagePath = await SaveFileAsync(teachertDto.Image.OpenReadStream(), teachertDto.Image.FileName);
            teacher.Image = "https://localhost:5001/Images/" + imagePath;

            teacher.Update();

            var result = await unitOfWork.Teachers.UpdateAsync(teacher);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
