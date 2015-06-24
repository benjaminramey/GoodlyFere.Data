#region License

// ------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseDataContext.cs">
//  GoodlyFere.NServiceBus.EntityFramework
//  
//  Copyright (C) 2014 
//  
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 2.1 of the License, or (at your option) any later version.
//  This library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//  Lesser General Public License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
//  
//  http://www.gnu.org/licenses/lgpl-2.1-standalone.html
//  
//  You can contact me at ben.ramey@gmail.com.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using GoodlyFere.Criteria;

#endregion

namespace GoodlyFere.Data
{
    public abstract class BaseDataContext : IDataContext
    {
        #region Methods

        protected abstract IRepository<T> GetRepository<T>();

        #endregion

        #region Public Methods

        public virtual T Create<T>(T newObject)
        {
            var repo = GetRepository<T>();
            return repo.Create(newObject);
        }

        public virtual T Delete<T>(T objectToDelete)
        {
            var repo = GetRepository<T>();
            return repo.Delete(objectToDelete);
        }

        public abstract void Dispose();

        public virtual IList<T> Find<T>(ICriteria<T> criteria)
        {
            var repo = GetRepository<T>();
            return repo.Find(criteria);
        }

        public virtual T FindById<T>(object id)
        {
            var repo = GetRepository<T>();
            return repo.FindById(id);
        }

        public virtual T FindOne<T>(ICriteria<T> criteria)
        {
            var repo = GetRepository<T>();
            return repo.FindOne(criteria);
        }

        public virtual T FindOne<T, TSortKey>(ICriteria<T> criteria, Expression<Func<T, TSortKey>> ordering, bool desc = false)
        {
            var repo = GetRepository<T>();
            return repo.FindOne(criteria, ordering, desc);
        }

        public virtual IList<T> GetAll<T>()
        {
            var repo = GetRepository<T>();
            return repo.GetAll();
        }

        public virtual T GetOne<T>()
        {
            var repo = GetRepository<T>();
            return repo.FindOne();
        }

        public virtual void LoadChildren<T>(T obj, string propertyName)
        {
            var repo = GetRepository<T>();
            repo.LoadChildren(obj, propertyName);
        }

        public virtual void LoadParent<T>(T obj, string propertyName)
        {
            var repo = GetRepository<T>();
            repo.LoadParent(obj, propertyName);
        }

        public virtual T Update<T>(T newObject)
        {
            var repo = GetRepository<T>();
            return repo.Update(newObject);
        }

        public abstract DbTransaction BeginTransaction(IsolationLevel isolationLevel);

        public abstract void SaveChanges();

        #endregion
    }
}