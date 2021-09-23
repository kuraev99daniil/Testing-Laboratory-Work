using System.Collections.Generic;
using System.Linq;

namespace Laboratory_Work_One
{
    class PersonalDepartment
    {
        public string Address { get; set; }
        public bool IsOpened { get; set; }
        public string WorkSchedule { get; set; }
        public List<Vacancy> ListVacancies { get; set; }
        public List<Employee> ListEmployees { get; set; }
        public List<ResigningPerson> ListResigningPerson { get; set; }

        public double GetAverageSalaryEmployees()
        {
            return ListEmployees.Average(employee => employee.Salary);
        }

        public List<string> GetDescriptionVacancy()
        {
            List<string> listResult = new List<string>();

            foreach (Vacancy item in ListVacancies)
            {
                listResult.Add(item.Description);
            }

            return listResult;
        }

        public int GetCountResigningPerson()
        {
            return ListResigningPerson.Count;
        }

        public int GetWorkExperience(int passportSeries, int passportNumber)
        {
            return ListResigningPerson.Find(person => person.PassportSeries == passportSeries && person.PassportNumber == passportNumber).WorkExperience;
        }

        public object GetFirstVacancy()
        {
            return ListVacancies.First();
        }

        public void AddVacancy(Vacancy vacancy)
        {
            ListVacancies.Add(vacancy);
        }

        public bool RemoveVacancy(Vacancy vacancy)
        {
            return ListVacancies.Remove(vacancy);
        }

        public void AddEmployee(Employee employee)
        {
            ListEmployees.Add(employee);
        }

        public bool RemoveEmployee(Employee employee)
        {
            return ListEmployees.Remove(employee);
        }

        public Employee GetEmployee(int passportSeries, int passportNumber)
        {
            return ListEmployees.Find(employee => employee.PassportSeries == passportSeries && employee.PassportNumber == passportNumber);
        }

        // Добавить сотрудника
        // Удалить вакансию
        // Уволить сотрудника
        // Проверить является ли сотрудник по паспорту

    }
}
