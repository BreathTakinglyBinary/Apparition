using log4net;
using MiNET;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using System.Collections.Generic;

namespace Apparition.Commands {
	public class WarpCommands {
		private static readonly ILog log = LogManager.GetLogger(typeof(WarpCommands));

		private readonly Apparition apparition;

		public WarpCommands(Apparition plugin) {
			apparition = plugin;
		}

		[Command(Description = "Set a Warp Point")]
		public void setWarp(Player player, string name) {
			if (name == null) {
				player.SendMessage("§c§lYou must provide a name for the warp point.");
				return;
			}
			apparition.warpManager.setWarp(name, player.KnownPosition);
			player.SendMessage("§5Successfully set warp point " + name + "!");
		}

		[Command(Description = "Teleport to a known Warp Point")]
		public void warp(Player player, string warpPointName) {
			//TODO
			PlayerLocation warpPoint = apparition.warpManager.getWarp(warpPointName);
			if (warpPoint != null) {
				player.Teleport(warpPoint);
			} else {
				player.SendMessage("Warp " + warpPointName + " doesn't exist.");
			}
		}

		[Command(Description = "Get a list of Warp Points")]
		public void warps(Player player) {
			//TODO
			var warpPoints = apparition.warpManager.getAllWarpPoints();
			if (warpPoints != null)
			{
				foreach (KeyValuePair<string, PlayerLocation> entry in warpPoints) {
					player.SendMessage(entry.Key);
				}
			}
		}

	}
}
