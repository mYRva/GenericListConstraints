using System;
using System.Collections.Generic;

namespace appTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameToFind = "John";

            var myList = new CustomList<Person>();
            myList.AddHead(new Person("John", "Doe", 1));
            myList.AddHead(new Employee("EmpX13","Anna", "Duval", 2));
            myList.AddHead(new Employee("EmpX14","Marcus", "Clinton", 3));

            var lst = myList.FindFirstMatchByName(nameToFind);

            if (lst != null)
            {
                Console.WriteLine(lst._name + "'s LastName is " + lst._lastName + " and Id is");
            }
            
            else
            {
                Console.WriteLine("No se encontraron coincidencias");
            }         

        }
    }

    public class Person
    {
    //TODO: Implement constructor using expression bodies declaration
    //TODO: Implement 3 properties: (string) Name, (string) LastName and (int) Id
        public string _name;
        public string _lastName;
        public int _id;

        public Person(string Name, string LastName, int Id)
        {
            _name = Name;
            _lastName = LastName;
            _id = Id;
        }

    }
    public class Employee: Person
    {
        //TODO: Employee class should derive from Person class
        //TODO: Add a property called (string) EmpId
        //TODO: Implement constructor that accepts EmpId and passes other 3 values to parent class
        public string _empId;

        public Employee(string EmpId, string Name, string LastName, int Id):base(Name, LastName,Id)
        {
            _empId = EmpId;

        }
    }

    public class CustomList<T> where T : Person
    {
        private class Node
        {
            public Node(T t) => (Next, Data) = (null, t);

            public Node Next { get; set; }
            public T Data { get; set; }
        }

        private Node head;

        public void AddHead(T t)
        {
            Node n = new Node(t) { Next = head };
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T FindFirstMatchByName(string name)
        {
            Node current = head;
            //Given a variable t of a parameterized type T, the statement t = null is only valid if T is a reference type and t = 0 will 
            //only work for numeric value types but not for structs. The solution is to use the default keyword, which will return null for reference types and zero for numeric value types. 
            //For structs, it will return each member of the struct initialized to zero or null depending on whether they are value or reference types. 
            //For nullable value types, default returns a System.Nullable, which is initialized like any struct.

            //With the new syntax from C# 7.1, you can be able to return:
            //return default;
            
            T t = default;

            while (current != null)
            {
                if (current.Data._name == name)
                {
                    t = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }

            return t;
        }
    }


   
    
}


 
