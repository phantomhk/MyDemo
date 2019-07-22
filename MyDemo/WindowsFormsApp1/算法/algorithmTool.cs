using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// 排序
    /// </summary>
    public class algorithmTool
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listNum"></param>
        /// <param name="isAsc">正序还是反序</param>
        /// <returns></returns>
        public List<T> BubbleSort<T>(List<T> listNum, bool isAsc) where T : struct, IComparable
        {
            if (listNum == null || listNum.Count < 2)
                return null;

            for (int i = 0; i < listNum.Count; i++)
            {
                for (int j = 1; j < listNum.Count - i; j++)
                {
                    if ((isAsc && listNum[j].CompareTo(listNum[j - 1]) < 0) || (!isAsc && listNum[j].CompareTo(listNum[j - 1]) > 0))
                    {
                        T tmp = listNum[j];
                        listNum[j] = listNum[j - 1];
                        listNum[j - 1] = tmp;
                    }
                }
            }

            return listNum;
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listNum"></param>
        /// <param name="isAsc">正序还是反序</param>
        /// <returns></returns>
        public List<T> SelectSort<T>(List<T> listNum, bool isAsc) where T : struct, IComparable
        {
            if (listNum == null || listNum.Count < 2)
                return null;

            for (int i = 0; i < listNum.Count; i++)
            {
                for (int j = i + 1; j < listNum.Count; j++)
                {
                    if ((isAsc && listNum[i].CompareTo(listNum[j]) > 0) || (!isAsc && listNum[i].CompareTo(listNum[j]) < 0))
                    {
                        T tmp = listNum[i];
                        listNum[i] = listNum[j];
                        listNum[j] = tmp;
                    }
                }
            }

            return listNum;
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listNum"></param>
        /// <param name="isAsc">正序还是反序</param>
        /// <returns></returns>
        public List<T> InsertSort<T>(List<T> listNum, bool isAsc) where T : struct, IComparable
        {
            if (listNum == null || listNum.Count < 2)
                return null;

            for (int i = 1; i < listNum.Count; i++)
            {
                T tmp = listNum[i];
                int j = i - 1;
                while (j >= 0 && ((isAsc && listNum[j].CompareTo(tmp) > 0) || (!isAsc && listNum[j].CompareTo(tmp) < 0)))
                {
                    listNum[j + 1] = listNum[j];
                    j--;
                }

                listNum[j + 1] = tmp;
            }

            return listNum;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void quick_sort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                //Swap(s[l], s[(l + r) / 2]); //将中间的这个数和第一个数交换 参见注1  
                int i = left, j = right, x = nums[left];
                while (i < j)
                {
                    while (i < j && nums[j] >= x) // 从右向左找第一个小于x的数  
                        j--;
                    if (i < j)
                        nums[i++] = nums[j];

                    while (i < j && nums[i] < x) // 从左向右找第一个大于等于x的数  
                        i++;
                    if (i < j)
                        nums[j--] = nums[i];
                }
                nums[i] = x;
                quick_sort(nums, left, i - 1); // 递归调用   
                quick_sort(nums, i + 1, right);
            }
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="listNum"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="isAsc">正序还是反序</param>
        public void QuickSort(List<int> listNum, int left, int right, bool isAsc)
        {
            if (left < right)
            {
                int i = left, j = right, middle = listNum[left];
                while (i < j)
                {
                    while (i < j && ((middle < listNum[j] && isAsc) || (middle > listNum[j] && !isAsc))) // 从右向左找第一个小于x的数  
                        j--;
                    if (i < j)
                    {
                        listNum[i] = listNum[j];
                        i++;
                    }

                    while (i < j && ((middle > listNum[i] && isAsc) || (middle < listNum[i] && !isAsc))) // 从左向右找第一个大于等于x的数
                        i++;
                    if (i < j)
                    {
                        listNum[j] = listNum[i];
                        j--;
                    }
                }
                listNum[i] = middle;

                QuickSort(listNum, left, i - 1, isAsc);
                QuickSort(listNum, i + 1, right, isAsc);
            }
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listNum"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="isAsc"></param>
        public void QuickSort<T>(List<T> listNum, int left, int right, bool isAsc) where T : IComparable
        {
            if (left < right)
            {
                int i = left, j = right;
                T middle = listNum[left];
                while (i < j)
                {
                    while (i < j && ((middle.CompareTo(listNum[j]) < 0 && isAsc) || (middle.CompareTo(listNum[j]) > 0 && !isAsc))) // 从右向左找第一个小于x的数  
                        j--;
                    if (i < j)
                    {
                        listNum[i] = listNum[j];
                        i++;
                    }

                    while (i < j && ((middle.CompareTo(listNum[i]) > 0 && isAsc) || (middle.CompareTo(listNum[i]) < 0 && !isAsc))) // 从左向右找第一个大于等于x的数
                        i++;
                    if (i < j)
                    {
                        listNum[j] = listNum[i];
                        j--;
                    }
                }
                listNum[i] = middle;

                QuickSort(listNum, left, i - 1, isAsc);
                QuickSort(listNum, i + 1, right, isAsc);
            }
        }
    }
}
