namespace DesignPatterns.ChainOfResponsibility.exceptions
{
    internal class WrongInputException : Exception
    {
        private Enum _input;
        public WrongInputException(Enum input)
        {
            _input = input;
        }

        public override string Message 
            => $"This input [{_input}] is wrong";
    }
}
