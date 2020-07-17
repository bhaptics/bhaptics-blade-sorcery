using System.Globalization;
using UnityEngine;
using ThunderRoad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Bhaptics.Tact;
using CustomWebSocketSharp;
using Newtonsoft.Json.Linq;
using TLGFPowerBooks;

namespace TactsuitBS
{
    public class Engine : LevelModule
    {
        //Public parameters

        #region Public Parameters

        public bool Logging = true;

        public bool GravityEffectOnArms = false;
        public bool GravityEffectOnHead = false;
        public bool PlayFallbackEffectsForArmHead = true;
        public bool NoFallEffectWhenFallDamageIsDisabled = false;
        

        //Sleep Durations
        public int SleepDurationHeartBeat = 900;
        public int SleepDurationHeartBeatFast = 500;
        public int SleepDurationSpellCast = 500;
        public int SleepDurationBowString = 500;
        public int SleepDurationShootGun = 200;
        public int SleepDurationClimb = 500;
        public int SleepDurationSlowMotion = 1500;
        public int SleepDurationSpellHit = 300;

        //public float StuckArrowIntensityMultiplier = 0.4f;
        //public float StuckArrowDurationMultiplier = 4.0f;
        //public int StuckArrowSleepDuration = 3000;

        public float FallEffectMinVelocityMagnitude = 10.0f;

        public float IntensityDefaultDamage = 1.0f;
        public float IntensityPlayerBowPull = 1.0f;
        public float IntensityPlayerMeleeBladeWoodPierce = 1.0f;
        public float IntensityPlayerMeleeBladeMetalPierce = 1.0f;
        public float IntensityPlayerMeleeBladeStonePierce = 1.0f;
        public float IntensityPlayerMeleeBladeFabricPierce = 1.0f;
        public float IntensityPlayerMeleeBladeFleshPierce = 1.0f;
        public float IntensityPlayerMeleeBladeWoodSlash = 1.0f;
        public float IntensityPlayerMeleeBladeMetalSlash = 1.0f;
        public float IntensityPlayerMeleeBladeStoneSlash = 1.0f;
        public float IntensityPlayerMeleeBladeFabricSlash = 1.0f;
        public float IntensityPlayerMeleeBladeFleshSlash = 1.0f;
        public float IntensityPlayerMeleeBladeWoodBlunt = 1.0f;
        public float IntensityPlayerMeleeBladeMetalBlunt = 1.0f;
        public float IntensityPlayerMeleeBladeStoneBlunt = 1.0f;
        public float IntensityPlayerMeleeBladeFabricBlunt = 1.0f;
        public float IntensityPlayerMeleeBladeFleshBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodWoodBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodMetalBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodStoneBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodFabricBlunt = 1.0f;
        public float IntensityPlayerMeleeWoodFleshBlunt = 1.0f;
        public float IntensityPlayerMeleeStoneStoneBlunt = 1.0f;
        public float IntensityPlayerMeleeStoneFabricBlunt = 1.0f;
        public float IntensityPlayerMeleeStoneFleshBlunt = 1.0f;

        public float IntensityPlayerSpellFire = 1.0f;
        public float IntensityPlayerSpellLightning = 1.0f;
        public float IntensityPlayerSpellGravity = 1.0f;
        public float IntensityPlayerSpellIce = 1.0f;
        public float IntensityPlayerSpellCrush = 1.0f;
        public float IntensityPlayerSpellHeal = 1.0f;
        public float IntensityPlayerSpellImplosion = 1.0f;
        public float IntensityPlayerSpellInvisibility = 1.0f;
        public float IntensityPlayerSpellTesla = 1.0f;
        public float IntensityPlayerSpellUtility = 1.0f;
        public float IntensityPlayerSpellCorruption = 1.0f;
        public float IntensityPlayerSpellTeleport = 1.0f;
        public float IntensityPlayerSpellRasengan = 1.0f;
        public float IntensityPlayerSpellNeedle = 1.0f;
        public float IntensityPlayerSpellDrain = 1.0f;
        public float IntensityPlayerSpellForceField = 1.0f;
        public float IntensityPlayerSpellOther = 1.0f;

        public float IntensityPlayerTelekinesisActive = 1.0f;
        public float IntensityPlayerTelekinesisPull = 0.3f;
        public float IntensityPlayerTelekinesisRepel = 0.3f;
        public float IntensityPlayerTelekinesisCatch = 2.0f;

        public float IntensityDamageVestArrow = 1.0f;
        public float IntensityDamageArmArrow = 1.0f;
        public float IntensityDamageHeadArrow = 1.0f;
        public float IntensityDamageVestFireArrow = 1.0f;
        public float IntensityDamageArmFireArrow = 1.0f;
        public float IntensityDamageHeadFireArrow = 1.0f;
        public float IntensityDamageVestLightningArrow = 1.0f;
        public float IntensityDamageArmLightningArrow = 1.0f;
        public float IntensityDamageHeadLightningArrow = 1.0f;
        public float IntensityDamageVestIceArrow = 1.0f;
        public float IntensityDamageArmIceArrow = 1.0f;
        public float IntensityDamageHeadIceArrow = 1.0f;
        public float IntensityDamageHeadFire = 1.0f;
        public float IntensityDamageHeadLightning = 1.0f;
        public float IntensityDamageHeadGravity = 1.0f;
        public float IntensityDamageHeadIce = 1.0f;
        public float IntensityDamageHeadDrain = 1.0f;
        public float IntensityDamageHeadEnergy = 1.0f;
        public float IntensityDamageArmFire = 1.0f;
        public float IntensityDamageArmLightning = 1.0f;
        public float IntensityDamageArmGravity = 1.0f;
        public float IntensityDamageArmIce = 1.0f;
        public float IntensityDamageArmDrain = 1.0f;
        public float IntensityDamageArmEnergy = 1.0f;

        public float IntensityDamageVestEnergy = 1.0f;
        public float IntensityDamageVestFire = 1.0f;
        public float IntensityDamageVestLightning = 1.0f;
        public float IntensityDamageVestGravity = 1.0f;
        public float IntensityDamageVestIce = 1.0f;
        public float IntensityDamageVestDrain = 1.0f;

        public float IntensityDamageVestPierceBladeSmall = 1.0f;
        public float IntensityDamageVestSlashBladeSmall = 1.0f;
        public float IntensityDamageVestBluntBladeSmall = 1.0f;
        public float IntensityDamageVestBluntWoodSmall = 1.0f;
        public float IntensityDamageVestBluntMetalSmall = 1.0f;
        public float IntensityDamageVestBluntStoneSmall = 1.0f;
        public float IntensityDamageVestBluntFleshSmall = 1.0f;
        public float IntensityDamageVestPierceFireSmall = 1.0f;
        public float IntensityDamageVestSlashFireSmall = 1.0f;
        public float IntensityDamageVestBluntFireSmall = 1.0f;
        public float IntensityDamageVestPierceLightningSmall = 1.0f;
        public float IntensityDamageVestSlashLightningSmall = 1.0f;
        public float IntensityDamageVestBluntLightningSmall = 1.0f;
        public float IntensityDamageVestPierceIceSmall = 1.0f;
        public float IntensityDamageVestSlashIceSmall = 1.0f;
        public float IntensityDamageVestBluntIceSmall = 1.0f;
        public float IntensityDamageVestPierceBladeLarge = 1.0f;
        public float IntensityDamageVestSlashBladeLarge = 1.0f;
        public float IntensityDamageVestBluntBladeLarge = 1.0f;
        public float IntensityDamageVestBluntWoodLarge = 1.0f;
        public float IntensityDamageVestBluntMetalLarge = 1.0f;
        public float IntensityDamageVestBluntStoneLarge = 1.0f;
        public float IntensityDamageVestBluntFleshLarge = 1.0f;
        public float IntensityDamageVestPierceFireLarge = 1.0f;
        public float IntensityDamageVestSlashFireLarge = 1.0f;
        public float IntensityDamageVestBluntFireLarge = 1.0f;
        public float IntensityDamageVestPierceLightningLarge = 1.0f;
        public float IntensityDamageVestSlashLightningLarge = 1.0f;
        public float IntensityDamageVestBluntLightningLarge = 1.0f;
        public float IntensityDamageVestPierceIceLarge = 1.0f;
        public float IntensityDamageVestSlashIceLarge = 1.0f;
        public float IntensityDamageVestBluntIceLarge = 1.0f;
        public float IntensityDamageArmPierceBladeSmall = 1.0f;
        public float IntensityDamageArmSlashBladeSmall = 1.0f;
        public float IntensityDamageArmBluntBladeSmall = 1.0f;
        public float IntensityDamageArmBluntWoodSmall = 1.0f;
        public float IntensityDamageArmBluntMetalSmall = 1.0f;
        public float IntensityDamageArmBluntStoneSmall = 1.0f;
        public float IntensityDamageArmBluntFleshSmall = 1.0f;
        public float IntensityDamageArmPierceFireSmall = 1.0f;
        public float IntensityDamageArmSlashFireSmall = 1.0f;
        public float IntensityDamageArmBluntFireSmall = 1.0f;
        public float IntensityDamageArmPierceLightningSmall = 1.0f;
        public float IntensityDamageArmSlashLightningSmall = 1.0f;
        public float IntensityDamageArmBluntLightningSmall = 1.0f;
        public float IntensityDamageArmPierceIceSmall = 1.0f;
        public float IntensityDamageArmSlashIceSmall = 1.0f;
        public float IntensityDamageArmBluntIceSmall = 1.0f;
        public float IntensityDamageArmPierceBladeLarge = 1.0f;
        public float IntensityDamageArmSlashBladeLarge = 1.0f;
        public float IntensityDamageArmBluntBladeLarge = 1.0f;
        public float IntensityDamageArmBluntWoodLarge = 1.0f;
        public float IntensityDamageArmBluntMetalLarge = 1.0f;
        public float IntensityDamageArmBluntStoneLarge = 1.0f;
        public float IntensityDamageArmBluntFleshLarge = 1.0f;
        public float IntensityDamageArmPierceFireLarge = 1.0f;
        public float IntensityDamageArmSlashFireLarge = 1.0f;
        public float IntensityDamageArmBluntFireLarge = 1.0f;
        public float IntensityDamageArmPierceLightningLarge = 1.0f;
        public float IntensityDamageArmSlashLightningLarge = 1.0f;
        public float IntensityDamageArmBluntLightningLarge = 1.0f;
        public float IntensityDamageArmPierceIceLarge = 1.0f;
        public float IntensityDamageArmSlashIceLarge = 1.0f;
        public float IntensityDamageArmBluntIceLarge = 1.0f;
        public float IntensityDamageHeadPierceBladeSmall = 1.0f;
        public float IntensityDamageHeadSlashBladeSmall = 1.0f;
        public float IntensityDamageHeadBluntBladeSmall = 1.0f;
        public float IntensityDamageHeadBluntWoodSmall = 1.0f;
        public float IntensityDamageHeadBluntMetalSmall = 1.0f;
        public float IntensityDamageHeadBluntStoneSmall = 1.0f;
        public float IntensityDamageHeadBluntFleshSmall = 1.0f;
        public float IntensityDamageHeadPierceFireSmall = 1.0f;
        public float IntensityDamageHeadSlashFireSmall = 1.0f;
        public float IntensityDamageHeadBluntFireSmall = 1.0f;
        public float IntensityDamageHeadPierceLightningSmall = 1.0f;
        public float IntensityDamageHeadSlashLightningSmall = 1.0f;
        public float IntensityDamageHeadBluntLightningSmall = 1.0f;
        public float IntensityDamageHeadPierceIceSmall = 1.0f;
        public float IntensityDamageHeadSlashIceSmall = 1.0f;
        public float IntensityDamageHeadBluntIceSmall = 1.0f;
        public float IntensityDamageHeadPierceBladeLarge = 1.0f;
        public float IntensityDamageHeadSlashBladeLarge = 1.0f;
        public float IntensityDamageHeadBluntBladeLarge = 1.0f;
        public float IntensityDamageHeadBluntWoodLarge = 1.0f;
        public float IntensityDamageHeadBluntMetalLarge = 1.0f;
        public float IntensityDamageHeadBluntStoneLarge = 1.0f;
        public float IntensityDamageHeadBluntFleshLarge = 1.0f;
        public float IntensityDamageHeadPierceFireLarge = 1.0f;
        public float IntensityDamageHeadSlashFireLarge = 1.0f;
        public float IntensityDamageHeadBluntFireLarge = 1.0f;
        public float IntensityDamageHeadPierceLightningLarge = 1.0f;
        public float IntensityDamageHeadSlashLightningLarge = 1.0f;
        public float IntensityDamageHeadBluntLightningLarge = 1.0f;
        public float IntensityDamageHeadPierceIceLarge = 1.0f;
        public float IntensityDamageHeadSlashIceLarge = 1.0f;
        public float IntensityDamageHeadBluntIceLarge = 1.0f;

        public float IntensityHeartBeat = 0.5f;
        public float IntensityHeartBeatFast = 0.5f;
        public float IntensityHealing = 1.5f;
        public float IntensityPotionDrinking = 1.5f;
        public float IntensityPoisonDrinking = 1.5f;
        public float IntensityFallDamage = 1.5f;
        public float IntensityFallDamageFeet = 1.0f;
        public float IntensitySlowMotion = 1.0f;
        public float IntensityHolster = 1.0f;
        public float IntensityUnholster = 1.0f;
        public float IntensityHolsterArrow = 1.0f;
        public float IntensityUnholsterArrow = 1.0f;
        public float IntensityClimbing = 1.0f;
        public float IntensityPlayerKickOther = 1.0f;
        public float IntensityPlayerKickWood = 1.0f;
        public float IntensityPlayerKickFlesh = 1.0f;
        public float IntensityPlayerKickStone = 1.0f;
        public float IntensityPlayerKickMetal = 1.0f;
        public float IntensityPlayerKickFabric = 1.0f;
        public float IntensityPlayerPunchOther = 1.0f;
        public float IntensityPlayerPunchWood = 1.0f;
        public float IntensityPlayerPunchFlesh = 1.0f;
        public float IntensityPlayerPunchStone = 1.0f;
        public float IntensityPlayerPunchMetal = 1.0f;
        public float IntensityPlayerPunchFabric = 1.0f;

        public float IntensityPlayerGun = 1.0f;
        public float IntensityPlayerGunBlaster = 1.0f;
        public float IntensityPlayerGunAutomatic = 1.0f;
        public float IntensityPlayerGunBallistic = 1.0f;
        public float IntensityPlayerGunSpray = 1.0f;
        public float IntensityPlayerGunMiniGun = 1.0f;
        public float IntensityPlayerGunBazooka = 1.0f;
        public float IntensityPlayerGunHeavy = 1.0f;
        public float IntensityPlayerGunLaser = 1.0f;
        public float IntensityPlayerGunRifle = 1.0f;
        public float IntensityPlayerGunPistol = 1.0f;
        public float IntensityPlayerGunPlasma = 1.0f;
        public float IntensityPlayerGunShotgun = 1.0f;
        public float IntensityPlayerGunEnergy = 1.0f;
        public float IntensityKickbackPlayerGun = 1.0f;
        public float IntensityKickbackPlayerGunPistol = 1.0f;
        public float IntensityKickbackPlayerGunBallistic = 1.0f;
        public float IntensityKickbackPlayerGunLaser = 1.0f;
        public float IntensityKickbackPlayerGunPlasma = 1.0f;
        public float IntensityKickbackPlayerGunSpray = 1.0f;
        public float IntensityKickbackPlayerGunHeavy = 1.0f;

        public float IntensityPlayerThrow = 1.0f;

        public float IntensityExplosion = 1.0f;

        public float IntensityShoulderTurret = 1.0f;
        public float IntensityHoverJetFeet = 1.0f;

        #endregion

        //Private parameters

        #region Private Parameters

        private bool eventsCreated = false;

        //private bool playerEventsCreated = false;
        private TactsuitVR tactsuitVr;
        private bool Heartbeating = false;
        private bool HeartbeatingFast = false;
        private bool gamePaused = false;
        private bool CastingLeft = false;
        private bool CastingRight = false;
        private string CastingLeftSpellId = "";
        private string CastingRightSpellId = "";

        private bool TelekinesisPullLeft = false;
        private bool TelekinesisPullRight = false;
        private bool TelekinesisRepelLeft = false;
        private bool TelekinesisRepelRight = false;
        private bool TelekinesisActiveLeft = false;
        private bool TelekinesisActiveRight = false;

        private bool TelekinesisCatchLeftLast = false;
        private bool TelekinesisCatchRightLast = false;

        private bool slowMotionActive = false;

        private ParticleSystem leftItemShootVFX = null;
        private ParticleSystem leftItemShoot2VFX = null;

        private ParticleSystem rightItemShootVFX = null;
        private ParticleSystem rightItemShoot2VFX = null;

