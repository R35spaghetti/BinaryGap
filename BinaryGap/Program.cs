using System.Text;
using BinaryGap;

Solution test = new Solution();

var number1 = test.TurnNumberIntoBinary(1041);
var number2 = test.TurnNumberIntoBinary(15);
var number3 = test.TurnNumberIntoBinary(32);
Console.WriteLine(test.GetBiggestBinaryZeroGap(number1));
Console.WriteLine(test.GetBiggestBinaryZeroGap(number2));
Console.WriteLine(test.GetBiggestBinaryZeroGap(number3));

namespace BinaryGap
{
    public class Solution
    {
        public int GetBiggestBinaryZeroGap(string number)
        {
            int currentCount = 0;
            int longestCount = 0;
            bool hasOne = false;

            foreach (char digit in number)
            {
                if (digit == '0')
                {
                    currentCount++;
                }
                else
                {
                    if (hasOne)
                    {
                        if (currentCount > longestCount)
                        {
                            longestCount = currentCount;
                        }

                        currentCount = 0;
                    }

                    hasOne = true;
                }
            }

            // If there are no binary gaps, return 0
            if (!hasOne)
            {
                return 0;
            }

            return longestCount;
        }


        public string TurnNumberIntoBinary(int n)
        {
            StringBuilder binary = new StringBuilder();
            do
            {
                if (n % 2 == 0)
                {
                    binary.Insert(0, "0");
                }
                else
                {
                    binary.Insert(0, "1");
                }

                n = n / 2;
            } while (n != 0);


            string binaryString = binary.ToString();

            if (binaryString.Count(c => c == '1') == 1)
            {
                return "0";
            }

            return binaryString;
        }
    }
}


//
// A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is surrounded by ones at both ends in the binary representation of N.
//
//     For example, number 9 has binary representation 1001 and contains a binary gap of length 2. The number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3.
// The number 20 has binary representation 10100 and contains one binary gap of length 1. The number 15 has binary representation 1111 and has no binary gaps. The number 32 has binary representation 100000 and has no binary gaps.
//
//     Write a function:
//
// class Solution { public int solution(int N); }
//
// that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.
//
//     For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5. Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.
//
//     Write an efficient algorithm for the following assumptions:
//
// N is an integer within the range [1..2,147,483,647].
//