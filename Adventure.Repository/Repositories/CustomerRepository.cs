using Adventure.Repository.Entity;
using Adventure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Adventure.Repository
{
    /// <summary>
    /// CustomerRepository implementation.
    /// </summary>
    public class CustomerRepository: ICustomerRepository
    {
        #region Members

        private readonly adventureDevEntities _context;

        #endregion

        #region Constructor

        public CustomerRepository(adventureDevEntities context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.AsEnumerable();
        }

        /// <inheritdoc />
        public void Add(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    _context.Customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Update(Customer customer)
        {
            try
            {
                //var local = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                if (customer != null)
                {
                    //local.Name = customer.Name;
                    //local.Active = customer.Active;
                    //local.CustomerName = customer.CustomerName;
                    //local.OfficialName = customer.OfficialName;
                    //local.ReportingLanguage = customer.ReportingLanguage;
                    //local.SubscriptionId = customer.SubscriptionId;
                    //local.Type = customer.Type;

                    //_context.Entry(local).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Delete(Guid customerId)
        {
            try
            {
                //var customerEntity =
                //    _context
                //    .Customers
                //        .SingleOrDefault(customer => customer.Id == customerId);

                //if (customerEntity != null)
                //{
                    //_context
                    //    .Customers
                    //    .Local
                    //        .Where(customer => customer.Id == customerId &&
                    //              (customer.AdditionalServices == null ||
                    //               customer.Contacts == null ||
                    //               customer.CustomerTypes == null ||
                    //               customer.CustomerTeamMembers == null ||
                    //               customer.CustomerTypes == null ||
                    //               customer.Services == null ||
                    //               customer.Tests == null ||
                    //               customer.TestObjects == null
                    //              ))
                    //    .ToList()
                    //    .ForEach(customer =>
                    //        _context.Customers.Remove(customer));

                //    _context.Customers.Remove(customerEntity);
                //}
                //else
                //{
                //    {
                //        throw new ArgumentException("Record doesn't exist");
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public Customer GetById(Guid id)
        {
            return _context.Customers.SingleOrDefault(customer => customer.rowguid == id);
        }
        #endregion
    }
}
