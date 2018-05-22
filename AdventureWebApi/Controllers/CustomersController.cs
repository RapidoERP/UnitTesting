#region Using
using Adventure.API.Model;
using AdventureWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
#endregion

namespace AdventureWebApi.Controllers
{
    /// <summary>
    /// Endpoint for customer related information.
    /// </summary>
    [RoutePrefix("api/customers")]   
    public class CustomersController : ApiController
    {
        #region Members

        private readonly ICustomerService _customerService;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor injecting an instance of <see cref="ICustomerService"/>.
        /// </summary>
        /// <param name="customerService">The injected service.</param>
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets and returns all customers.
        /// </summary>
        /// <returns>All found customers.</returns>
        [HttpGet, Route("")]
        [ResponseType(typeof(IEnumerable<CustomerModel>))]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_customerService.GetCustomers());
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Gets a customer by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of the customer that is requested.</param>
        /// <returns>The instance of the found customer.</returns>
        [HttpGet, Route("{id}")]
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Customer Id cannot be empty.");
                }

                CustomerModel customer = _customerService.GetCustomer(id);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        
        /// <summary>
        /// Creates a new instance of a customer.
        /// </summary>
        /// <param name="customer">The customer that needs to be created.</param>
        /// <returns>Created when the instance is created.</returns>
        [HttpPost, Route("")]
        [ResponseType(typeof(void))]       
        public IHttpActionResult Post(CustomerModel customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("Customer cannot be null or empty.");
                }

                int result = _customerService.Create(customer);

                return Created(result.ToString(), customer);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Updates a excisting customer instance.
        /// </summary>
        /// <param name="customer">The customer data that needs to be percisted.</param>
        /// <returns>Ok when the instance is updated.</returns>
        [HttpPut, Route("")]
        [ResponseType(typeof(void))]        
        public IHttpActionResult Put(CustomerModel customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("Customer cannot be null or empty.");
                }

                _customerService.Update(customer);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an instance of a customer by it's unique identifier.
        /// </summary>
        /// <param name="id">the indentifier of the instance that needs to be deleted.</param>
        /// <returns>Ok when the instance is deleted.</returns>
        [HttpDelete, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Customer Id cannot be empty.");
                }

                _customerService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        #endregion
    }
}