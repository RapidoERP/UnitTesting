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
                var local = _context.Customers.SingleOrDefault(c => c.CustomerID == customer.CustomerID);
                if (customer != null)
                {
                    local.CompanyName = customer.CompanyName;
                    local.CustomerAddresses = customer.CustomerAddresses;
                    local.EmailAddress = customer.EmailAddress;
                    local.FirstName = customer.FirstName;
                    local.LastName = customer.LastName;
                    local.MiddleName = customer.MiddleName;
                    local.ModifiedDate = customer.ModifiedDate;
                    local.NameStyle = customer.NameStyle;
                    local.PasswordHash = customer.PasswordHash;
                    local.PasswordSalt = customer.PasswordSalt;
                    local.Phone = customer.Phone;
                    local.rowguid = customer.rowguid == Guid.Empty ? Guid.NewGuid() : customer.rowguid;
                    local.Suffix = customer.Suffix;
                    local.Title = customer.Title;
                    _context.Entry(local).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Delete(int customerId)
        {
            try
            {
                var customerEntity =
                    _context
                    .Customers
                        .SingleOrDefault(customer => customer.CustomerID == customerId);

                if (customerEntity != null)
                {
                    _context.Customers.Remove(customerEntity);
                }
                else
                {
                    {
                        throw new ArgumentException("Record doesn't exist");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public Customer GetById(int id)
        {
            return _context.Customers.SingleOrDefault(customer => customer.CustomerID == id);
        }
        #endregion
    }
}
