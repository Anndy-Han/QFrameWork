using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QFrameWork
{
    public interface IZipHelper
    {
        /// <summary>
        /// 压缩数据。
        /// </summary>
        /// <param name="bytes">要压缩的数据。</param>
        /// <returns>压缩后的数据。</returns>
        byte[] Compress(byte[] bytes);

        /// <summary>
        /// 解压缩数据。
        /// </summary>
        /// <param name="bytes">要解压缩的数据。</param>
        /// <returns>解压缩后的数据。</returns>
        byte[] Decompress(byte[] bytes);

    }
}
