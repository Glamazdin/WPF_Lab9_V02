using Lab9_V02.DAL.Repositories;
using Lab9_V02.Domain.Interfaces;

using Lab9_V02.TestData;
using Lab9_V02_Business.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab9_V02_Business.Infrastructure
{
    public class ManagersFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly StudentManager studentManager;
        private readonly GroupManager groupManager;
       
        IConfiguration configuration;
        public ManagersFactory()
        {
            unitOfWork = new TestUnitOfWork();
            //studentManager = new StudentManager(unitOfWork);
            //groupManager = new GroupManager(unitOfWork);
        }
        public ManagersFactory(string connectionString)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connString = configuration.GetConnectionString("DefaultConnection");
            unitOfWork = new EFUnitOfWork(connString);
            //studentManager = new StudentManager(unitOfWork);
            //groupManager = new GroupManager(unitOfWork);
        }

        public StudentManager GetSudentManager()
        {
            return studentManager
                ?? new StudentManager(unitOfWork);
        }
        public GroupManager GetGroupManager()
        {
            return groupManager
                ?? new GroupManager(unitOfWork);
        }
    }
}
