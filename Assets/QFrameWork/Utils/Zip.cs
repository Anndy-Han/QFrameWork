﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    public static partial class Zip
    {
        private static IZipHelper s_ZipHelper = null;

        /// <summary>
        /// 设置压缩解压缩辅助器。
        /// </summary>
        /// <param name="zipHelper">要设置的压缩解压缩辅助器。</param>
        public static void SetZipHelper(IZipHelper zipHelper)
        {
            s_ZipHelper = zipHelper;
        }

        /// <summary>
        /// 压缩数据。
        /// </summary>
        /// <param name="bytes">要压缩的数据。</param>
        /// <returns>压缩后的数据。</returns>
        public static byte[] Compress(byte[] bytes)
        {
            if (s_ZipHelper == null)
            {
                throw new Exception("Zip helper is invalid.");
            }

            return s_ZipHelper.Compress(bytes);
        }

        /// <summary>
        /// 解压缩数据。
        /// </summary>
        /// <param name="bytes">要解压缩的数据。</param>
        /// <returns>解压缩后的数据。</returns>
        public static byte[] Decompress(byte[] bytes)
        {
            if (s_ZipHelper == null)
            {
                throw new Exception("Zip helper is invalid.");
            }

            return s_ZipHelper.Decompress(bytes);
        }
    }
}
