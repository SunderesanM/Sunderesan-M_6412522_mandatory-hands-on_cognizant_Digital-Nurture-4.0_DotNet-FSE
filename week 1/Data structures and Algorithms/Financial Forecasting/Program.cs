using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial_Forecasting
{
    //Recursion
    //Recursion is a programming technique where a function calls itself to solve a problem by breaking it down into smaller, similar subproblems.
    //it simplifies problems by reducing them to a base case, which is the simplest form that can be solved directly, and then combines the results of these smaller problems to solve the original problem.
    //Recursion is often used in algorithms like factorial calculation, Fibonacci sequence generation, and tree traversal.

    //we are given a present value (PV) and a list of past interest rates, we want to calculate the future value of the investment after applying these rates recursively.

    //first we apply past rates sequentially..
    //then compute the average recursively
    //compute the future value recursively
    internal class Program
    {
        static void Main(string[] args)
        {
            double pv = 1000.0; //present value
            double[] pastRates = new double[] { 0.03, 0.04, -0.02, 0.05 }; //past interest rates
            Console.WriteLine("Enter the futurePeriod to predict: ");
            int futurePeriods = Convert.ToInt32(Console.ReadLine()); //number of future periods to calculate

            double forecasted = ForecastRecursive(pv, pastRates, futurePeriods);

            Console.WriteLine($"Present Value: {pv}");
            Console.WriteLine("Past Rates: [" + string.Join(", ", pastRates) + "]");
            Console.WriteLine($"Future Periods: {futurePeriods}");
            Console.WriteLine($"Forecasted Value: {forecasted}");
        }
        //recursive functions

        //this method applies the past rates recursively to the present value
        static double ApplyRatesRecursive(double presentValue, double[] rates, int index)
            {
                if (index < 0 || rates == null) return presentValue; //base case: no more rates to apply
                double previousValue = ApplyRatesRecursive(presentValue, rates, index - 1); //recursive call
                return previousValue * (1 + rates[index]); //apply the current rate
            }
        //this method sums the rates recursively

        static double SumRatesRecursive(double[] rates, int index)
            {
                if (index < 0 || rates == null) return 0.0; //base case: no more rates to sum
                return rates[index] + SumRatesRecursive(rates, index - 1); //recursive call
            }
        //this method computes the power of a base value raised to an exponent recursively
        static double PowerFast(double baseValue, int exponent)
            {
                if (exponent == 0) return 1.0; //base case: any number to the power of 0 is 1
                if (exponent == 1) return baseValue; //base case: any number to the power of 1 is itself

                double halfPower = PowerFast(baseValue, exponent / 2); //recursive call
                if (exponent % 2 == 0)
                {
                    double half = PowerFast(baseValue, exponent / 2);
                    return half * half;
                }
                else
                {
                    double half = PowerFast(baseValue, (exponent - 1) / 2);
                    return baseValue * half * half;
                }
            }

        //this method forecasts the future value recursively based on the present value, past rates, and future periods
        static double ForecastRecursive(double presentValue, double[] rates, int futureperiods)
            {
                double afterHistory = ApplyRatesRecursive(presentValue, rates, (rates!=null)?rates.Length - 1:-1); //apply past rates recursively
                double avgRate = 0.0;
                if (rates != null && rates.Length > 0)
                {
                    avgRate = SumRatesRecursive(rates, rates.Length - 1) / rates.Length; //compute average rate recursively
                }
                double futureFactor = PowerFast(1 + avgRate, futureperiods); //compute future value recursively
                return afterHistory * futureFactor; //calculate the forecasted value -> formula referred from google.

        }
        }
    }
//complexity analysis:
//for applyRatesRecursive and sumRatesRecursive, complexity is O(n), where n is the length of the rates array.
//for powerFast complexity is O(log n), where n is future period
//for ForecastRecursive complexity is O(n + log m), where n is the length of array and m is future periods.

//optimization:
//we can use memoization to store previously computed values in a dictionary to avoid redundant calculations, especially for the powerFast function. This can significantly reduce the time complexity for larger inputs by avoiding repeated calculations of the same powers.
//however, in this case, the input size is small and the recursive depth is limited,and each sub-call is unique or reused locally. so memoization may not be necessary for performance improvement.
//but it can be implemented if needed for larger datasets or more complex calculations.
//We can use iterative methods instead of recursion to avoid stack overflow issues for large inputs.
//sometimes iterative methods have O(1) in auxiliary space, while recursion has O(n) in auxiliary space due to the call stack.

//This is the overall analysis of the code and its functionality. The code demonstrates how to use recursion to forecast future values based on past interest rates, applying the principles of recursion effectively to solve the problem at hand.
//some formulas to compute previousRates & future value based on present value are referred from google & some other sources/websites, but the implementation of recursive approach and code is written/done by me based on my understandings....