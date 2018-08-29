using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessServices;
using BusinessEntities;
using System.ComponentModel;

namespace ContactInformation.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly IContactDetailsServices _contactDetailsServices;
        
        #region Public Constructor

        public ContactDetailsController()
        {
            _contactDetailsServices = new ContactDetailsServices();
        }

        #endregion

        // GET: ContactDetails
        public ActionResult Index()
        {
            IEnumerable<ContactDetailsEntity> collContacts = _contactDetailsServices.GetAllContactDetails();
            if (collContacts == null)
                collContacts = new List<ContactDetailsEntity>();
            return View(collContacts);
        }

        // GET: ContactDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int contactId = (int)id;
            ContactDetailsEntity contactDetail = _contactDetailsServices.GetContactDetailsById(contactId);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // GET: ContactDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactDetailsEntity contactDetail)
        {
            if (ModelState.IsValid)
            {
                _contactDetailsServices.CreateContactDetails(contactDetail);
                return RedirectToAction("Index");
            }

            return View(contactDetail);
        }

        // GET: ContactDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int contsatId = (int)id;
            ContactDetailsEntity contactDetail = _contactDetailsServices.GetContactDetailsById(contsatId);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // POST: ContactDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactDetailsEntity contactDetail)
        {
            if (ModelState.IsValid)
            {
                _contactDetailsServices.UpdateContactDetails(contactDetail.ContactId, contactDetail);
                return RedirectToAction("Index");
            }
            return View(contactDetail);
        }

        // GET: ContactDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int contactId = (int)id;
            ContactDetailsEntity contactDetail = _contactDetailsServices.GetContactDetailsById(contactId);
            if (contactDetail == null)
            {
                return HttpNotFound();
            }
            return View(contactDetail);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _contactDetailsServices.DeleteContactDetails(id);
            return RedirectToAction("Index");
        }
    }
}
