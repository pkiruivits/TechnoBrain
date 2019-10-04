using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TechnoBrainTest
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public double EmployeeSalary { get; set; }

        public Employee EmployeeDetails(string CSVData)
        {
            Employee employee = null;


            return employee;
        }
        public List<Employee> GetPeople(string csvContent)
        {
            List<Employee> people = new List<Employee>();
            csvdata csv = new csvdata(csvContent);
            foreach (string[] line in csv)
            {
                Employee person = new Employee();
                person.Name = line[0];
                person.TelephoneNo = line[1];
                people.Add(person);
            }
            return people;
        }
        public class csvdata : List<string[]>
        {
            protected string csv = string.Empty;
            protected string delimiter = ",";

            public csvdata(string csv, string delimiter = "\",\"")
            {
                this.csv = csv;
                this.delimiter = delimiter;

                foreach (string line in Regex.Split(csv, System.Environment.NewLine).ToList().Where(s => !string.IsNullOrEmpty(s)))
                {
                    string[] realdata = Regex.Split(line, delimiter);

                    for (int i = 0; i < realdata.Length; i++)
                    {

                        realdata[i] = realdata[i].Trim('\"');
                    }

                    this.Add(realdata);
                }
            }
        }
    }
}
