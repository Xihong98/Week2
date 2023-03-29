
using System.Collections.Generic;

public class Solution1
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> hash = new Dictionary<int, int>();
        int[] res = new int[2];
        for (int i = 0; i < nums.Length; i++) 
        {
            if (hash.ContainsKey(target - nums[i]))
            {
                res[0] = i;
                res[1] = hash[target - nums[i]];
                return res;
            }
            else
            {
                if (!hash.ContainsKey(nums[i])) 
                {
                    hash.Add(nums[i], i);
                }              
            }
        }
        return res;
    }
}



public class Solution9
{
    public bool IsPalindrome(int x)
    {
        string stringX = x.ToString();
        char[] charArray = stringX.ToCharArray();
        Array.Reverse(charArray);
        return stringX == new string(charArray);
    }
}



public class Solution217
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);
        return set.Count < nums.Length;
    }
}



public class Solution412
{
    public IList<string> FizzBuzz(int n)
    {
        List<string> res = new List<string>();
        for (int i = 1; i <= n; i++) 
        {
            if (i % 3 == 0 && i % 5 == 0) { res.Add("FizzBuzz"); }
            else if (i % 3 == 0 && i % 5 != 0) { res.Add("Fizz"); }
            else if (i % 3 != 0 && i % 5 == 0) { res.Add("Buzz"); }
            else { res.Add($"{i}"); }
        }
        return res;
    }
}