using System;
using System.Collections.Generic;

namespace HQF.Tutorial.WCF.Serializer.XUnitTest
{
    public class SerializerFixture:IDisposable
    {
        public Employee CurrentEmployee { get; private set; }

        public List<Employee> EmployeeList { get; private set; }

        public SerializerFixture()
        {
            
            var e = new Employee(101, "Xudong", "Huo");
            CurrentEmployee = e;

            EmployeeList=new List<Employee>();
            EmployeeList.Add(e);
        }

        public void Dispose()
        {
           
        }
    }
}
