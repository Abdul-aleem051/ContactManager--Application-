using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewContactManager
{
    public interface IContactManager
    {
        void AddContact(string name, string phoneNumber, string? email);

        void SearchContactById(int id);

        void SearchContactByPhoneNumber(string phoneNumber);

        void ListAllContacts();

        void UpdateContact(int id, string name, string mobileNumber, string? email, string? alternatePhone, string? workPhone, ContactType? contactType);

        void DeleteContact(int id);
    }
}