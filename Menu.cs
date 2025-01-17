using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewContactManager
{
    public class Menu
    {

        private readonly IContactManager _contactManager;

        public Menu()
        {
            _contactManager = new ContactManager();
        }

        public void ContactMenu()
        {
            bool exit = false;

            while (!exit)
            {
                PrintContactMenu();

                Console.Write("Enter option: ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 0:
                            exit = true;
                            break;

                        case 1:
                            Console.Write("Enter contact name:");
                            string name = Console.ReadLine()!;
                            Console.Write("Enter phone number:");
                            string phoneNumber = Console.ReadLine()!;
                            Console.Write("Enter email: ");
                            string? email = Console.ReadLine();
                            _contactManager.AddContact(name, phoneNumber, email);
                            break;

                        case 2:
                            Console.Write("Enter the ID of contact: ");
                            int id = int.Parse(Console.ReadLine()!);
                            _contactManager.SearchContactById(id);
                            break;

                        case 3:
                            Console.Write("Enter the phone number of contact: ");
                            string number = Console.ReadLine()!;
                            _contactManager.SearchContactByPhoneNumber(number);
                            break;

                        case 4:
                            Console.Write("Enter the ID of contact: ");
                            int updateId = int.Parse(Console.ReadLine()!);
                            Console.Write("Enter contact name:");
                            string updatedName = Console.ReadLine()!;
                            Console.Write("Enter phone number:");
                            string updatedPhoneNumber = Console.ReadLine()!;
                            Console.Write("Enter email: ");
                            string? updatedEmail = Console.ReadLine();
                            _contactManager.UpdateContact(updateId, updatedName, updatedPhoneNumber, updatedEmail, null, null, null);
                            break;

                        case 5:
                            _contactManager.ListAllContacts();
                            break;

                        case 6:
                            Console.Write("Enter the ID of contact: ");
                            int deleteId = int.Parse(Console.ReadLine()!);
                            _contactManager.DeleteContact(deleteId);
                            break;

                        default:
                            Console.WriteLine("Invalid operation!");
                            break;
                    }
                }
            }
        }

        private static void PrintContactMenu()
        {
            Console.WriteLine("Enter 1 to Add new contact");
            Console.WriteLine("Enter 2 to Search contact by ID");
            Console.WriteLine("Enter 3 to Search contact by phone number");
            Console.WriteLine("Enter 4 to Update contact");
            Console.WriteLine("Enter 5 to Display all contacts");
            Console.WriteLine("Enter 6 to Delete contact");
            Console.WriteLine("Enter 0 to Exit");
        }
    }
}