using System;
using System.Collections.Generic;

namespace Modules.Permissions.Interfaces
{
    /// <summary>
    /// A generic tag that applies to anything that an IPermission should apply to.
    /// 
    /// There is zero properties for anything implemention, this is intentional.
    /// If we want to query the underlying object, we cast it to the appropriate type and check nullity in the PermissionFunction.
    /// </summary>
    public interface IPermissionHolder
    {
    }
}
