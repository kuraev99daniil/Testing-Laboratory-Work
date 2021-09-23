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
                        PassportSeries = 129856,
                        PassportNumber = 5678,
                        Age = 25,
                        Post = "Инженер",
                        Salary = 15_000
                    },
                    new Employee()
                    {
                         Surname = "Ермилов",
                        Name = "Андрей",
                        MiddleName = "Глебович",
                        PassportSeries = 543456,
                        PassportNumber = 5678,
                        Age = 31,
                        Post = "Заведущий",
                        Salary = 35_000
                    },
                    new Employee()
                    {
                         Surname = "Семенов",
                        Name = "Николай",
                        MiddleName = "Святославович",
                        PassportSeries = 123589,
                        PassportNumber = 5678,
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
                Assert.Greater(description.Length, 10);
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
            Assert.IsInstanceOf<Vacancy>(personalDepartment.GetFirstVacancy());
        }

        [Test]
        public void AddVacancy()
        {
            personalDepartment.AddVacancy(
                new Vacancy()
                {
                    Date = "11.11.2005",
                    Title = ".NET-программист",
                    Description = "Требуется SENIOR .NET-программист ",
                    EstimatedSalary = 50_000,
                    AdditionLink = "https://some_link"
                }
            );

            var findedVacancy = personalDepartment.ListVacancies.Find(vacancy => vacancy.Title == ".NET-программист");

            Assert.IsNotNull(findedVacancy);
        }

        [Test]
        public void RemoveVacancy()
        {
            var vacancy = personalDepartment.ListVacancies.Find(v => v.Title == "IT-специалист");

            var isRemoved = personalDepartment.RemoveVacancy(vacancy);

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public void AddEmployee()
        {
            personalDepartment.AddEmployee(
                new Employee()
                {
                    Surname = "Николаев",
                    Name = "Максим",
                    MiddleName = "Константинович",
                    PassportSeries = 129856,
                    PassportNumber = 5678,
                    Age = 25,
                    Post = "Инженер",
                    Salary = 15_000
                }
            );

            var findedEmployee = personalDepartment.ListEmployees.Find(e => e.PassportSeries == 129856 && e.PassportNumber == 5678);

            Assert.IsNotNull(findedEmployee);
        }

        [Test]
        public void RemoveEmployee()
        {
            var employee = personalDepartment.ListEmployees.Find(e => e.PassportSeries == 129856 && e.PassportNumber == 5678);

            var isRemoved = personalDepartment.RemoveEmployee(employee);

            Assert.IsTrue(isRemoved);
        }

        [Test]
        public void HasEmployee()
        {
            Assert.IsNotNull(personalDepartment.GetEmployee(543456, 5678));
        }

    }
}
