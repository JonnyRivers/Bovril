using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMockingTestbed
{
    class EFDepartmentRepository : IDepartmentRepository, IDisposable
    {
        private employeeEntities m_dbContext;

        internal EFDepartmentRepository()
        {
            m_dbContext = new employeeEntities();
        }

        public IEnumerable<department> GetAll()
        {
            return m_dbContext.departments;
        }

        public void Dispose()
        {
            m_dbContext.Dispose();
        }
    }
}
