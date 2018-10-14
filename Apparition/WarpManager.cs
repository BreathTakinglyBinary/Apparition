using System.Collections.Generic;
using MiNET.Utils;

namespace Apparition {
	public class WarpManager {
		private Dictionary<string, PlayerLocation> warpPoints = new Dictionary<string, PlayerLocation>();

		public void setWarp(string name, PlayerLocation location) {
			warpPoints.Add(name, location);
		}

		public PlayerLocation getWarp(string name) {
			if (warpPoints.ContainsKey(name)) {
				return warpPoints.GetValueOrDefault(name);
			}
			return null;
		}

		public Dictionary<string, PlayerLocation> getAllWarpPoints() {
			return warpPoints;
		}
	}
}
