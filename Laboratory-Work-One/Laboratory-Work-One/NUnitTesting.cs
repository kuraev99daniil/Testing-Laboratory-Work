using NUnit.Framework;
using System.Collections.Generic;

namespace Laboratory_Work_One
{
    [TestFixture]
    public class NUnitTesting
    {

        private PersonalDepartment personalDepartment;

        [SetUp]
        public void Init()
        {
            personalDepartment = new PersonalDepartment() 
            {
                Address = "9th Street West",
                IsOpened = true,
                WorkSchedule = "11:00-19:00",
                ListVacancies = new List<Vacancy>()
                {
                    new Vacancy()
                    {
                        Date = "11.11.2000",
                        Title = "IT-специалист",
                        Description = "JAVA-разработчик",
                        EstimatedSalary = 10_000,
                        AdditionLink = "https://some_link"
                    }
                },
                ListEmployees = new List<Employee>()
                {
                    new Employee()
                    {
                        Surname = "Николаев",
                        Name = "Максим",
                        MiddleName = "Константинович",
                        Age = 25,
                        Post = "Инженер",
                        Salary = 15_000
                    },
                    new Employee()
                    {
                         Surname = "Ермилов",
                        Name = "Андрей",
                        MiddleName = "Глебович",
                        Age = 31,
                        Post = "Заведущий",
                        Salary = 35_000
                    },
                    new Employee()
                    {
                         Surname = "Семенов",
                        Name = "Николай",
                        MiddleName = "Святославович",
                        Age = 30,
                        Post = "Бухгалтер",
                        Salary = 25_000
                    }
                },
                ListResigningPerson = new List<ResigningPerson>()
                {
                    new ResigningPerson()
                    {
                        Surname = "Смирнов",
                        Name = "Алексей",
                        MiddleName = "Олегович",
                        PassportSeries = 123456,
                        PassportNumber = 5678,
                        Reason = "На пенсию",
                        WorkExperience = 5,
                        IsOptional = true
                    },
                    new ResigningPerson()
                    {
                        Surname = "Соловьев",
                        Name = "Иван",
                        MiddleName = "Дмитриевич",
                        PassportSeries = 123459,
                        PassportNumber = 5178,
                        Reason = "Смена места работы",
                        WorkExperience = 9,
                        IsOptional = true
                    }
                }
            };
        }

        [Test]
        public void AnalyzeSalary()
        {
            var minSalary = 11_653;
            Assert.Less(minSalary, personalDepartment.GetAverageSalaryEmployees());
        }

        [Test]
        public void AnalyseDescriptionVacancy()
        {
            foreach (string description in personalDepartment.GetDescriptionVacancy())
            {
                Assert.Less(description.Length, 10);
            } 
        }

        [Test]
        public void AnalyseAddress()
        {
            StringAssert.Contains("Street West", personalDepartment.Address);
        }

        [Test]
        public void AnalyseOpening()
        {
            Assert.IsTrue(personalDepartment.IsOpened);
        }

        [Test]
        public void AnalyseCountResigning()
        {
            Assert.AreNotEqual(5, personalDepartment.GetCountResigningPerson());
        }

        [Test]
        public void AnalyseWorkExperience()
        {
            Assert.AreNotEqual(1, personalDepartment.GetWorkExperience(123456, 5678));
        }

        [Test]
        public void AnalyseVacancy()
        {
            Assert.IsNotInstanceOf<Vacancy>(personalDepartment.GetFirstVacancy());
        }

    }
}
