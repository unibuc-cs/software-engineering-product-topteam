namespace backend_MT.Exceptions
{
	public class LockedOutException : Exception
	{
		public LockedOutException(string message) : base(message) { }
	}
}
