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

        public ArreyList EmployeeDetails(string CSVData)
        {
           Employees onewemp = null;
            string full = System.IO.Path.GetFullPath(CSVData);
            string file = System.IO.Path.GetFileName(full);
            string dir = System.IO.Path.GetDirectoryName(full);

            DataTable dtData = new DataTable();
            string sconnection = "Provider=Microsoft.Jet.OLEDB.4.0;"
            + "Data Source=\"" + dir + "\\\";"
            + "Extended Properties=\"text;HDR=NO;FMT=Delimited\"";

            string query = "SELECT * FROM [" + file + "]";
            try
            {
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, sconnection);
                dAdapter.Fill(dtData);
                dAdapter.Dispose();
            }
            catch (Exception ex)
            {
                ;
               
            }

            DataSet dsOutput = new DataSet();
            dsOutput.Tables.Add(dtData.Copy());
            int numrows = dsOutput.Tables[0].Rows.Count;

            int beginAt = 0, maxcolumns = 4;
            int totalRows = dsOutput.Tables[0].Rows.Count;
           
            int currentRow = 0;

            Employees Employee = null;
            ArrayList mylisst = new ArrayList();
            List<Employees> mylist = new List<Employees>();

            foreach (DataRow drow in dsOutput.Tables[0].Rows)
            {
                currentRow++;
           
              

                onewemp = new Employees();
                
                    string[] myData;
                  

                    for (int i = beginAt; i < dsOutput.Tables[0].Columns.Count; i++)
                    {
                        string myval = drow[i].ToString();
                        myData = myval.Split(',');

                      

                        for (int j = 0; j < myData.Length; j++)
                        {

                            int itemNum = j + 1;
                          

                            if (itemNum <= maxcolumns)
                            {


                                string item = myData[j].ToString();
                                if (item.Trim() == "-") item = "";

                                switch (j)
                                {
                               
                                    case 0:
                                        int empid = 0;
                                        int.TryParse(item, out empid);
                                        onewemp.EmployeeId = empid;
                                        break;

                                    case 1:
                                        int managid = 0;
                                        int.TryParse(item, out managid);
                                        onewemp.ManagerId = managid;
                                        break;

                                
                                    case 2:
                                        double salary = 0;
                                        double.TryParse(item, out salary);
                                        onewemp.EmployeeSalary = salary;
                                        break;


                                }
                            }
                        }
                    }

                    if (onewemp != null)
                {
                  
                    mylisst.Add(onewemp);

                }
              
            }
            return mylisst;
        }
       
     
    }
}
