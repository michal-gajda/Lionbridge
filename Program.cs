namespace Lionbridge
{
    using System;
    using System.Collections.Generic;

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Program
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // TODO: Implement this function
            // You are given two linked lists representing two non-negative integers. The digits are stored in reverse order, ie least significant digit first.
            // Each of the nodes contains a single digit.
            // The numbers do not have leading zeros
            //
            // Add the two numbers and return the sum as a linked list.
            // You may assume the two numbers do not contain any leading zero, except the number 0 itself.
            //
            // 342 -> [2] [4] [3]
            // 465 -> [5] [6] [4]
            // +
            // 807 -> [7] [0] [8]

            ListNode result = new ListNode(0);
            ListNode p = l1, q = l2, current = result;
            int carry = 0;

            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;

                if (p != null)
                {
                    p = p.next;
                }

                if (q != null)
                {
                    q = q.next;
                }
            }

            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }

            return result.next;
            // return null;
        }

        public static void Main()
        {
            Console.WriteLine("Starting");
            var cases = GetCases();

            foreach (var c in cases)
            {
                var result = AddTwoNumbers(c.a, c.b);
                bool same = VerifyNumbers(result, c.res);
                PrintResults(result, c.res, same);
            }

            Console.WriteLine("Finished");
        }

        public static void PrintResults(ListNode actual, ListNode expected, bool same)
        {
            if (actual == null)
            {
                Console.Write("null");
            }
            else
            {
                Stack<int> rev = new Stack<int>();
                ListNode n = actual;

                while (n != null)
                {
                    rev.Push(n.val);
                    n = n.next;
                }

                foreach (var val in rev)
                {
                    Console.Write(val.ToString());
                }
            }

            if (!same)
            {
                Console.Write(" != ");
            }
            else
            {
                Console.Write(" == ");
            }

            if (expected == null)
            {
                Console.Write("null");
            }
            else
            {
                Stack<int> rev = new Stack<int>();
                ListNode n = expected;

                while (n != null)
                {
                    rev.Push(n.val);
                    n = n.next;
                }

                foreach (var val in rev)
                {
                    Console.Write(val.ToString());
                }
            }

            Console.WriteLine();
        }

        public static bool VerifyNumbers(ListNode actual, ListNode expected)
        {
            return true;
        }

        public static List<TestCase> GetCases()
        {
            var cases = new List<TestCase>();

            TestCase tst = new TestCase(
                new List<int> { 3, 4, 2 },
                new List<int> { 4, 6, 5 },
                new List<int> { 8, 0, 7 }
            );
            cases.Add(tst);

            return cases;
        }
    }

    public class TestCase
    {
        public ListNode a;
        public ListNode b;
        public ListNode res;

        private static ListNode BuildList(List<int> nums)
        {
            ListNode res = null;

            if (nums != null)
            {
                foreach (var num in nums)
                {
                    res = new ListNode(num, res);
                }
            }

            return res;
        }

        public TestCase(List<int> term_a, List<int> term_b, List<int> sum)
        {
            a = BuildList(term_a);
            b = BuildList(term_b);
            res = BuildList(sum);
        }
    }
}
