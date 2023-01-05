using System.Linq.Expressions;
using org.matheval;
using Expression = org.matheval.Expression;

namespace CalculatorLogic
{
    public class Logic
    {
        string _input = "";
        bool _isRounded;
        public string Result = "";
        public string Instance = "";

        public Logic(string input)
        {
            _input = input;
        }
        public Logic(string input, bool isRounded) : this(input)
        {
            _isRounded = isRounded;
        }

        public void Calculate()
        {
            try
            {
                Instance = _input + " = ";
                Result = _input != null ? new Expression(_input).Eval().ToString() : "";
                if (_isRounded)
                {
                    Result = $"{Math.Round(Convert.ToDouble(Result))}";
                }
                Instance += _isRounded ? $"{Result} RND" : $"{Result}";
            }
            catch (Exception ex)
            {
                SendError(ex);
                Result = "ERR";
                Instance = $"{_input} = ERR";
            }
        }

        public void SendError(Exception ex)
        {
            
        }



    }
}
