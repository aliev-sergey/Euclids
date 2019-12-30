using System;
using System.Text;

namespace EuclidsAlgorithm
{
    public class GCDSolver
    {
        public delegate int CalcGCD(int firstNum, int secondNum);
        private CalcGCD _calc;
        public const int MaxParamCount = 5;

        public int CalculateEuclidGCD(int firstNum, int secondNum)
        {
            ValidateInput(ref firstNum, ref secondNum);

            if (secondNum == 0)
            {
                return firstNum;
            }
                
            return CalculateEuclidGCD(secondNum, firstNum % secondNum);
        }

        public int CalculateGCD(CalcGCD calc, params int[] values)
        {
            if (values.Length > MaxParamCount)
            {
                throw new Exception("Количество параметров превышает максимально возможное число");
            }

            _calc = calc;

            int result = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                result = calc(result, values[i]);
            }

            return result;
        }

        public int CalculateSteinGCD(int firstNum, int secondNum)
        {
            if (firstNum == secondNum)
            {
                return secondNum;
            }

            if (firstNum == 0)
            {
                return secondNum;
            }

            if (secondNum == 0)
            {
                return firstNum;
            }                

            if ((~firstNum & 1) > 0)
            {
                if ((secondNum & 1) > 0)
                {
                    return CalculateEuclidGCD(firstNum >> 1, secondNum);
                }
                else
                {
                    return CalculateEuclidGCD(firstNum >> 1, secondNum >> 1) << 1;
                }
            }        
                    
            if ((~secondNum & 1) > 0)
            {
                return CalculateEuclidGCD(firstNum, secondNum >> 1);
            }


            if (firstNum > secondNum)
            {
                return CalculateEuclidGCD((firstNum - secondNum) >> 1, secondNum);
            }                

            return CalculateEuclidGCD((firstNum - secondNum) >> 1, firstNum);
        }
    
        private void ValidateInput(ref int firstNum, ref int secondNum)
        {
            if (firstNum < 0 || secondNum < 0)
            {
                throw new NegativeValueException("Один из параметров является отрицательной величиной", firstNum, secondNum);
            }

            if (secondNum > firstNum)
            {
                int temp = firstNum;
                firstNum = secondNum;
                secondNum = temp;
            }
        }
    }

    public class NegativeValueException : Exception
    {
        private int[] _values;
        public NegativeValueException(string message, params int[] values) : base(message)
        {
            _values = new int[values.Length];
            Array.Copy(values, _values, values.Length);
        }

        public string getValues()
        {
            StringBuilder sb = new StringBuilder();
            char ch = 'a';

            foreach (int value in _values)
            {
                sb.Append($"\n {ch++} = {value}");
            }

            return sb.ToString();
        }
    }
}