        private ParticleSystem leftShoulderTurretShootVFX = null;
        private ParticleSystem hoverJetVFX = null;


        private AudioSource leftItemShootSFX = null;

        private AudioSource rightItemShootSFX = null;

        private float deltaTime = 0.0f;
        private float shootGunCheckTimeLeft = 0.0f;
        private float climbingCheckTimeLeft = 0.0f;
        private float hapticCheckTimeLeft = 0.0f;
        private float hapticCheckTimeRight = 0.0f;

        private bool bowStringHeld = false;

        private bool ItemHeldInLeftHand = false;
        private bool ItemHeldInRightHand = false;

        private bool leftHandClimbing = false;
        private bool rightHandClimbing = false;

        private bool beingPushed = false;
        private bool beingPushedOther = false;
        private bool beingPulledLeft = false;
        private bool beingPulledRight = false;

        private float TOLERANCE = 0.0001f;

        private bool leftItemUseStarted = false;
        private bool leftItemAltUseStarted = false;

        private bool rightItemUseStarted = false;
        private bool rightItemAltUseStarted = false;

        private bool shootingLeftGun = false;
        private bool shootingRightGun = false;
        private bool altShootingLeftGun = false;
        private bool altShootingRightGun = false;

        private bool shootingLeftShoulderTurret = false;
        private bool hoveringWithHoverJet = false;


        private Vector3 lastFrameVelocity = Vector3.zero;
        private bool noExplosionFeedback = false;

        private List<string> SFXList;
        private List<string> VFXList;

        Dictionary<string, bool> GunUseMultipleShotMap = new Dictionary<string, bool>();
        Dictionary<string, bool> GunAltUseMultipleShotMap = new Dictionary<string, bool>();

        #endregion

        void LOG(string logStr)
        {
            if (Logging)
            {
                Utility.LOG(logStr);
            }
        }

        #region Overrides

        public override void OnLevelLoaded(LevelDefinition levelDefinition)
        {
            tactsuitVr = new TactsuitVR();
            tactsuitVr.CreateSystem();

            #region Intensities

            tactsuitVr.IntensityDefaultDamage = IntensityDefaultDamage;
            tactsuitVr.IntensityPlayerBowPull = IntensityPlayerBowPull;
            tactsuitVr.IntensityPlayerMeleeBladeWoodPierce = IntensityPlayerMeleeBladeWoodPierce;
            tactsuitVr.IntensityPlayerMeleeBladeMetalPierce = IntensityPlayerMeleeBladeMetalPierce;
            tactsuitVr.IntensityPlayerMeleeBladeStonePierce = IntensityPlayerMeleeBladeStonePierce;
            tactsuitVr.IntensityPlayerMeleeBladeFabricPierce = IntensityPlayerMeleeBladeFabricPierce;
            tactsuitVr.IntensityPlayerMeleeBladeFleshPierce = IntensityPlayerMeleeBladeFleshPierce;
            tactsuitVr.IntensityPlayerMeleeBladeWoodSlash = IntensityPlayerMeleeBladeWoodSlash;
            tactsuitVr.IntensityPlayerMeleeBladeMetalSlash = IntensityPlayerMeleeBladeMetalSlash;
            tactsuitVr.IntensityPlayerMeleeBladeStoneSlash = IntensityPlayerMeleeBladeStoneSlash;
            tactsuitVr.IntensityPlayerMeleeBladeFabricSlash = IntensityPlayerMeleeBladeFabricSlash;
            tactsuitVr.IntensityPlayerMeleeBladeFleshSlash = IntensityPlayerMeleeBladeFleshSlash;
            tactsuitVr.IntensityPlayerMeleeBladeWoodBlunt = IntensityPlayerMeleeBladeWoodBlunt;
            tactsuitVr.IntensityPlayerMeleeBladeMetalBlunt = IntensityPlayerMeleeBladeMetalBlunt;
            tactsuitVr.IntensityPlayerMeleeBladeStoneBlunt = IntensityPlayerMeleeBladeStoneBlunt;
            tactsuitVr.IntensityPlayerMeleeBladeFabricBlunt = IntensityPlayerMeleeBladeFabricBlunt;
            tactsuitVr.IntensityPlayerMeleeBladeFleshBlunt = IntensityPlayerMeleeBladeFleshBlunt;
            tactsuitVr.IntensityPlayerMeleeWoodWoodBlunt = IntensityPlayerMeleeWoodWoodBlunt;
            tactsuitVr.IntensityPlayerMeleeWoodMetalBlunt = IntensityPlayerMeleeWoodMetalBlunt;
            tactsuitVr.IntensityPlayerMeleeWoodStoneBlunt = IntensityPlayerMeleeWoodStoneBlunt;
            tactsuitVr.IntensityPlayerMeleeWoodFabricBlunt = IntensityPlayerMeleeWoodFabricBlunt;
            tactsuitVr.IntensityPlayerMeleeWoodFleshBlunt = IntensityPlayerMeleeWoodFleshBlunt;
            tactsuitVr.IntensityPlayerMeleeStoneStoneBlunt = IntensityPlayerMeleeStoneStoneBlunt;
            tactsuitVr.IntensityPlayerMeleeStoneFabricBlunt = IntensityPlayerMeleeStoneFabricBlunt;
            tactsuitVr.IntensityPlayerMeleeStoneFleshBlunt = IntensityPlayerMeleeStoneFleshBlunt;

            tactsuitVr.IntensityPlayerSpellFire = IntensityPlayerSpellFire;
            tactsuitVr.IntensityPlayerSpellLightning = IntensityPlayerSpellLightning;
            tactsuitVr.IntensityPlayerSpellGravity = IntensityPlayerSpellGravity;
            tactsuitVr.IntensityPlayerSpellIce = IntensityPlayerSpellIce;
            tactsuitVr.IntensityPlayerSpellCrush = IntensityPlayerSpellCrush;
            tactsuitVr.IntensityPlayerSpellHeal = IntensityPlayerSpellHeal;
            tactsuitVr.IntensityPlayerSpellImplosion = IntensityPlayerSpellImplosion;
            tactsuitVr.IntensityPlayerSpellInvisibility = IntensityPlayerSpellInvisibility;
            tactsuitVr.IntensityPlayerSpellTesla = IntensityPlayerSpellTesla;
            tactsuitVr.IntensityPlayerSpellUtility = IntensityPlayerSpellUtility;
            tactsuitVr.IntensityPlayerSpellCorruption = IntensityPlayerSpellCorruption;
            tactsuitVr.IntensityPlayerSpellTeleport = IntensityPlayerSpellTeleport;
            tactsuitVr.IntensityPlayerSpellRasengan = IntensityPlayerSpellRasengan;
            tactsuitVr.IntensityPlayerSpellNeedle = IntensityPlayerSpellNeedle;
            tactsuitVr.IntensityPlayerSpellDrain = IntensityPlayerSpellDrain;
            tactsuitVr.IntensityPlayerSpellForceField = IntensityPlayerSpellForceField;
            tactsuitVr.IntensityPlayerSpellOther = IntensityPlayerSpellOther;

            tactsuitVr.IntensityPlayerTelekinesisActive = IntensityPlayerTelekinesisActive;
            tactsuitVr.IntensityPlayerTelekinesisPull = IntensityPlayerTelekinesisPull;
            tactsuitVr.IntensityPlayerTelekinesisRepel = IntensityPlayerTelekinesisRepel;
            tactsuitVr.IntensityPlayerTelekinesisCatch = IntensityPlayerTelekinesisCatch;

            tactsuitVr.IntensityDamageVestArrow = IntensityDamageVestArrow;
            tactsuitVr.IntensityDamageArmArrow = IntensityDamageArmArrow;
            tactsuitVr.IntensityDamageHeadArrow = IntensityDamageHeadArrow;
            tactsuitVr.IntensityDamageVestFireArrow = IntensityDamageVestFireArrow;
            tactsuitVr.IntensityDamageArmFireArrow = IntensityDamageArmFireArrow;
            tactsuitVr.IntensityDamageHeadFireArrow = IntensityDamageHeadFireArrow;
            tactsuitVr.IntensityDamageVestLightningArrow = IntensityDamageVestLightningArrow;
            tactsuitVr.IntensityDamageArmLightningArrow = IntensityDamageArmLightningArrow;
            tactsuitVr.IntensityDamageHeadLightningArrow = IntensityDamageHeadLightningArrow;
            tactsuitVr.IntensityDamageVestIceArrow = IntensityDamageVestIceArrow;
            tactsuitVr.IntensityDamageArmIceArrow = IntensityDamageArmIceArrow;
            tactsuitVr.IntensityDamageHeadIceArrow = IntensityDamageHeadIceArrow;
            tactsuitVr.IntensityDamageHeadFire = IntensityDamageHeadFire;
            tactsuitVr.IntensityDamageHeadLightning = IntensityDamageHeadLightning;
            tactsuitVr.IntensityDamageHeadGravity = IntensityDamageHeadGravity;
            tactsuitVr.IntensityDamageHeadIce = IntensityDamageHeadIce;
            tactsuitVr.IntensityDamageHeadDrain = IntensityDamageHeadDrain;
            tactsuitVr.IntensityDamageHeadEnergy = IntensityDamageHeadEnergy;
            tactsuitVr.IntensityDamageArmFire = IntensityDamageArmFire;
            tactsuitVr.IntensityDamageArmLightning = IntensityDamageArmLightning;
            tactsuitVr.IntensityDamageArmGravity = IntensityDamageArmGravity;
            tactsuitVr.IntensityDamageArmIce = IntensityDamageArmIce;
            tactsuitVr.IntensityDamageArmDrain = IntensityDamageArmDrain;
            tactsuitVr.IntensityDamageArmEnergy = IntensityDamageArmEnergy;

            tactsuitVr.IntensityDamageVestEnergy = IntensityDamageVestEnergy;
            tactsuitVr.IntensityDamageVestFire = IntensityDamageVestFire;
            tactsuitVr.IntensityDamageVestIce = IntensityDamageVestIce;
            tactsuitVr.IntensityDamageVestDrain = IntensityDamageVestDrain;
            tactsuitVr.IntensityDamageVestLightning = IntensityDamageVestLightning;
            tactsuitVr.IntensityDamageVestGravity = IntensityDamageVestGravity;

            tactsuitVr.IntensityDamageVestPierceBladeSmall = IntensityDamageVestPierceBladeSmall;
            tactsuitVr.IntensityDamageVestSlashBladeSmall = IntensityDamageVestSlashBladeSmall;
            tactsuitVr.IntensityDamageVestBluntBladeSmall = IntensityDamageVestBluntBladeSmall;
            tactsuitVr.IntensityDamageVestBluntWoodSmall = IntensityDamageVestBluntWoodSmall;
            tactsuitVr.IntensityDamageVestBluntMetalSmall = IntensityDamageVestBluntMetalSmall;
            tactsuitVr.IntensityDamageVestBluntStoneSmall = IntensityDamageVestBluntStoneSmall;
            tactsuitVr.IntensityDamageVestBluntFleshSmall = IntensityDamageVestBluntFleshSmall;
            tactsuitVr.IntensityDamageVestPierceFireSmall = IntensityDamageVestPierceFireSmall;
            tactsuitVr.IntensityDamageVestSlashFireSmall = IntensityDamageVestSlashFireSmall;
            tactsuitVr.IntensityDamageVestBluntFireSmall = IntensityDamageVestBluntFireSmall;
            tactsuitVr.IntensityDamageVestPierceLightningSmall = IntensityDamageVestPierceLightningSmall;
            tactsuitVr.IntensityDamageVestSlashLightningSmall = IntensityDamageVestSlashLightningSmall;
            tactsuitVr.IntensityDamageVestBluntLightningSmall = IntensityDamageVestBluntLightningSmall;
            tactsuitVr.IntensityDamageVestPierceIceSmall = IntensityDamageVestPierceIceSmall;
            tactsuitVr.IntensityDamageVestSlashIceSmall = IntensityDamageVestSlashIceSmall;
            tactsuitVr.IntensityDamageVestBluntIceSmall = IntensityDamageVestBluntIceSmall;
            tactsuitVr.IntensityDamageVestPierceBladeLarge = IntensityDamageVestPierceBladeLarge;
            tactsuitVr.IntensityDamageVestSlashBladeLarge = IntensityDamageVestSlashBladeLarge;
            tactsuitVr.IntensityDamageVestBluntBladeLarge = IntensityDamageVestBluntBladeLarge;
            tactsuitVr.IntensityDamageVestBluntWoodLarge = IntensityDamageVestBluntWoodLarge;
            tactsuitVr.IntensityDamageVestBluntMetalLarge = IntensityDamageVestBluntMetalLarge;
            tactsuitVr.IntensityDamageVestBluntStoneLarge = IntensityDamageVestBluntStoneLarge;
            tactsuitVr.IntensityDamageVestBluntFleshLarge = IntensityDamageVestBluntFleshLarge;
            tactsuitVr.IntensityDamageVestPierceFireLarge = IntensityDamageVestPierceFireLarge;
            tactsuitVr.IntensityDamageVestSlashFireLarge = IntensityDamageVestSlashFireLarge;
            tactsuitVr.IntensityDamageVestBluntFireLarge = IntensityDamageVestBluntFireLarge;
            tactsuitVr.IntensityDamageVestPierceLightningLarge = IntensityDamageVestPierceLightningLarge;
            tactsuitVr.IntensityDamageVestSlashLightningLarge = IntensityDamageVestSlashLightningLarge;
            tactsuitVr.IntensityDamageVestBluntLightningLarge = IntensityDamageVestBluntLightningLarge;
            tactsuitVr.IntensityDamageVestPierceIceLarge = IntensityDamageVestPierceIceLarge;
            tactsuitVr.IntensityDamageVestSlashIceLarge = IntensityDamageVestSlashIceLarge;
            tactsuitVr.IntensityDamageVestBluntIceLarge = IntensityDamageVestBluntIceLarge;
            tactsuitVr.IntensityDamageArmPierceBladeSmall = IntensityDamageArmPierceBladeSmall;
            tactsuitVr.IntensityDamageArmSlashBladeSmall = IntensityDamageArmSlashBladeSmall;
            tactsuitVr.IntensityDamageArmBluntBladeSmall = IntensityDamageArmBluntBladeSmall;
            tactsuitVr.IntensityDamageArmBluntWoodSmall = IntensityDamageArmBluntWoodSmall;
            tactsuitVr.IntensityDamageArmBluntMetalSmall = IntensityDamageArmBluntMetalSmall;
            tactsuitVr.IntensityDamageArmBluntStoneSmall = IntensityDamageArmBluntStoneSmall;
            tactsuitVr.IntensityDamageArmBluntFleshSmall = IntensityDamageArmBluntFleshSmall;
            tactsuitVr.IntensityDamageArmPierceFireSmall = IntensityDamageArmPierceFireSmall;
            tactsuitVr.IntensityDamageArmSlashFireSmall = IntensityDamageArmSlashFireSmall;
            tactsuitVr.IntensityDamageArmBluntFireSmall = IntensityDamageArmBluntFireSmall;
            tactsuitVr.IntensityDamageArmPierceLightningSmall = IntensityDamageArmPierceLightningSmall;
            tactsuitVr.IntensityDamageArmSlashLightningSmall = IntensityDamageArmSlashLightningSmall;
            tactsuitVr.IntensityDamageArmBluntLightningSmall = IntensityDamageArmBluntLightningSmall;
            tactsuitVr.IntensityDamageArmPierceIceSmall = IntensityDamageArmPierceIceSmall;
            tactsuitVr.IntensityDamageArmSlashIceSmall = IntensityDamageArmSlashIceSmall;
            tactsuitVr.IntensityDamageArmBluntIceSmall = IntensityDamageArmBluntIceSmall;
            tactsuitVr.IntensityDamageArmPierceBladeLarge = IntensityDamageArmPierceBladeLarge;
            tactsuitVr.IntensityDamageArmSlashBladeLarge = IntensityDamageArmSlashBladeLarge;
            tactsuitVr.IntensityDamageArmBluntBladeLarge = IntensityDamageArmBluntBladeLarge;
            tactsuitVr.IntensityDamageArmBluntWoodLarge = IntensityDamageArmBluntWoodLarge;
            tactsuitVr.IntensityDamageArmBluntMetalLarge = IntensityDamageArmBluntMetalLarge;
            tactsuitVr.IntensityDamageArmBluntStoneLarge = IntensityDamageArmBluntStoneLarge;
            tactsuitVr.IntensityDamageArmBluntFleshLarge = IntensityDamageArmBluntFleshLarge;
            tactsuitVr.IntensityDamageArmPierceFireLarge = IntensityDamageArmPierceFireLarge;
            tactsuitVr.IntensityDamageArmSlashFireLarge = IntensityDamageArmSlashFireLarge;
            tactsuitVr.IntensityDamageArmBluntFireLarge = IntensityDamageArmBluntFireLarge;
            tactsuitVr.IntensityDamageArmPierceLightningLarge = IntensityDamageArmPierceLightningLarge;
            tactsuitVr.IntensityDamageArmSlashLightningLarge = IntensityDamageArmSlashLightningLarge;
            tactsuitVr.IntensityDamageArmBluntLightningLarge = IntensityDamageArmBluntLightningLarge;
            tactsuitVr.IntensityDamageArmPierceIceLarge = IntensityDamageArmPierceIceLarge;
            tactsuitVr.IntensityDamageArmSlashIceLarge = IntensityDamageArmSlashIceLarge;
            tactsuitVr.IntensityDamageArmBluntIceLarge = IntensityDamageArmBluntIceLarge;
            tactsuitVr.IntensityDamageHeadPierceBladeSmall = IntensityDamageHeadPierceBladeSmall;
            tactsuitVr.IntensityDamageHeadSlashBladeSmall = IntensityDamageHeadSlashBladeSmall;
            tactsuitVr.IntensityDamageHeadBluntBladeSmall = IntensityDamageHeadBluntBladeSmall;
            tactsuitVr.IntensityDamageHeadBluntWoodSmall = IntensityDamageHeadBluntWoodSmall;
            tactsuitVr.IntensityDamageHeadBluntMetalSmall = IntensityDamageHeadBluntMetalSmall;
            tactsuitVr.IntensityDamageHeadBluntStoneSmall = IntensityDamageHeadBluntStoneSmall;
            tactsuitVr.IntensityDamageHeadBluntFleshSmall = IntensityDamageHeadBluntFleshSmall;
            tactsuitVr.IntensityDamageHeadPierceFireSmall = IntensityDamageHeadPierceFireSmall;
            tactsuitVr.IntensityDamageHeadSlashFireSmall = IntensityDamageHeadSlashFireSmall;
            tactsuitVr.IntensityDamageHeadBluntFireSmall = IntensityDamageHeadBluntFireSmall;
            tactsuitVr.IntensityDamageHeadPierceLightningSmall = IntensityDamageHeadPierceLightningSmall;
            tactsuitVr.IntensityDamageHeadSlashLightningSmall = IntensityDamageHeadSlashLightningSmall;
            tactsuitVr.IntensityDamageHeadBluntLightningSmall = IntensityDamageHeadBluntLightningSmall;
            tactsuitVr.IntensityDamageHeadPierceIceSmall = IntensityDamageHeadPierceIceSmall;
            tactsuitVr.IntensityDamageHeadSlashIceSmall = IntensityDamageHeadSlashIceSmall;
            tactsuitVr.IntensityDamageHeadBluntIceSmall = IntensityDamageHeadBluntIceSmall;
            tactsuitVr.IntensityDamageHeadPierceBladeLarge = IntensityDamageHeadPierceBladeLarge;
            tactsuitVr.IntensityDamageHeadSlashBladeLarge = IntensityDamageHeadSlashBladeLarge;
            tactsuitVr.IntensityDamageHeadBluntBladeLarge = IntensityDamageHeadBluntBladeLarge;
            tactsuitVr.IntensityDamageHeadBluntWoodLarge = IntensityDamageHeadBluntWoodLarge;
            tactsuitVr.IntensityDamageHeadBluntMetalLarge = IntensityDamageHeadBluntMetalLarge;
            tactsuitVr.IntensityDamageHeadBluntStoneLarge = IntensityDamageHeadBluntStoneLarge;
            tactsuitVr.IntensityDamageHeadBluntFleshLarge = IntensityDamageHeadBluntFleshLarge;
            tactsuitVr.IntensityDamageHeadPierceFireLarge = IntensityDamageHeadPierceFireLarge;
            tactsuitVr.IntensityDamageHeadSlashFireLarge = IntensityDamageHeadSlashFireLarge;
            tactsuitVr.IntensityDamageHeadBluntFireLarge = IntensityDamageHeadBluntFireLarge;
            tactsuitVr.IntensityDamageHeadPierceLightningLarge = IntensityDamageHeadPierceLightningLarge;
            tactsuitVr.IntensityDamageHeadSlashLightningLarge = IntensityDamageHeadSlashLightningLarge;
            tactsuitVr.IntensityDamageHeadBluntLightningLarge = IntensityDamageHeadBluntLightningLarge;
            tactsuitVr.IntensityDamageHeadPierceIceLarge = IntensityDamageHeadPierceIceLarge;
            tactsuitVr.IntensityDamageHeadSlashIceLarge = IntensityDamageHeadSlashIceLarge;
            tactsuitVr.IntensityDamageHeadBluntIceLarge = IntensityDamageHeadBluntIceLarge;

            tactsuitVr.IntensityHeartBeat = IntensityHeartBeat;
            tactsuitVr.IntensityHeartBeatFast = IntensityHeartBeatFast;
            tactsuitVr.IntensityHealing = IntensityHealing;
            tactsuitVr.IntensityPotionDrinking = IntensityPotionDrinking;
            tactsuitVr.IntensityPoisonDrinking = IntensityPoisonDrinking;
            tactsuitVr.IntensityFallDamage = IntensityFallDamage;
            tactsuitVr.IntensityFallDamageFeet = IntensityFallDamageFeet;
            tactsuitVr.IntensitySlowMotion = IntensitySlowMotion;
            tactsuitVr.IntensityHolster = IntensityHolster;
            tactsuitVr.IntensityUnholster = IntensityUnholster;
            tactsuitVr.IntensityHolsterArrow = IntensityHolsterArrow;
            tactsuitVr.IntensityUnholsterArrow = IntensityUnholsterArrow;
            tactsuitVr.IntensityClimbing = IntensityClimbing;
            tactsuitVr.IntensityPlayerKickOther = IntensityPlayerKickOther;
            tactsuitVr.IntensityPlayerKickWood = IntensityPlayerKickWood;
            tactsuitVr.IntensityPlayerKickFlesh = IntensityPlayerKickFlesh;
            tactsuitVr.IntensityPlayerKickStone = IntensityPlayerKickStone;
            tactsuitVr.IntensityPlayerKickMetal = IntensityPlayerKickMetal;
            tactsuitVr.IntensityPlayerKickFabric = IntensityPlayerKickFabric;
            tactsuitVr.IntensityPlayerPunchOther = IntensityPlayerPunchOther;
            tactsuitVr.IntensityPlayerPunchWood = IntensityPlayerPunchWood;
            tactsuitVr.IntensityPlayerPunchFlesh = IntensityPlayerPunchFlesh;
            tactsuitVr.IntensityPlayerPunchStone = IntensityPlayerPunchStone;
            tactsuitVr.IntensityPlayerPunchMetal = IntensityPlayerPunchMetal;
            tactsuitVr.IntensityPlayerPunchFabric = IntensityPlayerPunchFabric;

            tactsuitVr.IntensityPlayerGun = IntensityPlayerGun ;
            tactsuitVr.IntensityPlayerGunBlaster = IntensityPlayerGunBlaster ;
            tactsuitVr.IntensityPlayerGunAutomatic = IntensityPlayerGunAutomatic ;
            tactsuitVr.IntensityPlayerGunBallistic = IntensityPlayerGunBallistic ;
            tactsuitVr.IntensityPlayerGunSpray = IntensityPlayerGunSpray ;
            tactsuitVr.IntensityPlayerGunMiniGun = IntensityPlayerGunMiniGun ;
            tactsuitVr.IntensityPlayerGunBazooka = IntensityPlayerGunBazooka ;
            tactsuitVr.IntensityPlayerGunHeavy = IntensityPlayerGunHeavy ;
            tactsuitVr.IntensityPlayerGunLaser = IntensityPlayerGunLaser ;
            tactsuitVr.IntensityPlayerGunRifle = IntensityPlayerGunRifle ;
            tactsuitVr.IntensityPlayerGunPistol = IntensityPlayerGunPistol ;
            tactsuitVr.IntensityPlayerGunPlasma = IntensityPlayerGunPlasma ;
            tactsuitVr.IntensityPlayerGunShotgun = IntensityPlayerGunShotgun ;
            tactsuitVr.IntensityPlayerGunEnergy = IntensityPlayerGunEnergy ;
            tactsuitVr.IntensityKickbackPlayerGun = IntensityKickbackPlayerGun ;
            tactsuitVr.IntensityKickbackPlayerGunPistol = IntensityKickbackPlayerGunPistol ;
            tactsuitVr.IntensityKickbackPlayerGunBallistic = IntensityKickbackPlayerGunBallistic ;
            tactsuitVr.IntensityKickbackPlayerGunLaser = IntensityKickbackPlayerGunLaser ;
            tactsuitVr.IntensityKickbackPlayerGunPlasma = IntensityKickbackPlayerGunPlasma ;
            tactsuitVr.IntensityKickbackPlayerGunSpray = IntensityKickbackPlayerGunSpray ;
            tactsuitVr.IntensityKickbackPlayerGunHeavy = IntensityKickbackPlayerGunHeavy;

            tactsuitVr.IntensityPlayerThrow = IntensityPlayerThrow;

            tactsuitVr.IntensityExplosion = IntensityExplosion;

            tactsuitVr.IntensityShoulderTurret = IntensityShoulderTurret;
            tactsuitVr.IntensityHoverJetFeet = IntensityHoverJetFeet;

            tactsuitVr.Logging = Logging;

            #endregion

            LOG("Loaded.");

            FillFXLists();

            string materials = "";
            foreach (MaterialData data in Catalog.GetDataList(Catalog.Category.Material))
            {
                if (data != null)
                {
                    materials = materials + (materials.IsNullOrEmpty() ? "": ", ") + data.id;
                }
            }

            LOG("Game materials: " + materials);

            base.OnLevelLoaded(levelDefinition);
        }

