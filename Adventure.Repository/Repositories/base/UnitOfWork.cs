#region Using
using Adventure.Repository.Entity;
using Adventure.Repository.Interfaces;
using Unity;
using System;
using Unity.Attributes;
#endregion

namespace Adventure.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private Members

        private readonly adventureDevEntities context;

        #endregion

        /// <summary>
        /// Constructor injecting an instance of <see cref="HaaSEntities"/>.
        /// </summary>
        /// <param name="haasContext">The injected <see cref="HaaSEntities"/>.</param>
        public UnitOfWork(adventureDevEntities context)
        {
            this.context = context;
        }

        #region Public Members

        [Dependency]
        public ICustomerRepository CustomerRepository { get; set; }

        
        #endregion

        #region Public Methods

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        #endregion

    }
}