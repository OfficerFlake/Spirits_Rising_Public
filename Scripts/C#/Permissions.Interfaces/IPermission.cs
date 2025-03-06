using System;
using System.Collections.Generic;

namespace Permissions.Interfaces
{
    /// <summary>
    /// A permission that can be granted or denied.
    /// 
    /// Permissions are given a default list of members to evaluate against; but can otherwise be tested for any object that implements IPermissionHolder.
    /// Permissions work on a "True/False" basis, and aims to answer the question: "Is this function true for any of the given objects?"
    /// Permissions should apply to one event only. If multiple events need to chain together or depend on each other, you should embed or chain individual permissions.
    /// </summary>
    public interface IPermission
    {
        /// <summary>
        /// An enumberable of anything that the permission can apply to. Can be a single object, could be a class of objects.
        /// 
        /// You can pass a LINQ expression here and the expression will be re-evaluated at runtime.
        /// </summary>
        IEnumerable<IPermissionHolder> Sources { get; set; }

        /// <summary>
        /// A permission function that takes 0 arguments and return a Boolean.
        /// 
        /// We do NOT pass parameters; They must be accessbile and common for every IPermissionHolder in the source.
        /// We assign a Lambda function to this property, that makes use of the properties of the Sources.
        /// 
        /// By using an Enumerable with the Lambda function, we process the permission check at the time the check is required, with updated context.
        /// </summary>
        Func<IEnumerable<IPermissionHolder>, bool> PermissionsFunction { get; set; }
    }
}
