using System.Collections.Generic;
using BigDLL4221.Models;
using BigDLL4221.StageManagers;
using CustomMapUtility;

namespace TheGreenHunter_SV21341
{
    public class EnemyTeamStageManager_TheGreenHunter_SV21341 : EnemyTeamStageManager_BaseWithCMU_DLL4221
    {
        public override void OnWaveStart()
        {
            SetParameters(CustomMapHandler.GetCMU(GreenModParameters.PackageId),
                new GreenGuardianUtil().GreenGuardianNpcUtil,
                new List<MapModel> { GreenModParameters.GreenHunter });
            base.OnWaveStart();
        }
    }
}