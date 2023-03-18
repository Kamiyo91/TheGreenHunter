using CustomMapUtility;
using UnityEngine;

namespace TheGreenHunter_SV21341.Maps
{
    public class GreenHunter_SV21341MapManager : CustomMapManager
    {
        protected override string[] CustomBGMs => new[] { "GreenHunter_SV21341.ogg" };

        public override void EnableMap(bool b)
        {
            sephirahColor = Color.black;
            base.EnableMap(b);
        }
    }
}