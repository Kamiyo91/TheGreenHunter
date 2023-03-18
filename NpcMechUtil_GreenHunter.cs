using BigDLL4221.BaseClass;
using BigDLL4221.Extensions;
using BigDLL4221.Models;
using TheGreenHunter_SV21341.Buffs;

namespace TheGreenHunter_SV21341
{
    public class NpcMechUtil_GreenHunter : NpcMechUtilBase
    {
        public NpcMechUtil_GreenHunter(NpcMechUtilBaseModel model) : base(model, GreenModParameters.PackageId)
        {
        }

        public override void ExtraMethodOnPhaseChangeRoundStart(MechPhaseOptions mechOptions)
        {
            Model.Owner.AddBuff<BattleUnitBuf_GreenLeaf_SV21341>(10);
        }
    }
}