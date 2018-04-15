/* 
 * ServiceContainer
 * =====================================================================
 * FileName: service_container.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

using System;
using System.Collections.Generic;

namespace Troya.GXI
{
    public class ServiceContainer : IServiceProvider
    {
        Dictionary<Type, object> services;


        public ServiceContainer( ) {
            this.services = new Dictionary<Type, object>( );
        }

        public void AddService<T>( T service ) {
            this.services.Add( typeof( T ), service );
        }
        public void RemoveService( object service ) {
            this.services.Remove( ( Type )service.GetType( ) );
        }
        public object GetService( Type serviceType ) {
            object service = null;
            this.services.TryGetValue( serviceType, out service );

            return service;
        }
    }
}