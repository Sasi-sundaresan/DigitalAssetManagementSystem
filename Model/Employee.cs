

namespace DigitalAssetManagementApplication.Model
{
    public class Employee
    {
        private int employeeId;
        private string name;
        private string department;
        private string email;
        private string password;

       
        public Employee() {
        }


        public Employee(int employeeId, string name, string department, string email, string password)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.department = department;
            this.email = email;
            this.password = password;
        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public override string ToString()
        {
            return $"Id::{EmployeeId}\tName::{Name}\tDepartment::{Department}\tEmail::{Email}\tPaassword::{Password}";
        }

    }
}
