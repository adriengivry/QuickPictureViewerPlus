using QuickLibraryPlus;
using System;
using System.Windows.Forms;

namespace QuickPictureViewerPlus
{
	internal static class Program
	{
		static string GetOpenPath(string[] args)
		{
			if (args.Length > 0 && args[0] != "-1")
			{
				return args[0];
			}

			return string.Empty;
		}

		[STAThread]
		static void Main(string[] args)
		{
			ApplicationConfiguration.Initialize();

			string openPath = GetOpenPath(args);

			if (Properties.Settings.Default.CallUpgrade)
			{
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.CallUpgrade = false;
				Properties.Settings.Default.Save();
			}

			Theme theme = ThemeMan.GetSupportedTheme(Properties.Settings.Default.Theme);
			ThemeMan.ApplyTheme(theme);

			Application.Run(new MainForm(openPath));
		}
	}
}
