using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    /// <summary>
    /// Product Service Contract
    /// </summary>
    public interface IContactDetailsServices
    {
        ContactDetailsEntity GetContactDetailsById(int? contactId);
        IEnumerable<ContactDetailsEntity> GetAllContactDetails();
        int CreateContactDetails(ContactDetailsEntity contactDetailsEntity);
        bool UpdateContactDetails(int contactId, ContactDetailsEntity contactDetailsEntity);
        bool DeleteContactDetails(int contactId);
    }
}
