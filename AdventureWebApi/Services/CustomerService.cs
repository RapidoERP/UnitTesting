#region Using
using Adventure.API.Model;
using Adventure.Repository.Entity;
using Adventure.Repository.Interfaces;
using AdventureWebApi.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
#endregion

namespace AdventureWebApi.Services
{
    /// <summary>
    /// Service implementation for the customer related data.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        #region Members

        private readonly IUnitOfWork _unitofWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor injecting an instance of <see cref="IUnitOfWork"/>.
        /// </summary>
        /// <param name="unitofWork">The injected instance of <see cref="IUnitOfWork"/>.</param>
        public CustomerService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public IEnumerable<CustomerModel> GetCustomers()
        {
            try
            {
                var result = _unitofWork.CustomerRepository.GetAll();
                return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerModel>>(result);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <inheritdoc />
        public CustomerModel GetCustomer(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = _unitofWork.CustomerRepository.GetById(id);
                    if(result == null)
                    {
                        return null;
                    }

                    return Mapper.Map<Customer, CustomerModel>(result);
                }
                
                throw new ArgumentException("Customer Id cannot be null (or) empty.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        /// <inheritdoc />
        public int Create(CustomerModel customer)
        {
            try
            {
                if (customer != null)
                {
                    customer.rowguid = customer.rowguid == Guid.Empty ? Guid.NewGuid() : customer.rowguid;
                    var result = Mapper.Map<CustomerModel, Customer>(customer);
                    _unitofWork.CustomerRepository.Add(result);
                    _unitofWork.Save();
                    return customer.CustomerID;
                }
                throw new ArgumentException("Customer is empty");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Update(CustomerModel customer)
        {
            try
            {
                if (customer != null)
                {
                    var result = Mapper.Map<CustomerModel,Customer>(customer);
                    _unitofWork.CustomerRepository.Update(result);
                    _unitofWork.Save();
                }
                else
                {
                    throw new ArgumentException("Customer is empty");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _unitofWork.CustomerRepository.Delete(id);
                    _unitofWork.Save();
                }
                else
                {
                    throw new ArgumentException("Customer Id cannot be null (or) empty.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        #endregion
    }
}