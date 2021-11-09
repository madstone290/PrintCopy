using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.Utils
{
    public class ArrayUtil
    {
        /// <summary>
        /// 바이트 배열 비교
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static bool ArrayEquals(byte[] array1, byte[] array2)
        {
            if (array1 == null || array2 == null)
                return false;

            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 바이트 배열 비교
        /// </summary>
        /// <param name="array1">배열1</param>
        /// <param name="array2">배열2</param>
        /// <param name="length">비교할 길이</param>
        /// <returns></returns>
        public static bool ArrayEquals(byte[] array1, byte[] array2, int length)
        {
            if (array1 == null || array2 == null)
                return false;

            if(array1.Length < length || array2.Length < length)
                return false;

            for (int i = 0; i < length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 바이트배열 검색
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int FindIndex(byte[] source, byte[] target, int startIndex)
        {
            if (source == null || source.Length == 0)
                throw new ArgumentException(nameof(source));
            if (target == null || target.Length == 0)
                throw new ArgumentException(nameof(target));

            int sourceLength = source.Length;
            int targetLength = target.Length;

            for (int sourceIndex = startIndex; sourceIndex < sourceLength - targetLength + 1; sourceIndex++)
            {
                bool match = true;
                for (int targetIndex = 0; targetIndex < targetLength; targetIndex++)
                {
                    if (source[sourceIndex + targetIndex] != target[targetIndex])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                    return sourceIndex;
            }

            return -1;
        }

    }
}
