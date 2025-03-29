using System;
using System.Collections.Generic;

namespace Modules.Permissions.Interfaces
{
    public static class PermissionExtensions
    {
        /// <summary>
        /// Check if the permission is granted for any of the predefined Sources.
        /// </summary>
        /// <param name="permission">The permission to check.</param>
        /// <returns>True if the permission is granted, false otherwise.</returns>
        public static bool Can(this IPermission permission)
        {
            return permission.PermissionsFunction(permission.Sources);
        }

        /// <summary>
        /// Check if the permission is denied for any of the predefined Sources.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool Cannot(this IPermission permission)
        {
            return !permission.Can();
        }
        /// <summary>
        /// Check if the permission would be granted for the source if the source was in the include list.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool Can(this IPermissionHolder source, IPermission permission)
        {
            return permission.PermissionsFunction(new List<IPermissionHolder> { source });
        }

        /// <summary>
        /// Check if the permission would be denied for the source if the source was in the include list.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool Cannot(this IPermissionHolder source, IPermission permission)
        {
            return !Can(source, permission);
        }

        /// <summary>
        /// Check if the permission would be granted for the source if the source was in the include list.
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool Can(this IEnumerable<IPermissionHolder> sources, IPermission permission)
        {
            return permission.PermissionsFunction(sources);
        }

        /// <summary>
        /// Check if the permission would be denied for the source if the source was in the include list.
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool Cannot(this IEnumerable<IPermissionHolder> sources, IPermission permission)
        {
            return !Can(sources, permission);
        }
    }
}
