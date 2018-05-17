using RWR.Common;
using WCF = System.Runtime.Serialization;

namespace RWR.FaultContracts
{
	/// <summary>
	/// Data Contract Class - Unspecified Fault
	/// </summary>
	[WCF::DataContract(Namespace = Constants.SERVER_URL, Name = "UnspecifiedFault")]
	public class UnspecifiedFault
	{
		private string message;

		/// <summary>
		/// An Unspecified Message.
		/// </summary>
		[WCF::DataMember(Name = "UnspecifiedMessage", IsRequired = false, Order = 0)]
		public string Message
		{
			get { return message; }
			set { message = value; }
		}
	}
}
