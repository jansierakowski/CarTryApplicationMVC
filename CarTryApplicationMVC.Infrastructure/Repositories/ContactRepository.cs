using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarTryApplicationMVC.Domain.Interfaces;
using CarTryApplicationMVC.Domain.Model;

namespace CarTryApplicationMVC.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }
        public int AddContact(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return contact.Id;
        }

        public void DeleteContact(int contactId)
        {
            var contact = _context.Contacts.Find(contactId);
            if (contact !=null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }

        public IQueryable<Car> GetCarsAdsByContactId(int contactId)
        {
            var cars = _context.Cars.Where(a => a.Contact.Id == contactId);
            return cars;
        }

        public IQueryable<CustomerFeedback> GetContactFeedbeckByContactId(int contactId)
        {
            var contactFeedback = _context.CustomerFeedbacks.Where(a => a.Contact.Id == contactId);
            return contactFeedback;
        }

        public IQueryable<ContactDetail> GetDetailContactInfotmationByContactId(int contactId)
        {
            var detialContact = _context.ContactDetails.Where(a => a.Contact.Id == contactId);
            return detialContact;
        }
    }
}
