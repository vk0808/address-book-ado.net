using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Address Book ADO.NET\n");

            // Object instantiation
            PersonModel person = new PersonModel();
            AddressBookRepo repo = new AddressBookRepo();

            //Add record
            person.FirstName = "Madana";
            person.LastName = "Mohana";
            person.Address = "13th cross";
            person.City = "Hyderabad";
            person.State = "Andhra Pradesh";
            person.Zip = "522403";
            person.PhoneNumber = "1234567890";
            person.Email = "mohan@gmail.com";
            person.BookName = "book3";
            person.BookType = "Profession";

            if (repo.AddEmployee(person))
            {
                Console.WriteLine("\nPerson added successfully");
            }

            // Call method
            repo.GetAllPeople();
        }
    }
}
