using Lab9_V02.Domain.Entities;
using Lab9_V02.Domain.Interfaces;
using Lab9_V02_Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9_V02_Business.Infrastructure
{
    public static class DbTestData
    {
        public static void SetupData(GroupManager groupManager)
        {
            // Добавление групп
            groupManager.AddRange(new List<Group>
            {
                new Group
                {
                    BasePrice = 100,
                    Commence = new DateTime(2017,01,20),
                    CourseName = "Знакомство с Adobe Photoshop"
                },
                new Group
                {
                    BasePrice = 150,
                    Commence = new DateTime(2017,02, 11),
                    CourseName = "Вязание крючком"
                }
            });


            var groups = groupManager.Groups.ToArray();
            // Добавление студентов
            groupManager.AddStudentToGroup(
                    new Student
                    {
                        IndividualPrice = 100,
                        DateOfBirth = new DateTime(1978, 10, 23),
                        FullName = "Никита Хрущев",
                        ImageFileName = "1.jpg"
                    },
                    groups[0].GroupId, false
                );
            groupManager.AddStudentToGroup(
                new Student
                {
                    IndividualPrice = 100,
                    DateOfBirth = new DateTime(1981, 03, 05),
                    FullName = "Дарт Вэйдер",
                    ImageFileName = "2.jpg"
                },
                groups[0].GroupId, true);
            groupManager.AddStudentToGroup(
                new Student
                {
                    IndividualPrice = 120,
                    DateOfBirth = new DateTime(1991, 06, 14),
                    FullName = "Иван Драго",
                    ImageFileName = "3.jpg"
                },
                groups[1].GroupId, false);
            groupManager.AddStudentToGroup(
                new Student
                {
                    IndividualPrice = 150,
                    DateOfBirth = new DateTime(1989, 12, 06),
                    FullName = "Геракл Зевсович",
                    ImageFileName = "4.jpg"
                },
                groups[1].GroupId, false);
            groupManager.AddStudentToGroup(
                new Student
                {
                    IndividualPrice = 150,
                    DateOfBirth = new DateTime(1985, 09, 11),
                    FullName = "Мерлин Мэнсон",
                    ImageFileName = "5.jpg"
                },
                groups[1].GroupId, false);     
        }

    }
}
