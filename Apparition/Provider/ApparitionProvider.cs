using MiNET.Utils;
using System.Collections.Generic;

namespace Apparition.Provider {
    abstract class ApparitionProvider {
        abstract public Dictionary<string, PlayerLocation> getAllWarpPoints();

        abstract public void saveAllWarpPoints(Dictionary<string, PlayerLocation> warps);
    }
}
