using CarTryApplicationMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTryApplicationMVC.Domain.Interfaces
{
    public interface IContactRepository
    {
        int AddContact(Contact contact);
        void DeleteContact(int contactId);
        IQueryable<ContactDetail> GetDetailContactInfotmationByContactId(int contactId);
        IQueryable<Car> GetCarsAdsByContactId(int contactId);
        IQueryable<CustomerFeedback> GetContactFeedbeckByContactId(int contactId);

    }
}
