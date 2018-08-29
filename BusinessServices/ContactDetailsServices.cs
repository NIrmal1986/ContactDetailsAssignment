using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class ContactDetailsServices : IContactDetailsServices
    {
        private readonly UnitOfWork _unitOfWork;
        private IMapper mapper;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ContactDetailsServices()
        {
            _unitOfWork = new UnitOfWork();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ContactDetail, ContactDetailsEntity>(); });
            mapper = config.CreateMapper();
        }
        /// <summary>
        /// Fetches contact details by id
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ContactDetailsEntity GetContactDetailsById(int? contactId)
        {
            var contactDetail = _unitOfWork.ContactDetailRepository.GetByID(contactId);
            if (contactDetail != null)
            {
                var contactDetailModel = mapper.Map<ContactDetail, ContactDetailsEntity>(contactDetail);
                return contactDetailModel;
            }
            return null;
        }
        /// <summary>
        /// Fetches all the contact details.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessEntities.ContactDetailsEntity> GetAllContactDetails()
        {
            var contactDetails = _unitOfWork.ContactDetailRepository.GetAll().ToList();
            if (contactDetails.Any())
            {                
                var productsModel = mapper.Map<List<ContactDetail>, List<ContactDetailsEntity>>(contactDetails);
                return productsModel;
            }
            return null;
        }
        /// <summary>
        /// Creates a ContactDetails
        /// </summary>
        /// <param name="contactDetailsEntity"></param>
        /// <returns></returns>
        public int CreateContactDetails(BusinessEntities.ContactDetailsEntity contactDetailsEntity)
        {
            using (var scope = new TransactionScope())
            {
                var contactDetail = new ContactDetail
                {
                    FirstName = contactDetailsEntity.FirstName,
                    LastName = contactDetailsEntity.LastName,
                    Email = contactDetailsEntity.Email,
                    PhoneNumber = contactDetailsEntity.PhoneNumber,
                    Status = contactDetailsEntity.Status,
                };
                _unitOfWork.ContactDetailRepository.Insert(contactDetail);
                _unitOfWork.Save();
                scope.Complete();
                return contactDetail.ContactId;
            }
        }
        /// <summary>
        /// Updates a ContactDetails
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="contactDetailsEntity"></param>
        /// <returns></returns>
        public bool UpdateContactDetails(int contactId, ContactDetailsEntity contactDetailsEntity)
        {
            var success = false;
            if (contactDetailsEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var contactDetail = _unitOfWork.ContactDetailRepository.GetByID(contactId);
                    if (contactDetail != null)
                    {
                        contactDetail.FirstName = contactDetailsEntity.FirstName;
                        contactDetail.LastName = contactDetailsEntity.LastName;
                        contactDetail.Email = contactDetailsEntity.Email;
                        contactDetail.PhoneNumber = contactDetailsEntity.PhoneNumber;
                        contactDetail.Status = contactDetailsEntity.Status;
                        _unitOfWork.ContactDetailRepository.Update(contactDetail);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        /// <summary>
        /// Deletes a particular ContactDetail
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool DeleteContactDetails(int contactId)
        {
            var success = false;
            if (contactId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var contactDetail = _unitOfWork.ContactDetailRepository.GetByID(contactId);
                    if (contactDetail != null)
                    {
                        _unitOfWork.ContactDetailRepository.Delete(contactDetail);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}