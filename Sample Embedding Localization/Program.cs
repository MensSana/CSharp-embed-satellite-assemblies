using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace SampleEmbeddingLocalization
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Add this event handler at top of Main()
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
			// Usual plain Main() following...
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			string resourceName = BuildResourceName(args.Name);
			try
			{
				using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
				{
					Byte[] dllBytes = new Byte[stream.Length];
					stream.Read(dllBytes, 0, dllBytes.Length);
					return Assembly.Load(dllBytes);
				}
			}
			catch
			{
				return null;
			}
		}

		private static string BuildResourceName(string nameToResolve)
		{
			string nameSpace = typeof(Program).Namespace;
			string language = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
			string dllName = new AssemblyName(nameToResolve).Name;
			return $"{nameSpace}.{language}.{dllName}.dll";
		}
	}
}
