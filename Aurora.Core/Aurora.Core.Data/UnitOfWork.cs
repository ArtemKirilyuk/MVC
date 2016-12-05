﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Core.Data
{
    
    /// <summary>
    /// The unit of work guarantees that all the repositories will use the same context(during a request)
    /// </summary>
    /// <typeparam name="DB"></typeparam>
    public class UnitOfWork<DB> : IUnitOfWork<DB> where DB : DbContext, IAuditableDBContext, new() 
    {
        /// <summary>
        /// The user name that modifies the object
        /// </summary>
        private readonly ICurrentUserService _currentUserService;
        
        private readonly DbFactory<DB> _dbFactory;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="dbFactory">The factory that will provide the DBContext object</param>
        /// <param name="currentUserService">A service that will return the name of the user that will be used to audit
        /// all the objects of type 'EntityBase'. Usually the implementation should be HttpContext.Current.User.Identity.Name </param>
        public UnitOfWork(DbFactory<DB> dbFactory,
                        ICurrentUserService currentUserService)
        {
            if (dbFactory == null)
            {
                throw new ArgumentNullException("dbFactory", "The 'dbFactory' parameter cannot be null!");
            }
            if (currentUserService==null)
            {
                throw new ArgumentNullException("currentUserService", "The 'currentUserService' parameter cannot be null!");
            }

            _currentUserService = currentUserService;
            _dbFactory = dbFactory;
        }

        public DB DbContext
        {
            get { return _dbFactory.DBContext(); }
        }

        public DbFactory<DB> DbFactory
        {
            get { return _dbFactory; }
        }


        public string UserName
        {
            get
            {
                return _currentUserService.GetCurrentUser();
            }
        }

        public void Commit()
        {
            DbContext.SaveChanges(UserName);
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }


        //TODO:Provide functionality for repository registration

    }
}
