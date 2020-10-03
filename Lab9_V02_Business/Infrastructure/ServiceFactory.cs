using Lab9_V02.DAL.Repositories;
using Lab9_V02.Domain.Interfaces;
using Lab9_V02.Domain.Managers;
using Lab9_V02.TestData;
using Lab9_V02_Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab9_V02_Business.Infrastructure
{
    public class ServiceFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly StudentManager studentManager;
        private readonly GroupManager groupManager;
        private readonly StudentService studentService;
        private readonly GroupService groupService;
        IConfiguration configuration;
        public ServiceFactory()
        {
            unitOfWork = new TestUnitOfWork();
            studentManager = new StudentManager(unitOfWork);
            groupManager = new GroupManager(unitOfWork);
        }
        public ServiceFactory(string connectionString)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connString = configuration.GetConnectionString("DefaultConnection");
            unitOfWork = new EFUnitOfWork(connString);
            studentManager = new StudentManager(unitOfWork);
            groupManager = new GroupManager(unitOfWork);
        }       
        
        public StudentService GetSudentService()
        {
            return studentService
                ?? new StudentService(studentManager, MapBootstrapper.GetMapper());
        }
        public GroupService GetGroupService()
        {
            return groupService
                ?? new GroupService(groupManager, MapBootstrapper.GetMapper());
        }
    }
}
