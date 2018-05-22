using System;
using System.Collections.Generic;
using Adventure.Repository.Entity;

namespace Adventure.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets a list of all <see cref="Customer"/> instances.
        /// </summary>
        /// <returns>List of all <see cref="Customer"/> instances.</returns>
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Gets an instance of <see cref="Customer"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of instance that needs to be returned.</param>
        /// <returns>The found instance of <see cref="Customer"/>.</returns>
        Customer GetById(int id);

        /// <summary>
        /// Adds/stores a new instance of <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The instance that needs to be stored.</param>
        void Add(Customer customer);

        /// <summary>
        /// Updates an excisting instance of <see cref="Customer"/>.
        /// </summary>
        /// <param name="customer">The customer data that needs to be stored.</param>
        void Update(Customer customer);

        /// <summary>
        /// Detelte an instance of <see cref="Customer"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the instance that needs to be deleted.</param>
        void Delete(int id);
    }
}
