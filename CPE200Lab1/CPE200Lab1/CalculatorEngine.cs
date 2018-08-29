using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            string[] parts;
            int remainLength;
            double result;
            double memory1=0;
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        
                        

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    //your code here
                    return  (Convert.ToDouble(firstOperand) * (Convert.ToDouble(secondOperand) / 100)).ToString();
                    break;
                case "√":
                    result = Math.Sqrt(Convert.ToDouble(firstOperand));
                    // split between integer part and fractional part
                    parts = result.ToString().Split('.');
                    // if integer part length is already break max output, return error
                    if (parts[0].Length > maxOutputSize)
                    {
                        return "E";
                    }
                    // calculate remaining space for fractional part.
                    remainLength = maxOutputSize - parts[0].Length - 1;
                    // trim the fractional part gracefully. =
                    return result.ToString("N" + remainLength);
                    break;
                case "1/X":
                    return (1 / (Convert.ToDouble(firstOperand))).ToString();
                    break;
              /*  case "MC":
                    return "0";
                    break;
                case "M+":
                    memory1 += Convert.ToDouble(firstOperand);
                    break;
                case "M-":
                    break;
                case "MR":
                    return memory1.ToString();
                    
                case "MS":
                    return firstOperand.ToString();*/
            }
            if (operate == "MC")
            {
                return "0";
            }
            if (operate == "M+")
            {
                memory1 += (Convert.ToDouble(firstOperand));
                return memory1.ToString();
            }
            if (operate == "M-")
            {

            }
            if (operate == "MR")
            {
                return memory1.ToString();
            }
            if (operate == "MS")
            {
                memory1 = Convert.ToDouble(firstOperand);
                return memory1.ToString();
            }
            return "E";
        }
    }
}
