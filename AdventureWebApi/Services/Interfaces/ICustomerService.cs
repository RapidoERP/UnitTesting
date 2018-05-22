#region Using
using Adventure.API.Model;
using Adventure.Repository.Entity;
using System;
using System.Collections.Generic;
#endregion

namespace AdventureWebApi.Interfaces
{
    /// <summary>
    /// Interface for the customer service implementation.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Gets a list of all <see cref="CustomerModel"/> instances.
        /// </summary>
        /// <returns>List of all <see cref="CustomerModel"/> instances.</returns>
        IEnumerable<CustomerModel> GetCustomers();

        /// <summary>
        /// Gets an instance of <see cref="CustomerModel"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of instance that needs to be returned.</param>
        /// <returns>The found instance of <see cref="CustomerModel"/>.</returns>
        CustomerModel GetCustomer(int id);

        /// <summary>
        /// Creates a new instance of <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The instance that needs to be stored.</param>
        int Create(CustomerModel customer);

        /// <summary>
        /// Updates an excisting instance of <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The customer data that needs to be stored.</param>
        void Update(CustomerModel customer);

        /// <summary>
        /// Detelte an instance of <see cref="Customer"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the instance that needs to be deleted.</param>
        void Delete(int id);
        
    }
}