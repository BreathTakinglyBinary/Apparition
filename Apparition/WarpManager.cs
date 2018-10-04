using MiNET.Utils;
using System.Collections.Generic;

namespace Apparition {
    public class WarpManager {
        private Dictionary<string, PlayerLocation> warpPoints;

        public WarpManager() {

        }
        public void setWarp(string name, PlayerLocation location) {
            warpPoints[name] = location;
        }

        public PlayerLocation getWarp(string name) {
            if (warpPoints.ContainsKey(name)) {
                return warpPoints[name];
            }
            return null;
        }

        public Dictionary<string, PlayerLocation> getAllWarpPoints() {
            return warpPoints;
        }
    }
}
