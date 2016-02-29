using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMockingTestbed
{
    class Program
    {
        static void PrintEmployees(IEnumerable<employee> employees)
        {
            foreach (employee employee in employees)
            {
                Console.WriteLine(
                    "{0} {1} of department {2}",
                    employee.first_name,
                    employee.last_name,
                    employee.department.name);
            }
        }

        // Repository pattern appraisal
        // + we can mock db access
        // - we have to write code for every query

        static void Main(string[] args)
        {
            // use the db
            IEmployeeRepository employeeRepository = new EFEmployeeRepository();

            IEnumerable<employee> allEmployees = employeeRepository.GetAll();
            PrintEmployees(allEmployees);

            IEnumerable<employee> toolsEmployees = employeeRepository.GetByDepartmentName("Tools");
            PrintEmployees(toolsEmployees);

            // mock it with Moq

            // setup data
            department department1 = new department {department_id = 1, name = "Tools"};
            employee employee1 = new employee {employee_id = 1, first_name = "Frank", last_name = "Smith", department_id = 1, department = department1};

            // Fix navigation data
            department1.employees = new employee[] { employee1 };

            Moq.Mock<IEmployeeRepository> employeeRepoMock1 = new Moq.Mock<IEmployeeRepository>();
            employeeRepoMock1.Setup(m => m.GetAll()).Returns(
                new employee[] {
                    employee1
                }
            );

            IEnumerable<employee> mockEmployees = employeeRepoMock1.Object.GetAll();
            PrintEmployees(mockEmployees);


            Moq.Mock<IEmployeeRepository> employeeRepoMock2 = new Moq.Mock<IEmployeeRepository>();
            employeeRepoMock2.Setup(m => m.GetByDepartmentName("Tools")).Returns(
                new employee[] {
                    employee1
                }
            );
            employeeRepoMock2.Setup(m => m.GetByDepartmentName("")).Returns(
                new employee[] {
                }
            );

            IEnumerable<employee> mockToolsEmployees = employeeRepoMock2.Object.GetByDepartmentName("Tools");
            PrintEmployees(mockToolsEmployees);

            IEnumerable<employee> mockBlankDepartmentEmployees = employeeRepoMock2.Object.GetByDepartmentName("");
            PrintEmployees(mockBlankDepartmentEmployees);
        }
    }
}
