using System;
using ASMX = System.Xml.Serialization;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Base Request
	/// </summary>
	[Serializable]
	public class BaseRequest
	{
		/// <summary>
		/// The Client assigned Id for this Transaction.
		/// </summary>
		[ASMX::XmlElement(IsNullable = true)]
		public string ClientTransactionId;
	}
}
