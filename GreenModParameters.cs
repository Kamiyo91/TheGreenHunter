using System.Collections.Generic;
using BigDLL4221.BaseClass;
using BigDLL4221.Models;
using LOR_XML;
using TheGreenHunter_SV21341.Buffs;
using TheGreenHunter_SV21341.Maps;

namespace TheGreenHunter_SV21341
{
    public static class GreenModParameters
    {
        public const string PackageId = "GreenHunterModSV21341.Mod";
        public const string VortexPackageId = "VortexTowerModSa21341.Mod";
        public static string Path = string.Empty;

        public static MapModel GreenHunter = new MapModel(typeof(GreenHunter_SV21341MapManager), "GreenHunter_SV21341",
            bgy: 0.2f, fy: 0.25f,
            originalMapStageIds: new List<LorId> { new LorId(PackageId, 1) });
    }

    public class GreenGuardianUtil
    {
        public NpcMechUtil_GreenHunter GreenGuardianNpcUtil =
            new NpcMechUtil_GreenHunter(new NpcMechUtilBaseModel("GreenHunterPhase21341",
                permanentBuffList: new List<PermanentBuffOptions>
                {
                    new PermanentBuffOptions(new BattleUnitBuf_GreenLeaf_SV21341()),
                    new PermanentBuffOptions(new BattleUnitBuf_Bullet_SV21341())
                },
                mechOptions: new Dictionary<int, MechPhaseOptions>
                {
                    {
                        0, new MechPhaseOptions(2, 90, hasCustomMap: true)
                    },
                    {
                        1, new MechPhaseOptions(hasExtraFunctionRoundStart: true, startMassAttack: true,
                            hasCustomMap: true, setCounterToMax: true,
                            egoMassAttackCardsOptions: new List<SpecialAttackCardOptions>
                            {
                                new SpecialAttackCardOptions(new LorId(GreenModParameters.PackageId, 10))
                            },
                            speedDieAdder: 2, loweredCost: 1, changeCardCost: true,
                            musicOptions: new MusicOptions("GreenHunter2_SV21341.ogg", "GreenHunter_SV21341"),
                            onPhaseChangeDialogList: new List<AbnormalityCardDialog>
                            {
                                new AbnormalityCardDialog
                                {
                                    id = "",
                                    dialog = ModParameters.LocalizedItems[GreenModParameters.PackageId]
                                        .EffectTexts["GreenHunterPhase2_21341"].Desc
                                }
                            })
                    }
                }, egoMaps: new Dictionary<LorId, MapModel>
                {
                    { new LorId(GreenModParameters.PackageId, 10), GreenModParameters.GreenHunter }
                }));

        public MechUtilBase GreenGuardianPlayerUtil = new MechUtilBase(new MechUtilBaseModel(
            egoMaps: new Dictionary<LorId, MapModel>
                { { new LorId(GreenModParameters.PackageId, 9), GreenModParameters.GreenHunter } },
            personalCards: new Dictionary<LorId, PersonalCardOptions>
            {
                { new LorId(GreenModParameters.PackageId, 9), new PersonalCardOptions() },
                { new LorId(GreenModParameters.PackageId, 1), new PersonalCardOptions() },
                { new LorId(GreenModParameters.PackageId, 4), new PersonalCardOptions() },
                { new LorId(GreenModParameters.PackageId, 5), new PersonalCardOptions() }
            },
            permanentBuffList: new List<PermanentBuffOptions>
            {
                new PermanentBuffOptions(new BattleUnitBuf_GreenLeaf_SV21341()),
                new PermanentBuffOptions(new BattleUnitBuf_Bullet_SV21341())
            }), GreenModParameters.PackageId);
    }
}