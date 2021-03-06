﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BinaryTree;

namespace QueryBinaryTree
{
    class Program
    {
        static void doWork()
        {
            Tree<Employee> empTree = new Tree<Employee>(new Employee { Id = 1, FirstName = "Yu", LastName = "Deng", Department = "CEO" });
            empTree.Insert(new Employee { Id = 2, FirstName = "Zeyun", LastName = "Qiu", Department = "VP" });
            empTree.Insert(new Employee { Id = 3, FirstName = "Yong", LastName = "Deng", Department = "IT" });
            empTree.Insert(new Employee { Id = 4, FirstName = "Meng", LastName = "Deng", Department = "Sales" });

            Console.WriteLine("List of departments");
            //var depts = empTree.Select(d => d.Department).Distinct();
            var depts = (from d in empTree select d.Department).Distinct();
            foreach (var dept in depts)
            {
                Console.WriteLine($"Department:{dept}");
            }

            Console.WriteLine("Employees in the IT department");
            //var ITEmployees = empTree.Where(e => String.Equals(e.Department, "IT")).Select(emp => emp);
            var ITEmployees = from e in empTree where String.Equals(e.Department, "IT") select e;
            foreach (var emp in ITEmployees)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("All employees grouped by department");
            var employeesByDept = from e in empTree group e by e.Department;
            foreach (var dept in employeesByDept)
            {
                Console.WriteLine($"Department:{dept.Key}");
                foreach (var emp in dept)
                {
                    Console.WriteLine($"\t{emp.FirstName}{emp.LastName}");
                }
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("All employees");
            var allEmployees = from e in empTree.ToList<Employee>() select e;  //加入将消除推迟求值
            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp);
            }

            empTree.Insert(new Employee { Id = 5, FirstName = "Bill", LastName = "Gates", Department = "Microsoft" });

            Console.WriteLine("All employees Two");
            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp);
            }

        }

        static void Main()
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
