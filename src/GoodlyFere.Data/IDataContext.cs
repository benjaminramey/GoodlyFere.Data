#region License

// ------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDataContext.cs">
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
using System.Linq;

#endregion

namespace GoodlyFere.Data
{
    /// <summary>
    ///     The creation of the IDataContext represents the beginning of a business
    ///     transaction.  It's disposal should mark the completion of a business
    ///     transaction.
    /// </summary>
    public interface IDataContext : IReadOnlyDataContext
    {
        #region Public Methods

        T Create<T>(T newObject);

        T Delete<T>(T objectToDelete);

        T Update<T>(T newObject);

        void SaveChanges();

        #endregion
    }
}