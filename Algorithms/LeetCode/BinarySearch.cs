using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LeetCode
{
    public class BinarySearch
    {
        public int Search(int[] nums, int target)
        {
            return Rank(nums, target, 0, nums.Length - 1);
        }

        //LeetCode的最优解貌似可以比这个少递归几次。
        public int Rank(int[] nums, int target, int lo, int hi)
        {
            if (hi < lo) return -1;
            //[!]int mid = lo + hi / 2; 
            int mid = (lo + hi) / 2;
            if (target < nums[mid]) return Rank(nums, target, lo, mid - 1);
            else if (target > nums[mid]) return Rank(nums, target, mid + 1, hi);
            else return mid;
        }


        public static int Rank(int[] nums, int target)
        {
            int lo = 0, hi = nums.Length - 1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                if (target < nums[mid]) hi = mid - 1;
                else if (target > nums[mid]) lo = mid + 1;
                else return mid;
            }
            return -1;
        }
    }
}
