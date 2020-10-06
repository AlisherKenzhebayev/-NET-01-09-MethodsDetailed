// <copyright file="ExtensionNullable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET_01_09_MethodsInDetails
{
    public static class ExtensionNullable
    {
        public static bool IsNull(this int? nullable)
        {
            return nullable == null;
        }

        public static bool IsNull(this bool? nullable)
        {
            return nullable == null;
        }

        public static bool IsNull(this string nullable)
        {
            return nullable == null;
        }

        public static bool IsNull<T>(this T? nullable)
            where T : struct
        {
            return nullable == null;
        }
    }
}