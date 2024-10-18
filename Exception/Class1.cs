namespace Exceptionlib
{
    [Serializable]
    public class TrackingNumberNotFoundException : Exception
    {
        public TrackingNumberNotFoundException() { }
        public TrackingNumberNotFoundException(string message) : base(message) { }
        public TrackingNumberNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected TrackingNumberNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class InvalidEmployeeIdException : Exception
    {
        public InvalidEmployeeIdException() { }
        public InvalidEmployeeIdException(string message) : base(message) { }
        public InvalidEmployeeIdException(string message, Exception inner) : base(message, inner) { }
        protected InvalidEmployeeIdException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
