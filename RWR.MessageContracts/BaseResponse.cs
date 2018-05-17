using System;
using RWR.Common;
using WCF = System.ServiceModel;

namespace RWR.MessageContracts
{
	/// <summary>
	/// The Base Response object.
	/// </summary>
	[Serializable]
	[WCF::MessageContract(WrapperName = "BaseRS", WrapperNamespace = Constants.SERVER_URL)]
	public class BaseResponse
	{
	}
}