        private void FillFXLists()
        {
            SFXList= new List<string>();
            VFXList = new List<string>();

            string modPath = Directory.GetCurrentDirectory() + "\\BladeAndSorcery_Data\\StreamingAssets";

            DirectoryInfo d = new DirectoryInfo(modPath);
            if (d != null)
            {
                FileInfo[] Files = d.GetFiles("Item_*.json", SearchOption.AllDirectories);
                if (Files != null)
                {
                    for (int i = 0; i < Files.Length; i++)
                    {
                        string filename = Files[i].Name;
                        string fullName = Files[i].FullName;
                        if (filename == "." || filename == "..")
                            continue;

                        string jsonFileStr = File.ReadAllText(fullName);
                        if (!jsonFileStr.IsNullOrEmpty() && jsonFileStr.Contains("Shooter"))
                        {
                            JObject obj = JObject.Parse(jsonFileStr);
                            if (obj != null)
                            {
                                string displayName = (string) obj["displayName"];

                                foreach (var module in obj.SelectTokens("modules[*]"))
                                {
                                    if (module != null)
                                    {
                                        bool shotWithAltUse = false;

                                        if (module["shootWithAltUse"] != null)
                                        {
                                            shotWithAltUse = (bool) module["shootWithAltUse"];
                                            bool multipleShots = false;
                                            if (module["multipleShotsWithoutReleasingTrigger"] != null)
                                            {
                                                multipleShots = (bool)module["multipleShotsWithoutReleasingTrigger"];
                                                
                                                if (shotWithAltUse)
                                                {
                                                    GunAltUseMultipleShotMap[displayName] = multipleShots;
                                                    LOG("Gun " + displayName + " alt fire: " + (multipleShots ? "multiple" : "single"));
                                                }
                                                else
                                                {
                                                    GunUseMultipleShotMap[displayName] = multipleShots;
                                                    LOG("Gun " + displayName + " fire: " + (multipleShots ? "multiple" : "single"));
                                                }
                                            }
                                        }

                                        string shootSfx = (string) module["shootSFX"];
                                        string shootVfx = (string) module["shootVFX"];
                                        if (!shootSfx.IsNullOrEmpty())
                                        {
                                            if (!SFXList.Contains(shootSfx))
                                                SFXList.Add(shootSfx);
                                        }

                                        if (!shootVfx.IsNullOrEmpty())
                                        {
                                            if (!VFXList.Contains(shootVfx))
                                                VFXList.Add(shootVfx);
                                        }
                                    }
                                }
                            }
                        }
                        else if (!jsonFileStr.IsNullOrEmpty() && jsonFileStr.Contains("SimpleBallistics"))
                        {
                            JObject obj = JObject.Parse(jsonFileStr);
                            if (obj != null)
                            {
                                string displayName = (string)obj["displayName"];

                                foreach (var module in obj.SelectTokens("modules[*]"))
                                {
                                    if (module != null)
                                    {
                                        GunUseMultipleShotMap[displayName] = false;
                                        LOG("Gun " + displayName + " fire: single");

                                        string shootSfx = (string)module["fireSoundRef"];
                                        string shootVfx = (string)module["muzzleFlashRef"];
                                        if (!shootSfx.IsNullOrEmpty())
                                        {
                                            if (!SFXList.Contains(shootSfx))
                                                SFXList.Add(shootSfx);
                                        }

                                        if (!shootVfx.IsNullOrEmpty())
                                        {
                                            if (!VFXList.Contains(shootVfx))
                                                VFXList.Add(shootVfx);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            SFXList.Add("GrappleSound"); //Support fur ButtersAndSorcery's Batman Grapple Mod
            GunUseMultipleShotMap["GrappleGun"] = false;
            GunUseMultipleShotMap["BatmanGrapple"] = false;

            LOG("Found Gun VFX count: " + VFXList.Count + " Gun SFX count: " + SFXList.Count);
            LOG("Found Gun VFXs: " + String.Join(", ", VFXList));
            LOG("Found Gun SFXs: " + String.Join(", ", SFXList));
        }

        public override void OnLevelUnloaded(LevelDefinition levelDefinition)
        {
            if (tactsuitVr != null && tactsuitVr.hapticPlayer != null)
            {
                tactsuitVr.hapticPlayer.Disable();
                tactsuitVr.hapticPlayer.Dispose();
            }

            LOG("Unloaded.");

            base.OnLevelUnloaded(levelDefinition);
        }

        public override void Update(LevelDefinition levelDefinition)
        {
            if (GameManager.isQuitting)
            {
                if (tactsuitVr != null && tactsuitVr.hapticPlayer != null)
                {
                    tactsuitVr.hapticPlayer.Disable();
                    tactsuitVr.hapticPlayer.Dispose();
                }
            }

            gamePaused = MenuBook.local.book.GetBookState() == PBook.BookState.OPEN;
            
            if (initialized)
            {
                if (!eventsCreated)
                {
                    EventManager.onCreatureHitEvent += OnCreatureHitFunc;
                    EventManager.onCreatureHealEvent += OnCreatureHealFunc;
                    EventManager.onCreatureKillEvent += OnCreatureKillFunc;
                    EventManager.onCreatureParryEvent += OnCreatureParryFunc;
                    EventManager.onDeflectEvent += OnDeflectFunc;
                    EventManager.onPlayerSpawned += OnPlayerSpawnFunc;

                    //Locomotion.OnGroundEvent 
                    eventsCreated = true;
                    LOG("Events are created.");
                }

                deltaTime = Time.deltaTime * 1000f;

                if (!GameManager.timeStopped)
                {
                    if (Player.local != null && Player.local.body != null && Player.local.body.creature != null && Player.local.body.creature.initialized)
                    {
                        CheckStates(Player.local.body.creature);
                    }
                    else
                    {
                        lastFrameVelocity = Vector3.zero;
                    }
                }
                else
                {
                    lastFrameVelocity = Vector3.zero;
                }
            }
            else
            {
                lastFrameVelocity = Vector3.zero;
            }
            base.Update(levelDefinition);
        }

        private void CheckPlayerSpawn()
        {
            while (Player.local == null || Player.local.body == null || Player.local.body.creature == null || Player.local.body.creature.health == null || Player.local.locomotion == null || Player.local.body.creature.initialized == false || Player.local.body.creature.ragdoll == null)
            {
                Thread.Sleep(1000);
            }

            LOG("Player spawned.");
            LiquidReceiver lr = Player.local.body.creature.health.GetComponentInChildren<LiquidReceiver>();
            if ((bool) (UnityEngine.Object) lr)
            {
                lr.OnReceptionEvent += new LiquidReceiver.ReceptionEvent(OnLiquidReceptionFunc);
                LOG("Liquid reception function added.");
            }
            else
            {
                LOG("Can't find Liquid Receiver on player.");
            }

            Player.local.locomotion.OnGroundEvent += OnGroundFunc;
            LOG("OnGround function added.");

            Player.local.body.creature.health.OnDamageEvent += OnDamageFunc;
            Player.local.body.creature.health.OnKillEvent += OnKillFunc;

            if (Player.local.body.GetHand(Side.Left)?.interactor != null) Player.local.body.GetHand(Side.Left).interactor.OnGrabEvent += new Interactor.GrabEvent(GrabFunc);
            if (Player.local.body.GetHand(Side.Right)?.interactor != null) Player.local.body.GetHand(Side.Right).interactor.OnGrabEvent += new Interactor.GrabEvent(GrabFunc);
            if (Player.local.body.GetHand(Side.Left)?.interactor != null) Player.local.body.GetHand(Side.Left).interactor.OnUnGrabEvent += new Interactor.UnGrabEvent(UnGrabFunc);
            if (Player.local.body.GetHand(Side.Right)?.interactor != null) Player.local.body.GetHand(Side.Right).interactor.OnUnGrabEvent += new Interactor.UnGrabEvent(UnGrabFunc);

            foreach (ObjectHolder holder in Player.local.body.creature.holders)
            {
                if (holder != null)
                {
                    //Holder found on Player: BackRight
                    //Holder found on Player: BackLeft
                    if (holder.definition?.name == "BackLeft")
                    {
                        holder.Snapped += HolsterLeftShoulderFunc;
                        holder.UnSnapped += UnHolsterLeftShoulderFunc;
                    }
                    else if (holder.definition?.name == "BackRight")
                    {
                        holder.Snapped += HolsterRightShoulderFunc;
                        holder.UnSnapped += UnHolsterRightShoulderFunc;
                    }

                    foreach (Item holdObject in holder.holdObjects)
                    {
                        if (holdObject.data.type == ItemPhysic.Type.Quiver)
                        {
                            ItemQuiver quiver = holdObject.GetComponent<ItemQuiver>();
                            if (quiver?.holder != null)
                            {
                                if (holder.definition?.name == "BackLeft")
                                {
                                    quiver.holder.Snapped += new ObjectHolder.HolderDelegate(LeftProjectileAddedFunc);
                                    quiver.holder.UnSnapped += new ObjectHolder.HolderDelegate(LeftProjectileRemovedFunc);
                                }
                                else if (holder.definition?.name == "BackRight")
                                {
                                    quiver.holder.Snapped += new ObjectHolder.HolderDelegate(RightProjectileAddedFunc);
                                    quiver.holder.UnSnapped += new ObjectHolder.HolderDelegate(RightProjectileRemovedFunc);
                                }

                            }
                        }
                    }
                }
            }

            //List<CollisionHandler> playerCollisionHandlersList = new List<CollisionHandler>((IEnumerable<CollisionHandler>)Player.local.GetComponentsInChildren<CollisionHandler>());

            //foreach (var collisionHandler in playerCollisionHandlersList)
            //{
            //    if (collisionHandler != null)
            //    {
            //        LOG("Added Player collision checker for collisionhandler: " + collisionHandler.name + " Item: " + (collisionHandler.item!= null ? collisionHandler.item.name : ""));
            //        collisionHandler.OnCollisionStartEvent += BodyPartCollisionStartFunc;
            //    }
            //}

            if (Player.local.handLeft?.itemHand?.item?.definition?.collisionHandlers != null)
            {
                foreach (var collisionHandler in Player.local.handLeft.itemHand.item.definition.collisionHandlers)
                {
                    if (collisionHandler != null)
                    {
                        collisionHandler.OnCollisionStartEvent += BodyPartCollisionStartFunc;
                        collisionHandler.OnCollisionStopEvent += BodyPartCollisionStopFunc;
                    }
                }
            }

            if (Player.local.handRight?.itemHand?.item?.definition?.collisionHandlers != null)
            {
                foreach (var collisionHandler in Player.local.handRight.itemHand.item.definition.collisionHandlers)
                {
                    if (collisionHandler != null)
                    {
                        collisionHandler.OnCollisionStartEvent += BodyPartCollisionStartFunc;
                        collisionHandler.OnCollisionStopEvent += BodyPartCollisionStopFunc;
                    }
                }
            }

            if (Player.local.footLeft?.footObject?.definition?.collisionHandlers != null)
            {
                foreach (var collisionHandler in Player.local.footLeft.footObject.definition.collisionHandlers)
                {
                    if (collisionHandler != null)
                    {
                        collisionHandler.OnCollisionStartEvent += BodyPartCollisionStartFunc;
                    }
                }
            }

            if (Player.local.footRight?.footObject?.definition?.collisionHandlers != null)
            {
                foreach (var collisionHandler in Player.local.footRight.footObject.definition.collisionHandlers)
                {
                    if (collisionHandler != null)
                    {
                        collisionHandler.OnCollisionStartEvent += BodyPartCollisionStartFunc;
                    }
                }
            }

            foreach (var part in Player.local.body.creature.ragdoll.parts)
            {
                if (part?.partData != null && part.partData.type == RagdollData.Part.Type.Torso)
                {
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                    part.collisionHandler.OnCollisionStartEvent += TorsoCollisionFunc;
                }
            }
        }

        private TactsuitVR.FeedbackType GetPlayerPunchFeedback(string material)
        {
            if (!material.IsNullOrEmpty())
            {
                if (material.Contains("Wood"))
                    return TactsuitVR.FeedbackType.PlayerPunchWoodRight;
                else if (material.Contains("Stone") || material.Contains("Glass"))
                    return TactsuitVR.FeedbackType.PlayerPunchStoneRight;
                else if (material.Contains("Flesh") || material.Contains("Sand"))
                    return TactsuitVR.FeedbackType.PlayerPunchFleshRight;
                else if (material.Contains("Metal"))
                    return TactsuitVR.FeedbackType.PlayerPunchMetalRight;
                else if (material.Contains("Fabric"))
                    return TactsuitVR.FeedbackType.PlayerPunchFabricRight;
                else
                    return TactsuitVR.FeedbackType.PlayerPunchOtherRight;
            }
            else
            {
                return TactsuitVR.FeedbackType.PlayerPunchOtherRight;
            }
        }

        private TactsuitVR.FeedbackType GetPlayerKickFeedback(string material)
        {
            if (!material.IsNullOrEmpty())
            {
                if (material.Contains("Wood"))
                    return TactsuitVR.FeedbackType.PlayerKickWoodRight;
                else if (material.Contains("Stone") || material.Contains("Glass"))
                    return TactsuitVR.FeedbackType.PlayerKickStoneRight;
                else if (material.Contains("Flesh") || material.Contains("Sand"))
                    return TactsuitVR.FeedbackType.PlayerKickFleshRight;
                else if (material.Contains("Metal"))
                    return TactsuitVR.FeedbackType.PlayerKickMetalRight;
                else if (material.Contains("Fabric"))
                    return TactsuitVR.FeedbackType.PlayerKickFabricRight;
                else
                    return TactsuitVR.FeedbackType.PlayerKickOtherRight;
            }
            else
            {
                return TactsuitVR.FeedbackType.PlayerKickOtherRight;
            }
        }


        private void BodyPartCollisionStopFunc(ref CollisionStruct collisionInstance)
        {
            if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup == null && (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "").Contains("Hand") && (bool)(UnityEngine.Object)collisionInstance.sourceColliderGroup.collisionHandler?.item?.leftPlayerHand)
            {
                leftHandClimbing = false;
            }

            if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup == null && (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "").Contains("Hand") && (bool)(UnityEngine.Object)collisionInstance.sourceColliderGroup.collisionHandler?.item?.rightPlayerHand)
            {
                rightHandClimbing = false;
            }
        }

        private void BodyPartCollisionStartFunc(ref CollisionStruct collisionInstance)
        {
            float hitAngle = Utility.GetAngleForPosition(collisionInstance.contactPoint);
            
            //if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup == null && (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "").Contains("Hand") && (bool)(UnityEngine.Object)collisionInstance.sourceColliderGroup.collisionHandler?.item?.leftPlayerHand)
            //{
            //    if (!leftHandClimbing)
            //    {
            //        leftHandClimbing = true;
            //        Thread thread = new Thread(() => ClimbingFunc(Side.Left));
            //        thread.Start();
            //    }
            //}

            //if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup == null && (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "").Contains("Hand") && (bool)(UnityEngine.Object)collisionInstance.sourceColliderGroup.collisionHandler?.item?.rightPlayerHand)
            //{
            //    if (!rightHandClimbing)
            //    {
            //        rightHandClimbing = true;
            //        Thread thread = new Thread(() => ClimbingFunc(Side.Right));
            //        thread.Start();
            //    }
            //}

            if ((bool) (UnityEngine.Object) collisionInstance.sourceColliderGroup)
            {
                if (collisionInstance.sourceColliderGroup.collisionHandler?.item != collisionInstance.targetColliderGroup?.collisionHandler?.item)
                {
                    if ((bool) (UnityEngine.Object) collisionInstance.sourceColliderGroup.collisionHandler?.item?.leftPlayerHand)
                    {
                        TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "");
                        tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, true);
                        LOG("Left hand collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
                    }

                    if ((bool) (UnityEngine.Object) collisionInstance.sourceColliderGroup.collisionHandler?.item?.rightPlayerHand)
                    {
                        TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "");
                        tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, false);
                        LOG("Right hand collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
                    }
                }

                if (collisionInstance.sourceColliderGroup.collisionHandler?.item?.data.type == ItemPhysic.Type.Body)
                {
                    if ((UnityEngine.Object) Player.local?.footLeft.footObject == (UnityEngine.Object) collisionInstance.sourceColliderGroup.collisionHandler.item)
                    {
                        TactsuitVR.FeedbackType feedback = GetPlayerKickFeedback(collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "");
                        tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, true);
                        LOG("Left foot collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
                    }

                    if ((UnityEngine.Object) Player.local?.footRight.footObject == (UnityEngine.Object) collisionInstance.sourceColliderGroup.collisionHandler.item)
                    {
                        TactsuitVR.FeedbackType feedback = GetPlayerKickFeedback(collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "");
                        tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, false);
                        LOG("Right foot collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
                    }
                }
            }

            if ((bool) (UnityEngine.Object) collisionInstance.targetColliderGroup)
            {
                if (collisionInstance.sourceColliderGroup?.collisionHandler?.item != collisionInstance.targetColliderGroup?.collisionHandler?.item)
                {
                    if ((bool) (UnityEngine.Object) collisionInstance.targetColliderGroup?.collisionHandler?.item?.leftPlayerHand)
                    {
                        TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "");
                        tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, true);
                        LOG("Something collides with Left hand with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : "") + " DamageType: " + Utility.GetDamageTypeName(collisionInstance.damageStruct.damageType));
                    }

                    if ((bool) (UnityEngine.Object) collisionInstance.targetColliderGroup.collisionHandler.item?.rightPlayerHand)
                    {
                        TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "");
                        tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, false);
                        LOG("Something collides with Right hand with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : "") + " DamageType: " + Utility.GetDamageTypeName(collisionInstance.damageStruct.damageType));
                    }
                }

                if (collisionInstance.targetColliderGroup?.collisionHandler?.item?.data.type == ItemPhysic.Type.Body)
                {
                    if ((UnityEngine.Object)Player.local?.footLeft.footObject == (UnityEngine.Object)collisionInstance.targetColliderGroup.collisionHandler.item)
                    {
                        TactsuitVR.FeedbackType feedback = GetPlayerKickFeedback(collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "");
                        tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, true);
                        LOG("Something collides with Left foot with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
                    }

                    if ((UnityEngine.Object)Player.local?.footRight.footObject == (UnityEngine.Object)collisionInstance.targetColliderGroup.collisionHandler.item)
                    {
                        TactsuitVR.FeedbackType feedback = GetPlayerKickFeedback(collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "");
                        tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, false);
                        LOG("Something collides with Right foot with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
                    }
                }
            }
        }
        
        private void TorsoCollisionFunc(ref CollisionStruct collisionInstance)
        {
            if (collisionInstance.damageStruct.hitRagdollPart?.ragdoll?.creature != null || collisionInstance.damageStruct.damage > TOLERANCE || collisionInstance.impactVelocity.magnitude < 7.0f)
                return;

            bool sourceIsPlayer = false;
            bool targetIsPlayer = false;

            if (collisionInstance.sourceColliderGroup?.collisionHandler != null)
            {
                if (collisionInstance.sourceColliderGroup?.collisionHandler?.isRagdollPart == true)
                {
                    if (collisionInstance.sourceColliderGroup?.collisionHandler?.ragdollPart?.ragdoll?.creature == Player.local?.body?.creature)
                    {
                        sourceIsPlayer = true;
                    }
                }
                if (!sourceIsPlayer && collisionInstance.sourceColliderGroup?.collisionHandler?.isItem == true)
                {
                    if (collisionInstance.sourceColliderGroup?.collisionHandler?.item?.rightPlayerHand != null
                        || collisionInstance.sourceColliderGroup?.collisionHandler?.item?.leftPlayerHand != null
                        || collisionInstance.sourceColliderGroup?.collisionHandler?.item?.ignoredRagdoll?.creature == Player.local?.body?.creature
                        || (UnityEngine.Object)Player.local?.footRight.footObject == (UnityEngine.Object)collisionInstance.sourceColliderGroup.collisionHandler.item
                        || (UnityEngine.Object)Player.local?.footRight.footObject == (UnityEngine.Object)collisionInstance.sourceColliderGroup.collisionHandler.item)
                    {
                        sourceIsPlayer = true;
                    }
                }
            }
            if (collisionInstance.targetColliderGroup?.collisionHandler != null)
            {
                if (collisionInstance.targetColliderGroup?.collisionHandler?.isRagdollPart == true)
                {
                    if (collisionInstance.targetColliderGroup?.collisionHandler?.ragdollPart?.ragdoll?.creature == Player.local?.body?.creature)
                    {
                        targetIsPlayer = true;
                    }
                }
                if (!targetIsPlayer && collisionInstance.targetColliderGroup?.collisionHandler?.isItem == true)
                {
                    if (collisionInstance.targetColliderGroup?.collisionHandler?.item?.rightPlayerHand != null
                        || collisionInstance.targetColliderGroup?.collisionHandler?.item?.leftPlayerHand != null
                        || collisionInstance.targetColliderGroup?.collisionHandler?.item?.ignoredRagdoll?.creature == Player.local?.body?.creature
                        || (UnityEngine.Object)Player.local?.footRight.footObject == (UnityEngine.Object)collisionInstance.targetColliderGroup?.collisionHandler?.item
                        || (UnityEngine.Object)Player.local?.footRight.footObject == (UnityEngine.Object)collisionInstance.targetColliderGroup?.collisionHandler?.item)
                    {
                        targetIsPlayer = true;
                    }
                }
            }

            float hitAngle = Utility.GetAngleForPosition(collisionInstance.contactPoint);

            if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup != null)
            {
                LOG("Player torso collision " + (sourceIsPlayer ? "Source is player!" : "") + " " + (targetIsPlayer ? "Target is player!" : "") + " ST: SourceName: " + (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "") + " TargetName: " + (collisionInstance.targetColliderGroup.collisionHandler != null ? collisionInstance.targetColliderGroup.collisionHandler.name : "") + " with Hit Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture) + " with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " with ImpactVelocity:" + collisionInstance.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " DamageType: " + Enum.GetName(typeof(DamageType), collisionInstance.damageStruct.damageType) + " " + ("Materials: " + ((collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "Null") + " > " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "Null"))));
            }
            else if (collisionInstance.sourceColliderGroup != null && collisionInstance.targetColliderGroup == null)
            {
                LOG("Player torso collision " + (sourceIsPlayer ? "Source is player!" : "") + " S: SourceName: " + (collisionInstance.sourceColliderGroup.collisionHandler != null ? collisionInstance.sourceColliderGroup.collisionHandler.name : "") + " with Hit Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture) + " with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " with ImpactVelocity:" + collisionInstance.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " DamageType: " + Enum.GetName(typeof(DamageType), collisionInstance.damageStruct.damageType) + " " + ("Materials: " + ((collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "Null") + " > " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "Null"))));
            }
            else if (collisionInstance.sourceColliderGroup == null && collisionInstance.targetColliderGroup != null)
            {
                LOG("Player torso collision " + (targetIsPlayer ? "Target is player!" : "") + " T: TargetName: " + (collisionInstance.targetColliderGroup.collisionHandler != null ? collisionInstance.targetColliderGroup.collisionHandler.name : "") + " with Hit Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture) + " with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " with ImpactVelocity:" + collisionInstance.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " DamageType: " + Enum.GetName(typeof(DamageType), collisionInstance.damageStruct.damageType) + " " + ("Materials: " + ((collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "Null") + " > " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "Null"))));
            }
            else if (collisionInstance.sourceColliderGroup == null && collisionInstance.targetColliderGroup == null)
            {
                LOG("Player torso collision with Hit Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture) + " with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " with ImpactVelocity:" + collisionInstance.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " DamageType: " + Enum.GetName(typeof(DamageType), collisionInstance.damageStruct.damageType) + " " + ("Materials: " + ((collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id : "Null") + " > " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "Null"))));
            }
            
            tactsuitVr.ProvideHapticFeedbackThread(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestBluntStoneLarge, collisionInstance.intensity, false, false);
        }

        private void HeldItemRightCollisionStartFunc(ref CollisionStruct collisionInstance)
        {
            if (collisionInstance.damageStruct.hitRagdollPart?.ragdoll?.creature != null)
                return;

            Imbue imbue = null;
            if (collisionInstance.sourceColliderGroup?.collisionHandler?.item?.imbues != null)
            {
                if (collisionInstance.sourceColliderGroup?.collisionHandler?.item?.imbues.Count > 0)
                    imbue = collisionInstance.sourceColliderGroup?.collisionHandler?.item?.imbues[0];
            }

            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionInstance.damageStruct.damageType, collisionInstance.sourceMaterial, collisionInstance.targetMaterial);
            tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, false);
            LOG("Right hand item (" + (collisionInstance.sourceCollider != null ? collisionInstance.sourceCollider.name : "") + ") collides with something (" + (collisionInstance.targetCollider != null ? collisionInstance.targetCollider.name : "") + ") with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : "") + " MaterialEffect:" + (collisionInstance.damageStruct.materialEffectData != null ? collisionInstance.damageStruct.materialEffectData.id : "") + " DamageType: " + Utility.GetDamageTypeName(collisionInstance.damageStruct.damageType));
        }

        private void HeldItemLeftCollisionStartFunc(ref CollisionStruct collisionInstance)
        {
            if (collisionInstance.damageStruct.hitRagdollPart?.ragdoll?.creature != null)
                return;

            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionInstance.damageStruct.damageType, collisionInstance.sourceMaterial, collisionInstance.targetMaterial);
            tactsuitVr.ProvideHapticFeedbackThread(0, 0, feedback, collisionInstance.intensity, false, true);
            LOG("Left hand item with (" + (collisionInstance.sourceCollider != null ? collisionInstance.sourceCollider.name : "") + ") collides with something (" + (collisionInstance.targetCollider != null ? collisionInstance.targetCollider.name : "") + ") with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : "") + " MaterialEffect:" + (collisionInstance.damageStruct.materialEffectData != null ? collisionInstance.damageStruct.materialEffectData.id : "") + " DamageType: " + Utility.GetDamageTypeName(collisionInstance.damageStruct.damageType));
        }

        private void RightProjectileRemovedFunc(Item item)
        {
            if (!gamePaused && !GameManager.timeStopped && item != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnholsterArrowRightShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Arrow unholstered on right shoulder: " + item.name);
            }
        }

        private void RightProjectileAddedFunc(Item item)
        {
            if (!gamePaused && !GameManager.timeStopped && item != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HolsterArrowRightShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Arrow holstered on right shoulder: " + item.name);
            }
        }

        private void LeftProjectileRemovedFunc(Item item)
        {
            if (!gamePaused && !GameManager.timeStopped && item != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnholsterArrowLeftShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Arrow unholstered on right shoulder: " + item.name);
            }
        }

        private void LeftProjectileAddedFunc(Item item)
        {
            if (!gamePaused && !GameManager.timeStopped && item != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HolsterArrowLeftShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Arrow holstered on right shoulder: " + item.name);
            }
        }

        private void UnHolsterRightShoulderFunc(Item item)
        {
            if (!gamePaused && !GameManager.timeStopped && item != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnholsterRightShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                if (item.data.type == ItemPhysic.Type.Quiver)
                {
                    ItemQuiver quiver = item.GetComponent<ItemQuiver>();
                    if (quiver?.holder != null)
                    {
                        quiver.holder.Snapped -= new ObjectHolder.HolderDelegate(RightProjectileAddedFunc);
                        quiver.holder.UnSnapped -= new ObjectHolder.HolderDelegate(RightProjectileRemovedFunc);
                    }
                }

                LOG("Item unholstered on right shoulder: " + item.name);
            }
        }

        private void HolsterRightShoulderFunc(Item item)
        {
            if (!gamePaused && !GameManager.timeStopped && item != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HolsterRightShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                if (item.data.type == ItemPhysic.Type.Quiver)
                {
                    ItemQuiver quiver = item.GetComponent<ItemQuiver>();
                    if (quiver?.holder != null)
                    {
                        quiver.holder.Snapped += new ObjectHolder.HolderDelegate(RightProjectileAddedFunc);
                        quiver.holder.UnSnapped += new ObjectHolder.HolderDelegate(RightProjectileRemovedFunc);
                    }
                }

                LOG("Item holstered on right shoulder: " + item.name);
            }
        }

        private void UnHolsterLeftShoulderFunc(Item item)
        {
            if (!gamePaused && !GameManager.timeStopped && item != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.UnholsterLeftShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                if (item.data.type == ItemPhysic.Type.Quiver)
                {
                    ItemQuiver quiver = item.GetComponent<ItemQuiver>();
                    if (quiver?.holder != null)
                    {
                        quiver.holder.Snapped -= new ObjectHolder.HolderDelegate(LeftProjectileAddedFunc);
                        quiver.holder.UnSnapped -= new ObjectHolder.HolderDelegate(LeftProjectileRemovedFunc);
                    }
                }

                LOG("Item unholstered on left shoulder: " + item.name);
            }
        }

        private void HolsterLeftShoulderFunc(Item item)
        {
            if (!gamePaused && !GameManager.timeStopped && item != null)
            {
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HolsterLeftShoulder, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                if (item.data.type == ItemPhysic.Type.Quiver)
                {
                    ItemQuiver quiver = item.GetComponent<ItemQuiver>();
                    if (quiver?.holder != null)
                    {
                        quiver.holder.Snapped += new ObjectHolder.HolderDelegate(LeftProjectileAddedFunc);
                        quiver.holder.UnSnapped += new ObjectHolder.HolderDelegate(LeftProjectileRemovedFunc);
                    }
                }

                LOG("Item holstered on left shoulder: " + item.name);
            }
        }
        
        private void BeingPushedFunc()
        {
            while (!gamePaused && !GameManager.timeStopped && Player.local.body.creature.state != Creature.State.Dead && !Player.local.locomotion.isEnabled && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.rb.velocity.magnitude >= 0.1f)
            {
                Vector3 contactPoint = Player.local.locomotion.transform.position - Player.local.locomotion.rb.velocity;
                float hitAngle = Utility.GetAngleForPosition(contactPoint);

                float intensity = Player.local.locomotion.rb.velocity.magnitude / 5f;
                tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                if (GravityEffectOnHead)
                {
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageHeadGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                }
                if (GravityEffectOnArms)
                {
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageRightArmGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageRightArmGravity, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                }

                Thread.Sleep(SleepDurationSpellHit);
            }

            beingPushed = false;
        }

        private void BeingPulledFunc(Side side)
        {
            if (Player.local?.body?.creature != null)
            {
                if (side == Side.Left)
                {
                    Item leftItem = Player.local.body.creature.GetHeldobject(Side.Left);
                    while (!beingPushed && !gamePaused && !GameManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.body.creature.state != Creature.State.Dead && Player.local.locomotion.rb.velocity.magnitude > 1f && Player.local.locomotion.rb.velocity.y >= 0f && leftItem != null && leftItem.name.Contains("Grapple") && leftItemUseStarted)
                    {
                        float intensity = Player.local.locomotion.rb.velocity.magnitude / 3f;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);

                        Thread.Sleep(SleepDurationSpellCast);
                    }

                    beingPulledLeft = false;
                }
                else
                {
                    Item rightItem = Player.local.body.creature.GetHeldobject(Side.Right);

                    while (!beingPushed && !gamePaused && !GameManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.body.creature.state != Creature.State.Dead && Player.local.locomotion.rb.velocity.magnitude > 1f && Player.local.locomotion.rb.velocity.y >= 0f && rightItem != null && rightItem.name.Contains("Grapple") && rightItemUseStarted)
                    {
                        float intensity = Player.local.locomotion.rb.velocity.magnitude / 3f;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);

                        Thread.Sleep(SleepDurationClimb);
                    }
                    beingPulledRight = false;
                }
            }
        }

        private void BeingPushedOtherFunc()
        {
            while (!beingPushed && !gamePaused && !GameManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.body.creature.state != Creature.State.Dead && Player.local.locomotion.rb.velocity.magnitude > 1f)
            {
                Vector3 contactPoint = Player.local.locomotion.transform.position - Player.local.locomotion.rb.velocity;
                float hitAngle = Utility.GetAngleForPosition(contactPoint);

                float intensity = Player.local.locomotion.rb.velocity.magnitude / 5f;
                tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.Explosion, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
               
                Thread.Sleep(SleepDurationSpellHit);
            }

            beingPushedOther = false;
        }

        private void BowStringFunc(Side side)
        {
            Item leftItem = Player.local.body.creature.GetHeldWeapon(Side.Left);
            Item rightItem = Player.local.body.creature.GetHeldWeapon(Side.Right);

            BowString bowString = leftItem?.GetComponentInChildren<BowString>() ?? rightItem?.GetComponentInChildren<BowString>();

            while (bowString != null && bowStringHeld)
            {
                if (GameManager.timeStopped)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                if (Player.local?.body?.creature == null)
                    break;

                leftItem = Player.local.body.creature.GetHeldWeapon(Side.Left);
                rightItem = Player.local.body.creature.GetHeldWeapon(Side.Right);

                if (leftItem == null && rightItem == null)
                    break;

                if ((leftItem != null && leftItem.GetComponentInChildren<BowString>() == null) && (rightItem != null && rightItem.GetComponentInChildren<BowString>() == null))
                {
                    break;
                }

                if (leftItem == rightItem && bowString.isPulling)
                {
                    float intensity = Utility.GetCurrentPull(bowString) + 0.1f / bowString.maxPull;
                    if (intensity >= 0.1f && intensity < 0.2f)
                        intensity = 0.2f;

                    if (side == Side.Right)
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerBowPullRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    else
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerBowPullRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                }

                Thread.Sleep(SleepDurationBowString);
            }
        }

        private void ClimbingFunc(Side side)
        {
            if (side == Side.Left)
            {
                float lastIntensity = 0;
                while (!GameManager.timeStopped && leftHandClimbing)
                {
                    float intensity = Math.Abs(Player.local.handLeft.transform.position.y - Player.local.head.transform.position.y);
                    //LOG("***> Climbing left debug: " + lastIntensity + " - " + intensity + ">=0.03f");
                    if (Math.Abs(lastIntensity - intensity) >= 0.03f)
                    {
                        lastIntensity = intensity;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, (leftHandClimbing && rightHandClimbing) ? intensity/2f : intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    }

                    Thread.Sleep(SleepDurationClimb);
                }

                leftHandClimbing = false;
            }
            else
            {
                float lastIntensity = 0;
                while (!GameManager.timeStopped && rightHandClimbing)
                {
                    float intensity = Math.Abs(Player.local.handRight.transform.position.y - Player.local.head.transform.position.y);
                    //LOG("***> Climbing right debug: " + lastIntensity + " - " + intensity + ">=0.03f");
                    if (Math.Abs(lastIntensity - intensity) >= 0.03f)
                    {
                        lastIntensity = intensity;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, (leftHandClimbing && rightHandClimbing) ? intensity / 2f : intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    }

                    Thread.Sleep(SleepDurationClimb);
                }

                rightHandClimbing = false;
            }
        }

        private void UnGrabFunc(Side side, Handle handle, bool throwing, EventTime eventTime)
        {
            if (eventTime != EventTime.OnEnd)
                return;

            if (handle != null)
            {
                if (handle.name == "HandleString" && handle.item?.data?.moduleAI?.weaponClass == ItemModuleAI.WeaponClass.Bow)
                {
                    bowStringHeld = false;
                }
                else //if (handle?.item?.data?.moduleAI?.weaponClass != ItemModuleAI.WeaponClass.None)
                {
                    if (handle?.item != null)
                    {
                        if (side == Side.Left)
                        {
                            ItemHeldInLeftHand = false;
                            foreach (var collisionHandler in handle.item.definition.collisionHandlers)
                            {
                                if (collisionHandler != null)
                                {
                                    collisionHandler.OnCollisionStartEvent -= HeldItemLeftCollisionStartFunc;
                                }
                            }
                            handle.item.OnHeldActionEvent -= LeftItemHeldActionEventFunc;
                            leftItemUseStarted = false;
                            leftItemAltUseStarted = false;
                        }
                        else
                        {
                            ItemHeldInRightHand = false;
                            foreach (var collisionHandler in handle.item.definition.collisionHandlers)
                            {
                                if (collisionHandler != null)
                                {
                                    collisionHandler.OnCollisionStartEvent -= HeldItemRightCollisionStartFunc;
                                }
                            }
                            handle.item.OnHeldActionEvent -= RightItemHeldActionEventFunc;
                            rightItemUseStarted = false;
                            rightItemAltUseStarted = false;
                        }
                    }
                }

                LOG("Ungrabbed handle with " + (side == Side.Left ? "left" : "right") + " hand. Handle Name: " + handle.name);
            }
        }

        private void RightItemHeldActionEventFunc(Interactor interactor, Handle handle, Interactable.Action action)
        {
            if (action == Interactable.Action.UseStart)
            {
                rightItemUseStarted = true;

                if (Player.local?.body?.creature != null)
                {
                    Item rightItem = Player.local?.body?.creature.GetHeldobject(Side.Right);

                    if (rightItem != null && rightItem.name.Contains("Grapple"))
                    {
                        if (!noExplosionFeedback)
                        {
                            noExplosionFeedback = true;
                            Thread thread = new Thread(ExplosionWaitFunc);
                            thread.Start();
                        }
                    }
                }
            }
            else if (action == Interactable.Action.UseStop)
            {
                rightItemUseStarted = false;
            }
            else if (action == Interactable.Action.AlternateUseStart)
            {
                rightItemAltUseStarted = true;
            }
            else if (action == Interactable.Action.AlternateUseStop)
            {
                rightItemAltUseStarted = false;
            }
            else if (action == Interactable.Action.Ungrab)
            {
                rightItemUseStarted = false;
                rightItemAltUseStarted = false;
            }
        }

        private void LeftItemHeldActionEventFunc(Interactor interactor, Handle handle, Interactable.Action action)
        {
            if (action == Interactable.Action.UseStart)
            {
                leftItemUseStarted = true;

                if(Player.local?.body?.creature != null)
                {
                    Item leftItem = Player.local?.body?.creature.GetHeldobject(Side.Left);

                    if (leftItem != null && leftItem.name.Contains("Grapple"))
                    {
                        if (!noExplosionFeedback)
                        {
                            noExplosionFeedback = true;
                            Thread thread = new Thread(ExplosionWaitFunc);
                            thread.Start();
                        }
                    }
                }
            }
            else if (action == Interactable.Action.UseStop)
            {
                leftItemUseStarted = false;
            }
            else if (action == Interactable.Action.AlternateUseStart)
            {
                leftItemAltUseStarted = true;
            }
            else if (action == Interactable.Action.AlternateUseStop)
            {
                leftItemAltUseStarted = false;
            }
            else if (action == Interactable.Action.Ungrab)
            {
                leftItemUseStarted = false;
                leftItemAltUseStarted = false;
            }
        }

        private void GrabFunc(Side side, Handle handle, float axisPosition, HandleOrientation orientation, EventTime eventTime)
        {
            if (eventTime != EventTime.OnStart)
            {
                return;
            }
            
            if (Player.local?.head != null && Player.local?.body?.creature != null)
            {
                string objectName = "";
                if (handle.gameObject != null)
                    objectName += handle.gameObject.name;
                if (handle.item != null)
                    objectName += " " + handle.item.name;

                LOG("Grabbed handle with " + (side == Side.Left ? "left" : "right") + " hand. Object Name: " + objectName);


                if (handle !=null)
                {
                    if (handle?.name == "HandleString" && handle?.item?.data?.moduleAI?.weaponClass == ItemModuleAI.WeaponClass.Bow)
                    {
                        LOG("...it is a bow string, grabbed with " + (side == Side.Right ? "right" : "left") + "hand.");
                        if (!bowStringHeld)
                        {
                            bowStringHeld = true;
                            Thread thread = new Thread(() => BowStringFunc(side));
                            thread.Start();
                        }

                        return;
                    }
                    else 
                    {
                        if (handle.item != null)
                        {
                            LOG("...grabbed with " + (side == Side.Right ? "right" : "left") + "hand.");
                            if (side == Side.Left)
                            {
                                if (!ItemHeldInLeftHand)
                                {
                                    ItemHeldInLeftHand = true;
                                    foreach (var collisionHandler in handle.item.definition.collisionHandlers)
                                    {
                                        if (collisionHandler != null)
                                        {
                                            collisionHandler.OnCollisionStartEvent += HeldItemLeftCollisionStartFunc;
                                        }
                                    }
                                    handle.item.OnHeldActionEvent += LeftItemHeldActionEventFunc;
                                }
                            }
                            else
                            {
                                if (!ItemHeldInRightHand)
                                {
                                    ItemHeldInRightHand = true;
                                    foreach (var collisionHandler in handle.item.definition.collisionHandlers)
                                    {
                                        if (collisionHandler != null)
                                        {
                                            collisionHandler.OnCollisionStartEvent += HeldItemRightCollisionStartFunc;
                                        }
                                    }
                                    handle.item.OnHeldActionEvent += RightItemHeldActionEventFunc;
                                }
                            }

                            return;
                        }
                    }
                }
            }
        }

        private void OnDamageFunc(ref CollisionStruct collisionstruct)
        {
            if (collisionstruct.targetCollider == null && collisionstruct.sourceCollider == null)
            {
                if (collisionstruct.damageStruct.damage > TOLERANCE)
                {
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.DefaultDamage, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    LOG("Player other damage by Damager: " + (collisionstruct.damageStruct.damager != null ? collisionstruct.damageStruct.damager.name : "") + " Imbue: " + (collisionstruct.damageStruct.damager?.damagerImbue != null ? collisionstruct.damageStruct.damager.damagerImbue.name : " None") + " Amount: " + collisionstruct.damageStruct.damage.ToString(CultureInfo.InvariantCulture) + " Source: " + (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown") + " on " + (collisionstruct.targetCollider != null ? collisionstruct.targetCollider.name : "whole body") + " with Intensity:" + collisionstruct.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionstruct.sourceMaterial != null && collisionstruct.targetMaterial != null) ? ("Materials: " + collisionstruct.sourceMaterial.id + " > " + collisionstruct.targetMaterial.id) : "") + " DamageType: " + Utility.GetDamageTypeName(collisionstruct.damageStruct.damageType) + " Penetration: " + ((collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? (collisionstruct.damageStruct.damager.data.penetrationSize == DamagerData.PenetrationSize.Small ? "Small" : "Large") : ""));
                }
            }
        }

        private void OnPlayerSpawnFunc(Player player)
        {
            if (player.isLocal)
            {
                //if(!playerEventsCreated)
                //{
                //    playerEventsCreated = true;
                Thread thread = new Thread(CheckPlayerSpawn);
                thread.Start();
                //}
            }
        }

        private void OnGroundFunc(bool grounded, Vector3 velocity)
        {
            if (NoFallEffectWhenFallDamageIsDisabled && !Health.playerFallDamage)
            {
                return;
            }

            if (grounded && Player.local?.body?.creature?.data != null)
            {
                //Play default damage effect
                float damage = Player.local.body.creature.data.playerFallDamageCurve.Evaluate(velocity.magnitude);
                if (damage > 1.0f)
                {
                    float intensity = damage / 20.0f;
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamage, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamageFeet, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    LOG("Player grounded damage. Amount: " + damage.ToString(CultureInfo.InvariantCulture) + " Intensity: " + intensity.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    if (velocity.magnitude > FallEffectMinVelocityMagnitude)
                    {
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamageFeet, false, velocity.magnitude / 50.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.FallDamage, false, velocity.magnitude / 50.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                    }
                }
            }
        }

        private void OnLiquidReceptionFunc(ItemModulePotion.Content content)
        {
            if (content.liquid.type != ItemModulePotion.Liquid.Type.Poison)
            {
                //Play just drinking effect
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PotionDrinking, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Player potion drinking. Amount: " + content.liquid.value.ToString(CultureInfo.InvariantCulture) + " Level: " + content.level.ToString(CultureInfo.InvariantCulture));
            }
            else //Poison
            {
                //Play drinking effect and poisoned effect
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PoisonDrinking, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Player poison drinking. Amount: " + content.liquid.value.ToString(CultureInfo.InvariantCulture) + " Level: " + content.level.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void HeartBeatFunc()
        {
            while (!GameManager.timeStopped && !gamePaused && Heartbeating)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HeartBeat, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                Thread.Sleep(SleepDurationHeartBeat);
            }
        }

        private void HeartBeatFastFunc()
        {
            while (!GameManager.timeStopped && !gamePaused && HeartbeatingFast)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HeartBeatFast, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                Thread.Sleep(SleepDurationHeartBeatFast);
            }
        }

        private void SlowMotionFunc()
        {
            while (!GameManager.timeStopped && GameManager.slowMotionState == GameManager.SlowMotionState.Running)
            {
                tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.SlowMotion, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                Thread.Sleep(SleepDurationSlowMotion);
            }
        }

        private void ExplosionWaitFunc()
        {
            while (true)
            {
                Thread.Sleep(5000);
                if (Player.local?.body?.creature != null && Player.local?.locomotion != null)
                {
                    Item rightItem = Player.local?.body?.creature.GetHeldobject(Side.Right);

                    if (rightItem != null && rightItem.name.Contains("Grapple") && rightItemUseStarted)
                    {
                        continue;
                    }

                    Item leftItem = Player.local?.body?.creature.GetHeldobject(Side.Left);

                    if (leftItem != null && leftItem.name.Contains("Grapple") && leftItemUseStarted)
                    {
                        continue;
                    }

                    break;
                }
                else
                {
                    break;
                }
            }

            noExplosionFeedback = false;
        }

        private void FireLeftShoulderTurret()
        {
            if (tactsuitVr != null)
            {
                while (!gamePaused && !GameManager.timeStopped && (leftShoulderTurretShootVFX != null && leftShoulderTurretShootVFX.isPlaying))
                {
                    tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.LeftShoulderTurret, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                    Thread.Sleep(SleepDurationShootGun);
                }

                LOG("Player stopped firing left shoulder turret.");

                shootingLeftShoulderTurret = false;
            }
        }

        private void FireHoverJet()
        {
            if (tactsuitVr != null)
            {
                while (!gamePaused && !GameManager.timeStopped && (hoverJetVFX != null && hoverJetVFX.isPlaying))
                {
                    tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.HoverJetFeet, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                    Thread.Sleep(SleepDurationShootGun);
                }

                LOG("Player stopped hovering.");

                hoveringWithHoverJet = false;
            }
        }

        private void FireGun(string name, string displayname, bool altFire, bool leftHand)
        {
            if (tactsuitVr != null)
            {
                TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(name, displayname);
                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.FeedbackType.NoFeedback;
                if (!name.Contains("Grapple"))
                {
                    feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, leftHand ? Side.Left : Side.Right);
                }

                if (leftHand)
                {
                    while (!gamePaused && !GameManager.timeStopped 
                                       && ((leftItemUseStarted && !altFire && (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying)))) 
                                           ||(leftItemAltUseStarted && altFire && (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying))))))
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(SleepDurationShootGun);
                    }
                    LOG("Player stopped " + (altFire ? "alt" : "") + " firing left gun: " + name);

                    if (altFire) altShootingLeftGun = false;
                    else shootingLeftGun = false;
                }
                else
                {
                    while (!gamePaused && !GameManager.timeStopped
                                       && ((rightItemUseStarted && !altFire && (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying))))
                                            || (rightItemAltUseStarted && altFire && (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying))))))
                    {
                        
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(SleepDurationShootGun);
                    }
                    LOG("Player stopped " + (altFire ? "alt" : "") + " firing right gun: " + name);

                    if (altFire) altShootingRightGun = false;
                    else shootingRightGun = false;
                }
            }
        }

        private void SpellCastFunc(string spellId, bool leftHand)
        {
            if (tactsuitVr != null)
            {
                TactsuitVR.FeedbackType feedback = TactsuitVR.GetSpellFeedbackFromId(spellId);
                if (leftHand)
                {
                    while (!GameManager.timeStopped && CastingLeft && spellId == CastingLeftSpellId)
                    {
                        if (Player.local != null && Player.local.body != null && Player.local.body.creature != null
                            && Player.local.body.creature.mana != null && Player.local.body.creature.mana.casterLeft != null)
                        {
                            float intensity = 1.0f;
                            if (Player.local.body.creature.mana.casterLeft.spellInstance is SpellCastCharge)
                            {
                                SpellCastCharge scc = (Player.local.body.creature.mana.casterLeft.spellInstance as SpellCastCharge);
                                if (scc != null)
                                {
                                    intensity = scc.currentCharge;
                                    if (intensity < 0.2f)
                                        intensity = 0.2f;
                                }
                            }

                            if ((bool) (UnityEngine.Object) Player.local.body.creature.mana.casterLeft.bodyHand.interactor.grabbedHandle)
                            {
                                intensity *= 0.5f;
                            }

                            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                            Thread.Sleep(SleepDurationSpellCast);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    while (!GameManager.timeStopped && CastingRight && spellId == CastingRightSpellId)
                    {
                        if (Player.local != null && Player.local.body != null && Player.local.body.creature != null
                            && Player.local.body.creature.mana != null && Player.local.body.creature.mana.casterRight != null)
                        {
                            float intensity = 1.0f;
                            if (Player.local.body.creature.mana.casterRight.spellInstance is SpellCastCharge)
                            {
                                SpellCastCharge scc = (Player.local.body.creature.mana.casterRight.spellInstance as SpellCastCharge);
                                if (scc != null)
                                {
                                    intensity = scc.currentCharge;
                                    if (intensity < 0.2f)
                                        intensity = 0.2f;
                                }
                            }

                            if ((bool) (UnityEngine.Object) Player.local.body.creature.mana.casterRight.bodyHand.interactor.grabbedHandle)
                            {
                                intensity *= 0.5f;
                            }

                            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                            Thread.Sleep(SleepDurationSpellCast);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void TelekinesisActivateFunc(bool leftHand)
        {
            if (tactsuitVr != null)
            {
                while (!GameManager.timeStopped && ((TelekinesisActiveLeft && leftHand) || (TelekinesisActiveRight && !leftHand)))
                {
                    if ((leftHand && Player.local.body.creature.GetHeldobject(Side.Left)) || (!leftHand && Player.local.body.creature.GetHeldobject(Side.Right)))
                        break;

                    tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerTelekinesisActiveRight, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, leftHand ? true : false);
                    Thread.Sleep(SleepDurationSpellCast);
                }
                tactsuitVr.PauseHapticFeedBack(TactsuitVR.FeedbackType.PlayerTelekinesisActiveRight);
            }
        }

        private void TelekinesisFunc(bool pull, bool leftHand)
        {
            if (tactsuitVr != null)
            {
                TactsuitVR.FeedbackType feedback = pull ? (TactsuitVR.FeedbackType.PlayerTelekinesisPullRight) : (TactsuitVR.FeedbackType.PlayerTelekinesisRepelRight);
                
                while (!GameManager.timeStopped && ((TelekinesisPullRight && pull) || (TelekinesisRepelRight && !pull)))
                {
                    if ((leftHand && Player.local.body.creature.GetHeldobject(Side.Left)) || (!leftHand && Player.local.body.creature.GetHeldobject(Side.Right)))
                        break;

                    tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, leftHand ? true : false);
                    Thread.Sleep(SleepDurationSpellCast);
                }
                tactsuitVr.PauseHapticFeedBack(feedback);
            }
        }

        private void CheckStates(Creature creature)
        {
            if (creature != null)
            {
                #region Heartbeat Check

                if (creature.health != null)
                {
                    if (!gamePaused && creature.state != Creature.State.Dead && !creature.health.isKilled && creature.health.currentHealth <= creature.health.maxHealth * 0.1f && creature.health.currentHealth > 0.01f)
                    {
                        Heartbeating = false;
                        if (!HeartbeatingFast)
                        {
                            HeartbeatingFast = true;
                            Thread thread = new Thread(HeartBeatFastFunc);
                            thread.Start();
                        }
                    }
                    else if (!gamePaused && creature.state != Creature.State.Dead && !creature.health.isKilled && creature.health.currentHealth <= creature.health.maxHealth * 0.2f && creature.health.currentHealth > 0.01f)
                    {
                        HeartbeatingFast = false;
                        if (!Heartbeating)
                        {
                            Heartbeating = true;
                            Thread thread = new Thread(HeartBeatFunc);
                            thread.Start();
                        }
                    }
                    else
                    {
                        HeartbeatingFast = false;
                        Heartbeating = false;
                    }
                }
                else
                {
                    HeartbeatingFast = false;
                    Heartbeating = false;
                }

                #endregion

                #region Slow Motion

                if (slowMotionActive)
                {
                    if (GameManager.slowMotionState != GameManager.SlowMotionState.Running)
                    {
                        slowMotionActive = false;
                    }
                }
                else
                {
                    if (GameManager.slowMotionState == GameManager.SlowMotionState.Running)
                    {
                        slowMotionActive = true;
                        Thread thread = new Thread(SlowMotionFunc);
                        thread.Start();
                    }
                }

                #endregion

                #region Pushed

                if (Player.local.locomotion.isGrounded && !Player.local.locomotion.isEnabled && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.rb.velocity.magnitude >= 0.1f && (hoverJetVFX == null))
                {
                    if (!beingPushed)
                    {
                        beingPushed = true;

                        Thread thread = new Thread(BeingPushedFunc);
                        thread.Start();
                        LOG("Player is being pushed by a force.");
                    }
                }

                if (!beingPushed && (hoverJetVFX == null))
                {
                    Item leftItem = creature.GetHeldobject(Side.Left);
                    Item rightItem = creature.GetHeldobject(Side.Right);

                    if (!noExplosionFeedback && Player.local.locomotion.isGrounded && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.rb.velocity.magnitude > 5f && Player.local.locomotion.rb.velocity.y>=-TOLERANCE
                     && (leftItem == null || (leftItem != null && !leftItemUseStarted) || (leftItem != null && leftItemUseStarted && !leftItem.name.Contains("Grapple")))
                     && (rightItem == null || (rightItem != null && !rightItemUseStarted) || (rightItem != null && rightItemUseStarted && !rightItem.name.Contains("Grapple"))))
                    {
                        if (!beingPushedOther)
                        {
                            beingPushedOther = true;

                            Thread thread = new Thread(BeingPushedOtherFunc);
                            thread.Start();
                            LOG("Player is being pushed by a strong force like explosion.");
                        }
                    }
                    else
                    {
                        if (Player.local.locomotion.rb.velocity.magnitude > 3f && Player.local.locomotion.rb.velocity.y >=-TOLERANCE)
                        {
                            if (leftItem != null && leftItem.name.Contains("Grapple") && leftItemUseStarted)
                            {
                                if (!beingPulledLeft)
                                {
                                    beingPulledLeft = true;

                                    Thread thread = new Thread(()=> BeingPulledFunc(Side.Left));
                                    thread.Start();
                                    LOG("Player is being pulled by grappling hook left.");
                                }
                            }

                            if (rightItem != null && rightItem.name.Contains("Grapple") && rightItemUseStarted)
                            {
                                if (!beingPulledRight)
                                {
                                    beingPulledRight = true;

                                    Thread thread = new Thread(() => BeingPulledFunc(Side.Right));
                                    thread.Start();
                                    LOG("Player is being pulled by grappling hook right.");
                                }
                            }
                        }
                    }
                }

                #endregion
                
                #region SuddenStop

                if (Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.rb.velocity.magnitude < 0.1f && lastFrameVelocity.magnitude > 5.0f)
                {
                    float hitAngle = Utility.GetAngleForPosition(Player.local.transform.position + lastFrameVelocity);

                    LOG("Hit a wall. Velocity before hit: " + lastFrameVelocity.magnitude.ToString(CultureInfo.InvariantCulture) + " Angle: " + hitAngle.ToString(CultureInfo.InvariantCulture));
                    tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestBluntStoneLarge, false, lastFrameVelocity.magnitude/10f, TactsuitVR.FeedbackType.NoFeedback, false);
                }

                lastFrameVelocity = Player.local.locomotion.rb.velocity;

                #endregion

                #region Telekinesis

                if (creature.mana != null)
                {
                    if (creature.mana.casterLeft != null && creature.mana.casterLeft.telekinesis != null)
                    {
                        if (creature.mana.casterLeft.telekinesis.catchedHandle != null)
                        {
                            if (!TelekinesisActiveLeft)
                            {
                                TelekinesisActiveLeft = true;
                                Thread thread = new Thread(() => TelekinesisActivateFunc(true));
                                thread.Start();
                                LOG("Player is activating with telekinesis left hand.");
                            }
                        }
                        else
                        {
                            if (TelekinesisActiveLeft)
                            {
                                TelekinesisActiveLeft = false;
                                LOG("Player stops activating telekinesis left hand.");
                            }
                        }

                        if (creature.mana.casterLeft.telekinesis.pullSpeed > 0)
                        {
                            if (!TelekinesisPullLeft)
                            {
                                TelekinesisPullLeft = true;
                                Thread thread = new Thread(() => TelekinesisFunc(true, true));
                                thread.Start();
                                LOG("Player is pulling with telekinesis left hand.");
                            }
                        }
                        else
                        {
                            if (TelekinesisPullLeft)
                            {
                                TelekinesisPullLeft = false;
                                LOG("Player stops pulling with telekinesis left hand.");
                            }
                        }

                        if (creature.mana.casterLeft.telekinesis.repelSpeed > 0)
                        {
                            if (!TelekinesisRepelLeft)
                            {
                                TelekinesisRepelLeft = true;
                                Thread thread = new Thread(() => TelekinesisFunc(false, true));
                                thread.Start();
                                LOG("Player is repelling with telekinesis left hand.");
                            }
                        }
                        else
                        {
                            if (TelekinesisRepelLeft)
                            {
                                TelekinesisRepelLeft = false;
                                LOG("Player stops repelling with telekinesis left hand.");
                            }
                        }
                        if (creature.mana.casterLeft.telekinesis.justCatched)
                        {
                            if (TelekinesisCatchLeftLast == false)
                            {
                                TelekinesisCatchLeftLast = true;
                                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerTelekinesisCatchRight, true, creature.mana.casterLeft.telekinesis.pullSpeed / creature.mana.casterLeft.telekinesis.pullAndRepelMaxSpeed, TactsuitVR.FeedbackType.NoFeedback, true);
                                LOG("Player catched item with left hand.");
                            }
                        }
                        else
                        {
                            TelekinesisCatchLeftLast = false;
                        }
                    }

                    if (creature.mana.casterRight != null && creature.mana.casterRight.telekinesis != null)
                    {
                        if (creature.mana.casterRight.telekinesis.catchedHandle != null)
                        {
                            if (!TelekinesisActiveRight)
                            {
                                TelekinesisActiveRight = true;
                                Thread thread = new Thread(() => TelekinesisActivateFunc(false));
                                thread.Start();
                                LOG("Player is activating with telekinesis right hand.");
                            }
                        }
                        else
                        {
                            if (TelekinesisActiveRight)
                            {
                                TelekinesisActiveRight = false;
                                LOG("Player stops activating telekinesis right hand.");
                            }
                        }

                        if (creature.mana.casterRight.telekinesis.pullSpeed > 0)
                        {
                            if (!TelekinesisPullRight)
                            {
                                TelekinesisPullRight = true;
                                Thread thread = new Thread(() => TelekinesisFunc(true, false));
                                thread.Start();
                                LOG("Player is pulling with telekinesis right hand.");
                            }
                        }
                        else
                        {
                            if (TelekinesisPullRight)
                            {
                                TelekinesisPullRight = false;
                                LOG("Player stops pulling with telekinesis right hand.");
                            }
                        }

                        if (creature.mana.casterRight.telekinesis.repelSpeed > 0)
                        {
                            if (!TelekinesisRepelRight)
                            {
                                TelekinesisRepelRight = true;
                                Thread thread = new Thread(() => TelekinesisFunc(false, false));
                                thread.Start();
                                LOG("Player is repelling with telekinesis right hand.");
                            }
                        }
                        else
                        {
                            if (TelekinesisRepelRight)
                            {
                                TelekinesisRepelRight = false;
                                LOG("Player stops repelling with telekinesis right hand.");
                            }
                        }

                        if (creature.mana.casterRight.telekinesis.justCatched)
                        {
                            if (TelekinesisCatchRightLast == false)
                            {
                                TelekinesisCatchRightLast = true;
                                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerTelekinesisCatchRight, true, creature.mana.casterRight.telekinesis.pullSpeed / creature.mana.casterRight.telekinesis.pullAndRepelMaxSpeed, TactsuitVR.FeedbackType.NoFeedback, false);
                                LOG("Player catched item with right hand.");
                            }
                        }
                        else
                        {
                            TelekinesisCatchRightLast = false;
                        }
                    }
                }

                #endregion

                #region Throw

                hapticCheckTimeLeft -= deltaTime;

                if (!GameManager.timeStopped && hapticCheckTimeLeft <= 0f)
                {
                    hapticCheckTimeLeft = 50;

                    if (PlayerControl.handLeft.hapticPlayClipEnabled && PlayerControl.handLeft.hapticPlayClip == Catalog.gameData.haptics.telekinesisThrow)
                    {
                        hapticCheckTimeLeft = 1000;
                        tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerThrowRight, true, PlayerControl.handLeft.hapticPlayClipAmplitude, TactsuitVR.FeedbackType.NoFeedback, true);
                    }
                }

                hapticCheckTimeRight -= deltaTime;

                if (!GameManager.timeStopped && hapticCheckTimeRight <= 0f)
                {
                    hapticCheckTimeRight = 50;

                    if (PlayerControl.handRight.hapticPlayClipEnabled && PlayerControl.handRight.hapticPlayClip == Catalog.gameData.haptics.telekinesisThrow)
                    {
                        hapticCheckTimeRight = 1000;
                        tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.PlayerThrowRight, true, PlayerControl.handRight.hapticPlayClipAmplitude, TactsuitVR.FeedbackType.NoFeedback, false);
                    }
                }

                #endregion

                #region Spell Cast Left Hand

                if (creature.mana != null && creature.mana.casterLeft != null && creature.mana.casterLeft.spellInstance != null && creature.mana.casterLeft.isFiring)
                {
                    if (!CastingLeft)
                    {
                        CastingLeft = true;
                        CastingLeftSpellId = creature.mana.casterLeft.spellInstance.id;
                        Thread thread = new Thread(() => SpellCastFunc(creature.mana.casterLeft.spellInstance.id, true));
                        thread.Start();
                        LOG("Player is firing left spell: " + creature.mana.casterLeft.spellInstance.id); //Fire-Gravity-Lightning
                    }
                }
                else
                {
                    if (CastingLeft)
                    {
                        CastingLeft = false;
                        CastingLeftSpellId = "";
                        LOG("Player stops firing left spell.");
                    }
                }

                #endregion

                #region Spell Cast Right Hand

                if (creature.mana != null && creature.mana.casterRight != null && creature.mana.casterRight.spellInstance != null && creature.mana.casterRight.isFiring)
                {
                    if (!CastingRight)
                    {
                        CastingRight = true;
                        CastingRightSpellId = creature.mana.casterRight.spellInstance.id;
                        Thread thread = new Thread(() => SpellCastFunc(creature.mana.casterRight.spellInstance.id, false));
                        thread.Start();
                        LOG("Player is firing right spell: " + creature.mana.casterRight.spellInstance.id); //Fire-Gravity-Lightning
                    }
                }
                else
                {
                    if (CastingRight)
                    {
                        CastingRight = false;
                        CastingRightSpellId = "";
                        LOG("Player stops firing right spell.");
                    }
                }

                #endregion

                #region Climbing

                climbingCheckTimeLeft -= deltaTime;

                if (!GameManager.timeStopped && climbingCheckTimeLeft <= 0f)
                {
                    climbingCheckTimeLeft = 300;

                    Item leftObject = creature.GetHeldobject(Side.Left);
                    Item rightObject = creature.GetHeldobject(Side.Right);

                    if ((leftObject == null && Player.local?.handLeft?.link != null && Player.local?.handLeft?.link.isActive == true && Player.local?.handLeft?.link.playerJointActive == true && Player.local?.handLeft?.itemHand != null && Player.local.handLeft.itemHand.isGripping)
                        || (creature.body.bodyIk != null && creature.body.bodyIk.handLeftEnabled && creature.body.bodyIk.handLeftTarget != null && leftObject == null && creature.GetHeldHandle(Side.Left) != null && Math.Abs(creature.body.bodyIk.GetHandPositionWeight(Side.Left) - 1f) < TOLERANCE))
                    {
                        if (!leftHandClimbing)
                        {
                            leftHandClimbing = true;
                            Thread thread = new Thread(() => ClimbingFunc(Side.Left));
                            thread.Start();
                            LOG("Left hand climbing...");
                        }
                    }
                    else
                    {
                        leftHandClimbing = false;
                    }

                    if ((rightObject == null && Player.local?.handRight?.link != null && Player.local?.handRight?.link.isActive == true && Player.local?.handRight?.link.playerJointActive == true && Player.local?.handRight?.itemHand != null && Player.local.handRight.itemHand.isGripping)
                      || (creature.body.bodyIk != null && creature.body.bodyIk.handRightEnabled && creature.body.bodyIk.handRightTarget != null && rightObject == null && creature.GetHeldHandle(Side.Right) != null && Math.Abs(creature.body.bodyIk.GetHandPositionWeight(Side.Right) - 1f) < TOLERANCE))
                    {
                        if (!rightHandClimbing)
                        {
                            rightHandClimbing = true;
                            Thread thread = new Thread(() => ClimbingFunc(Side.Right));
                            thread.Start();
                            LOG("Right hand climbing...");
                        }
                    }
                    else
                    {
                        rightHandClimbing = false;
                    }
                }

                #endregion

                #region Shooting a weapon

                shootGunCheckTimeLeft -= deltaTime;

                if (!GameManager.timeStopped && shootGunCheckTimeLeft <= 0f)
                {
                    shootGunCheckTimeLeft = 30;

                    Item leftItem = creature.GetHeldobject(Side.Left);
                    Item rightItem = creature.GetHeldobject(Side.Right);

                    if (leftItem != null)
                    {
                        ParticleSystem temp_leftItemShootVFX = null;

                        if (leftItem.definition?.GetCustomReference("FireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            temp_leftItemShootVFX = leftItem.definition.GetCustomReference("FireEffect").GetComponent<ParticleSystem>();
                        }

                        foreach (var vfx in VFXList)
                        {
                            if (leftItem.transform?.Find(vfx)?.gameObject?.GetComponentInChildren<ParticleSystem>() != null)
                            {
                                temp_leftItemShootVFX = leftItem.transform.Find(vfx).gameObject.GetComponentInChildren<ParticleSystem>();
                                if (temp_leftItemShootVFX != null)
                                    break;
                            }
                            else if (leftItem.definition?.GetCustomReference(vfx)?.GetComponent<ParticleSystem>() != null)
                            {
                                temp_leftItemShootVFX = (ParticleSystem) ((Component) ((ItemDefinition)leftItem.definition).GetCustomReference(vfx)).GetComponent<ParticleSystem>();
                                if (temp_leftItemShootVFX != null)
                                    break;
                            }
                        }

                        leftItemShootVFX = temp_leftItemShootVFX;

                        if (leftItem.definition?.GetCustomReference("AltFireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            leftItemShoot2VFX = leftItem.definition.GetCustomReference("AltFireEffect").GetComponent<ParticleSystem>();
                        }
                        else
                        {
                            leftItemShoot2VFX = null;
                        }

                        foreach (var sfx in SFXList)
                        {
                            if (leftItem.transform?.Find(sfx)?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                            {
                                leftItemShootSFX = leftItem.transform.Find(sfx).gameObject.GetComponentInChildren<AudioSource>();
                                if (leftItemShootSFX != null)
                                    break;
                            }
                            else if (leftItem.definition?.GetCustomReference(sfx)?.GetComponent<AudioSource>() != null)
                            {
                                leftItemShootSFX = (AudioSource) ((Component) ((ItemDefinition) leftItem.definition).GetCustomReference(sfx)).GetComponent<AudioSource>();
                                if (leftItemShootSFX != null)
                                    break;
                            }
                        }

                        if ((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying))
                        {
                            if (!GunUseMultipleShotMap.ContainsKey(leftItem.data.displayName))
                            {
                                LOG("ERROR: GunUseMultipleShotMap doesn't contain key for " + leftItem.data.displayName);
                            }
                            if (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying))
                                && (leftItemUseStarted && GunUseMultipleShotMap.ContainsKey(leftItem.data.displayName))) // Item allows use and use started
                            {
                                bool value = false;
                                if (GunUseMultipleShotMap.TryGetValue(leftItem.data.displayName, out value))
                                {
                                    if (value) //This item allows multi shots
                                    {
                                        if (!shootingLeftGun)
                                        {
                                            shootingLeftGun = true;
                                            Thread thread = new Thread(() => FireGun(leftItem.name, leftItem.data.displayName, false, true));
                                            thread.Start();
                                            LOG("Player is firing left gun: " + leftItem.data.displayName);
                                        }
                                    }
                                    else //This item doesn't allow multi shot. Don't play the effect until leftitemusestarted is first false, then true again.
                                    {
                                        leftItemUseStarted = false;
                                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(leftItem.name, leftItem.data.displayName);
                                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                                        if (!leftItem.name.Contains("Grapple"))
                                        {
                                            TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Left);
                                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                        }

                                        LOG("Fired left gun: " + leftItem.data.displayName);
                                    }
                                }
                            }
                            if (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying))
                                && (leftItemAltUseStarted && GunAltUseMultipleShotMap.ContainsKey(leftItem.data.displayName))) // Item allows alt use and use started
                            {
                                bool value = false;
                                if (GunAltUseMultipleShotMap.TryGetValue(leftItem.data.displayName, out value))
                                {
                                    if (value) //This item allows multi shots
                                    {
                                        if (!altShootingLeftGun)
                                        {
                                            altShootingLeftGun = true;
                                            Thread thread = new Thread(() => FireGun(leftItem.name, leftItem.data.displayName, true, true));
                                            thread.Start();
                                            LOG("Player is alt firing left gun: " + leftItem.data.displayName);
                                        }
                                    }
                                    else //This item doesn't allow multi shot. Don't play the effect until leftitemaltusestarted is first false, then true again.
                                    {
                                        leftItemAltUseStarted = false;
                                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(leftItem.name, leftItem.data.displayName);
                                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                                        if (!leftItem.name.Contains("Grapple"))
                                        {
                                            TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Left);
                                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                        }

                                        LOG("Alt Fired left gun: " + leftItem.data.displayName);
                                    }
                                }
                            }
                        }
                    }

                    if (rightItem != null)
                    {
                        ParticleSystem temp_rightItemShootVFX = null;
                        
                        if (rightItem.definition?.GetCustomReference("FireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            temp_rightItemShootVFX = rightItem.definition.GetCustomReference("FireEffect").GetComponent<ParticleSystem>();
                        }
                        else 
                        {
                            foreach (var vfx in VFXList)
                            {
                                if (rightItem.transform?.Find(vfx)?.gameObject?.GetComponentInChildren<ParticleSystem>() != null)
                                {
                                    temp_rightItemShootVFX = rightItem.transform.Find(vfx).gameObject.GetComponentInChildren<ParticleSystem>();
                                    if (temp_rightItemShootVFX != null)
                                        break;
                                }
                                else if (rightItem.definition?.GetCustomReference(vfx)?.GetComponent<ParticleSystem>() != null)
                                {
                                    temp_rightItemShootVFX = (ParticleSystem)((Component)((ItemDefinition)rightItem.definition).GetCustomReference(vfx)).GetComponent<ParticleSystem>();
                                    if (temp_rightItemShootVFX != null)
                                        break;
                                }
                            }
                        }

                        rightItemShootVFX = temp_rightItemShootVFX;

                        if (rightItem.definition?.GetCustomReference("AltFireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            rightItemShoot2VFX = rightItem.definition.GetCustomReference("AltFireEffect").GetComponent<ParticleSystem>();
                        }
                        else
                        {
                            rightItemShoot2VFX = null;
                        }

                        foreach (var sfx in SFXList)
                        {
                            if (rightItem.transform?.Find(sfx)?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                            {
                                rightItemShootSFX = rightItem.transform.Find(sfx).gameObject.GetComponentInChildren<AudioSource>();
                            }
                            else if (rightItem.definition?.GetCustomReference(sfx)?.GetComponent<AudioSource>() != null)
                            {
                                rightItemShootSFX = (AudioSource)((Component)((ItemDefinition)rightItem.definition).GetCustomReference(sfx)).GetComponent<AudioSource>();
                                if (rightItemShootSFX != null)
                                    break;
                            }
                        }

                        if ((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying))
                        {
                            if (!GunUseMultipleShotMap.ContainsKey(rightItem.data.displayName))
                            {
                                LOG("ERROR: GunUseMultipleShotMap doesn't contain key for " + rightItem.data.displayName);
                            }
                            if (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying)) 
                                && (rightItemUseStarted && GunUseMultipleShotMap.ContainsKey(rightItem.data.displayName))) // Item allows use and use started
                            {
                                bool value = false;
                                if (GunUseMultipleShotMap.TryGetValue(rightItem.data.displayName, out value))
                                {
                                    if (value) //This item allows multi shots
                                    {
                                        if (!shootingRightGun)
                                        {
                                            shootingRightGun = true;
                                            Thread thread = new Thread(() => FireGun(rightItem.name, rightItem.data.displayName, false, false));
                                            thread.Start();
                                            LOG("Player is firing right gun: " + rightItem.data.displayName);
                                        }
                                    }
                                    else //This item doesn't allow multi shot. Don't play the effect until rightitemusestarted is first false, then true again.
                                    {
                                        rightItemUseStarted = false;
                                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(rightItem.name, rightItem.data.displayName);
                                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                        if (!rightItem.name.Contains("Grapple"))
                                        {
                                            TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Right);
                                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                        }
                                        
                                        LOG("Fired right gun: " + rightItem.data.displayName);
                                    }
                                }
                            }
                            if (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying)) 
                                && (rightItemAltUseStarted && GunAltUseMultipleShotMap.ContainsKey(rightItem.data.displayName))) // Item allows alt use and use started
                            {
                                bool value = false;
                                if (GunAltUseMultipleShotMap.TryGetValue(rightItem.data.displayName, out value))
                                {
                                    if (value) //This item allows multi shots
                                    {
                                        if (!altShootingRightGun)
                                        {
                                            altShootingRightGun = true;
                                            Thread thread = new Thread(() => FireGun(rightItem.name, rightItem.data.displayName, true, false));
                                            thread.Start();
                                            LOG("Player is alt firing right gun: " + rightItem.data.displayName);
                                        }
                                    }
                                    else //This item doesn't allow multi shot. Don't play the effect until rightitemaltusestarted is first false, then true again.
                                    {
                                        rightItemAltUseStarted = false;
                                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(rightItem.name, rightItem.data.displayName);
                                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                        if (!rightItem.name.Contains("Grapple"))
                                        {
                                            TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Right);
                                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                        }

                                        LOG("Alt Fired right gun: " + rightItem.data.displayName);
                                    }
                                }
                            }
                        }
                    }

                    //Barzel support
                    if (creature?.animator?.GetBoneTransform(HumanBodyBones.LeftShoulder) != null && creature?.animator?.GetBoneTransform(HumanBodyBones.LeftShoulder).childCount > 0)
                    {
                        for (int i = 0; i < creature?.animator?.GetBoneTransform(HumanBodyBones.LeftShoulder).childCount; i++)
                        {
                            if (creature?.animator?.GetBoneTransform(HumanBodyBones.LeftShoulder)?.GetChild(i)?.Find("muzflash")?.gameObject != null)
                            {
                                leftShoulderTurretShootVFX = creature.animator.GetBoneTransform(HumanBodyBones.LeftShoulder).GetChild(i).Find("muzflash").gameObject.GetComponent<ParticleSystem>();
                                if (leftShoulderTurretShootVFX != null && leftShoulderTurretShootVFX.isPlaying)
                                {
                                    if (!shootingLeftShoulderTurret)
                                    {
                                        shootingLeftShoulderTurret = true;
                                        Thread thread = new Thread(FireLeftShoulderTurret);
                                        thread.Start();
                                        LOG("Player is firing left shoulder turret.");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        leftShoulderTurretShootVFX = null;
                    }

                    if (creature?.animator?.GetBoneTransform(HumanBodyBones.RightLowerLeg) != null && creature?.animator?.GetBoneTransform(HumanBodyBones.RightLowerLeg).childCount > 0)
                    {
                        for (int i = 0; i < creature.animator.GetBoneTransform(HumanBodyBones.RightLowerLeg).childCount; i++)
                        {
                            if (creature?.animator?.GetBoneTransform(HumanBodyBones.RightLowerLeg)?.GetChild(i)?.Find("Flames_vfx1")?.gameObject != null)
                            {
                                hoverJetVFX = creature.animator.GetBoneTransform(HumanBodyBones.RightLowerLeg).GetChild(i).Find("Flames_vfx1").gameObject.GetComponent<ParticleSystem>();
                                if (hoverJetVFX != null && hoverJetVFX.isPlaying)
                                {
                                    if (!hoveringWithHoverJet)
                                    {
                                        hoveringWithHoverJet = true;
                                        Thread thread = new Thread(FireHoverJet);
                                        thread.Start();
                                        LOG("Player is firing hover jet.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        hoverJetVFX = null;
                    }
                }

                #endregion
            }
            else
            {
                HeartbeatingFast = false;
                Heartbeating = false;
                CastingLeft = false;
                CastingRight = false;
            }
        }

        #endregion

        #region Events

        private void PlayerGotHit(CollisionStruct collisionstruct, bool kill, float fixedLocationHeight)
        {
            LOG("Player got hit by something. ImpactVelocity:" + collisionstruct.impactVelocity.magnitude.ToString(CultureInfo.InvariantCulture));

            float hitAngle = Utility.GetAngleForPosition(collisionstruct.contactPoint);
            Direction direction = Utility.GetDirectionFromVector(collisionstruct.impactVelocity, collisionstruct.contactPoint, hitAngle);

            string targetColliderName = collisionstruct.targetCollider != null ? collisionstruct.targetCollider.name : "";

            float locationHeight = fixedLocationHeight;

            string modifiedTargetColliderName = targetColliderName;
            bool heightCalculated = false;
            if (PlayFallbackEffectsForArmHead && !targetColliderName.IsNullOrEmpty())
            {
                if (targetColliderName.Contains("Head") && !tactsuitVr.hapticPlayer.IsActive(PositionType.Head))
                {
                    modifiedTargetColliderName = "Neck";
                    if (hitAngle > 90f && hitAngle < 270f) hitAngle = 180f;
                    else hitAngle = 0f;
                }
                else if(targetColliderName.Contains("Arm"))
                {
                    if (targetColliderName.Contains("Left") && !tactsuitVr.hapticPlayer.IsActive(PositionType.ForearmL))
                    {
                        modifiedTargetColliderName = "Part_LeftShoulder";
                        locationHeight = 0.45f;
                        hitAngle = 90f;
                        heightCalculated = true;
                    }
                    else if (targetColliderName.Contains("Right") && !tactsuitVr.hapticPlayer.IsActive(PositionType.ForearmR))
                    {
                        modifiedTargetColliderName = "Part_RightShoulder";
                        locationHeight = 0.45f;
                        hitAngle = 270f;
                        heightCalculated = true;
                    }
                }
            }
            
            Imbue imbue = null;
            if (collisionstruct.sourceColliderGroup?.collisionHandler?.item?.imbues != null)
            {
                if (collisionstruct.sourceColliderGroup?.collisionHandler?.item?.imbues.Count > 0)
                    imbue = collisionstruct.sourceColliderGroup?.collisionHandler?.item?.imbues[0];
            }

            string imbueSpellId = "";

            if (imbue?.spellCastBase?.imbueMaterialId != null && (imbue.spellCastBase.imbueMaterialId != ""))
            {
                var imbueMaterialData = Catalog.GetData<MaterialData>(imbue.spellCastBase.imbueMaterialId, false);
                imbueSpellId = imbueMaterialData != null ? imbueMaterialData.id : "";
            }

            if (imbueSpellId == "" && imbue != null)
            {
                if(imbue.spellCastBase is SpellCastLightning)
                    imbueSpellId = "Lightning";
                else if (imbue.spellCastBase is SpellCastGravity)
                    imbueSpellId = "Gravity";
            }

            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGotHitFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial, collisionstruct.casterHand?.spellInstance != null ? collisionstruct.casterHand.spellInstance.id : "", 
                (collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? collisionstruct.damageStruct.damager.data.penetrationSize : DamagerData.PenetrationSize.Small, (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown"), modifiedTargetColliderName, direction, imbueSpellId);
            
            if (!heightCalculated && Math.Abs(fixedLocationHeight) < TOLERANCE && collisionstruct.targetCollider != null)
            {
                //Part_Head, Part_Neck
                //Part_Spine, Part_RightLowerArm, Part_RightUpperArm, Part_LeftLowerArm, Part_LeftUpperArm
                //Part_LeftShoulder, Part_RightShoulder
                //Part_Chest
                //Part_Hips
                //Part_LeftUpperLeg, Part_RightUpperLeg
                if (targetColliderName.Contains("Head") || targetColliderName.Contains("Neck"))
                {
                    locationHeight = 0.45f;
                }
                else if (targetColliderName.Contains("Spine"))
                {
                    locationHeight = (((float) (RandomNumber.Between(0, 6))) / 20.0f);
                }
                else if (targetColliderName.Contains("Shoulder"))
                {
                    locationHeight = 0.45f;
                }
                else if (targetColliderName.Contains("Chest"))
                {
                    locationHeight = (((float) (RandomNumber.Between(0, 5))) / 10.0f) - 0.20f;
                }
                else if (targetColliderName.Contains("Hips"))
                {
                    locationHeight = -0.25f;
                }
                else if (targetColliderName.Contains("Leg"))
                {
                    locationHeight = -0.40f;    
                }
            }

            float intensity = collisionstruct.intensity;

            if (intensity <= 0.001f)
            {
                if (collisionstruct.damageStruct.damage > 0f)
                    intensity = Math.Min(1.0f, collisionstruct.damageStruct.damage);
                else if (collisionstruct.impactVelocity.magnitude > 2f)
                {
                    intensity = Math.Min(1.0f, collisionstruct.impactVelocity.magnitude/5f);
                }
            }

            if(Logging)
                LOG("Player got hit by Spell: " + (collisionstruct.casterHand?.spellInstance != null ? collisionstruct.casterHand.spellInstance.id : "null") + " Damager: " + (collisionstruct.damageStruct.damager != null ? collisionstruct.damageStruct.damager.name : "") + " Imbue: " + imbueSpellId + " - Source: " + (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown") + " on " + (collisionstruct.targetCollider != null ? collisionstruct.targetCollider.name : "whole body") + " with Hit Angle: " + hitAngle + " LocationHeight: " + locationHeight.ToString(CultureInfo.InvariantCulture) + " Intensity:" + collisionstruct.intensity.ToString(CultureInfo.InvariantCulture) + " " + ("Materials: " + ((collisionstruct.sourceMaterial != null ? collisionstruct.sourceMaterial.id : "Null") + " > " + (collisionstruct.targetMaterial != null ? collisionstruct.targetMaterial.id : "Null"))) + " DamageType: " + Utility.GetDamageTypeName(collisionstruct.damageStruct.damageType) + " Penetration: " + ((collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? (collisionstruct.damageStruct.damager.data.penetrationSize == DamagerData.PenetrationSize.Small ? "Small" : "Large") : ""));

            bool reflected = modifiedTargetColliderName.Contains("Arm") && modifiedTargetColliderName.Contains("Left");
            
            tactsuitVr?.ProvideHapticFeedback(hitAngle, locationHeight, feedback, false, kill ? intensity*5f : intensity, TactsuitVR.FeedbackType.NoFeedback, reflected);

        }

        private void OnCreatureHitFunc(Creature creature, ref CollisionStruct collisionstruct)
        {
            if (creature && Player.local && Player.local.body && Player.local.body.creature && Player.local.body.creature == creature)
            {
                var @struct = collisionstruct;
                Thread thread = new Thread(() => PlayerGotHit(@struct, false,0f));
                thread.Start();
            }
            else if (creature && Player.local && Player.local.body && Player.local.body.creature && Player.local.body.creature != creature)
            {
                //For debug purposes
                LOG("------------------------>An NPC got hit by Spell: " + (collisionstruct.casterHand?.spellInstance != null ? collisionstruct.casterHand.spellInstance.id : "null") + " Source:" + (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown") + " on " + collisionstruct.targetCollider.name + " with Intensity:" + collisionstruct.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionstruct.sourceMaterial != null && collisionstruct.targetMaterial != null) ? ("Materials: " + collisionstruct.sourceMaterial.id + " > " + collisionstruct.targetMaterial.id) : "") + " DamageType: " + Utility.GetDamageTypeName(collisionstruct.damageStruct.damageType) + " Penetration: " + ((collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? (collisionstruct.damageStruct.damager.data.penetrationSize == DamagerData.PenetrationSize.Small ? "Small" : "Large") : ""));
            }

            if (collisionstruct.intensity > 0.01f)
            {
                if (collisionstruct.IsDoneByPlayer())
                {
                    LOG("Player hit something...");
                    LOG("->Player hit something with " + collisionstruct.sourceCollider.name);

                    if ((bool) (UnityEngine.Object) collisionstruct.sourceColliderGroup.collisionHandler?.item?.rightPlayerHand)
                    {
                        if (collisionstruct.sourceColliderGroup.collisionHandler.item.data?.type == ItemPhysic.Type.Body) //punch
                        {
                            TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(collisionstruct.targetMaterial != null ? collisionstruct.targetMaterial.id : "");
                            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                            LOG("Player punched something with right Hand: Intensity: " + collisionstruct.intensity);
                        }
                        else
                        {
                            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                            LOG("Player hit something with right Hand: Intensity: " + collisionstruct.intensity);
                        }
                    }

                    if ((bool) (UnityEngine.Object) collisionstruct.sourceColliderGroup.collisionHandler?.item?.leftPlayerHand)
                    {
                        if (collisionstruct.sourceColliderGroup.collisionHandler.item.data?.type == ItemPhysic.Type.Body) //punch
                        {
                            TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(collisionstruct.targetMaterial != null ? collisionstruct.targetMaterial.id : "");
                            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                            LOG("Player punched something with left Hand: Intensity: " + collisionstruct.intensity);
                        }
                        else
                        {
                            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                            tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                            LOG("Player hit something with left Hand weapon: Intensity: " + collisionstruct.intensity);
                        }
                    }
                }

                if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup && collisionstruct.targetColliderGroup?.collisionHandler?.item != null)
                {
                    if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup.collisionHandler?.item?.leftPlayerHand)
                    {
                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                        LOG("Something hit Player's left Hand item: Intensity: " + collisionstruct.intensity);
                    }

                    if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup.collisionHandler?.item?.rightPlayerHand)
                    {
                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                        LOG("Something hit Player's right Hand item: Intensity: " + collisionstruct.intensity);
                    }
                }
            }
        }

        private void OnCreatureParryFunc(Creature creature, ref CollisionStruct collisionstruct)
        {
            if (collisionstruct.damageStruct.damage <= 0.00001f)
                return;

            LOG("Parry. ");

            if ((bool) (UnityEngine.Object) collisionstruct.sourceColliderGroup)
            {
                if ((bool) (UnityEngine.Object) collisionstruct.sourceColliderGroup.collisionHandler.item?.leftPlayerHand)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    LOG("Player parry something with left Hand: Intensity: " + collisionstruct.intensity);
                }

                if ((bool) (UnityEngine.Object) collisionstruct.sourceColliderGroup.collisionHandler.item?.rightPlayerHand)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    LOG("Player parry something with right Hand: Intensity: " + collisionstruct.intensity);
                }
            }

            if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup)
            {
                if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup.collisionHandler.item?.leftPlayerHand)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
                    LOG("Something parry Player's left Hand item: Intensity: " + collisionstruct.intensity);
                }

                if ((bool) (UnityEngine.Object) collisionstruct.targetColliderGroup.collisionHandler.item?.rightPlayerHand)
                {
                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionstruct.damageStruct.damageType, collisionstruct.sourceMaterial, collisionstruct.targetMaterial);
                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, collisionstruct.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
                    LOG("Something parry Player's right Hand item: Intensity: " + collisionstruct.intensity);
                }
            }
        }
        
        private void OnKillFunc(ref CollisionStruct collisionstruct)
        {
            var @struct = collisionstruct;
            Thread thread = new Thread(() => PlayerGotHit(@struct, true,0f));
            thread.Start();
            LOG("Player is killed.");
            Heartbeating = false;
            HeartbeatingFast = false;
            lastFrameVelocity = Vector3.zero;
        }

        private void OnCreatureKillFunc(Creature creature, Player player, ref CollisionStruct collisionstruct)
        {
            if (creature && Player.local && Player.local.body && Player.local.body.creature && Player.local.body.creature == creature)
            {
                var @struct = collisionstruct;
                Thread thread = new Thread(() => PlayerGotHit(@struct, true,0f));
                thread.Start();
                LOG("Player is killed.");
                Heartbeating = false;
                HeartbeatingFast = false;
                lastFrameVelocity = Vector3.zero;
            }
        }

        private void OnCreatureHealFunc(Creature creature, float heal, Creature healer)
        {
            if (creature && Player.local && Player.local.body && Player.local.body.creature && Player.local.body.creature == creature)
            {
                //Play just healed effect.
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.Healing, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Player is healed. Amount: " + heal.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void OnDeflectFunc(Creature source, Item item, Creature target)
        {
            if (source && Player.local && Player.local.body && Player.local.body.creature && Player.local.body.creature == source)
            {
                LOG("Player deflected source. Item: " + item.definition.itemId);
            }

            if (target && Player.local && Player.local.body && Player.local.body.creature && Player.local.body.creature == target)
            {
                LOG("Player deflected target. Item: " + item.definition.itemId);
            }
        }

        #endregion
    }
}