namespace NhlStatsCrm.Application.Common.Exceptions
{
	public class DynamicsNotFoundException : Exception
	{
		public DynamicsNotFoundException () : base()
		{
		}

		public DynamicsNotFoundException (string errorMessage) : base(errorMessage)
		{
		}

		public DynamicsNotFoundException (string errorMessage, Exception innerException) : base(errorMessage, innerException)
		{
		}
	}
}