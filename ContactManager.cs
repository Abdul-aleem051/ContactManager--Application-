using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NewContactManager
{
    public class ContactManager : IContactManager
    {
        private readonly List<Contact> Contacts;
        private int _nextId;

        public ContactManager()
        {
            Contacts = new List<Contact>();
            _nextId = 1;
        }

        public void AddContact(string name, string phoneNumber, string? email)
        {
            try
            {
                if (ValidatePhoneNumber(phoneNumber))
                {
                    Console.WriteLine("Invalid phone number. It should be exactly 11 digits and contain no special characters.");
                    return;
                }

                if (ValidateContactName(name))
                {
                    Console.WriteLine("Invalid name. It should be at least 3 characters long and contain no special characters (except spaces and @).");
                    return;
                }

                if (IsContactExist(phoneNumber))
                {
                    Console.WriteLine($"Contact with {phoneNumber} already exists!");
                    return;
                }

                var contact = new Contact
                {
                    Id = _nextId++,
                    Name = name,
                    MobileNumber = phoneNumber,
                    Email = email,
                    CreatedAt = DateTime.Now
                };

                Contacts.Add(contact);
                Console.WriteLine($"Contact with name {contact.Name} and id {contact.Id} successfully created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the contact: {ex.Message}");
            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                var contact = Contacts.Find(x => x.Id == id);

                if (contact is null)
                {
                    Console.WriteLine("Contact you are trying to delete does not exist!");
                    return;
                }

                bool isRemoved = Contacts.Remove(contact);

                string result = isRemoved
                    ? "Contact removed successfully!"
                    : "Unable to remove contact!";

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the contact: {ex.Message}");
            }
        }

        public void ListAllContacts()
        {
            try
            {
                if (Contacts.Count == 0)
                {
                    Console.WriteLine("There is no contact in the record yet! Add a new contact.");
                    return;
                }

                foreach (var contact in Contacts)
                {
                    var formattedDate = contact.CreatedAt.ToString("dd MMM yyyy");
                    var contactData = $"Id: {contact.Id}\tName: {contact.Name}\tPhone: {contact.MobileNumber}\tEmail: {contact.Email}\tCreated: {formattedDate}";
                    Console.WriteLine(contactData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while listing contacts: {ex.Message}");
            }
        }

        public void SearchContactById(int id)
        {
            try
            {
                var contact = Contacts.Find(x => x.Id == id);

                if (contact is null)
                {
                    Console.WriteLine("Contact does not exist!");
                    return;
                }

                var result = $"""
                =====CONTACT DETAILS=====
                Name: {contact.Name}
                Mobile Number: {contact.MobileNumber}
                Email: {contact.Email ?? "N/A"}
                Alternate Mobile: {contact.AlternateMobileNumber ?? "N/A"}
                Work Number: {contact.WorkNumber ?? "N/A"}
                Contact Type: {contact.ContactType?.ToString() ?? "N/A"}
                """;

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching for the contact by Id: {ex.Message}");
            }
        }

        public void SearchContactByPhoneNumber(string mobileNumber)
        {
            try
            {
                var contact = Contacts.Find(x => x.MobileNumber == mobileNumber);

                if (contact is null)
                {
                    Console.WriteLine("Contact does not exist!");
                    return;
                }

                var result = $"""
                =====CONTACT DETAILS=====
                Name: {contact.Name}
                Mobile Number: {contact.MobileNumber}
                Email: {contact.Email ?? "N/A"}
                Alternate Mobile: {contact.AlternateMobileNumber ?? "N/A"}
                Work Number: {contact.WorkNumber ?? "N/A"}
                Contact Type: {contact.ContactType?.ToString() ?? "N/A"}
                """;

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching for the contact by phone number: {ex.Message}");
            }
        }

        public void UpdateContact(int id, string name, string mobileNumber, string? email, string? alternatePhone, string? workPhone, ContactType? contactType)
        {
            try
            {
                if (ValidatePhoneNumber(mobileNumber))
                {
                    Console.WriteLine("Invalid phone number. It should be exactly 11 digits and contain no special characters.");
                    return;
                }

                if (ValidateContactName(name))
                {
                    Console.WriteLine("Invalid name. It should be at least 3 characters long and contain no special characters (except spaces and @).");
                    return;
                }

                var contact = Contacts.Find(x => x.Id == id);

                if (contact is null)
                {
                    Console.WriteLine("Contact you are trying to edit does not exist!");
                    return;
                }

                if (contactType.HasValue && !Enum.IsDefined(typeof(ContactType), contactType.Value))
                {
                    Console.WriteLine("Invalid contact type.");
                    return;
                }

                contact.Name = name;
                contact.MobileNumber = mobileNumber;
                contact.Email = email;
                contact.AlternateMobileNumber = alternatePhone;
                contact.WorkNumber = workPhone;
                contact.ContactType = contactType;

                Console.WriteLine("Contact was updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the contact: {ex.Message}");
            }
        }

        private bool IsContactExist(string phoneNumber)
        {
            return Contacts.Any(c => c.MobileNumber == phoneNumber);
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 11 && Regex.IsMatch(phoneNumber, @"^\/%$");
        }

        private bool ValidateContactName(string name)
        {
            return name.Length >= 3 && Regex.IsMatch(name, @"%*&#$");
        }
    }
}