using System;

namespace CicekSepeti.Repository
{
    //UnitOfWork for db context
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}