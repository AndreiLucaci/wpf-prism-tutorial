using System;
using System.Runtime.Serialization;

namespace WpfTutorial.ChuckNorrisFactsModule.Exceptions
{
	public class NullFactsException : Exception
	{
		public NullFactsException()
		{
		}

		public NullFactsException(string message)
			: base(message)
		{
		}

		public NullFactsException(SerializationInfo serializationInfo, StreamingContext context)
			: base(serializationInfo, context)
		{
		}

		public NullFactsException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
