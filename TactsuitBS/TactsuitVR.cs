using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bhaptics.Tact;
using ThunderRoad;
using UnityEngine;

namespace TactsuitBS
{
    public class TactsuitVR
    {
        public bool ArmsActive = false;
        public bool HeadActive = false;
        public bool FeetActive = false;

        public enum PenetrationSize
        {
            Small,
            Large
        }

        //public bool Logging = false;
        
        public TactsuitVR()
        {
            FillFeedbackList();
        }

        void LOG(string logStr)
        {
            if (Engine.Logging)
            {
                Utility.LOG(logStr);
            }
        }

        private void FillFeedbackList()
        {
            feedbackMap.Clear();
            feedbackMap.Add(FeedbackType.HeartBeat, new Feedback(FeedbackType.HeartBeat, "HeartBeat_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.HeartBeatFast, new Feedback(FeedbackType.HeartBeatFast, "HeartBeatFast_", 0, PositionType.Vest));

            feedbackMap.Add(FeedbackType.DefaultDamage, new Feedback(FeedbackType.DefaultDamage, "DefaultDamage_", 0, PositionType.Vest));

            feedbackMap.Add(FeedbackType.PlayerBowPullRight, new Feedback(FeedbackType.PlayerBowPullRight, "PlayerBowPullRight_", 0, PositionType.ForearmR));
            
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeWoodPierceRight, new Feedback(FeedbackType.PlayerMeleeBladeWoodPierceRight, "PlayerMeleeBladeWoodPierceRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeMetalPierceRight, new Feedback(FeedbackType.PlayerMeleeBladeMetalPierceRight, "PlayerMeleeBladeMetalPierceRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeStonePierceRight, new Feedback(FeedbackType.PlayerMeleeBladeStonePierceRight, "PlayerMeleeBladeStonePierceRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFabricPierceRight, new Feedback(FeedbackType.PlayerMeleeBladeFabricPierceRight, "PlayerMeleeBladeFabricPierceRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFleshPierceRight, new Feedback(FeedbackType.PlayerMeleeBladeFleshPierceRight, "PlayerMeleeBladeFleshPierceRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeWoodSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeWoodSlashRight, "PlayerMeleeBladeWoodSlashRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeMetalSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeMetalSlashRight, "PlayerMeleeBladeMetalSlashRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeStoneSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeStoneSlashRight, "PlayerMeleeBladeStoneSlashRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFabricSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeFabricSlashRight, "PlayerMeleeBladeFabricSlashRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFleshSlashRight, new Feedback(FeedbackType.PlayerMeleeBladeFleshSlashRight, "PlayerMeleeBladeFleshSlashRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeWoodBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeWoodBluntRight, "PlayerMeleeBladeWoodBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeMetalBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeMetalBluntRight, "PlayerMeleeBladeMetalBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeStoneBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeStoneBluntRight, "PlayerMeleeBladeStoneBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFabricBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeFabricBluntRight, "PlayerMeleeBladeFabricBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeBladeFleshBluntRight, new Feedback(FeedbackType.PlayerMeleeBladeFleshBluntRight, "PlayerMeleeBladeFleshBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodWoodBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodWoodBluntRight, "PlayerMeleeWoodWoodBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodMetalBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodMetalBluntRight, "PlayerMeleeWoodMetalBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodStoneBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodStoneBluntRight, "PlayerMeleeWoodStoneBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodFabricBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodFabricBluntRight, "PlayerMeleeWoodFabricBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeWoodFleshBluntRight, new Feedback(FeedbackType.PlayerMeleeWoodFleshBluntRight, "PlayerMeleeWoodFleshBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeStoneStoneBluntRight, new Feedback(FeedbackType.PlayerMeleeStoneStoneBluntRight, "PlayerMeleeStoneStoneBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeStoneFabricBluntRight, new Feedback(FeedbackType.PlayerMeleeStoneFabricBluntRight, "PlayerMeleeStoneFabricBluntRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeStoneFleshBluntRight, new Feedback(FeedbackType.PlayerMeleeStoneFleshBluntRight, "PlayerMeleeStoneFleshBluntRight_", 0, PositionType.ForearmR));

            feedbackMap.Add(FeedbackType.PlayerMeleeLightsaberClashRight, new Feedback(FeedbackType.PlayerMeleeLightsaberClashRight, "PlayerMeleeLightsaberClashRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeLightsaberSlashRight, new Feedback(FeedbackType.PlayerMeleeLightsaberSlashRight, "PlayerMeleeLightsaberSlashRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeLightsaberPierceRight, new Feedback(FeedbackType.PlayerMeleeLightsaberPierceRight, "PlayerMeleeLightsaberPierceRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerMeleeLightsaberBluntRight, new Feedback(FeedbackType.PlayerMeleeLightsaberBluntRight, "PlayerMeleeLightsaberBluntRight_", 0, PositionType.ForearmR));

            feedbackMap.Add(FeedbackType.PlayerSpellFireRight, new Feedback(FeedbackType.PlayerSpellFireRight, "PlayerSpellFireRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellLightningRight, new Feedback(FeedbackType.PlayerSpellLightningRight, "PlayerSpellLightningRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellGravityRight, new Feedback(FeedbackType.PlayerSpellGravityRight, "PlayerSpellGravityRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellIceRight, new Feedback(FeedbackType.PlayerSpellIceRight, "PlayerSpellIceRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellCrushRight, new Feedback(FeedbackType.PlayerSpellCrushRight, "PlayerSpellCrushRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellHealRight, new Feedback(FeedbackType.PlayerSpellHealRight, "PlayerSpellHealRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellImplosionRight, new Feedback(FeedbackType.PlayerSpellImplosionRight, "PlayerSpellImplosionRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellInvisibilityRight, new Feedback(FeedbackType.PlayerSpellInvisibilityRight, "PlayerSpellInvisibilityRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellTeslaRight, new Feedback(FeedbackType.PlayerSpellTeslaRight, "PlayerSpellTeslaRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellUtilityRight, new Feedback(FeedbackType.PlayerSpellUtilityRight, "PlayerSpellUtilityRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellCorruptionRight, new Feedback(FeedbackType.PlayerSpellCorruptionRight, "PlayerSpellCorruptionRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellTeleportRight, new Feedback(FeedbackType.PlayerSpellTeleportRight, "PlayerSpellTeleportRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellRasenganRight, new Feedback(FeedbackType.PlayerSpellRasenganRight, "PlayerSpellRasenganRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellNeedleRight, new Feedback(FeedbackType.PlayerSpellNeedleRight, "PlayerSpellNeedleRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellDrainRight, new Feedback(FeedbackType.PlayerSpellDrainRight, "PlayerSpellDrainRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellForceFieldRight, new Feedback(FeedbackType.PlayerSpellForceFieldRight, "PlayerSpellForceFieldRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerSpellOtherRight, new Feedback(FeedbackType.PlayerSpellOtherRight, "PlayerSpellOtherRight_", 0, PositionType.ForearmR));

            feedbackMap.Add(FeedbackType.PlayerTelekinesisActiveRight, new Feedback(FeedbackType.PlayerTelekinesisActiveRight, "PlayerTelekinesisActiveRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerTelekinesisPullRight, new Feedback(FeedbackType.PlayerTelekinesisPullRight, "PlayerTelekinesisPullRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerTelekinesisRepelRight, new Feedback(FeedbackType.PlayerTelekinesisRepelRight, "PlayerTelekinesisRepelRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerTelekinesisCatchRight, new Feedback(FeedbackType.PlayerTelekinesisCatchRight, "PlayerTelekinesisCatchRight_", 0, PositionType.ForearmR));

            feedbackMap.Add(FeedbackType.DamageVestPierceBladeSmall, new Feedback(FeedbackType.DamageVestPierceBladeSmall, "DamageVestPierceBladeSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeSmallLRD, new Feedback(FeedbackType.DamageVestSlashBladeSmallLRD, "DamageVestSlashBladeSmallLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeSmallLRU, new Feedback(FeedbackType.DamageVestSlashBladeSmallLRU, "DamageVestSlashBladeSmallLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeSmallRLD, new Feedback(FeedbackType.DamageVestSlashBladeSmallRLD, "DamageVestSlashBladeSmallRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeSmallRLU, new Feedback(FeedbackType.DamageVestSlashBladeSmallRLU, "DamageVestSlashBladeSmallRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntBladeSmall, new Feedback(FeedbackType.DamageVestBluntBladeSmall, "DamageVestBluntBladeSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntWoodSmall, new Feedback(FeedbackType.DamageVestBluntWoodSmall, "DamageVestBluntWoodSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntMetalSmall, new Feedback(FeedbackType.DamageVestBluntMetalSmall, "DamageVestBluntMetalSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntStoneSmall, new Feedback(FeedbackType.DamageVestBluntStoneSmall, "DamageVestBluntStoneSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntFleshSmall, new Feedback(FeedbackType.DamageVestBluntFleshSmall, "DamageVestBluntFleshSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestPierceFireSmall, new Feedback(FeedbackType.DamageVestPierceFireSmall, "DamageVestPierceFireSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireSmallLRD, new Feedback(FeedbackType.DamageVestSlashFireSmallLRD, "DamageVestSlashFireSmallLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireSmallLRU, new Feedback(FeedbackType.DamageVestSlashFireSmallLRU, "DamageVestSlashFireSmallLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireSmallRLD, new Feedback(FeedbackType.DamageVestSlashFireSmallRLD, "DamageVestSlashFireSmallRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireSmallRLU, new Feedback(FeedbackType.DamageVestSlashFireSmallRLU, "DamageVestSlashFireSmallRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntFireSmall, new Feedback(FeedbackType.DamageVestBluntFireSmall, "DamageVestBluntFireSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestPierceLightningSmall, new Feedback(FeedbackType.DamageVestPierceLightningSmall, "DamageVestPierceLightningSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningSmallLRD, new Feedback(FeedbackType.DamageVestSlashLightningSmallLRD, "DamageVestSlashLightningSmallLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningSmallLRU, new Feedback(FeedbackType.DamageVestSlashLightningSmallLRU, "DamageVestSlashLightningSmallLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningSmallRLD, new Feedback(FeedbackType.DamageVestSlashLightningSmallRLD, "DamageVestSlashLightningSmallRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningSmallRLU, new Feedback(FeedbackType.DamageVestSlashLightningSmallRLU, "DamageVestSlashLightningSmallRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntLightningSmall, new Feedback(FeedbackType.DamageVestBluntLightningSmall, "DamageVestBluntLightningSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestPierceIceSmall, new Feedback(FeedbackType.DamageVestPierceIceSmall, "DamageVestPierceIceSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceSmallLRD, new Feedback(FeedbackType.DamageVestSlashIceSmallLRD, "DamageVestSlashIceSmallLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceSmallLRU, new Feedback(FeedbackType.DamageVestSlashIceSmallLRU, "DamageVestSlashIceSmallLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceSmallRLD, new Feedback(FeedbackType.DamageVestSlashIceSmallRLD, "DamageVestSlashIceSmallRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceSmallRLU, new Feedback(FeedbackType.DamageVestSlashIceSmallRLU, "DamageVestSlashIceSmallRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntIceSmall, new Feedback(FeedbackType.DamageVestBluntIceSmall, "DamageVestBluntIceSmall_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestPierceBladeLarge, new Feedback(FeedbackType.DamageVestPierceBladeLarge, "DamageVestPierceBladeLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeLargeLRD, new Feedback(FeedbackType.DamageVestSlashBladeLargeLRD, "DamageVestSlashBladeLargeLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeLargeLRU, new Feedback(FeedbackType.DamageVestSlashBladeLargeLRU, "DamageVestSlashBladeLargeLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeLargeRLD, new Feedback(FeedbackType.DamageVestSlashBladeLargeRLD, "DamageVestSlashBladeLargeRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashBladeLargeRLU, new Feedback(FeedbackType.DamageVestSlashBladeLargeRLU, "DamageVestSlashBladeLargeRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntBladeLarge, new Feedback(FeedbackType.DamageVestBluntBladeLarge, "DamageVestBluntBladeLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntWoodLarge, new Feedback(FeedbackType.DamageVestBluntWoodLarge, "DamageVestBluntWoodLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntMetalLarge, new Feedback(FeedbackType.DamageVestBluntMetalLarge, "DamageVestBluntMetalLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntStoneLarge, new Feedback(FeedbackType.DamageVestBluntStoneLarge, "DamageVestBluntStoneLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntFleshLarge, new Feedback(FeedbackType.DamageVestBluntFleshLarge, "DamageVestBluntFleshLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestPierceFireLarge, new Feedback(FeedbackType.DamageVestPierceFireLarge, "DamageVestPierceFireLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireLargeLRD, new Feedback(FeedbackType.DamageVestSlashFireLargeLRD, "DamageVestSlashFireLargeLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireLargeLRU, new Feedback(FeedbackType.DamageVestSlashFireLargeLRU, "DamageVestSlashFireLargeLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireLargeRLD, new Feedback(FeedbackType.DamageVestSlashFireLargeRLD, "DamageVestSlashFireLargeRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashFireLargeRLU, new Feedback(FeedbackType.DamageVestSlashFireLargeRLU, "DamageVestSlashFireLargeRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntFireLarge, new Feedback(FeedbackType.DamageVestBluntFireLarge, "DamageVestBluntFireLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestPierceLightningLarge, new Feedback(FeedbackType.DamageVestPierceLightningLarge, "DamageVestPierceLightningLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningLargeLRD, new Feedback(FeedbackType.DamageVestSlashLightningLargeLRD, "DamageVestSlashLightningLargeLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningLargeLRU, new Feedback(FeedbackType.DamageVestSlashLightningLargeLRU, "DamageVestSlashLightningLargeLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningLargeRLD, new Feedback(FeedbackType.DamageVestSlashLightningLargeRLD, "DamageVestSlashLightningLargeRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightningLargeRLU, new Feedback(FeedbackType.DamageVestSlashLightningLargeRLU, "DamageVestSlashLightningLargeRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntLightningLarge, new Feedback(FeedbackType.DamageVestBluntLightningLarge, "DamageVestBluntLightningLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestPierceIceLarge, new Feedback(FeedbackType.DamageVestPierceIceLarge, "DamageVestPierceIceLarge_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceLargeLRD, new Feedback(FeedbackType.DamageVestSlashIceLargeLRD, "DamageVestSlashIceLargeLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceLargeLRU, new Feedback(FeedbackType.DamageVestSlashIceLargeLRU, "DamageVestSlashIceLargeLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceLargeRLD, new Feedback(FeedbackType.DamageVestSlashIceLargeRLD, "DamageVestSlashIceLargeRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashIceLargeRLU, new Feedback(FeedbackType.DamageVestSlashIceLargeRLU, "DamageVestSlashIceLargeRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntIceLarge, new Feedback(FeedbackType.DamageVestBluntIceLarge, "DamageVestBluntIceLarge_", 0, PositionType.Vest));

            feedbackMap.Add(FeedbackType.DamageVestBlaster, new Feedback(FeedbackType.DamageVestBlaster, "DamageVestBlaster_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBlasterStun, new Feedback(FeedbackType.DamageVestBlasterStun, "DamageVestBlasterStun_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageRightArmBlaster, new Feedback(FeedbackType.DamageRightArmBlaster, "DamageRightArmBlaster_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBlasterStun, new Feedback(FeedbackType.DamageRightArmBlasterStun, "DamageRightArmBlasterStun_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageHeadBlaster, new Feedback(FeedbackType.DamageHeadBlaster, "DamageHeadBlaster_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBlasterStun, new Feedback(FeedbackType.DamageHeadBlasterStun, "DamageHeadBlasterStun_", 0, PositionType.Head));
            
            feedbackMap.Add(FeedbackType.DamageVestPierceLightsaber, new Feedback(FeedbackType.DamageVestPierceLightsaber, "DamageVestPierceLightsaber_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightsaberLRD, new Feedback(FeedbackType.DamageVestSlashLightsaberLRD, "DamageVestSlashLightsaberLRD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightsaberLRU, new Feedback(FeedbackType.DamageVestSlashLightsaberLRU, "DamageVestSlashLightsaberLRU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightsaberRLD, new Feedback(FeedbackType.DamageVestSlashLightsaberRLD, "DamageVestSlashLightsaberRLD_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestSlashLightsaberRLU, new Feedback(FeedbackType.DamageVestSlashLightsaberRLU, "DamageVestSlashLightsaberRLU_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestBluntLightsaber, new Feedback(FeedbackType.DamageVestBluntLightsaber, "DamageVestBluntLightsaber_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntLightsaber, new Feedback(FeedbackType.DamageRightArmBluntLightsaber, "DamageRightArmBluntLightsaber_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceLightsaber, new Feedback(FeedbackType.DamageRightArmPierceLightsaber, "DamageRightArmPierceLightsaber_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashLightsaber, new Feedback(FeedbackType.DamageRightArmSlashLightsaber, "DamageRightArmSlashLightsaber_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageHeadPierceLightsaber, new Feedback(FeedbackType.DamageHeadPierceLightsaber, "DamageHeadPierceLightsaber_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashLightsaber, new Feedback(FeedbackType.DamageHeadSlashLightsaber, "DamageHeadSlashLightsaber_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntLightsaber, new Feedback(FeedbackType.DamageHeadBluntLightsaber, "DamageHeadBluntLightsaber_", 0, PositionType.Head));

            feedbackMap.Add(FeedbackType.DamageRightArmPierceBladeSmall, new Feedback(FeedbackType.DamageRightArmPierceBladeSmall, "DamageRightArmPierceBladeSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashBladeSmall, new Feedback(FeedbackType.DamageRightArmSlashBladeSmall, "DamageRightArmSlashBladeSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntBladeSmall, new Feedback(FeedbackType.DamageRightArmBluntBladeSmall, "DamageRightArmBluntBladeSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntWoodSmall, new Feedback(FeedbackType.DamageRightArmBluntWoodSmall, "DamageRightArmBluntWoodSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntMetalSmall, new Feedback(FeedbackType.DamageRightArmBluntMetalSmall, "DamageRightArmBluntMetalSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntStoneSmall, new Feedback(FeedbackType.DamageRightArmBluntStoneSmall, "DamageRightArmBluntStoneSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntFleshSmall, new Feedback(FeedbackType.DamageRightArmBluntFleshSmall, "DamageRightArmBluntFleshSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceFireSmall, new Feedback(FeedbackType.DamageRightArmPierceFireSmall, "DamageRightArmPierceFireSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashFireSmall, new Feedback(FeedbackType.DamageRightArmSlashFireSmall, "DamageRightArmSlashFireSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntFireSmall, new Feedback(FeedbackType.DamageRightArmBluntFireSmall, "DamageRightArmBluntFireSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceLightningSmall, new Feedback(FeedbackType.DamageRightArmPierceLightningSmall, "DamageRightArmPierceLightningSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashLightningSmall, new Feedback(FeedbackType.DamageRightArmSlashLightningSmall, "DamageRightArmSlashLightningSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntLightningSmall, new Feedback(FeedbackType.DamageRightArmBluntLightningSmall, "DamageRightArmBluntLightningSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceIceSmall, new Feedback(FeedbackType.DamageRightArmPierceIceSmall, "DamageRightArmPierceIceSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashIceSmall, new Feedback(FeedbackType.DamageRightArmSlashIceSmall, "DamageRightArmSlashIceSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntIceSmall, new Feedback(FeedbackType.DamageRightArmBluntIceSmall, "DamageRightArmBluntIceSmall_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceBladeLarge, new Feedback(FeedbackType.DamageRightArmPierceBladeLarge, "DamageRightArmPierceBladeLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashBladeLarge, new Feedback(FeedbackType.DamageRightArmSlashBladeLarge, "DamageRightArmSlashBladeLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntBladeLarge, new Feedback(FeedbackType.DamageRightArmBluntBladeLarge, "DamageRightArmBluntBladeLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntWoodLarge, new Feedback(FeedbackType.DamageRightArmBluntWoodLarge, "DamageRightArmBluntWoodLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntMetalLarge, new Feedback(FeedbackType.DamageRightArmBluntMetalLarge, "DamageRightArmBluntMetalLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntStoneLarge, new Feedback(FeedbackType.DamageRightArmBluntStoneLarge, "DamageRightArmBluntStoneLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntFleshLarge, new Feedback(FeedbackType.DamageRightArmBluntFleshLarge, "DamageRightArmBluntFleshLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceFireLarge, new Feedback(FeedbackType.DamageRightArmPierceFireLarge, "DamageRightArmPierceFireLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashFireLarge, new Feedback(FeedbackType.DamageRightArmSlashFireLarge, "DamageRightArmSlashFireLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntFireLarge, new Feedback(FeedbackType.DamageRightArmBluntFireLarge, "DamageRightArmBluntFireLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceLightningLarge, new Feedback(FeedbackType.DamageRightArmPierceLightningLarge, "DamageRightArmPierceLightningLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashLightningLarge, new Feedback(FeedbackType.DamageRightArmSlashLightningLarge, "DamageRightArmSlashLightningLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntLightningLarge, new Feedback(FeedbackType.DamageRightArmBluntLightningLarge, "DamageRightArmBluntLightningLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmPierceIceLarge, new Feedback(FeedbackType.DamageRightArmPierceIceLarge, "DamageRightArmPierceIceLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmSlashIceLarge, new Feedback(FeedbackType.DamageRightArmSlashIceLarge, "DamageRightArmSlashIceLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmBluntIceLarge, new Feedback(FeedbackType.DamageRightArmBluntIceLarge, "DamageRightArmBluntIceLarge_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageHeadPierceBladeSmall, new Feedback(FeedbackType.DamageHeadPierceBladeSmall, "DamageHeadPierceBladeSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashBladeSmall, new Feedback(FeedbackType.DamageHeadSlashBladeSmall, "DamageHeadSlashBladeSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntBladeSmall, new Feedback(FeedbackType.DamageHeadBluntBladeSmall, "DamageHeadBluntBladeSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntWoodSmall, new Feedback(FeedbackType.DamageHeadBluntWoodSmall, "DamageHeadBluntWoodSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntMetalSmall, new Feedback(FeedbackType.DamageHeadBluntMetalSmall, "DamageHeadBluntMetalSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntStoneSmall, new Feedback(FeedbackType.DamageHeadBluntStoneSmall, "DamageHeadBluntStoneSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntFleshSmall, new Feedback(FeedbackType.DamageHeadBluntFleshSmall, "DamageHeadBluntFleshSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadPierceFireSmall, new Feedback(FeedbackType.DamageHeadPierceFireSmall, "DamageHeadPierceFireSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashFireSmall, new Feedback(FeedbackType.DamageHeadSlashFireSmall, "DamageHeadSlashFireSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntFireSmall, new Feedback(FeedbackType.DamageHeadBluntFireSmall, "DamageHeadBluntFireSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadPierceLightningSmall, new Feedback(FeedbackType.DamageHeadPierceLightningSmall, "DamageHeadPierceLightningSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashLightningSmall, new Feedback(FeedbackType.DamageHeadSlashLightningSmall, "DamageHeadSlashLightningSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntLightningSmall, new Feedback(FeedbackType.DamageHeadBluntLightningSmall, "DamageHeadBluntLightningSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadPierceIceSmall, new Feedback(FeedbackType.DamageHeadPierceIceSmall, "DamageHeadPierceIceSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashIceSmall, new Feedback(FeedbackType.DamageHeadSlashIceSmall, "DamageHeadSlashIceSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntIceSmall, new Feedback(FeedbackType.DamageHeadBluntIceSmall, "DamageHeadBluntIceSmall_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadPierceBladeLarge, new Feedback(FeedbackType.DamageHeadPierceBladeLarge, "DamageHeadPierceBladeLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashBladeLarge, new Feedback(FeedbackType.DamageHeadSlashBladeLarge, "DamageHeadSlashBladeLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntBladeLarge, new Feedback(FeedbackType.DamageHeadBluntBladeLarge, "DamageHeadBluntBladeLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntWoodLarge, new Feedback(FeedbackType.DamageHeadBluntWoodLarge, "DamageHeadBluntWoodLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntMetalLarge, new Feedback(FeedbackType.DamageHeadBluntMetalLarge, "DamageHeadBluntMetalLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntStoneLarge, new Feedback(FeedbackType.DamageHeadBluntStoneLarge, "DamageHeadBluntStoneLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntFleshLarge, new Feedback(FeedbackType.DamageHeadBluntFleshLarge, "DamageHeadBluntFleshLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadPierceFireLarge, new Feedback(FeedbackType.DamageHeadPierceFireLarge, "DamageHeadPierceFireLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashFireLarge, new Feedback(FeedbackType.DamageHeadSlashFireLarge, "DamageHeadSlashFireLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntFireLarge, new Feedback(FeedbackType.DamageHeadBluntFireLarge, "DamageHeadBluntFireLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadPierceLightningLarge, new Feedback(FeedbackType.DamageHeadPierceLightningLarge, "DamageHeadPierceLightningLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashLightningLarge, new Feedback(FeedbackType.DamageHeadSlashLightningLarge, "DamageHeadSlashLightningLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntLightningLarge, new Feedback(FeedbackType.DamageHeadBluntLightningLarge, "DamageHeadBluntLightningLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadPierceIceLarge, new Feedback(FeedbackType.DamageHeadPierceIceLarge, "DamageHeadPierceIceLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadSlashIceLarge, new Feedback(FeedbackType.DamageHeadSlashIceLarge, "DamageHeadSlashIceLarge_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadBluntIceLarge, new Feedback(FeedbackType.DamageHeadBluntIceLarge, "DamageHeadBluntIceLarge_", 0, PositionType.Head));

            feedbackMap.Add(FeedbackType.DamageVestArrow, new Feedback(FeedbackType.DamageVestArrow, "DamageVestArrow_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageRightArmArrow, new Feedback(FeedbackType.DamageRightArmArrow, "DamageRightArmArrow_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageHeadArrow, new Feedback(FeedbackType.DamageHeadArrow, "DamageHeadArrow_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageVestFireArrow, new Feedback(FeedbackType.DamageVestFireArrow, "DamageVestFireArrow_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageRightArmFireArrow, new Feedback(FeedbackType.DamageRightArmFireArrow, "DamageRightArmFireArrow_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageHeadFireArrow, new Feedback(FeedbackType.DamageHeadFireArrow, "DamageHeadFireArrow_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageVestLightningArrow, new Feedback(FeedbackType.DamageVestLightningArrow, "DamageVestLightningArrow_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageRightArmLightningArrow, new Feedback(FeedbackType.DamageRightArmLightningArrow, "DamageRightArmLightningArrow_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageHeadLightningArrow, new Feedback(FeedbackType.DamageHeadLightningArrow, "DamageHeadLightningArrow_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageVestIceArrow, new Feedback(FeedbackType.DamageVestIceArrow, "DamageVestIceArrow_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageRightArmIceArrow, new Feedback(FeedbackType.DamageRightArmIceArrow, "DamageRightArmIceArrow_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageHeadIceArrow, new Feedback(FeedbackType.DamageHeadIceArrow, "DamageHeadIceArrow_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageRightArmFire, new Feedback(FeedbackType.DamageRightArmFire, "DamageRightArmFire_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmLightning, new Feedback(FeedbackType.DamageRightArmLightning, "DamageRightArmLightning_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmGravity, new Feedback(FeedbackType.DamageRightArmGravity, "DamageRightArmGravity_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmIce, new Feedback(FeedbackType.DamageRightArmIce, "DamageRightArmIce_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmDrain, new Feedback(FeedbackType.DamageRightArmDrain, "DamageRightArmDrain_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.DamageRightArmEnergy, new Feedback(FeedbackType.DamageRightArmEnergy, "DamageRightArmEnergy_", 0, PositionType.ForearmR));

            feedbackMap.Add(FeedbackType.DamageHeadFire, new Feedback(FeedbackType.DamageHeadFire, "DamageHeadFire_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadLightning, new Feedback(FeedbackType.DamageHeadLightning, "DamageHeadLightning_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadGravity, new Feedback(FeedbackType.DamageHeadGravity, "DamageHeadGravity_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadIce, new Feedback(FeedbackType.DamageHeadIce, "DamageHeadIce_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadDrain, new Feedback(FeedbackType.DamageHeadDrain, "DamageHeadDrain_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.DamageHeadEnergy, new Feedback(FeedbackType.DamageHeadEnergy, "DamageHeadEnergy_", 0, PositionType.Head));

            feedbackMap.Add(FeedbackType.DamageVestEnergy, new Feedback(FeedbackType.DamageVestEnergy, "DamageVestEnergy_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestFire, new Feedback(FeedbackType.DamageVestFire, "DamageVestFire_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestIce, new Feedback(FeedbackType.DamageVestIce, "DamageVestIce_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestDrain, new Feedback(FeedbackType.DamageVestDrain, "DamageVestDrain_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestLightning, new Feedback(FeedbackType.DamageVestLightning, "DamageVestLightning_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.DamageVestGravity, new Feedback(FeedbackType.DamageVestGravity, "DamageVestGravity_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.PotionDrinking, new Feedback(FeedbackType.PotionDrinking, "PotionDrinking_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.PoisonDrinking, new Feedback(FeedbackType.PoisonDrinking, "PoisonDrinking_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.Healing, new Feedback(FeedbackType.Healing, "Healing_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.FallDamage, new Feedback(FeedbackType.FallDamage, "FallDamage_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.FallDamageFeet, new Feedback(FeedbackType.FallDamageFeet, "FallDamageFeet_", 0, PositionType.FootR));
            feedbackMap.Add(FeedbackType.SlowMotion, new Feedback(FeedbackType.SlowMotion, "SlowMotion_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.HolsterLeftShoulder, new Feedback(FeedbackType.HolsterLeftShoulder, "HolsterLeftShoulder_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.HolsterRightShoulder, new Feedback(FeedbackType.HolsterRightShoulder, "HolsterRightShoulder_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.UnholsterLeftShoulder, new Feedback(FeedbackType.UnholsterLeftShoulder, "UnholsterLeftShoulder_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.UnholsterRightShoulder, new Feedback(FeedbackType.UnholsterRightShoulder, "UnholsterRightShoulder_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.HolsterArrowLeftShoulder, new Feedback(FeedbackType.HolsterArrowLeftShoulder, "HolsterArrowLeftShoulder_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.HolsterArrowRightShoulder, new Feedback(FeedbackType.HolsterArrowRightShoulder, "HolsterArrowRightShoulder_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.UnholsterArrowLeftShoulder, new Feedback(FeedbackType.UnholsterArrowLeftShoulder, "UnholsterArrowLeftShoulder_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.UnholsterArrowRightShoulder, new Feedback(FeedbackType.UnholsterArrowRightShoulder, "UnholsterArrowRightShoulder_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.ClimbingRight, new Feedback(FeedbackType.ClimbingRight, "ClimbingRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerKickOtherRight, new Feedback(FeedbackType.PlayerKickOtherRight, "PlayerKickOtherRight_", 0, PositionType.FootR));
            feedbackMap.Add(FeedbackType.PlayerKickWoodRight, new Feedback(FeedbackType.PlayerKickWoodRight, "PlayerKickWoodRight_", 0, PositionType.FootR));
            feedbackMap.Add(FeedbackType.PlayerKickFleshRight, new Feedback(FeedbackType.PlayerKickFleshRight, "PlayerKickFleshRight_", 0, PositionType.FootR));
            feedbackMap.Add(FeedbackType.PlayerKickStoneRight, new Feedback(FeedbackType.PlayerKickStoneRight, "PlayerKickStoneRight_", 0, PositionType.FootR));
            feedbackMap.Add(FeedbackType.PlayerKickMetalRight, new Feedback(FeedbackType.PlayerKickMetalRight, "PlayerKickMetalRight_", 0, PositionType.FootR));
            feedbackMap.Add(FeedbackType.PlayerKickFabricRight, new Feedback(FeedbackType.PlayerKickFabricRight, "PlayerKickFabricRight_", 0, PositionType.FootR));
            feedbackMap.Add(FeedbackType.PlayerPunchOtherRight, new Feedback(FeedbackType.PlayerPunchOtherRight, "PlayerPunchOtherRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerPunchWoodRight, new Feedback(FeedbackType.PlayerPunchWoodRight, "PlayerPunchWoodRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerPunchFleshRight, new Feedback(FeedbackType.PlayerPunchFleshRight, "PlayerPunchFleshRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerPunchStoneRight, new Feedback(FeedbackType.PlayerPunchStoneRight, "PlayerPunchStoneRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerPunchMetalRight, new Feedback(FeedbackType.PlayerPunchMetalRight, "PlayerPunchMetalRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerPunchFabricRight, new Feedback(FeedbackType.PlayerPunchFabricRight, "PlayerPunchFabricRight_", 0, PositionType.ForearmR));

            feedbackMap.Add(FeedbackType.PlayerGunRight, new Feedback(FeedbackType.PlayerGunRight, "PlayerGunRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunBlasterRight, new Feedback(FeedbackType.PlayerGunBlasterRight, "PlayerGunBlasterRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunAutomaticRight, new Feedback(FeedbackType.PlayerGunAutomaticRight, "PlayerGunAutomaticRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunBallisticRight, new Feedback(FeedbackType.PlayerGunBallisticRight, "PlayerGunBallisticRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunSprayRight, new Feedback(FeedbackType.PlayerGunSprayRight, "PlayerGunSprayRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunMiniGunRight, new Feedback(FeedbackType.PlayerGunMiniGunRight, "PlayerGunMiniGunRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunBazookaRight, new Feedback(FeedbackType.PlayerGunBazookaRight, "PlayerGunBazookaRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunHeavyRight, new Feedback(FeedbackType.PlayerGunHeavyRight, "PlayerGunHeavyRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunLaserRight, new Feedback(FeedbackType.PlayerGunLaserRight, "PlayerGunLaserRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunRifleRight, new Feedback(FeedbackType.PlayerGunRifleRight, "PlayerGunRifleRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunPistolRight, new Feedback(FeedbackType.PlayerGunPistolRight, "PlayerGunPistolRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunPlasmaRight, new Feedback(FeedbackType.PlayerGunPlasmaRight, "PlayerGunPlasmaRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunShotgunRight, new Feedback(FeedbackType.PlayerGunShotgunRight, "PlayerGunShotgunRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.PlayerGunEnergyRight, new Feedback(FeedbackType.PlayerGunEnergyRight, "PlayerGunEnergyRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunRight, new Feedback(FeedbackType.KickbackPlayerGunRight, "KickbackPlayerGunRight_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunPistolRight, new Feedback(FeedbackType.KickbackPlayerGunPistolRight, "KickbackPlayerGunPistolRight_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunBallisticRight, new Feedback(FeedbackType.KickbackPlayerGunBallisticRight, "KickbackPlayerGunBallisticRight_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunLaserRight, new Feedback(FeedbackType.KickbackPlayerGunLaserRight, "KickbackPlayerGunLaserRight_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunPlasmaRight, new Feedback(FeedbackType.KickbackPlayerGunPlasmaRight, "KickbackPlayerGunPlasmaRight_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunSprayRight, new Feedback(FeedbackType.KickbackPlayerGunSprayRight, "KickbackPlayerGunSprayRight_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunHeavyRight, new Feedback(FeedbackType.KickbackPlayerGunHeavyRight, "KickbackPlayerGunHeavyRight_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunLeft, new Feedback(FeedbackType.KickbackPlayerGunLeft, "KickbackPlayerGunLeft_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunPistolLeft, new Feedback(FeedbackType.KickbackPlayerGunPistolLeft, "KickbackPlayerGunPistolLeft_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunBallisticLeft, new Feedback(FeedbackType.KickbackPlayerGunBallisticLeft, "KickbackPlayerGunBallisticLeft_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunLaserLeft, new Feedback(FeedbackType.KickbackPlayerGunLaserLeft, "KickbackPlayerGunLaserLeft_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunPlasmaLeft, new Feedback(FeedbackType.KickbackPlayerGunPlasmaLeft, "KickbackPlayerGunPlasmaLeft_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunSprayLeft, new Feedback(FeedbackType.KickbackPlayerGunSprayLeft, "KickbackPlayerGunSprayLeft_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.KickbackPlayerGunHeavyLeft, new Feedback(FeedbackType.KickbackPlayerGunHeavyLeft, "KickbackPlayerGunHeavyLeft_", 0, PositionType.Vest));

            feedbackMap.Add(FeedbackType.PlayerThrowRight, new Feedback(FeedbackType.PlayerThrowRight, "PlayerThrowRight_", 0, PositionType.ForearmR));

            feedbackMap.Add(FeedbackType.Explosion, new Feedback(FeedbackType.Explosion, "Explosion_", 0, PositionType.Vest));

            feedbackMap.Add(FeedbackType.LeftShoulderTurret, new Feedback(FeedbackType.LeftShoulderTurret, "LeftShoulderTurret_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.HoverJetFeet, new Feedback(FeedbackType.HoverJetFeet, "HoverJetFeet_", 0, PositionType.FootR));
			
			feedbackMap.Add(FeedbackType.EquipCuirass, new Feedback(FeedbackType.EquipCuirass, "EquipCuirass_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.EquipGauntletsLeft, new Feedback(FeedbackType.EquipGauntletsLeft, "EquipGauntletsLeft_", 0, PositionType.ForearmL));
            feedbackMap.Add(FeedbackType.EquipGauntletsRight, new Feedback(FeedbackType.EquipGauntletsRight, "EquipGauntletsRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.EquipHelmet, new Feedback(FeedbackType.EquipHelmet, "EquipHelmet_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.UnequipCuirass, new Feedback(FeedbackType.UnequipCuirass, "UnequipCuirass_", 0, PositionType.Vest));
            feedbackMap.Add(FeedbackType.UnequipGauntletsLeft, new Feedback(FeedbackType.UnequipGauntletsLeft, "UnequipGauntletsLeft_", 0, PositionType.ForearmL));
            feedbackMap.Add(FeedbackType.UnequipGauntletsRight, new Feedback(FeedbackType.UnequipGauntletsRight, "UnequipGauntletsRight_", 0, PositionType.ForearmR));
            feedbackMap.Add(FeedbackType.UnequipHelmet, new Feedback(FeedbackType.UnequipHelmet, "UnequipHelmet_", 0, PositionType.Head));
            feedbackMap.Add(FeedbackType.EquipFeet, new Feedback(FeedbackType.EquipFeet, "EquipFeet_", 0, PositionType.FootR));
            feedbackMap.Add(FeedbackType.UnequipFeet, new Feedback(FeedbackType.UnequipFeet, "UnequipFeet_", 0, PositionType.FootR));

            feedbackMap.Add(FeedbackType.ConsumableFood, new Feedback(FeedbackType.ConsumableFood, "ConsumableFood_", 0, PositionType.Vest));

            
        }

        public bool systemInitialized = false;
        //public HapticPlayer hapticPlayer;

        public Dictionary<FeedbackType, Feedback> feedbackMap = new Dictionary<FeedbackType, Feedback>();

        public enum FeedbackType
        {
            //Default Damages on Player
            DefaultDamage,

            //Player Bow
            PlayerBowPullRight,

            //Player Melee
            PlayerMeleeBladeWoodPierceRight,
            PlayerMeleeBladeMetalPierceRight,
            PlayerMeleeBladeStonePierceRight,
            PlayerMeleeBladeFabricPierceRight,
            PlayerMeleeBladeFleshPierceRight,
            PlayerMeleeBladeWoodSlashRight,
            PlayerMeleeBladeMetalSlashRight,
            PlayerMeleeBladeStoneSlashRight,
            PlayerMeleeBladeFabricSlashRight,
            PlayerMeleeBladeFleshSlashRight,
            PlayerMeleeBladeWoodBluntRight,
            PlayerMeleeBladeMetalBluntRight,
            PlayerMeleeBladeStoneBluntRight,
            PlayerMeleeBladeFabricBluntRight,
            PlayerMeleeBladeFleshBluntRight,
            PlayerMeleeWoodWoodBluntRight,
            PlayerMeleeWoodMetalBluntRight,
            PlayerMeleeWoodStoneBluntRight,
            PlayerMeleeWoodFabricBluntRight,
            PlayerMeleeWoodFleshBluntRight,
            PlayerMeleeStoneStoneBluntRight,
            PlayerMeleeStoneFabricBluntRight,
            PlayerMeleeStoneFleshBluntRight,


            PlayerMeleeLightsaberClashRight,
            PlayerMeleeLightsaberSlashRight,
            PlayerMeleeLightsaberPierceRight,
            PlayerMeleeLightsaberBluntRight,


            //Player Spell Cast
            PlayerSpellFireRight,
            PlayerSpellLightningRight,
            PlayerSpellGravityRight,
            PlayerSpellIceRight,
            PlayerSpellCrushRight,
            PlayerSpellHealRight,
            PlayerSpellImplosionRight,
            PlayerSpellInvisibilityRight,
            PlayerSpellTeslaRight,
            PlayerSpellUtilityRight,
            PlayerSpellCorruptionRight,
            PlayerSpellTeleportRight,
            PlayerSpellRasenganRight,
            PlayerSpellNeedleRight,
            PlayerSpellDrainRight,
            PlayerSpellForceFieldRight,
            PlayerSpellOtherRight,
            
            PlayerTelekinesisActiveRight,
            PlayerTelekinesisPullRight,
            PlayerTelekinesisRepelRight,
            PlayerTelekinesisCatchRight,

            //Damage On Player

            DamageVestArrow,
            DamageRightArmArrow,
            DamageHeadArrow,
            DamageVestFireArrow,
            DamageRightArmFireArrow,
            DamageHeadFireArrow,
            DamageVestLightningArrow,
            DamageRightArmLightningArrow,
            DamageHeadLightningArrow,
            DamageVestIceArrow,
            DamageRightArmIceArrow,
            DamageHeadIceArrow,


            DamageHeadFire,
            DamageHeadLightning,
            DamageHeadGravity,
            DamageHeadIce,
            DamageHeadDrain,
            DamageHeadEnergy,

            DamageRightArmFire,
            DamageRightArmLightning,
            DamageRightArmGravity,
            DamageRightArmIce,
            DamageRightArmDrain,
            DamageRightArmEnergy,

            DamageVestFire,
            DamageVestLightning,
            DamageVestGravity,
            DamageVestIce,
            DamageVestDrain,
            DamageVestEnergy,

            DamageVestPierceBladeSmall,
            DamageVestSlashBladeSmallLRD,
            DamageVestSlashBladeSmallLRU,
            DamageVestSlashBladeSmallRLD,
            DamageVestSlashBladeSmallRLU,
            DamageVestBluntBladeSmall,
            DamageVestBluntWoodSmall,
            DamageVestBluntMetalSmall,
            DamageVestBluntStoneSmall,
            DamageVestBluntFleshSmall,
            DamageVestPierceFireSmall,
            DamageVestSlashFireSmallLRD,
            DamageVestSlashFireSmallLRU,
            DamageVestSlashFireSmallRLD,
            DamageVestSlashFireSmallRLU,
            DamageVestBluntFireSmall,
            DamageVestPierceLightningSmall,
            DamageVestSlashLightningSmallLRD,
            DamageVestSlashLightningSmallLRU,
            DamageVestSlashLightningSmallRLD,
            DamageVestSlashLightningSmallRLU,
            DamageVestBluntLightningSmall,
            DamageVestPierceIceSmall,
            DamageVestSlashIceSmallLRD,
            DamageVestSlashIceSmallLRU,
            DamageVestSlashIceSmallRLD,
            DamageVestSlashIceSmallRLU,
            DamageVestBluntIceSmall,
            DamageVestPierceBladeLarge,
            DamageVestSlashBladeLargeLRD,
            DamageVestSlashBladeLargeLRU,
            DamageVestSlashBladeLargeRLD,
            DamageVestSlashBladeLargeRLU,
            DamageVestBluntBladeLarge,
            DamageVestBluntWoodLarge,
            DamageVestBluntMetalLarge,
            DamageVestBluntStoneLarge,
            DamageVestBluntFleshLarge,
            DamageVestPierceFireLarge,
            DamageVestSlashFireLargeLRD,
            DamageVestSlashFireLargeLRU,
            DamageVestSlashFireLargeRLD,
            DamageVestSlashFireLargeRLU,
            DamageVestBluntFireLarge,
            DamageVestPierceLightningLarge,
            DamageVestSlashLightningLargeLRD,
            DamageVestSlashLightningLargeLRU,
            DamageVestSlashLightningLargeRLD,
            DamageVestSlashLightningLargeRLU,
            DamageVestBluntLightningLarge,
            DamageVestPierceIceLarge,
            DamageVestSlashIceLargeLRD,
            DamageVestSlashIceLargeLRU,
            DamageVestSlashIceLargeRLD,
            DamageVestSlashIceLargeRLU,
            DamageVestBluntIceLarge,

            DamageVestBlaster,
            DamageVestBlasterStun,
            DamageRightArmBlaster,
            DamageRightArmBlasterStun,
            DamageHeadBlaster,
            DamageHeadBlasterStun,

            DamageVestPierceLightsaber,
            DamageVestSlashLightsaberLRD,
            DamageVestSlashLightsaberLRU,
            DamageVestSlashLightsaberRLD,
            DamageVestSlashLightsaberRLU,
            DamageVestBluntLightsaber,
            DamageRightArmBluntLightsaber,
            DamageRightArmPierceLightsaber,
            DamageRightArmSlashLightsaber,
            DamageHeadPierceLightsaber,
            DamageHeadSlashLightsaber,
            DamageHeadBluntLightsaber,


            DamageRightArmPierceBladeSmall,
            DamageRightArmSlashBladeSmall,
            DamageRightArmBluntBladeSmall,
            DamageRightArmBluntWoodSmall,
            DamageRightArmBluntMetalSmall,
            DamageRightArmBluntStoneSmall,
            DamageRightArmBluntFleshSmall,
            DamageRightArmPierceFireSmall,
            DamageRightArmSlashFireSmall,
            DamageRightArmBluntFireSmall,
            DamageRightArmPierceLightningSmall,
            DamageRightArmSlashLightningSmall,
            DamageRightArmBluntLightningSmall,
            DamageRightArmPierceIceSmall,
            DamageRightArmSlashIceSmall,
            DamageRightArmBluntIceSmall,
            DamageRightArmPierceBladeLarge,
            DamageRightArmSlashBladeLarge,
            DamageRightArmBluntBladeLarge,
            DamageRightArmBluntWoodLarge,
            DamageRightArmBluntMetalLarge,
            DamageRightArmBluntStoneLarge,
            DamageRightArmBluntFleshLarge,
            DamageRightArmPierceFireLarge,
            DamageRightArmSlashFireLarge,
            DamageRightArmBluntFireLarge,
            DamageRightArmPierceLightningLarge,
            DamageRightArmSlashLightningLarge,
            DamageRightArmBluntLightningLarge,
            DamageRightArmPierceIceLarge,
            DamageRightArmSlashIceLarge,
            DamageRightArmBluntIceLarge,
            DamageHeadPierceBladeSmall,
            DamageHeadSlashBladeSmall,
            DamageHeadBluntBladeSmall,
            DamageHeadBluntWoodSmall,
            DamageHeadBluntMetalSmall,
            DamageHeadBluntStoneSmall,
            DamageHeadBluntFleshSmall,
            DamageHeadPierceFireSmall,
            DamageHeadSlashFireSmall,
            DamageHeadBluntFireSmall,
            DamageHeadPierceLightningSmall,
            DamageHeadSlashLightningSmall,
            DamageHeadBluntLightningSmall,
            DamageHeadPierceIceSmall,
            DamageHeadSlashIceSmall,
            DamageHeadBluntIceSmall,
            DamageHeadPierceBladeLarge,
            DamageHeadSlashBladeLarge,
            DamageHeadBluntBladeLarge,
            DamageHeadBluntWoodLarge,
            DamageHeadBluntMetalLarge,
            DamageHeadBluntStoneLarge,
            DamageHeadBluntFleshLarge,
            DamageHeadPierceFireLarge,
            DamageHeadSlashFireLarge,
            DamageHeadBluntFireLarge,
            DamageHeadPierceLightningLarge,
            DamageHeadSlashLightningLarge,
            DamageHeadBluntLightningLarge,
            DamageHeadPierceIceLarge,
            DamageHeadSlashIceLarge,
            DamageHeadBluntIceLarge,

            //Special stuff
            HeartBeat,
            HeartBeatFast,

            PotionDrinking,
            PoisonDrinking,
            Healing,
            ConsumableFood,

            FallDamage,
            FallDamageFeet,
            SlowMotion,

            HolsterLeftShoulder,
            HolsterRightShoulder,
            UnholsterLeftShoulder,
            UnholsterRightShoulder,

            HolsterArrowLeftShoulder,
            HolsterArrowRightShoulder,
            UnholsterArrowLeftShoulder,
            UnholsterArrowRightShoulder,

            ClimbingRight,

            PlayerKickOtherRight,
            PlayerKickWoodRight,
            PlayerKickFleshRight,
            PlayerKickStoneRight,
            PlayerKickMetalRight,
            PlayerKickFabricRight,

            PlayerPunchOtherRight,
            PlayerPunchWoodRight,
            PlayerPunchFleshRight,
            PlayerPunchStoneRight,
            PlayerPunchMetalRight,
            PlayerPunchFabricRight,

            //Player Gun
            PlayerGunRight,
            PlayerGunBlasterRight,
            PlayerGunAutomaticRight,
            PlayerGunBallisticRight,
            PlayerGunSprayRight,
            PlayerGunMiniGunRight,
            PlayerGunBazookaRight,
            PlayerGunHeavyRight,
            PlayerGunLaserRight,
            PlayerGunRifleRight,
            PlayerGunPistolRight,
            PlayerGunPlasmaRight,
            PlayerGunShotgunRight,
            PlayerGunEnergyRight,

            //Kickback Player Arm Feedbacks
            KickbackPlayerGunRight,
            KickbackPlayerGunPistolRight,
            KickbackPlayerGunBallisticRight,
            KickbackPlayerGunLaserRight,
            KickbackPlayerGunPlasmaRight,
            KickbackPlayerGunSprayRight,
            KickbackPlayerGunHeavyRight,

            KickbackPlayerGunLeft,
            KickbackPlayerGunPistolLeft,
            KickbackPlayerGunBallisticLeft,
            KickbackPlayerGunLaserLeft,
            KickbackPlayerGunPlasmaLeft,
            KickbackPlayerGunSprayLeft,
            KickbackPlayerGunHeavyLeft,

            PlayerThrowRight,

            Explosion,

            LeftShoulderTurret,
            HoverJetFeet,
			
			EquipCuirass,
            EquipGauntletsRight,
            EquipGauntletsLeft,
            EquipHelmet,
            UnequipCuirass,
            UnequipGauntletsRight,
            UnequipGauntletsLeft,
            UnequipHelmet,
            EquipFeet,
            UnequipFeet,

            NoFeedback
        }

        public static FeedbackType GetSpellFeedbackFromId(string id)
        {
            string lowerId = id.ToLowerInvariant();
            if (lowerId.Contains("fire"))
            {
                return FeedbackType.PlayerSpellFireRight;
            }
            else if (lowerId.Contains("lightning") || lowerId.Contains("electric") || lowerId.Contains("shock"))
            {
                return FeedbackType.PlayerSpellLightningRight;
            }
            else if (lowerId.Contains("gravity"))
            {
                return FeedbackType.PlayerSpellGravityRight;
            }
            else if (lowerId.Contains("ice") || lowerId.Contains("ıce"))
            {
                return FeedbackType.PlayerSpellIceRight;
            }
            else if (lowerId.Contains("crush"))
            {
                return FeedbackType.PlayerSpellCrushRight;
            }
            else if (lowerId.Contains("heal"))
            {
                return FeedbackType.PlayerSpellHealRight;
            }
            else if (lowerId.Contains("mplos"))
            {
                return FeedbackType.PlayerSpellImplosionRight;
            }
            else if (lowerId.Contains("nvisi"))
            {
                return FeedbackType.PlayerSpellInvisibilityRight;
            }
            else if (lowerId.Contains("tesla"))
            {
                return FeedbackType.PlayerSpellTeslaRight;
            }
            else if (lowerId.Contains("util"))
            {
                return FeedbackType.PlayerSpellUtilityRight;
            }
            else if (lowerId.Contains("corrupt"))
            {
                return FeedbackType.PlayerSpellCorruptionRight;
            }
            else if (lowerId.Contains("teleport"))
            {
                return FeedbackType.PlayerSpellTeleportRight;
            }
            else if (lowerId.Contains("rasengan") || lowerId.Contains("whirl"))
            {
                return FeedbackType.PlayerSpellRasenganRight;
            }
            else if (lowerId.Contains("needle") || lowerId.Contains("spawn"))
            {
                return FeedbackType.PlayerSpellNeedleRight;
            }
            else if (lowerId.Contains("drain"))
            {
                return FeedbackType.PlayerSpellDrainRight;
            }
            else if (lowerId.Contains("force") || lowerId.Contains("jet") || lowerId.Contains("iron"))
            {
                return FeedbackType.PlayerSpellForceFieldRight;
            }
            else
            {
                return FeedbackType.PlayerSpellOtherRight;
            }
        }

        public static FeedbackType GetPlayerMeleeFeedbackType(DamageType damageType, MaterialData sourceMaterialData, MaterialData targetMaterialData)
        {
            string sourceMaterial = "";
            string targetMaterial = "";
            if (sourceMaterialData != null)
            {
                sourceMaterial = sourceMaterialData.id;
            }
            if (targetMaterialData != null)
            {
                targetMaterial = targetMaterialData.id;
            }

            
            if (damageType == DamageType.Pierce)
            {
                if (sourceMaterial == "Blade" || sourceMaterial == "Metal")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalPierceRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeBladeWoodPierceRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeBladeFleshPierceRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeBladeStonePierceRight;
                    }
                }
                else if (sourceMaterial == "Wood")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeWoodMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodWoodBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeWoodFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeWoodFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                }
                else if (sourceMaterial == "Flesh")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerPunchMetalRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerPunchWoodRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerPunchFleshRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerPunchFabricRight;
                    }
                    else if (targetMaterial == "Stone" || targetMaterial == "Glass")
                    {
                        return FeedbackType.PlayerPunchStoneRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerPunchOtherRight;
                    }
                }
                else if (sourceMaterial.Contains("Lightsaber"))
                {
                    if (targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeLightsaberClashRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeLightsaberPierceRight;
                    }
                }
                else if (sourceMaterial.Contains("Fire"))
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalPierceRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else if (targetMaterial == "Stone")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricPierceRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeBladeStonePierceRight;
                    }
                }
                else
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeStoneFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeStoneFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeStoneStoneBluntRight;
                    }
                }
            }
            else if (damageType == DamageType.Slash)
            {
                if (sourceMaterial == "Lightsaber")
                {
                    if (targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeLightsaberClashRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeLightsaberSlashRight;
                    }
                }
                if (sourceMaterial == "Blade" || sourceMaterial == "Metal" || sourceMaterial == "SpellFire")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalSlashRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeBladeWoodSlashRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeBladeFleshSlashRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricSlashRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeBladeStoneSlashRight;
                    }
                }
                else if (sourceMaterial == "Wood")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeWoodMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodWoodBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeWoodFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeWoodFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                }
                else if (sourceMaterial == "Flesh")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerPunchMetalRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerPunchWoodRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerPunchFleshRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerPunchFabricRight;
                    }
                    else if (targetMaterial == "Stone" || targetMaterial == "Glass")
                    {
                        return FeedbackType.PlayerPunchStoneRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerPunchOtherRight;
                    }
                }
                else
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeStoneFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeStoneFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeStoneStoneBluntRight;
                    }
                }
            }
            else
            {
                if (sourceMaterial == "Blade" || sourceMaterial == "Metal" || sourceMaterial == "SpellFire")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeBladeWoodBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeBladeFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeBladeFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeBladeStoneBluntRight;
                    }
                }
                else if (sourceMaterial == "Lightsaber")
                {
                    if (targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeLightsaberClashRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeLightsaberBluntRight;
                    }
                }
                else if (sourceMaterial == "Wood")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeWoodMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodWoodBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeWoodFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeWoodFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                }
                else if (sourceMaterial == "Flesh")
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerPunchMetalRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerPunchWoodRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerPunchFleshRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerPunchFabricRight;
                    }
                    else if (targetMaterial == "Stone" || targetMaterial == "Glass")
                    {
                        return FeedbackType.PlayerPunchStoneRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerPunchOtherRight;
                    }
                }
                else
                {
                    if (targetMaterial == "Blade" || targetMaterial == "Metal" || targetMaterial == "Chainmail" || targetMaterial == "Plate" || targetMaterial == "Lightsaber")
                    {
                        return FeedbackType.PlayerMeleeBladeMetalBluntRight;
                    }
                    else if (targetMaterial == "Wood" || targetMaterial == "Arrow")
                    {
                        return FeedbackType.PlayerMeleeWoodStoneBluntRight;
                    }
                    else if (targetMaterial == "Flesh")
                    {
                        return FeedbackType.PlayerMeleeStoneFleshBluntRight;
                    }
                    else if (targetMaterial == "Fabric" || targetMaterial == "Leather" || targetMaterial == "Rope")
                    {
                        return FeedbackType.PlayerMeleeStoneFabricBluntRight;
                    }
                    else
                    {
                        return FeedbackType.PlayerMeleeStoneStoneBluntRight;
                    }
                }
            }
            
        }

        public static FeedbackType GetPlayerGotHitFeedbackType(DamageType damageType, MaterialData sourceMaterialData, MaterialData targetMaterialData, string spellId, PenetrationSize penetrationSize, string sourceColliderName, string targetColliderName, Direction direction, string imbueSpellId, string damagerId)
        {
            string sourceMaterial = "";
            string targetMaterial = "";

            if (sourceMaterialData != null)
            {
                sourceMaterial = sourceMaterialData.id;
            }
            if (targetMaterialData != null)
            {
                targetMaterial = targetMaterialData.id;
            }
            

            if ((targetColliderName.Contains("Arm") || targetColliderName.Contains("Hand")) && (targetColliderName.Contains("Left") || targetColliderName.Contains("Right")))
            {
                if (damagerId == "BlasterBolt")
                {
                    return FeedbackType.DamageRightArmBlaster;
                }
                else if (damagerId == "BlasterStun")
                {
                    return FeedbackType.DamageRightArmBlasterStun;
                }
                else if (sourceColliderName == "Tip" || sourceMaterial == "Arrow")
                {
                    if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                    {
                        return FeedbackType.DamageRightArmFireArrow;
                    }
                    else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                    {
                        return FeedbackType.DamageRightArmLightningArrow;
                    }
                    else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                    {
                        return FeedbackType.DamageRightArmIceArrow;
                    }
                    else
                    {
                        return FeedbackType.DamageRightArmArrow;
                    }
                }
                else if (damageType == DamageType.Pierce)
                {
                    if (penetrationSize == PenetrationSize.Small)
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmPierceLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmPierceFireSmall;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmPierceLightningSmall;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmPierceIceSmall;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmPierceBladeSmall;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodSmall;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshSmall;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalSmall;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneSmall;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmPierceBladeSmall;
                        }
                    }
                    else //Large
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmPierceLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmPierceFireLarge;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmPierceLightningLarge;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmPierceIceLarge;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmPierceBladeLarge;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodLarge;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshLarge;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalLarge;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneLarge;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmPierceBladeLarge;
                        }
                    }
                }
                else if (damageType == DamageType.Slash)
                {
                    if (penetrationSize == PenetrationSize.Small)
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmSlashLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmSlashFireSmall;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmSlashLightningSmall;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmSlashIceSmall;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmSlashBladeSmall;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodSmall;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshSmall;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalSmall;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneSmall;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmSlashBladeSmall;
                        }
                    }
                    else //Large
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmSlashLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmSlashFireLarge;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmSlashLightningLarge;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmSlashIceLarge;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmSlashBladeLarge;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodLarge;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshLarge;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalLarge;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneLarge;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmSlashBladeLarge;
                        }
                    }
                }
                else if (damageType == DamageType.Energy)
                {
                    string lowerId = (spellId != "" ? spellId.ToLowerInvariant() : sourceMaterial.ToLowerInvariant()) + damagerId.ToLowerInvariant();
                    if (sourceMaterial == "Lightsaber")
                    {
                        return FeedbackType.DamageRightArmSlashLightsaber;
                    }
                    else if (lowerId.Contains("fire"))
                    {
                        return FeedbackType.DamageRightArmFire;
                    }
                    else if (lowerId.Contains("blaster"))
                    {
                        return FeedbackType.DamageRightArmFire;
                    }
                    else if (lowerId.Contains("lightning") || lowerId.Contains("electric") || lowerId.Contains("shock"))
                    {
                        return FeedbackType.DamageRightArmLightning;
                    }
                    else if (lowerId.Contains("gravity"))
                    {
                        return FeedbackType.DamageRightArmGravity;
                    }
                    else if (lowerId.Contains("ice") || lowerId.Contains("ıce"))
                    {
                        return FeedbackType.DamageRightArmIce;
                    }
                    else if (lowerId.Contains("drain") || lowerId.Contains("mplo"))
                    {
                        return FeedbackType.DamageRightArmDrain;
                    }
                    else
                    {
                        return FeedbackType.DamageRightArmEnergy;
                    }
                }
                else //Blunt
                {
                    if (penetrationSize == PenetrationSize.Small)
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmBluntLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmBluntFireSmall;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmBluntLightningSmall;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmBluntIceSmall;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmBluntBladeSmall;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodSmall;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshSmall;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalSmall;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneSmall;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmBluntBladeSmall;
                        }
                    }
                    else //Large
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageRightArmBluntLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageRightArmBluntFireLarge;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageRightArmBluntLightningLarge;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageRightArmBluntIceLarge;
                        }
                        else if (sourceMaterial == "Blade")
                        {
                            return FeedbackType.DamageRightArmBluntBladeLarge;
                        }
                        else if (sourceMaterial == "Wood")
                        {
                            return FeedbackType.DamageRightArmBluntWoodLarge;
                        }
                        else if (sourceMaterial == "Flesh")
                        {
                            return FeedbackType.DamageRightArmBluntFleshLarge;
                        }
                        else if (sourceMaterial == "Metal")
                        {
                            return FeedbackType.DamageRightArmBluntMetalLarge;
                        }
                        else if (sourceMaterial == "Stone")
                        {
                            return FeedbackType.DamageRightArmBluntStoneLarge;
                        }
                        else
                        {
                            return FeedbackType.DamageRightArmBluntBladeLarge;
                        }
                    }
                }
            }
            else
            {
                if (targetColliderName.Contains("Head")) //Head
                {
                    if (damagerId == "BlasterBolt")
                    {
                        return FeedbackType.DamageHeadBlaster;
                    }
                    else if (damagerId == "BlasterStun")
                    {
                        return FeedbackType.DamageHeadBlasterStun;
                    }
                    else if (sourceColliderName == "Tip" || sourceMaterial == "Arrow")
                    {
                        if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageHeadFireArrow;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageHeadLightningArrow;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageHeadIceArrow;
                        }
                        else
                        {
                            return FeedbackType.DamageHeadArrow;
                        }
                    }
                    else if (damageType == DamageType.Pierce)
                    {
                        if (penetrationSize == PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadPierceLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadPierceFireSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadPierceLightningSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadPierceIceSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadPierceBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadPierceBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadPierceLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadPierceFireLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadPierceLightningLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadPierceIceLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadPierceBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadPierceBladeLarge;
                            }
                        }
                    }
                    else if (damageType == DamageType.Slash)
                    {
                        if (penetrationSize == PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadSlashLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadSlashFireSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadSlashLightningSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadSlashIceSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadSlashBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadSlashBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadSlashLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadSlashFireLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadSlashLightningLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadSlashIceLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadSlashBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadSlashBladeLarge;
                            }
                        }
                    }
                    else if (damageType == DamageType.Energy)
                    {
                        string lowerId = (spellId != "" ? spellId.ToLowerInvariant() : sourceMaterial.ToLowerInvariant()) + damagerId.ToLowerInvariant();
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageHeadSlashLightsaber;
                        }
                        else if (lowerId.Contains("fire"))
                        {
                            return FeedbackType.DamageHeadFire;
                        }
                        else if (lowerId.Contains("lightning") || lowerId.Contains("electric") || lowerId.Contains("shock"))
                        {
                            return FeedbackType.DamageHeadLightning;
                        }
                        else if (lowerId.Contains("gravity"))
                        {
                            return FeedbackType.DamageHeadGravity;
                        }
                        else if (lowerId.Contains("ice") || lowerId.Contains("ıce"))
                        {
                            return FeedbackType.DamageHeadIce;
                        }
                        else if (lowerId.Contains("drain") || lowerId.Contains("mplo"))
                        {
                            return FeedbackType.DamageHeadDrain;
                        }
                        else
                        {
                            return FeedbackType.DamageHeadEnergy;
                        }
                    }
                    else //Blunt
                    {
                        if (penetrationSize == PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadBluntLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadBluntFireSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadBluntLightningSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadBluntIceSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadBluntBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadBluntBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageHeadBluntLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageHeadBluntFireLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageHeadBluntLightningLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageHeadBluntIceLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageHeadBluntBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageHeadBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageHeadBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageHeadBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageHeadBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageHeadBluntBladeLarge;
                            }
                        }
                    }
                }
                else //Vest
                {
                    if (damagerId == "BlasterBolt")
                    {
                        return FeedbackType.DamageVestBlaster;
                    }
                    else if (damagerId == "BlasterStun")
                    {
                        return FeedbackType.DamageVestBlasterStun;
                    }
                    else if (sourceColliderName == "Tip" || sourceMaterial == "Arrow")
                    {
                        if (sourceMaterial == "Lightsaber")
                        {
                            return FeedbackType.DamageVestPierceLightsaber;
                        }
                        else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                        {
                            return FeedbackType.DamageVestFireArrow;
                        }
                        else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                        {
                            return FeedbackType.DamageVestLightningArrow;
                        }
                        else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                        {
                            return FeedbackType.DamageVestIceArrow;
                        }
                        else
                        {
                            return FeedbackType.DamageVestArrow;
                        }
                    }
                    else if (damageType == DamageType.Pierce)
                    {
                        if (penetrationSize == PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageVestPierceLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageVestPierceFireSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageVestPierceIceSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageVestPierceLightningSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageVestPierceBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageVestPierceBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageVestPierceLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageVestPierceFireLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageVestPierceIceLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageVestPierceLightningLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageVestPierceBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageVestPierceBladeLarge;
                            }
                        }
                    }
                    else if (damageType == DamageType.Slash)
                    {
                        if (penetrationSize == PenetrationSize.Small)
                        {
                            if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashFireSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashFireSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashFireSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashFireSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashFireSmallLRD;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashLightningSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashLightningSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashLightningSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashLightningSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashLightningSmallLRD;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashIceSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashIceSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashIceSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashIceSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashIceSmallLRD;
                            }
                            else if (sourceMaterial == "Lightsaber")
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashLightsaberLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashLightsaberLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashLightsaberRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashLightsaberRLU;
                                else
                                    return FeedbackType.DamageVestSlashLightsaberLRD;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashBladeSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashBladeSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashBladeSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashBladeSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashBladeSmallLRD;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneSmall;
                            }
                            else
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashBladeSmallLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashBladeSmallLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashBladeSmallRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashBladeSmallRLU;
                                else
                                    return FeedbackType.DamageVestSlashBladeSmallLRD;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashFireLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashFireLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashFireLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashFireLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashFireLargeLRD;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashIceLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashIceLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashIceLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashIceLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashIceLargeLRD;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashLightningLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashLightningLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashLightningLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashLightningLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashLightningLargeLRD;
                            }
                            else if (sourceMaterial == "Lightsaber")
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashLightsaberLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashLightsaberLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashLightsaberRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashLightsaberRLU;
                                else
                                    return FeedbackType.DamageVestSlashLightsaberLRD;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashBladeLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashBladeLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashBladeLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashBladeLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashBladeLargeLRD;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneLarge;
                            }
                            else
                            {
                                if (direction == Direction.LeftRightDown)
                                    return FeedbackType.DamageVestSlashBladeLargeLRD;
                                else if (direction == Direction.LeftRightUp)
                                    return FeedbackType.DamageVestSlashBladeLargeLRU;
                                else if (direction == Direction.RightLeftDown)
                                    return FeedbackType.DamageVestSlashBladeLargeRLD;
                                else if (direction == Direction.RightLeftUp)
                                    return FeedbackType.DamageVestSlashBladeLargeRLU;
                                else
                                    return FeedbackType.DamageVestSlashBladeLargeLRD;
                            }
                        }
                    }
                    else if (damageType == DamageType.Energy)
                    {
                        string lowerId = (spellId != "" ? spellId.ToLowerInvariant() : sourceMaterial.ToLowerInvariant()) + damagerId.ToLowerInvariant();
                        if (sourceMaterial == "Lightsaber")
                        {
                            if (direction == Direction.LeftRightDown)
                                return FeedbackType.DamageVestSlashLightsaberLRD;
                            else if (direction == Direction.LeftRightUp)
                                return FeedbackType.DamageVestSlashLightsaberLRU;
                            else if (direction == Direction.RightLeftDown)
                                return FeedbackType.DamageVestSlashLightsaberRLD;
                            else if (direction == Direction.RightLeftUp)
                                return FeedbackType.DamageVestSlashLightsaberRLU;
                            else
                                return FeedbackType.DamageVestSlashLightsaberLRD;
                        }
                        else if (lowerId.Contains("fire"))
                        {
                            return FeedbackType.DamageVestFire;
                        }
                        else if (lowerId.Contains("lightning") || lowerId.Contains("electric") || lowerId.Contains("shock"))
                        {
                            return FeedbackType.DamageVestLightning;
                        }
                        else if (lowerId.Contains("ice") || lowerId.Contains("ıce"))
                        {
                            return FeedbackType.DamageVestIce;
                        }
                        else if (lowerId.Contains("drain") || lowerId.Contains("mplo"))
                        {
                            return FeedbackType.DamageVestDrain;
                        }
                        else if (lowerId.Contains("gravity"))
                        {
                            return FeedbackType.DamageVestGravity;
                        }
                        else
                        {
                            return FeedbackType.DamageVestEnergy;
                        }
                    }
                    else //Blunt
                    {
                        if (penetrationSize == PenetrationSize.Small)
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageVestBluntLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageVestBluntFireSmall;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageVestBluntLightningSmall;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageVestBluntIceSmall;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageVestBluntBladeSmall;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodSmall;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshSmall;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalSmall;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneSmall;
                            }
                            else
                            {
                                return FeedbackType.DamageVestBluntBladeSmall;
                            }
                        }
                        else //Large
                        {
                            if (sourceMaterial == "Lightsaber")
                            {
                                return FeedbackType.DamageVestBluntLightsaber;
                            }
                            else if (sourceMaterial.Contains("Fire") || imbueSpellId.Contains("Fire"))
                            {
                                return FeedbackType.DamageVestBluntFireLarge;
                            }
                            else if (sourceMaterial.Contains("Lightning") || imbueSpellId.Contains("Lightning"))
                            {
                                return FeedbackType.DamageVestBluntLightningLarge;
                            }
                            else if (sourceMaterial.Contains("Ice") || imbueSpellId.Contains("Ice"))
                            {
                                return FeedbackType.DamageVestBluntIceLarge;
                            }
                            else if (sourceMaterial == "Blade")
                            {
                                return FeedbackType.DamageVestBluntBladeLarge;
                            }
                            else if (sourceMaterial == "Wood")
                            {
                                return FeedbackType.DamageVestBluntWoodLarge;
                            }
                            else if (sourceMaterial == "Flesh")
                            {
                                return FeedbackType.DamageVestBluntFleshLarge;
                            }
                            else if (sourceMaterial == "Metal")
                            {
                                return FeedbackType.DamageVestBluntMetalLarge;
                            }
                            else if (sourceMaterial == "Stone")
                            {
                                return FeedbackType.DamageVestBluntStoneLarge;
                            }
                            else
                            {
                                return FeedbackType.DamageVestBluntBladeLarge;
                            }
                        }
                    }
                }
            }

            return FeedbackType.DefaultDamage;
        }

        public struct Feedback
        {
            public Feedback(FeedbackType _feedbackType, string _prefix, int _feedbackFileCount, PositionType _posType)
            {
                feedbackType = _feedbackType;
                prefix = _prefix;
                feedbackFileCount = _feedbackFileCount;
                posType = _posType;
            }
            public FeedbackType feedbackType;
            public string prefix;
            public int feedbackFileCount;
            public PositionType posType;
        };

        void TactFileRegister(string fullname, Feedback feedback)
        {
            if (feedbackMap.ContainsKey(feedback.feedbackType))
            {
                Feedback f = feedbackMap[feedback.feedbackType];
                f.feedbackFileCount += 1;
                feedbackMap[feedback.feedbackType] = f;

                string tactFileStr = File.ReadAllText(fullname);
                Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().RegisterTactFileStr(feedback.prefix + (feedbackMap[feedback.feedbackType].feedbackFileCount).ToString(), tactFileStr);
                if (feedback.prefix.Contains("Right"))
                {
                    string reflectedStr = tactFileStr;
                    if(reflectedStr.Contains("Forearm"))
                        reflectedStr = reflectedStr.Replace("\"ForearmR\"", "\"ForearmM\"").Replace("\"ForearmL\"", "\"ForearmR\"").Replace("\"ForearmM\"", "\"ForearmL\"");
                    if (reflectedStr.Contains("Foot"))
                        reflectedStr = reflectedStr.Replace("\"FootR\"", "\"FootM\"").Replace("\"FootL\"", "\"FootR\"").Replace("\"FootM\"", "\"FootL\"");

                    Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().RegisterTactFileStr("Reflected_" + feedback.prefix + (feedbackMap[feedback.feedbackType].feedbackFileCount).ToString(), reflectedStr);
                }
            }
        }

        void RegisterFeedbackFiles()
        {
            string configPath = Directory.GetCurrentDirectory() + "\\BladeAndSorcery_Data\\StreamingAssets\\Mods";

            DirectoryInfo d = new DirectoryInfo(configPath);
            FileInfo[] Files = d.GetFiles("*.tact", SearchOption.AllDirectories);

            for (int i = 0; i < Files.Length; i++)
            {
                string filename = Files[i].Name;
                string fullName = Files[i].FullName;
                if (filename == "." || filename == "..")
                    continue;

                foreach (var element in feedbackMap)
                {
                    if (filename.StartsWith(element.Value.prefix))
                    {
                        TactFileRegister(fullName, element.Value);
                        LOG("Tact file registered: " + filename);
                        break;
                    }
                }
            }

            
        }

        private readonly object syncLock = new object();

        public void CreateSystem()
        {
            lock (syncLock)
            {
                if (!systemInitialized || Bhaptics.Tact.HapticPlayerManager.Instance() == null || Bhaptics.Tact.HapticPlayerManager.Instance().Connected == false)
                {
                    if (Bhaptics.Tact.HapticPlayerManager.Instance() == null || Bhaptics.Tact.HapticPlayerManager.Instance().Connected == false)
                    {
                        LOG("No connection to bHaptics Player. Reconnecting.");
                    }
                    Bhaptics.Tact.HapticPlayerManager.SetAppInfo("mod_blade_sorcery", "mod_blade_sorcery");

                    if (Bhaptics.Tact.HapticPlayerManager.Instance() != null || Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer()!=null)
                    {
                        RegisterFeedbackFiles();
                        systemInitialized = true;

                        if (Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().IsActive(PositionType.Head))
                        {
                            HeadActive = true;
                        }
                        if (Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().IsActive(PositionType.FootR) || Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().IsActive(PositionType.FootL))
                        {
                            FeetActive = true;
                        }
                        if (Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().IsActive(PositionType.ForearmL) || Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().IsActive(PositionType.ForearmR))
                        {
                            ArmsActive = true;
                        }
                    }
                }
            }
        }

        bool IsPlayingKeyAll(bool reflected, string prefix, int feedbackFileCount)
        {
            for (int i = 1; i <= feedbackFileCount; i++)
            {
                string key = (reflected ? "Reflected_" : "") + prefix + i.ToString();
                if (Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().IsPlaying(key))
                {
                    return true;
                }
            }
            return false;
        }

        public float GetIntensityMultiplier(TactsuitVR.FeedbackType feedbackType)
        {
            switch (feedbackType)
            {
                case TactsuitVR.FeedbackType.DefaultDamage: return Engine.IntensityDefaultDamage; break;
                case TactsuitVR.FeedbackType.PlayerBowPullRight: return Engine.IntensityPlayerBowPull * Engine.IntensityMultiplierBow; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeWoodPierceRight: return Engine.IntensityPlayerMeleeBladeWoodPierce * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeMetalPierceRight: return Engine.IntensityPlayerMeleeBladeMetalPierce * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeStonePierceRight: return Engine.IntensityPlayerMeleeBladeStonePierce * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFabricPierceRight: return Engine.IntensityPlayerMeleeBladeFabricPierce * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFleshPierceRight: return Engine.IntensityPlayerMeleeBladeFleshPierce * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeWoodSlashRight: return Engine.IntensityPlayerMeleeBladeWoodSlash * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeMetalSlashRight: return Engine.IntensityPlayerMeleeBladeMetalSlash * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeStoneSlashRight: return Engine.IntensityPlayerMeleeBladeStoneSlash * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFabricSlashRight: return Engine.IntensityPlayerMeleeBladeFabricSlash * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFleshSlashRight: return Engine.IntensityPlayerMeleeBladeFleshSlash * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeWoodBluntRight: return Engine.IntensityPlayerMeleeBladeWoodBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeMetalBluntRight: return Engine.IntensityPlayerMeleeBladeMetalBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeStoneBluntRight: return Engine.IntensityPlayerMeleeBladeStoneBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFabricBluntRight: return Engine.IntensityPlayerMeleeBladeFabricBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeBladeFleshBluntRight: return Engine.IntensityPlayerMeleeBladeFleshBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodWoodBluntRight: return Engine.IntensityPlayerMeleeWoodWoodBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodMetalBluntRight: return Engine.IntensityPlayerMeleeWoodMetalBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodStoneBluntRight: return Engine.IntensityPlayerMeleeWoodStoneBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodFabricBluntRight: return Engine.IntensityPlayerMeleeWoodFabricBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeWoodFleshBluntRight: return Engine.IntensityPlayerMeleeWoodFleshBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeStoneStoneBluntRight: return Engine.IntensityPlayerMeleeStoneStoneBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeStoneFabricBluntRight: return Engine.IntensityPlayerMeleeStoneFabricBlunt * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeStoneFleshBluntRight: return Engine.IntensityPlayerMeleeStoneFleshBlunt * Engine.IntensityMultiplierMelee; break;

                case TactsuitVR.FeedbackType.PlayerMeleeLightsaberClashRight: return Engine.IntensityPlayerMeleeLightsaberClashRight * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeLightsaberSlashRight: return Engine.IntensityPlayerMeleeLightsaberSlashRight * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeLightsaberPierceRight: return Engine.IntensityPlayerMeleeLightsaberPierceRight * Engine.IntensityMultiplierMelee; break;
                case TactsuitVR.FeedbackType.PlayerMeleeLightsaberBluntRight: return Engine.IntensityPlayerMeleeLightsaberBluntRight * Engine.IntensityMultiplierMelee; break;

                case TactsuitVR.FeedbackType.PlayerSpellFireRight: return Engine.IntensityPlayerSpellFire * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellLightningRight: return Engine.IntensityPlayerSpellLightning * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellGravityRight: return Engine.IntensityPlayerSpellGravity * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellIceRight: return Engine.IntensityPlayerSpellIce * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellCrushRight: return Engine.IntensityPlayerSpellCrush * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellHealRight: return Engine.IntensityPlayerSpellHeal * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellImplosionRight: return Engine.IntensityPlayerSpellImplosion * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellInvisibilityRight: return Engine.IntensityPlayerSpellInvisibility * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellTeslaRight: return Engine.IntensityPlayerSpellTesla * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellUtilityRight: return Engine.IntensityPlayerSpellUtility * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellCorruptionRight: return Engine.IntensityPlayerSpellCorruption * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellTeleportRight: return Engine.IntensityPlayerSpellTeleport * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellRasenganRight: return Engine.IntensityPlayerSpellRasengan * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellNeedleRight: return Engine.IntensityPlayerSpellNeedle * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellDrainRight: return Engine.IntensityPlayerSpellDrain * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellForceFieldRight: return Engine.IntensityPlayerSpellForceField * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerSpellOtherRight: return Engine.IntensityPlayerSpellOther * Engine.IntensityMultiplierSpell; break;
                case TactsuitVR.FeedbackType.PlayerTelekinesisActiveRight: return Engine.IntensityPlayerTelekinesisActive * Engine.IntensityMultiplierTelekinesis; break;
                case TactsuitVR.FeedbackType.PlayerTelekinesisPullRight: return Engine.IntensityPlayerTelekinesisPull * Engine.IntensityMultiplierTelekinesis; break;
                case TactsuitVR.FeedbackType.PlayerTelekinesisRepelRight: return Engine.IntensityPlayerTelekinesisRepel * Engine.IntensityMultiplierTelekinesis; break;
                case TactsuitVR.FeedbackType.PlayerTelekinesisCatchRight: return Engine.IntensityPlayerTelekinesisCatch * Engine.IntensityMultiplierTelekinesis; break;
                case TactsuitVR.FeedbackType.DamageVestArrow: return Engine.IntensityDamageVestArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmArrow: return Engine.IntensityDamageArmArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadArrow: return Engine.IntensityDamageHeadArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageVestFireArrow: return Engine.IntensityDamageVestFireArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmFireArrow: return Engine.IntensityDamageArmFireArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadFireArrow: return Engine.IntensityDamageHeadFireArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageVestLightningArrow: return Engine.IntensityDamageVestLightningArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmLightningArrow: return Engine.IntensityDamageArmLightningArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadLightningArrow: return Engine.IntensityDamageHeadLightningArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageVestIceArrow: return Engine.IntensityDamageVestIceArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmIceArrow: return Engine.IntensityDamageArmIceArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadIceArrow: return Engine.IntensityDamageHeadIceArrow * Engine.IntensityMultiplierArrowDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadFire: return Engine.IntensityDamageHeadFire * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadLightning: return Engine.IntensityDamageHeadLightning * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadGravity: return Engine.IntensityDamageHeadGravity * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadIce: return Engine.IntensityDamageHeadIce * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadDrain: return Engine.IntensityDamageHeadDrain * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadEnergy: return Engine.IntensityDamageHeadEnergy * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmFire: return Engine.IntensityDamageArmFire * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmLightning: return Engine.IntensityDamageArmLightning * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmGravity: return Engine.IntensityDamageArmGravity * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmIce: return Engine.IntensityDamageArmIce * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmDrain: return Engine.IntensityDamageArmDrain * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmEnergy: return Engine.IntensityDamageArmEnergy * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageVestEnergy: return Engine.IntensityDamageVestEnergy * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageVestFire: return Engine.IntensityDamageVestFire * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageVestIce: return Engine.IntensityDamageVestIce * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageVestDrain: return Engine.IntensityDamageVestDrain * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageVestLightning: return Engine.IntensityDamageVestLightning * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageVestGravity: return Engine.IntensityDamageVestGravity * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageVestPierceBladeSmall: return Engine.IntensityDamageVestPierceBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeSmallLRD: return Engine.IntensityDamageVestSlashBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeSmallLRU: return Engine.IntensityDamageVestSlashBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeSmallRLD: return Engine.IntensityDamageVestSlashBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeSmallRLU: return Engine.IntensityDamageVestSlashBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntBladeSmall: return Engine.IntensityDamageVestBluntBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntWoodSmall: return Engine.IntensityDamageVestBluntWoodSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntMetalSmall: return Engine.IntensityDamageVestBluntMetalSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntStoneSmall: return Engine.IntensityDamageVestBluntStoneSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntFleshSmall: return Engine.IntensityDamageVestBluntFleshSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestPierceFireSmall: return Engine.IntensityDamageVestPierceFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireSmallLRD: return Engine.IntensityDamageVestSlashFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireSmallLRU: return Engine.IntensityDamageVestSlashFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireSmallRLD: return Engine.IntensityDamageVestSlashFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireSmallRLU: return Engine.IntensityDamageVestSlashFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntFireSmall: return Engine.IntensityDamageVestBluntFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestPierceLightningSmall: return Engine.IntensityDamageVestPierceLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningSmallLRD: return Engine.IntensityDamageVestSlashLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningSmallLRU: return Engine.IntensityDamageVestSlashLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningSmallRLD: return Engine.IntensityDamageVestSlashLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningSmallRLU: return Engine.IntensityDamageVestSlashLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntLightningSmall: return Engine.IntensityDamageVestBluntLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestPierceIceSmall: return Engine.IntensityDamageVestPierceIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceSmallLRD: return Engine.IntensityDamageVestSlashIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceSmallLRU: return Engine.IntensityDamageVestSlashIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceSmallRLD: return Engine.IntensityDamageVestSlashIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceSmallRLU: return Engine.IntensityDamageVestSlashIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntIceSmall: return Engine.IntensityDamageVestBluntIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestPierceBladeLarge: return Engine.IntensityDamageVestPierceBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeLargeLRD: return Engine.IntensityDamageVestSlashBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeLargeLRU: return Engine.IntensityDamageVestSlashBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeLargeRLD: return Engine.IntensityDamageVestSlashBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashBladeLargeRLU: return Engine.IntensityDamageVestSlashBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntBladeLarge: return Engine.IntensityDamageVestBluntBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntWoodLarge: return Engine.IntensityDamageVestBluntWoodLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntMetalLarge: return Engine.IntensityDamageVestBluntMetalLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntStoneLarge: return Engine.IntensityDamageVestBluntStoneLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntFleshLarge: return Engine.IntensityDamageVestBluntFleshLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestPierceFireLarge: return Engine.IntensityDamageVestPierceFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireLargeLRD: return Engine.IntensityDamageVestSlashFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireLargeLRU: return Engine.IntensityDamageVestSlashFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireLargeRLD: return Engine.IntensityDamageVestSlashFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashFireLargeRLU: return Engine.IntensityDamageVestSlashFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntFireLarge: return Engine.IntensityDamageVestBluntFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestPierceLightningLarge: return Engine.IntensityDamageVestPierceLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningLargeLRD: return Engine.IntensityDamageVestSlashLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningLargeLRU: return Engine.IntensityDamageVestSlashLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningLargeRLD: return Engine.IntensityDamageVestSlashLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightningLargeRLU: return Engine.IntensityDamageVestSlashLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntLightningLarge: return Engine.IntensityDamageVestBluntLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestPierceIceLarge: return Engine.IntensityDamageVestPierceIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceLargeLRD: return Engine.IntensityDamageVestSlashIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceLargeLRU: return Engine.IntensityDamageVestSlashIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceLargeRLD: return Engine.IntensityDamageVestSlashIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashIceLargeRLU: return Engine.IntensityDamageVestSlashIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntIceLarge: return Engine.IntensityDamageVestBluntIceLarge * Engine.IntensityMultiplierMeleeDamage; break;

                case TactsuitVR.FeedbackType.DamageVestBlaster: return Engine.IntensityDamageVestBlaster * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBlasterStun: return Engine.IntensityDamageVestBlasterStun * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBlaster: return Engine.IntensityDamageArmBlaster * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBlasterStun: return Engine.IntensityDamageArmBlasterStun * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBlaster: return Engine.IntensityDamageHeadBlaster * Engine.IntensityMultiplierSpellDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBlasterStun: return Engine.IntensityDamageHeadBlasterStun * Engine.IntensityMultiplierSpellDamage; break;

                case TactsuitVR.FeedbackType.DamageVestPierceLightsaber: return Engine.IntensityDamageVestPierceLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightsaberLRD: return Engine.IntensityDamageVestSlashLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightsaberRLD: return Engine.IntensityDamageVestSlashLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightsaberLRU: return Engine.IntensityDamageVestSlashLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestSlashLightsaberRLU: return Engine.IntensityDamageVestSlashLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageVestBluntLightsaber: return Engine.IntensityDamageVestBluntLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntLightsaber: return Engine.IntensityDamageRightArmBluntLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceLightsaber: return Engine.IntensityDamageRightArmPierceLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashLightsaber: return Engine.IntensityDamageRightArmSlashLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceLightsaber: return Engine.IntensityDamageHeadPierceLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashLightsaber: return Engine.IntensityDamageHeadSlashLightsaber * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntLightsaber: return Engine.IntensityDamageHeadBluntLightsaber * Engine.IntensityMultiplierMeleeDamage; break;

                case TactsuitVR.FeedbackType.DamageRightArmPierceBladeSmall: return Engine.IntensityDamageArmPierceBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashBladeSmall: return Engine.IntensityDamageArmSlashBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntBladeSmall: return Engine.IntensityDamageArmBluntBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntWoodSmall: return Engine.IntensityDamageArmBluntWoodSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntMetalSmall: return Engine.IntensityDamageArmBluntMetalSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntStoneSmall: return Engine.IntensityDamageArmBluntStoneSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntFleshSmall: return Engine.IntensityDamageArmBluntFleshSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceFireSmall: return Engine.IntensityDamageArmPierceFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashFireSmall: return Engine.IntensityDamageArmSlashFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntFireSmall: return Engine.IntensityDamageArmBluntFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceLightningSmall: return Engine.IntensityDamageArmPierceLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashLightningSmall: return Engine.IntensityDamageArmSlashLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntLightningSmall: return Engine.IntensityDamageArmBluntLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceIceSmall: return Engine.IntensityDamageArmPierceIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashIceSmall: return Engine.IntensityDamageArmSlashIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntIceSmall: return Engine.IntensityDamageArmBluntIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceBladeLarge: return Engine.IntensityDamageArmPierceBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashBladeLarge: return Engine.IntensityDamageArmSlashBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntBladeLarge: return Engine.IntensityDamageArmBluntBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntWoodLarge: return Engine.IntensityDamageArmBluntWoodLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntMetalLarge: return Engine.IntensityDamageArmBluntMetalLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntStoneLarge: return Engine.IntensityDamageArmBluntStoneLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntFleshLarge: return Engine.IntensityDamageArmBluntFleshLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceFireLarge: return Engine.IntensityDamageArmPierceFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashFireLarge: return Engine.IntensityDamageArmSlashFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntFireLarge: return Engine.IntensityDamageArmBluntFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceLightningLarge: return Engine.IntensityDamageArmPierceLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashLightningLarge: return Engine.IntensityDamageArmSlashLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntLightningLarge: return Engine.IntensityDamageArmBluntLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmPierceIceLarge: return Engine.IntensityDamageArmPierceIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmSlashIceLarge: return Engine.IntensityDamageArmSlashIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageRightArmBluntIceLarge: return Engine.IntensityDamageArmBluntIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceBladeSmall: return Engine.IntensityDamageHeadPierceBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashBladeSmall: return Engine.IntensityDamageHeadSlashBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntBladeSmall: return Engine.IntensityDamageHeadBluntBladeSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntWoodSmall: return Engine.IntensityDamageHeadBluntWoodSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntMetalSmall: return Engine.IntensityDamageHeadBluntMetalSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntStoneSmall: return Engine.IntensityDamageHeadBluntStoneSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntFleshSmall: return Engine.IntensityDamageHeadBluntFleshSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceFireSmall: return Engine.IntensityDamageHeadPierceFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashFireSmall: return Engine.IntensityDamageHeadSlashFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntFireSmall: return Engine.IntensityDamageHeadBluntFireSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceLightningSmall: return Engine.IntensityDamageHeadPierceLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashLightningSmall: return Engine.IntensityDamageHeadSlashLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntLightningSmall: return Engine.IntensityDamageHeadBluntLightningSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceIceSmall: return Engine.IntensityDamageHeadPierceIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashIceSmall: return Engine.IntensityDamageHeadSlashIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntIceSmall: return Engine.IntensityDamageHeadBluntIceSmall * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceBladeLarge: return Engine.IntensityDamageHeadPierceBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashBladeLarge: return Engine.IntensityDamageHeadSlashBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntBladeLarge: return Engine.IntensityDamageHeadBluntBladeLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntWoodLarge: return Engine.IntensityDamageHeadBluntWoodLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntMetalLarge: return Engine.IntensityDamageHeadBluntMetalLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntStoneLarge: return Engine.IntensityDamageHeadBluntStoneLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntFleshLarge: return Engine.IntensityDamageHeadBluntFleshLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceFireLarge: return Engine.IntensityDamageHeadPierceFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashFireLarge: return Engine.IntensityDamageHeadSlashFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntFireLarge: return Engine.IntensityDamageHeadBluntFireLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceLightningLarge: return Engine.IntensityDamageHeadPierceLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashLightningLarge: return Engine.IntensityDamageHeadSlashLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntLightningLarge: return Engine.IntensityDamageHeadBluntLightningLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadPierceIceLarge: return Engine.IntensityDamageHeadPierceIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadSlashIceLarge: return Engine.IntensityDamageHeadSlashIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.DamageHeadBluntIceLarge: return Engine.IntensityDamageHeadBluntIceLarge * Engine.IntensityMultiplierMeleeDamage; break;
                case TactsuitVR.FeedbackType.HeartBeat: return Engine.IntensityHeartBeat * Engine.IntensityMultiplierHeartbeat; break;
                case TactsuitVR.FeedbackType.HeartBeatFast: return Engine.IntensityHeartBeatFast * Engine.IntensityMultiplierHeartbeat; break;
                case TactsuitVR.FeedbackType.Healing: return Engine.IntensityHealing; break;
                case TactsuitVR.FeedbackType.PotionDrinking: return Engine.IntensityPotionDrinking * Engine.IntensityMultiplierConsuming; break;
                case TactsuitVR.FeedbackType.PoisonDrinking: return Engine.IntensityPoisonDrinking * Engine.IntensityMultiplierConsuming; break;
                case TactsuitVR.FeedbackType.FallDamage: return Engine.IntensityFallDamage * Engine.IntensityMultiplierFall; break;
                case TactsuitVR.FeedbackType.FallDamageFeet: return Engine.IntensityFallDamageFeet * Engine.IntensityMultiplierFall; break;
                case TactsuitVR.FeedbackType.SlowMotion: return Engine.IntensitySlowMotion * Engine.IntensityMultiplierSlowMotion; break;
                case TactsuitVR.FeedbackType.HolsterLeftShoulder: return Engine.IntensityHolster * Engine.IntensityMultiplierHolster; break;
                case TactsuitVR.FeedbackType.HolsterRightShoulder: return Engine.IntensityHolster * Engine.IntensityMultiplierHolster; break;
                case TactsuitVR.FeedbackType.UnholsterLeftShoulder: return Engine.IntensityUnholster * Engine.IntensityMultiplierHolster; break;
                case TactsuitVR.FeedbackType.UnholsterRightShoulder: return Engine.IntensityUnholster * Engine.IntensityMultiplierHolster; break;
                case TactsuitVR.FeedbackType.HolsterArrowLeftShoulder: return Engine.IntensityHolsterArrow * Engine.IntensityMultiplierHolster; break;
                case TactsuitVR.FeedbackType.HolsterArrowRightShoulder: return Engine.IntensityHolsterArrow * Engine.IntensityMultiplierHolster; break;
                case TactsuitVR.FeedbackType.UnholsterArrowLeftShoulder: return Engine.IntensityUnholsterArrow * Engine.IntensityMultiplierHolster; break;
                case TactsuitVR.FeedbackType.UnholsterArrowRightShoulder: return Engine.IntensityUnholsterArrow * Engine.IntensityMultiplierHolster; break;
                case TactsuitVR.FeedbackType.ClimbingRight: return Engine.IntensityClimbing * Engine.IntensityMultiplierClimbing; break;
                case TactsuitVR.FeedbackType.PlayerKickOtherRight: return Engine.IntensityPlayerKickOther; break;
                case TactsuitVR.FeedbackType.PlayerKickWoodRight: return Engine.IntensityPlayerKickWood; break;
                case TactsuitVR.FeedbackType.PlayerKickFleshRight: return Engine.IntensityPlayerKickFlesh; break;
                case TactsuitVR.FeedbackType.PlayerKickStoneRight: return Engine.IntensityPlayerKickStone; break;
                case TactsuitVR.FeedbackType.PlayerKickMetalRight: return Engine.IntensityPlayerKickMetal; break;
                case TactsuitVR.FeedbackType.PlayerKickFabricRight: return Engine.IntensityPlayerKickFabric; break;
                case TactsuitVR.FeedbackType.PlayerPunchOtherRight: return Engine.IntensityPlayerPunchOther; break;
                case TactsuitVR.FeedbackType.PlayerPunchWoodRight: return Engine.IntensityPlayerPunchWood; break;
                case TactsuitVR.FeedbackType.PlayerPunchFleshRight: return Engine.IntensityPlayerPunchFlesh; break;
                case TactsuitVR.FeedbackType.PlayerPunchStoneRight: return Engine.IntensityPlayerPunchStone; break;
                case TactsuitVR.FeedbackType.PlayerPunchMetalRight: return Engine.IntensityPlayerPunchMetal; break;
                case TactsuitVR.FeedbackType.PlayerPunchFabricRight: return Engine.IntensityPlayerPunchFabric; break;

                case TactsuitVR.FeedbackType.PlayerGunRight: return Engine.IntensityPlayerGun * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunBlasterRight: return Engine.IntensityPlayerGunBlaster * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunAutomaticRight: return Engine.IntensityPlayerGunAutomatic * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunBallisticRight: return Engine.IntensityPlayerGunBallistic * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunSprayRight: return Engine.IntensityPlayerGunSpray * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunMiniGunRight: return Engine.IntensityPlayerGunMiniGun * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunBazookaRight: return Engine.IntensityPlayerGunBazooka * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunHeavyRight: return Engine.IntensityPlayerGunHeavy * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunLaserRight: return Engine.IntensityPlayerGunLaser * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunRifleRight: return Engine.IntensityPlayerGunRifle * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunPistolRight: return Engine.IntensityPlayerGunPistol * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunPlasmaRight: return Engine.IntensityPlayerGunPlasma * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunShotgunRight: return Engine.IntensityPlayerGunShotgun * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerGunEnergyRight: return Engine.IntensityPlayerGunEnergy * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunRight: return Engine.IntensityKickbackPlayerGun * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunPistolRight: return Engine.IntensityKickbackPlayerGunPistol * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunBallisticRight: return Engine.IntensityKickbackPlayerGunBallistic * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunLaserRight: return Engine.IntensityKickbackPlayerGunLaser * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunPlasmaRight: return Engine.IntensityKickbackPlayerGunPlasma * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunSprayRight: return Engine.IntensityKickbackPlayerGunSpray * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunHeavyRight: return Engine.IntensityKickbackPlayerGunHeavy * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunLeft: return Engine.IntensityKickbackPlayerGun * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunPistolLeft: return Engine.IntensityKickbackPlayerGunPistol * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunBallisticLeft: return Engine.IntensityKickbackPlayerGunBallistic * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunLaserLeft: return Engine.IntensityKickbackPlayerGunLaser * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunPlasmaLeft: return Engine.IntensityKickbackPlayerGunPlasma * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunSprayLeft: return Engine.IntensityKickbackPlayerGunSpray * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.KickbackPlayerGunHeavyLeft: return Engine.IntensityKickbackPlayerGunHeavy * Engine.IntensityMultiplierGun; break;
                case TactsuitVR.FeedbackType.PlayerThrowRight: return Engine.IntensityPlayerThrow; break;
                case TactsuitVR.FeedbackType.Explosion: return Engine.IntensityExplosion; break;
                case TactsuitVR.FeedbackType.LeftShoulderTurret: return Engine.IntensityShoulderTurret; break;
                case TactsuitVR.FeedbackType.HoverJetFeet: return Engine.IntensityHoverJetFeet; break;

				case TactsuitVR.FeedbackType.EquipCuirass: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.EquipGauntletsLeft: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.EquipGauntletsRight: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.EquipHelmet: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.UnequipCuirass: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.UnequipGauntletsLeft: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.UnequipGauntletsRight: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.UnequipHelmet: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.EquipFeet: return Engine.IntensityEquipUnequip; break;
                case TactsuitVR.FeedbackType.UnequipFeet: return Engine.IntensityEquipUnequip; break;

                case TactsuitVR.FeedbackType.ConsumableFood: return Engine.IntensityConsumableFood * Engine.IntensityMultiplierConsuming; break;
            }

            return Engine.IntensityDefaultDamage;
        }

        public void ProvideDotFeedback(PositionType position, int index, int intensity, int durationMillis)
        {
            if (intensity < 0.001f)
                return;

            if (!systemInitialized || Bhaptics.Tact.HapticPlayerManager.Instance() == null || Bhaptics.Tact.HapticPlayerManager.Instance().Connected == false)
                CreateSystem();
            
            List<DotPoint> points = new List<DotPoint>() { new DotPoint(index, intensity) };

            Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().Submit("", position, points, durationMillis);
        }

        public void ProvideHapticFeedbackThread(float locationAngle, float locationHeight, FeedbackType effect, float intensityMultiplier, bool waitToPlay, bool reflected, float duration = 1.0f)
        {
            if (intensityMultiplier < 0.001f)
                return;
            
            if (!systemInitialized || Bhaptics.Tact.HapticPlayerManager.Instance()==null || Bhaptics.Tact.HapticPlayerManager.Instance().Connected == false)
                CreateSystem();

            if (Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer() != null)
            {
                if (feedbackMap.ContainsKey(effect))
                {
                    if (feedbackMap[effect].feedbackFileCount > 0)
                    {
                        if (waitToPlay)
                        {
                            if (IsPlayingKeyAll(reflected, feedbackMap[effect].prefix, feedbackMap[effect].feedbackFileCount))
                            {
                                return;
                            }
                        }
                        
                        if (feedbackMap[effect].posType == PositionType.Head && !HeadActive)
                        {
                            return;
                        }
                        else if ((feedbackMap[effect].posType == PositionType.FootR || feedbackMap[effect].posType == PositionType.FootL) && !FeetActive)
                        {
                            return;
                        }
                        else if ((feedbackMap[effect].posType == PositionType.ForearmR || feedbackMap[effect].posType == PositionType.ForearmL) && !ArmsActive)
                        {
                            return;
                        }

                        string key = (reflected ? "Reflected_" : "") + feedbackMap[effect].prefix + (RandomNumber.Between(1, feedbackMap[effect].feedbackFileCount)).ToString();

                        if (locationHeight < -0.485f)
                            locationHeight = -0.485f;
                        else if (locationHeight > 0.485f)
                            locationHeight = 0.485f;

                        Bhaptics.Tact.RotationOption RotOption = new RotationOption(locationAngle, locationHeight);

                        Bhaptics.Tact.ScaleOption scaleOption = new ScaleOption(intensityMultiplier, duration);

                        //hapticPlayer.SubmitRegistered(key, scaleOption);
                        Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().SubmitRegisteredVestRotation(key, key, RotOption, scaleOption);
                        LOG("===> Submitted Feedback: " + key + " Intensity: " + intensityMultiplier + " Height: " + locationHeight + " Angle: " + locationAngle);
                    }
                }
            }
        }
        
        public void ProvideHapticFeedback(float locationAngle, float locationHeight, FeedbackType effect, bool waitToPlay, float intensity, FeedbackType secondEffect, bool reflected, float duration = 1.0f)
        {
            if (effect != FeedbackType.NoFeedback)
            {
                float intensityMultiplier = GetIntensityMultiplier(effect)*intensity;
                if (intensityMultiplier > 0.01f)
                {
                    //ThreadPool.QueueUserWorkItem(state => ProvideHapticFeedbackThread(locationAngle, locationHeight, effect, intensityMultiplier, waitToPlay, reflected, duration));
                    //if (secondEffect != FeedbackType.NoFeedback)
                    //{
                    //    ThreadPool.QueueUserWorkItem(state => ProvideHapticFeedbackThread(locationAngle, locationHeight, secondEffect, intensityMultiplier, waitToPlay, reflected, duration));
                    //}
                    Thread thread = new Thread(() => ProvideHapticFeedbackThread(locationAngle, locationHeight, effect, intensityMultiplier, waitToPlay, reflected, duration));
                    thread.Start();
                    if (secondEffect != FeedbackType.NoFeedback)
                    {
                        Thread thread2 = new Thread(() => ProvideHapticFeedbackThread(locationAngle, locationHeight, secondEffect, intensityMultiplier, waitToPlay, reflected, duration));
                        thread2.Start();
                    }
                }
            }
        }

        public void StopHapticFeedback(FeedbackType effect)
        {
            if (Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer() != null)
            {
                if (feedbackMap.ContainsKey(effect))
                {
                    if (feedbackMap[effect].feedbackFileCount > 0)
                    {
                        for (int i = 1; i <= feedbackMap[effect].feedbackFileCount; i++)
                        {
                            string key = feedbackMap[effect].prefix + i.ToString();
                            Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().TurnOff(key);
                        }
                    }
                }
            }
        }

        public static FeedbackType GetPlayerGunShootFeedback(string itemName, string displayName, bool stun)
        {
            string lower = itemName.ToLowerInvariant() + " " + displayName.ToLowerInvariant();

            if(lower.Contains("blaster") || lower.Contains("starwars") || lower.Contains("peace") || lower.Contains("keeper"))
                return stun ? FeedbackType.PlayerGunPlasmaRight : FeedbackType.PlayerGunBlasterRight;
            else if (lower.Contains("spray") || lower.Contains("flame"))
                return FeedbackType.PlayerGunSprayRight;
            else if (lower.Contains("bazooka") || lower.Contains("launcher") || lower.Contains("mortar"))
                return FeedbackType.PlayerGunBazookaRight;
            else if (lower.Contains("heavy") || lower.Contains("lmg"))
                return FeedbackType.PlayerGunHeavyRight;
            else if (lower.Contains("laser") || lower.Contains("beam") || lower.Contains("bond"))
                return FeedbackType.PlayerGunLaserRight;
            else if (lower.Contains("rifle") || lower.Contains("assault") || lower.Contains("m4") || lower.Contains("47") || lower.Contains("m16") || lower.Contains("tony") || lower.Contains("friend") || lower.Contains("enfield") || lower.Contains("carbine"))
                return FeedbackType.PlayerGunRifleRight;
            else if (lower.Contains("minigun") || lower.Contains("usurper"))
                return FeedbackType.PlayerGunMiniGunRight;
            else if (lower.Contains("plasma") || lower.Contains("arrow"))
                return FeedbackType.PlayerGunPlasmaRight;
            else if (lower.Contains("shotgun"))
                return FeedbackType.PlayerGunShotgunRight;
            else if (lower.Contains("revolver") || lower.Contains("beretta") || lower.Contains("pistol") || lower.Contains("kitchen") || lower.Contains("glock") || lower.Contains("hamada") || lower.Contains("luger") || lower.Contains("mustang") || lower.Contains("m1911"))
                return FeedbackType.PlayerGunPistolRight;
            else if (lower.Contains("auto") || lower.Contains("sentinel") || lower.Contains("smg") || lower.Contains("modular") || lower.Contains("mp5") || lower.Contains("ump") || lower.Contains("alternator") || lower.Contains("machine") ||lower.Contains("s2200"))
                return FeedbackType.PlayerGunAutomaticRight;
            else if (lower.Contains("ball") || lower.Contains("grapple") || lower.Contains("flint"))
                return FeedbackType.PlayerGunBallisticRight;
            else if (lower.Contains("sibyl") || lower.Contains("energy"))
                return FeedbackType.PlayerGunEnergyRight;
            else
                return FeedbackType.PlayerGunRight;
        }

        public static FeedbackType GetPlayerGunShootFeedbackKickback(FeedbackType feedback, Side side)
        {
            switch (feedback)
            {
                case TactsuitVR.FeedbackType.PlayerGunRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunLeft : FeedbackType.KickbackPlayerGunRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunBlasterRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunPlasmaLeft : FeedbackType.KickbackPlayerGunPlasmaRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunAutomaticRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunHeavyLeft : FeedbackType.KickbackPlayerGunHeavyRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunBallisticRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunBallisticLeft : FeedbackType.KickbackPlayerGunBallisticRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunSprayRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunSprayLeft : FeedbackType.KickbackPlayerGunSprayRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunMiniGunRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunHeavyLeft : FeedbackType.KickbackPlayerGunHeavyRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunBazookaRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunHeavyLeft : FeedbackType.KickbackPlayerGunHeavyRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunHeavyRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunHeavyLeft : FeedbackType.KickbackPlayerGunHeavyRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunLaserRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunLaserLeft : FeedbackType.KickbackPlayerGunLaserRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunRifleRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunBallisticLeft : FeedbackType.KickbackPlayerGunBallisticRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunPistolRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunPistolLeft : FeedbackType.KickbackPlayerGunPistolRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunPlasmaRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunPlasmaLeft : FeedbackType.KickbackPlayerGunPlasmaRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunShotgunRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunLeft : FeedbackType.KickbackPlayerGunRight);
                    break;
                case TactsuitVR.FeedbackType.PlayerGunEnergyRight:
                    return (side == Side.Left ? FeedbackType.KickbackPlayerGunLaserLeft : FeedbackType.KickbackPlayerGunLaserRight);
                    break;
                default:
                    return FeedbackType.NoFeedback;
            }
        }

        public void PauseHapticFeedBack(FeedbackType effect)
        {
            for (int i = 1; i <= feedbackMap[effect].feedbackFileCount; i++)
            {
                Bhaptics.Tact.HapticPlayerManager.Instance().GetHapticPlayer().TurnOff(feedbackMap[effect].prefix + i.ToString());
            }
        }
    }
}
