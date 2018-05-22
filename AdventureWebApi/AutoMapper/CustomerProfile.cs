#region Using
using AutoMapper;
using Adventure.Repository.Entity;
using Adventure.API.Model;
#endregion

namespace AdventureWebApi.AutoMapper
{
    /// <summary>
    /// Profile for customer mappings.
    /// </summary>
    public class CustomerProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerModel>();

            CreateMap<CustomerModel, Customer>();
        }
    }
}