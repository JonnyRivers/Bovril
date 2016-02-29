using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMockingTestbed
{
    class EFEmployeeRepository : IEmployeeRepository, IDisposable
    {
        private employeeEntities m_dbContext;

        internal EFEmployeeRepository()
        {
            m_dbContext = new employeeEntities();
        }

        public IEnumerable<employee> GetAll()
        {
            return m_dbContext.employees.ToArray();
        }

        public IEnumerable<employee> GetByDepartmentName(string departmentName)
        {
            return m_dbContext.employees.Where(e => e.department.name == departmentName).ToArray();
        }

        public void Dispose()
        {
            m_dbContext.Dispose();
        }
    }
}
