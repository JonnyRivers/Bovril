using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMockingTestbed
{
    public interface IEmployeeRepository
    {
        IEnumerable<employee> GetAll();
        IEnumerable<employee> GetByDepartmentName(string departmentName);
    }
}
