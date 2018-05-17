using System;
using System.Windows.Forms;

namespace RWR.IssueTracker.UI
{
	/// <summary>
	/// The main entry point for the IssueTracker application.
	/// </summary>
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(new Issues());
		}
	}
}