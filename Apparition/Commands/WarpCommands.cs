using log4net;
using MiNET;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using System.Collections.Generic;

namespace Apparition {
    public class WarpCommands {
        private static readonly ILog log = LogManager.GetLogger(typeof(WarpCommands));

        private Apparition apparition;

        public WarpCommands(Apparition apparition) {
            this.apparition = apparition;
        }

        [Command(Description = "Set a Warp Point")]
        public void setWarp(Player player, string name) {
            if (name == null) {
                player.SendMessage("§c§lYou must provide a name for the warp point.");
                return;
            }
            PlayerLocation WarpPoint = player.KnownPosition;
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
            Dictionary<string, PlayerLocation> warpPoints = apparition.warpManager.getAllWarpPoints();

            foreach(KeyValuePair<string, PlayerLocation> entry in warpPoints) {
                player.SendMessage(entry.Key);
            }
        }

    }
}
