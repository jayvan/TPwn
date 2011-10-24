/*
 * User: Justin Vanderheide
 * Date: 10/23/2011
 * Time: 1:55 PM
 * 
 */
using System;
using System.Windows.Forms;

namespace tPwn
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
