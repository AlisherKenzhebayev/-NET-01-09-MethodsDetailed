// <copyright file="GcdFinder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET_01_09_MethodsInDetails
{
    using System;

    public class GcdFinder
    {
        public int EuclidGcd(int x, int y)
        {
            x = (x < 0) ? -x : x;
            y = (y < 0) ? -y : y;

            if (y == 0)
            {
                return x;
            }

            if (x < y)
            {
                var t = x;
                x = y;
                y = t;
            }

            return this.EuclidGcd(y, x % y);
        }

        public int EuclidGcd(int x, int y, int z)
        {
            return this.EuclidGcd(x, this.EuclidGcd(y, z));
        }

        public int EuclidGcd(int[] arr)
        {
            if (arr.Length < 1)
            {
                throw new ArgumentException("Array too short");
            }

            var retval = arr[0];
            foreach (var t in arr)
            {
                retval = this.EuclidGcd(retval, t);
            }

            return retval;
        }

        public int BinaryGcd(int u, int v)
        {
            u = (u < 0) ? -u : u;
            v = (v < 0) ? -v : v;

            if (u == v)
            {
                return u;
            }

            if (u == 0)
            {
                return v;
            }

            if (v == 0)
            {
                return u;
            }

            if (u % 2 == 0)
            {
                if (v % 2 == 1)
                {
                    return this.BinaryGcd(u >> 1, v);
                }
                else
                {
                    return this.BinaryGcd(u >> 1, v >> 1) << 1;
                }
            }

            if (v % 2 == 0)
            {
                return this.BinaryGcd(u, v >> 1);
            }

            if (u > v)
            {
                return this.BinaryGcd(u - v, v);
            }

            return this.BinaryGcd(v, u % v);
        }

        public int BinaryGcd(int x, int y, int z)
        {
            return this.BinaryGcd(x, this.BinaryGcd(y, z));
        }

        public int BinaryGcd(int[] arr)
        {
            if (arr.Length < 1)
            {
                throw new ArgumentException("Array too short");
            }

            var retval = arr[0];
            foreach (var t in arr)
            {
                retval = this.BinaryGcd(retval, t);
            }

            return retval;
        }
    }
}
