using Apparition.Commands;
using log4net;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;

namespace Apparition {
	[Plugin(PluginName = "Apparition", Description = "A Warps Plugin for MiNET", PluginVersion = "0.0.1", Author = "FiberglassCivic")]
	public class Apparition : Plugin {
		private static readonly ILog log = LogManager.GetLogger(typeof(Apparition));

		public WarpManager warpManager { get; private set; }

		protected override void OnEnable() {
			warpManager = new WarpManager();
			Context.PluginManager.LoadCommands(new WarpCommands(this));
		}
	}
}
