// =============================================================
// Copyright (c) 2021 huaaopro, All rights reserved.
// http://www.huaaopro.com
// 
// FrameworkUnityPlugin
// 
// Filename: Utitity.Marshal.cs
// Date:     2021/06/06
// Email:    huaaopro@163.com
// =============================================================

using System;

namespace FrameworkUnityPlugin
{
    public static partial class Utility
    {
        public static class Marshal
        {
            private const int BLOCK_SIZE = 1024 * 2;
            
            private static IntPtr s_CachedHGlobalPtr = IntPtr.Zero;
            private static int s_CachedHGlobalSize = 0;

            internal static IntPtr CachedHGlobalPtr 
            {
                get {
                    return s_CachedHGlobalPtr;
                }
            }

            internal static int CachedHGlobalSize
            {
                get {
                    return s_CachedHGlobalSize;
                }
            }

            public static void MallocCachedHGlobalSize(int size)
            {
                if (size < 0) {
                    throw new FrameworkException("Malloc size is invalid.");
                }

                if (s_CachedHGlobalPtr == IntPtr.Zero || s_CachedHGlobalSize < size) {
                    FreeCachedHGlobal();
                    int cachedSize = (size - 1 + BLOCK_SIZE) / BLOCK_SIZE * BLOCK_SIZE;
                    s_CachedHGlobalPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(cachedSize);
                    s_CachedHGlobalSize = cachedSize;
                }
            }

            public static void FreeCachedHGlobal()
            {
                if (s_CachedHGlobalPtr != IntPtr.Zero) {
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(s_CachedHGlobalPtr);
                    s_CachedHGlobalPtr = IntPtr.Zero;
                    s_CachedHGlobalSize = 0;
                }
            }

            public static byte[] StructureToBytes<T>(T structure)
            {
                return StructureToBytes(structure, System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)));
            }

            internal static byte[] StructureToBytes<T>(T structure, int structureSize)
            {
                if (structureSize < 0) {
                    throw new FrameworkException("Structure size is Invalid");
                }
                MallocCachedHGlobalSize(structureSize);
                System.Runtime.InteropServices.Marshal.StructureToPtr(structure, s_CachedHGlobalPtr, true);
                byte[] bytes = new byte[structureSize];
                System.Runtime.InteropServices.Marshal.Copy(s_CachedHGlobalPtr, bytes, 0, structureSize);
                return bytes;
            }

            public static void StructureToBytes<T>(T structure, byte[] bytes)
            {
                StructureToBytes(structure, System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)), bytes, 0);
            }

            public static void StructureToBytes<T>(T structure, int structureSize, byte[] bytes)
            {
                StructureToBytes(structure, structureSize, bytes, 0);
            }

            public static void StructureToBytes<T>(T structure, byte[] bytes, int startIndex)
            {
                StructureToBytes(structure, System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)), bytes, startIndex);
            }

            internal static void StructureToBytes<T>(T structure, int structureSize, byte[] bytes, int startIndex)
            {
                if (structureSize < 0) {
                    throw new FrameworkException("Structure size is invalid.");
                }

                if (bytes == null) {
                    throw new FrameworkException("Byte buffer is invalid.");
                }

                if (startIndex < 0) {
                    throw new FrameworkException("Start index is invalid.");
                }

                if (startIndex + structureSize > bytes.Length) {
                    throw new FrameworkException("Byte buffer is not enough.");
                }
                
                MallocCachedHGlobalSize(structureSize);
                System.Runtime.InteropServices.Marshal.StructureToPtr(structure, s_CachedHGlobalPtr, true);
                System.Runtime.InteropServices.Marshal.Copy(s_CachedHGlobalPtr, bytes, startIndex, structureSize);
            }

            public static T BytesToStructure<T>(byte[] bytes)
            {
                return BytesToStructure<T>(System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)), bytes, 0);
            }

            public static T BytesToStructure<T>(byte[] bytes, int startIndex)
            {
                return BytesToStructure<T>(System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)), bytes, startIndex);
            }

            public static T BytesToStructure<T>(int structureSize, byte[] bytes)
            {
                return BytesToStructure<T>(structureSize, bytes, 0);
            }

            internal static T BytesToStructure<T>(int structureSize, byte[] bytes, int startIndex)
            {
                if (structureSize < 0) {
                    throw new FrameworkException("Structure size is invalid.");
                }

                if (bytes == null) {
                    throw new FrameworkException("Byte buffer is invalid.");
                }

                if (startIndex < 0) {
                    throw new FrameworkException("Start index is invalid.");
                }

                if (startIndex + structureSize > bytes.Length) {
                    throw new FrameworkException("Byte buffer length is not enough.");
                }
                
                MallocCachedHGlobalSize(structureSize);
                System.Runtime.InteropServices.Marshal.Copy(bytes, startIndex, s_CachedHGlobalPtr, structureSize);
                return (T) System.Runtime.InteropServices.Marshal.PtrToStructure(s_CachedHGlobalPtr, typeof(T));
            }

        }
    }
}