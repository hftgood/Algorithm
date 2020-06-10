/*
题目名称：
最长回文子串

题目描述：
给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

示例1：
输入: "babad"
输出: "bab"
注意: "aba" 也是一个有效答案。

示例2：
输入: "cbbd"
输出: "bb"

代码结构：
public class Solution {
    public string LongestPalindrome(string s) {

    }
}

题目链接：
https://leetcode-cn.com/problems/longest-palindromic-substring/

官方题解：
https://leetcode-cn.com/problems/longest-palindromic-substring/solution/zui-chang-hui-wen-zi-chuan-by-leetcode-solution/
*/
using System;
using System.Collections.Generic;
namespace LongestPalindrome {

    class Solution {

        /// <summary>
        /// 解法1，动态规划
        /// 基本思路：
        /// 分析回文串的特征，我们可以发现一个回文字符串的首尾两个元素一定是相等的
        /// 以P(i, j)表示字符串s的第i到第j个字母组成的字符串，P(i, j)是回文串的前提条件是s[i] == s[j]且P(i + 1, j - 1)是回文串
        /// 即动态规划的状态转移方程为 P(i, j) = s[i] == s[j] && P(i + 1, j - 1)
        /// 从0到s.Length - 1的循环，表示i和j之间相差的字母数可以是0 到 (s.Length - 1)
        /// 当相差字母数是0时，即单个字母，显然是回文串
        /// 当相差字母数是1时，即两个字母，只要第一个字母和第二个字母相同即是回文串
        /// </summary>

        public string LongestPalindrome(string s) {
            int len = s.Length;
            string sub = "";
            bool[,] dp = new bool[len, len];
            for(int n = 0; n < len; n ++){
                for(int i = 0, j = i + n; j < len; i ++, j ++){
                    if(n == 0) dp[i, j] = true;
                    else if(n == 1) dp[i, j] = s[i] == s[j];
                    else dp[i, j] = s[i] == s[j] && dp[i + 1, j - 1];
                    if(dp[i, j] && j - i + 1 > sub.Length) sub = s.Substring(i, j - i + 1);
                }
            }
            return sub;
        }

        public void Test() {
            string s = "babad";
            s = "cbbd";
            s = "aaaf";
            s = "aaaa";
            s = "a";
            s = "abacaba";

            Console.WriteLine(LongestPalindrome(s));
        }
    }
}
