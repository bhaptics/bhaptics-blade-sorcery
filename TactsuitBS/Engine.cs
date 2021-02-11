using System.Globalization;
using UnityEngine;
using ThunderRoad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Bhaptics.Tact;
using CustomWebSocketSharp;
using Newtonsoft.Json.Linq;
using TLGFPowerBooks;
using UnityEngine.SceneManagement;

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


        //Rain
        public int RainVestSleepDuration = 700;
        public int RainHeadSleepDuration = 1000;
        public int RainArmSleepDuration = 1000;
        public int RainEffectDuration = 50;

        public float IntensityRaindropVest = 1.15f;
        public float IntensityRaindropArm = 0.8f;
        public float IntensityRaindropHead = 0.7f;


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

        public float IntensityPlayerMeleeLightsaberClashRight = 1.0f;
        public float IntensityPlayerMeleeLightsaberSlashRight = 1.0f;
        public float IntensityPlayerMeleeLightsaberPierceRight = 1.0f;
        public float IntensityPlayerMeleeLightsaberBluntRight = 1.0f;

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

        public float IntensityDamageVestBlaster = 1.0f;
        public float IntensityDamageVestBlasterStun = 1.0f;
        public float IntensityDamageArmBlaster = 1.0f;
        public float IntensityDamageArmBlasterStun = 1.0f;
        public float IntensityDamageHeadBlaster = 1.0f;
        public float IntensityDamageHeadBlasterStun = 1.0f;

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

        private AudioSource leftItemChargeSFX = null;

        private AudioSource rightItemChargeSFX = null;

        private AudioSource leftItemChargeReadySFX = null;

        private AudioSource rightItemChargeReadySFX = null;

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

        private bool leftModularGunFiring = false;
        private bool rightModularGunFiring = false;


        private bool shootingLeftGun = false;
        private bool shootingRightGun = false;
        private bool altShootingLeftGun = false;
        private bool altShootingRightGun = false;

        private bool shootingLeftShoulderTurret = false;
        private bool hoveringWithHoverJet = false;

        private GameObject rainController;

        private bool raining = false;
        private float rainIntensity = 0.52f;
        private float rainDensity = 7.0f; 

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

        public override IEnumerator OnLoadCoroutine(Level level)
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

            tactsuitVr.IntensityPlayerMeleeLightsaberClashRight = IntensityPlayerMeleeLightsaberClashRight;
            tactsuitVr.IntensityPlayerMeleeLightsaberSlashRight = IntensityPlayerMeleeLightsaberSlashRight;
            tactsuitVr.IntensityPlayerMeleeLightsaberPierceRight = IntensityPlayerMeleeLightsaberPierceRight;
            tactsuitVr.IntensityPlayerMeleeLightsaberBluntRight = IntensityPlayerMeleeLightsaberBluntRight;

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

            tactsuitVr.IntensityDamageVestBlaster = IntensityDamageVestBlaster;
            tactsuitVr.IntensityDamageVestBlasterStun = IntensityDamageVestBlasterStun;
            tactsuitVr.IntensityDamageArmBlaster = IntensityDamageArmBlaster;
            tactsuitVr.IntensityDamageArmBlasterStun = IntensityDamageArmBlasterStun;
            tactsuitVr.IntensityDamageHeadBlaster = IntensityDamageHeadBlaster;
            tactsuitVr.IntensityDamageHeadBlasterStun = IntensityDamageHeadBlasterStun;

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

            foreach (TactsuitVR.FeedbackType f in Enum.GetValues(typeof(TactsuitVR.FeedbackType)))
            {
                if (f == TactsuitVR.FeedbackType.NoFeedback)
                    continue;

                if (!tactsuitVr.feedbackMap.ContainsKey(f) || tactsuitVr.feedbackMap[f].feedbackFileCount == 0)
                {
                    LOG("Tact file NOT found: " + f.ToString());
                }
            }

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

            SceneManager.sceneLoaded += this.OnSceneLoadedFunc;
            SceneManager.sceneUnloaded += this.OnSceneUnloadedFunc;

            return base.OnLoadCoroutine(level);
        }

        private void OnSceneUnloadedFunc(Scene scene)
        {
            gamePaused = true;
            LOG("Scene unloaded: " + scene.name);
        }

        private void OnSceneLoadedFunc(Scene scene, LoadSceneMode mode)
        {
            gamePaused = false;

            LOG("Scene loaded: " + scene.name);
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
                        if (!jsonFileStr.IsNullOrEmpty())
                        {
                            if (jsonFileStr.Contains("Shooter"))
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
                                                    multipleShots = (bool) module["multipleShotsWithoutReleasingTrigger"];

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
                            else if (jsonFileStr.Contains("SimpleBallistics"))
                            {
                                JObject obj = JObject.Parse(jsonFileStr);
                                if (obj != null)
                                {
                                    string displayName = (string) obj["displayName"];

                                    foreach (var module in obj.SelectTokens("modules[*]"))
                                    {
                                        if (module != null)
                                        {
                                            GunUseMultipleShotMap[displayName] = false;
                                            LOG("Gun " + displayName + " fire: single");

                                            string shootSfx = (string) module["fireSoundRef"];
                                            string shootVfx = (string) module["muzzleFlashRef"];
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
                            else if (jsonFileStr.Contains("TheOuterRim"))
                            {
                                JObject obj = JObject.Parse(jsonFileStr);
                                if (obj != null)
                                {
                                    string displayName = (string) obj["displayName"];

                                    GunUseMultipleShotMap[displayName] = false;
                                    GunAltUseMultipleShotMap[displayName] = false;

                                }
                            }
                        }
                    }
                }
            }

            SFXList.Add("GrappleSound"); //Support for ButtersAndSorcery's Batman Grapple Mod
            SFXList.Add("FireSounds"); //Support for The Outer Rim
            SFXList.Add("FireSounds2"); //Support for The Outer Rim
            SFXList.Add("FireSounds3"); //Support for The Outer Rim
            GunUseMultipleShotMap["GrappleGun"] = false;
            GunUseMultipleShotMap["BatmanGrapple"] = false;

            LOG("Found Gun VFX count: " + VFXList.Count + " Gun SFX count: " + SFXList.Count);
            LOG("Found Gun VFXs: " + String.Join(", ", VFXList));
            LOG("Found Gun SFXs: " + String.Join(", ", SFXList));
        }

        public override void Update(Level level)
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
            
            if (level.loaded)
            {
                if (!eventsCreated)
                {
                    EventManager.onCreatureHit += OnCreatureHitFunc;
                    EventManager.onCreatureHeal += OnCreatureHealFunc;
                    EventManager.onCreatureKill += OnCreatureKillFunc;
                    EventManager.onCreatureParry += OnCreatureParryFunc;
                    EventManager.onDeflect += OnDeflectFunc;
                    EventManager.onPlayerSpawn += OnPlayerSpawnFunc;

                    //Locomotion.OnGroundEvent 
                    eventsCreated = true;
                    LOG("Events are created.");
                }

                deltaTime = Time.deltaTime * 1000f;

                if (!GameManager.timeStopped)
                {
                    if (Player.local != null && Player.local.creature != null && Player.local.creature.initialized)
                    {
                        CheckStates(Player.local.creature);
                        CheckStatesRarest(Player.local.creature);
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
            base.Update(level);
        }

        private void CheckPlayerSpawn()
        {
            while (Player.local == null || Player.local.creature == null || Player.local.locomotion == null || Player.local.creature.initialized == false || Player.local.creature.ragdoll == null)
            {
                Thread.Sleep(1000);
            }

            LOG("Player spawned.");
            LiquidReceiver lr = Player.local.creature.GetComponentInChildren<LiquidReceiver>();
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

            Player.local.creature.OnDamageEvent += OnDamageFunc;
            Player.local.creature.OnKillEvent += OnKillFunc;

            if (Player.local.GetHand(Side.Left)?.ragdollHand != null) Player.local.GetHand(Side.Left).ragdollHand.OnGrabEvent += new RagdollHand.GrabEvent(GrabFunc);
            if (Player.local.GetHand(Side.Right)?.ragdollHand != null) Player.local.GetHand(Side.Right).ragdollHand.OnGrabEvent += new RagdollHand.GrabEvent(GrabFunc);
            if (Player.local.GetHand(Side.Left)?.ragdollHand != null) Player.local.GetHand(Side.Left).ragdollHand.OnUnGrabEvent += new RagdollHand.UnGrabEvent(UnGrabFunc);
            if (Player.local.GetHand(Side.Right)?.ragdollHand != null) Player.local.GetHand(Side.Right).ragdollHand.OnUnGrabEvent += new RagdollHand.UnGrabEvent(UnGrabFunc);

            foreach (Holder holder in Player.local.creature.equipment.holders)
            {
                if (holder != null)
                {
                    //Holder found on Player: BackRight
                    //Holder found on Player: BackLeft
                    if (holder.name == "BackLeft")
                    {
                        holder.Snapped += HolsterLeftShoulderFunc;
                        holder.UnSnapped += UnHolsterLeftShoulderFunc;
                    }
                    else if (holder.name == "BackRight")
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
                                if (holder.name == "BackLeft")
                                {
                                    quiver.holder.Snapped += new Holder.HolderDelegate(LeftProjectileAddedFunc);
                                    quiver.holder.UnSnapped += new Holder.HolderDelegate(LeftProjectileRemovedFunc);
                                }
                                else if (holder.name == "BackRight")
                                {
                                    quiver.holder.Snapped += new Holder.HolderDelegate(RightProjectileAddedFunc);
                                    quiver.holder.UnSnapped += new Holder.HolderDelegate(RightProjectileRemovedFunc);
                                }

                            }
                        }
                    }
                }
            }

            List<CollisionHandler> playerCollisionHandlersList = new List<CollisionHandler>((IEnumerable<CollisionHandler>)Player.local.GetComponentsInChildren<CollisionHandler>());

            foreach (var collisionHandler in playerCollisionHandlersList)
            {
                if (collisionHandler != null)
                {
                    LOG("Player has this collisionhandler: " + collisionHandler.name + " Item: " + (collisionHandler.item != null ? collisionHandler.item.name : ""));
                    //collisionHandler.OnCollisionStartEvent += BodyPartCollisionStartFunc;
                }
            }

            if (Player.local.handLeft?.ragdollHand.collisionHandler != null)
            {
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStartEvent += LeftHandCollisionStartFunc;
                Player.local.handLeft.ragdollHand.collisionHandler.OnCollisionStopEvent += BodyPartCollisionStopFunc;
                LOG("Adding collision event to: Left Hand");
            }

            if (Player.local.handRight?.ragdollHand.collisionHandler != null)
            {
                Player.local.handRight.ragdollHand.collisionHandler.OnCollisionStartEvent += RightHandCollisionStartFunc;
                Player.local.handRight.ragdollHand.collisionHandler.OnCollisionStopEvent += BodyPartCollisionStopFunc;
                LOG("Adding collision event to: Right Hand");
            }

            if (Player.local.footLeft?.ragdollFoot?.collisionHandler != null)
            {
                Player.local.footLeft.ragdollFoot.collisionHandler.OnCollisionStartEvent += LeftFootCollisionStartFunc;
                LOG("Adding collision event to: Left Foot");
            }

            if (Player.local.footRight?.ragdollFoot?.collisionHandler != null)
            {
                Player.local.footRight.ragdollFoot.collisionHandler.OnCollisionStartEvent += RightFootCollisionStartFunc;
                LOG("Adding collision event to: Right Foot");
            }

            foreach (var part in Player.local.creature.ragdoll.parts)
            {
                if (part.type == RagdollPart.Type.Torso)
                {
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                    part.collisionHandler.OnCollisionStartEvent += TorsoCollisionFunc;
                }
                else if(part.collisionHandler.name == "LeftForeArm")
                {
                    part.collisionHandler.OnCollisionStartEvent += LeftHandCollisionStartFunc;
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                }
                else if (part.collisionHandler.name == "LeftArm")
                {
                    part.collisionHandler.OnCollisionStartEvent += LeftHandCollisionStartFunc;
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                }
                else if (part.collisionHandler.name == "RightForeArm")
                {
                    part.collisionHandler.OnCollisionStartEvent += RightHandCollisionStartFunc;
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                }
                else if (part.collisionHandler.name == "RightArm")
                {
                    part.collisionHandler.OnCollisionStartEvent += RightHandCollisionStartFunc;
                    LOG("Adding collision event to: " + part.collisionHandler.name);
                }
            }

            foreach (GameObject gameObject in (GameObject[])UnityEngine.Object.FindObjectsOfType<GameObject>())
            {
                if (gameObject != null)
                {
                    if (gameObject.GetComponent("RainController"))
                    {
                        rainController = gameObject;
                        break;
                    }
                }
            }

            if (rainController != null)
            {
                LOG("Rain Controller found in scene.");
            }
            else
            {
                LOG("Rain Controller not found in scene.");
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
                else if (material.Contains("Metal"))
                    return TactsuitVR.FeedbackType.PlayerPunchMetalRight;
                else if (material.Contains("Fabric"))
                    return TactsuitVR.FeedbackType.PlayerPunchFabricRight;
                else if (material.Contains("Flesh") || material.Contains("Sand"))
                    return TactsuitVR.FeedbackType.PlayerPunchFleshRight;
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
                else if (material.Contains("Metal"))
                    return TactsuitVR.FeedbackType.PlayerKickMetalRight;
                else if (material.Contains("Fabric"))
                    return TactsuitVR.FeedbackType.PlayerKickFabricRight;
                else if (material.Contains("Flesh") || material.Contains("Sand"))
                    return TactsuitVR.FeedbackType.PlayerKickFleshRight;
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

        private void LeftHandCollisionStartFunc(ref CollisionStruct collisionInstance)
        {
            string material = (collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id + " " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "") : "");

            material = Utility.ReplaceFirst(material, "Flesh", "");

            TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(material);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
            LOG("Left hand collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
        }

        private void RightHandCollisionStartFunc(ref CollisionStruct collisionInstance)
        {
            string material = (collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id + " " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "") : "");
            material = Utility.ReplaceFirst(material, "Flesh", "");

            TactsuitVR.FeedbackType feedback = GetPlayerPunchFeedback(material);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
            LOG("Right hand collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
        }

        private void LeftFootCollisionStartFunc(ref CollisionStruct collisionInstance)
        {
            string material = (collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id + " " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "") : "");
            material = Utility.ReplaceFirst(material, "Flesh", "");

            TactsuitVR.FeedbackType feedback = GetPlayerKickFeedback(material);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
            LOG("Left foot collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
       }

        private void RightFootCollisionStartFunc(ref CollisionStruct collisionInstance)
        {
            string material = (collisionInstance.sourceMaterial != null ? collisionInstance.sourceMaterial.id + " " + (collisionInstance.targetMaterial != null ? collisionInstance.targetMaterial.id : "") : "");
            material = Utility.ReplaceFirst(material, "Flesh", "");

            TactsuitVR.FeedbackType feedback = GetPlayerKickFeedback(material);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
            LOG("Right foot collides with something with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : ""));
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
                    if (collisionInstance.sourceColliderGroup?.collisionHandler?.ragdollPart?.ragdoll?.creature == Player.local?.creature)
                    {
                        sourceIsPlayer = true;
                    }
                }
                if (!sourceIsPlayer && collisionInstance.sourceColliderGroup?.collisionHandler?.isItem == true)
                {
                    if (collisionInstance.sourceColliderGroup?.collisionHandler?.item?.rightPlayerHand != null
                        || collisionInstance.sourceColliderGroup?.collisionHandler?.item?.leftPlayerHand != null
                        || collisionInstance.sourceColliderGroup?.collisionHandler?.item?.ignoredRagdoll?.creature == Player.local?.creature
                        || (UnityEngine.Object)Player.local?.footLeft?.ragdollFoot?.gameObject == (UnityEngine.Object)collisionInstance.sourceColliderGroup?.collisionHandler?.item?.gameObject
                        || (UnityEngine.Object)Player.local?.footRight?.ragdollFoot?.gameObject == (UnityEngine.Object)collisionInstance.sourceColliderGroup?.collisionHandler?.item?.gameObject)
                    {
                        sourceIsPlayer = true;
                    }
                }
            }
            if (collisionInstance.targetColliderGroup?.collisionHandler != null)
            {
                if (collisionInstance.targetColliderGroup?.collisionHandler?.isRagdollPart == true)
                {
                    if (collisionInstance.targetColliderGroup?.collisionHandler?.ragdollPart?.ragdoll?.creature == Player.local?.creature)
                    {
                        targetIsPlayer = true;
                    }
                }
                if (!targetIsPlayer && collisionInstance.targetColliderGroup?.collisionHandler?.isItem == true)
                {
                    if (collisionInstance.targetColliderGroup?.collisionHandler?.item?.rightPlayerHand != null
                        || collisionInstance.targetColliderGroup?.collisionHandler?.item?.leftPlayerHand != null
                        || collisionInstance.targetColliderGroup?.collisionHandler?.item?.ignoredRagdoll?.creature == Player.local?.creature
                        || (UnityEngine.Object)Player.local?.footLeft?.ragdollFoot?.gameObject == (UnityEngine.Object)collisionInstance.targetColliderGroup?.collisionHandler?.item?.gameObject
                        || (UnityEngine.Object)Player.local?.footRight?.ragdollFoot?.gameObject == (UnityEngine.Object)collisionInstance.targetColliderGroup?.collisionHandler?.item?.gameObject)
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
            
            tactsuitVr.ProvideHapticFeedback(hitAngle, 0, TactsuitVR.FeedbackType.DamageVestBluntStoneLarge, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
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
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, false);
            LOG("Right hand item (" + (collisionInstance.sourceCollider != null ? collisionInstance.sourceCollider.name : "") + ") collides with something (" + (collisionInstance.targetCollider != null ? collisionInstance.targetCollider.name : "") + ") with intensity=" + collisionInstance.intensity.ToString(CultureInfo.InvariantCulture) + " " + ((collisionInstance.sourceMaterial != null && collisionInstance.targetMaterial != null) ? ("Materials: " + collisionInstance.sourceMaterial.id + " > " + collisionInstance.targetMaterial.id) : "") + " MaterialEffect:" + (collisionInstance.damageStruct.materialEffectData != null ? collisionInstance.damageStruct.materialEffectData.id : "") + " DamageType: " + Utility.GetDamageTypeName(collisionInstance.damageStruct.damageType));
        }

        private void HeldItemLeftCollisionStartFunc(ref CollisionStruct collisionInstance)
        {
            if (collisionInstance.damageStruct.hitRagdollPart?.ragdoll?.creature != null)
                return;

            TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerMeleeFeedbackType(collisionInstance.damageStruct.damageType, collisionInstance.sourceMaterial, collisionInstance.targetMaterial);
            tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, collisionInstance.intensity, TactsuitVR.FeedbackType.NoFeedback, true);
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
                        quiver.holder.Snapped -= new Holder.HolderDelegate(RightProjectileAddedFunc);
                        quiver.holder.UnSnapped -= new Holder.HolderDelegate(RightProjectileRemovedFunc);
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
                        quiver.holder.Snapped += new Holder.HolderDelegate(RightProjectileAddedFunc);
                        quiver.holder.UnSnapped += new Holder.HolderDelegate(RightProjectileRemovedFunc);
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
                        quiver.holder.Snapped -= new Holder.HolderDelegate(LeftProjectileAddedFunc);
                        quiver.holder.UnSnapped -= new Holder.HolderDelegate(LeftProjectileRemovedFunc);
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
                        quiver.holder.Snapped += new Holder.HolderDelegate(LeftProjectileAddedFunc);
                        quiver.holder.UnSnapped += new Holder.HolderDelegate(LeftProjectileRemovedFunc);
                    }
                }

                LOG("Item holstered on left shoulder: " + item.name);
            }
        }
        
        private void BeingPushedFunc()
        {
            while (!gamePaused && !GameManager.timeStopped && Player.local.creature.state != Creature.State.Dead && !Player.local.locomotion.isEnabled && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.locomotion.rb.velocity.magnitude >= 0.1f)
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
            if (Player.local?.creature != null)
            {
                if (side == Side.Left)
                {
                    Item leftItem = Player.local.creature.equipment.GetHeldobject(Side.Left);
                    while (!beingPushed && !gamePaused && !GameManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.creature.state != Creature.State.Dead && Player.local.locomotion.rb.velocity.magnitude > 1f && Player.local.locomotion.rb.velocity.y >= 0f && leftItem != null && leftItem.name.Contains("Grapple") && leftItemUseStarted)
                    {
                        float intensity = Player.local.locomotion.rb.velocity.magnitude / 3f;
                        tactsuitVr.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.ClimbingRight, false, intensity, TactsuitVR.FeedbackType.NoFeedback, true);

                        Thread.Sleep(SleepDurationSpellCast);
                    }

                    beingPulledLeft = false;
                }
                else
                {
                    Item rightItem = Player.local.creature.equipment.GetHeldobject(Side.Right);

                    while (!beingPushed && !gamePaused && !GameManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.creature.state != Creature.State.Dead && Player.local.locomotion.rb.velocity.magnitude > 1f && Player.local.locomotion.rb.velocity.y >= 0f && rightItem != null && rightItem.name.Contains("Grapple") && rightItemUseStarted)
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
            while (!beingPushed && !gamePaused && !GameManager.timeStopped && Player.local.locomotion.moveDirection == UnityEngine.Vector3.zero && Player.local.creature.state != Creature.State.Dead && Player.local.locomotion.rb.velocity.magnitude > 1f)
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
            Item leftItem = Player.local.creature.equipment.GetHeldWeapon(Side.Left);
            Item rightItem = Player.local.creature.equipment.GetHeldWeapon(Side.Right);

            BowString bowString = leftItem?.GetComponentInChildren<BowString>() ?? rightItem?.GetComponentInChildren<BowString>();

            while (bowString != null && bowStringHeld)
            {
                if (GameManager.timeStopped)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                if (Player.local?.creature == null)
                    break;

                leftItem = Player.local.creature.equipment.GetHeldWeapon(Side.Left);
                rightItem = Player.local.creature.equipment.GetHeldWeapon(Side.Right);

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
                            foreach (var collisionHandler in handle.item.collisionHandlers)
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
                            foreach (var collisionHandler in handle.item.collisionHandlers)
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

        private void RightItemHeldActionEventFunc(RagdollHand ragdollHand, Handle handle, Interactable.Action action)
        {
            if (action == Interactable.Action.UseStart)
            {
                rightItemUseStarted = true;

                if (Player.local?.creature != null)
                {
                    Item rightItem = Player.local?.creature.equipment.GetHeldobject(Side.Right);

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

        private void LeftItemHeldActionEventFunc(RagdollHand ragdollHand, Handle handle, Interactable.Action action)
        {
            if (action == Interactable.Action.UseStart)
            {
                leftItemUseStarted = true;

                if(Player.local?.creature != null)
                {
                    Item leftItem = Player.local?.creature.equipment.GetHeldobject(Side.Left);

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
            
            if (Player.local?.head != null && Player.local?.creature != null)
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
                                    foreach (var collisionHandler in handle.item.collisionHandlers)
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
                                    foreach (var collisionHandler in handle.item.collisionHandlers)
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
            if (NoFallEffectWhenFallDamageIsDisabled && !Creature.playerFallDamage)
            {
                return;
            }

            if (grounded && Player.local?.creature?.data != null)
            {
                //Play default damage effect
                float damage = Player.local.creature.data.playerFallDamageCurve.Evaluate(velocity.magnitude);
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
                if (Player.local?.creature != null && Player.local?.locomotion != null)
                {
                    Item rightItem = Player.local?.creature.equipment.GetHeldobject(Side.Right);

                    if (rightItem != null && rightItem.name.Contains("Grapple") && rightItemUseStarted)
                    {
                        continue;
                    }

                    Item leftItem = Player.local?.creature.equipment.GetHeldobject(Side.Left);

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

        private void FireGun(string name, string displayname, bool altFire, bool leftHand, bool starwarsBlasterStun, bool burst, bool chargedFire)
        {
            if (tactsuitVr != null)
            {
                TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(name, displayname, starwarsBlasterStun);
                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.FeedbackType.NoFeedback;
                if (!name.Contains("Grapple"))
                {
                    feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, leftHand ? Side.Left : Side.Right);
                }
                int burstCount = 2;

                if (leftHand)
                {
                    while (!gamePaused && !GameManager.timeStopped 
                                       && ((leftItemUseStarted && !altFire && (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemChargeSFX != null && leftItemChargeSFX.isPlaying) || (leftItemChargeReadySFX != null && leftItemChargeReadySFX.isPlaying)))) 
                                           ||(leftItemAltUseStarted && altFire && (((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying))))))
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, chargedFire ? 0.5f:1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, chargedFire ? 0.5f : 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(!starwarsBlasterStun ? SleepDurationShootGun : SleepDurationShootGun*10 / 6);
                        if (burst)
                        {
                            burstCount--;
                            if (burstCount <= 0)
                            {
                                leftItemUseStarted = false;
                                break;
                            }
                        }
                    }
                    LOG("Player stopped " + (altFire ? "alt" : "") + " firing left gun: " + name);

                    if (altFire) altShootingLeftGun = false;
                    else shootingLeftGun = false;

                    if (chargedFire)
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.2f, TactsuitVR.FeedbackType.NoFeedback, true);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.2f, TactsuitVR.FeedbackType.NoFeedback, false);
                    }
                }
                else
                {
                    while (!gamePaused && !GameManager.timeStopped
                                       && ((rightItemUseStarted && !altFire && (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemChargeSFX != null && rightItemChargeSFX.isPlaying) || (rightItemChargeReadySFX != null && rightItemChargeReadySFX.isPlaying))))
                                            || (rightItemAltUseStarted && altFire && (((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying))))))
                    {
                        
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, chargedFire ? 0.5f : 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, chargedFire ? 0.5f : 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(!starwarsBlasterStun ? SleepDurationShootGun : SleepDurationShootGun * 10 / 6);

                        if (burst)
                        {
                            burstCount--;
                            if (burstCount <= 0)
                            {
                                rightItemUseStarted = false;
                                break;
                            }
                        }
                    }
                    LOG("Player stopped " + (altFire ? "alt" : "") + " firing right gun: " + name);

                    if (altFire) altShootingRightGun = false;
                    else shootingRightGun = false;

                    if (chargedFire)
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.2f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.2f, TactsuitVR.FeedbackType.NoFeedback, false);
                    }
                }
            }
        }

        private void FireGunModularFireArms(string name, string displayname, bool leftHand, bool burst)
        {
            if (tactsuitVr != null)
            {
                TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(name, displayname, false);
                TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, leftHand ? Side.Left : Side.Right);

                int burstCount = 2;

                if (leftHand)
                {
                    while (!gamePaused && !GameManager.timeStopped && (leftItemUseStarted || leftModularGunFiring))
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(SleepDurationShootGun);
                        if (burst)
                        {
                            burstCount--;
                            if (burstCount <= 0)
                            {
                                leftItemUseStarted = false;
                                break;
                            }
                        }

                    }
                    LOG("Player stopped firing left gun: " + name);

                    shootingLeftGun = false;
                }
                else
                {
                    while (!gamePaused && !GameManager.timeStopped && (rightItemUseStarted || rightModularGunFiring))
                    {
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                        Thread.Sleep(SleepDurationShootGun);
                        if (burst)
                        {
                            burstCount--;
                            if (burstCount <= 0)
                            {
                                rightItemUseStarted = false;
                                break;
                            }
                        }
                    }
                    LOG("Player stopped firing right gun: " + name);

                    shootingRightGun = false;
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
                        if (Player.local != null && Player.local.creature != null
                            && Player.local.creature.mana != null && Player.local.creature.mana.casterLeft != null)
                        {
                            float intensity = 1.0f;
                            if (Player.local.creature.mana.casterLeft.spellInstance is SpellCastCharge)
                            {
                                SpellCastCharge scc = (Player.local.creature.mana.casterLeft.spellInstance as SpellCastCharge);
                                if (scc != null)
                                {
                                    intensity = scc.currentCharge;
                                    if (intensity < 0.2f)
                                        intensity = 0.2f;
                                }
                            }

                            if ((bool) (UnityEngine.Object) Player.local.creature.mana.casterLeft.ragdollHand.grabbedHandle)
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
                        if (Player.local != null && Player.local.creature != null
                            && Player.local.creature.mana != null && Player.local.creature.mana.casterRight != null)
                        {
                            float intensity = 1.0f;
                            if (Player.local.creature.mana.casterRight.spellInstance is SpellCastCharge)
                            {
                                SpellCastCharge scc = (Player.local.creature.mana.casterRight.spellInstance as SpellCastCharge);
                                if (scc != null)
                                {
                                    intensity = scc.currentCharge;
                                    if (intensity < 0.2f)
                                        intensity = 0.2f;
                                }
                            }

                            if ((bool) (UnityEngine.Object) Player.local.creature.mana.casterRight.ragdollHand.grabbedHandle)
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
                    if ((leftHand && Player.local.creature.equipment.GetHeldobject(Side.Left)) || (!leftHand && Player.local.creature.equipment.GetHeldobject(Side.Right)))
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
                    if ((leftHand && Player.local.creature.equipment.GetHeldobject(Side.Left)) || (!leftHand && Player.local.creature.equipment.GetHeldobject(Side.Right)))
                        break;

                    tactsuitVr.ProvideHapticFeedback(0, 0, feedback, false, 1.0f, TactsuitVR.FeedbackType.NoFeedback, leftHand ? true : false);
                    Thread.Sleep(SleepDurationSpellCast);
                }
                tactsuitVr.PauseHapticFeedBack(feedback);
            }
        }

        private void RaindropVestEffect()
        {
            float minsleepduration = 100.0f;
            int minsleepDurationInt = 100;
            int sleepDuration = 100;

            while (raining)
            {
                minsleepduration = (float)RainVestSleepDuration / rainDensity;
                minsleepDurationInt = (int) minsleepduration;

                sleepDuration = RandomNumber.Between(minsleepDurationInt, minsleepDurationInt * 2);

                int index = RandomNumber.RandomBetweenLowerMoreProbable(0, 7, 8, 15, 4);
                int pos = RandomNumber.Between(0, 1);
                int durationOffset = RandomNumber.Between(0, 30) - 15;
                tactsuitVr.ProvideDotFeedback(pos == 1 ? PositionType.VestFront : PositionType.VestBack, index, (int)(30.0f * rainIntensity * IntensityRaindropVest), RainEffectDuration + durationOffset);
            
                Thread.Sleep(sleepDuration);
            }
        }

        private void RaindropArmEffect(bool left)
        {
            float minsleepduration = 100.0f;
            int minsleepDurationInt = 100;
            int sleepDuration = 100;

            while (raining)
            {
                minsleepduration = (float)RainArmSleepDuration / rainDensity;
                minsleepDurationInt = (int)(minsleepduration);

                sleepDuration = RandomNumber.Between(minsleepDurationInt, minsleepDurationInt * 2);

                int index = RandomNumber.Between(0, 5);
                int durationOffset = RandomNumber.Between(0, 30) - 15;
                tactsuitVr.ProvideDotFeedback(left ? PositionType.ForearmL : PositionType.ForearmR, index, (int)(30.0f * rainIntensity * IntensityRaindropArm), RainEffectDuration + durationOffset);

                Thread.Sleep(sleepDuration);
            }
        }

        private void RaindropHeadEffect()
        {
            float minsleepduration = 100.0f;
            int minsleepDurationInt = 100;
            int sleepDuration = 1;

            while (raining)
            {
                minsleepduration = (float)RainHeadSleepDuration / rainDensity;
                minsleepDurationInt = (int)(minsleepduration);

                sleepDuration = RandomNumber.Between(minsleepDurationInt, minsleepDurationInt * 2);

                int index = RandomNumber.Between(0, 5);
                int durationOffset = RandomNumber.Between(0, 30) - 15;
                tactsuitVr.ProvideDotFeedback(PositionType.Head, index, (int)(30.0f * rainIntensity * IntensityRaindropHead), RainEffectDuration + durationOffset);

                Thread.Sleep(sleepDuration);
            }
        }

        private int checkFunction2 = 80;

        private void CheckStatesRarest(Creature creature)
        {
            if (creature != null)
            {
                if(checkFunction2 <= 0)
                {
                    checkFunction2 = (int) (1.0f / Time.fixedDeltaTime);

                    #region Heartbeat Check

                    if (!gamePaused && creature.state != Creature.State.Dead && !creature.isKilled && creature.currentHealth <= creature.maxHealth * 0.1f && creature.currentHealth > 0.01f)
                    {
                        Heartbeating = false;
                        if (!HeartbeatingFast)
                        {
                            HeartbeatingFast = true;
                            Thread thread = new Thread(HeartBeatFastFunc);
                            thread.Start();
                        }
                    }
                    else if (!gamePaused && creature.state != Creature.State.Dead && !creature.isKilled && creature.currentHealth <= creature.maxHealth * 0.2f && creature.currentHealth > 0.01f)
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

                    #endregion

                    #region Rain Effect (The Outer Rim)

                    bool tempRaining = false;

                    if (rainController != null && rainController.activeSelf)
                    {
                        ParticleSystem[] particleSystems = rainController.GetComponentsInChildren<ParticleSystem>();

                        foreach (var ps in particleSystems)
                        {
                            if (ps.isPlaying && ps.isEmitting && !ps.isStopped && !ps.isPaused)
                            {
                                tempRaining = true;
                                break;
                            }
                        }
                    }

                    if (raining && tempRaining == false)
                    {
                        raining = false;
                        LOG("Rain effect is ending.");
                    }
                    else if (!raining && tempRaining)
                    {
                        raining = true;
                        if (IntensityRaindropVest > TOLERANCE)
                        {
                            Thread t55 = new Thread(() => RaindropVestEffect());
                            t55.Start();
                        }

                        if (IntensityRaindropArm > TOLERANCE)
                        {
                            Thread t56 = new Thread(() => RaindropArmEffect(false));
                            t56.Start();
                            Thread t57 = new Thread(() => RaindropArmEffect(true));
                            t57.Start();
                        }

                        if (IntensityRaindropHead > TOLERANCE)
                        {
                            Thread t58 = new Thread(() => RaindropHeadEffect());
                            t58.Start();
                        }

                        LOG("Rain effect is starting.");
                    }

                    #endregion
                }
                else
                {
                    checkFunction2--;
                }
            }
        }

        private void CheckStates(Creature creature)
        {
            if (creature != null)
            {
               
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
                    Item leftItem = creature.equipment.GetHeldobject(Side.Left);
                    Item rightItem = creature.equipment.GetHeldobject(Side.Right);

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

                    Item leftObject = creature.equipment.GetHeldobject(Side.Left);
                    Item rightObject = creature.equipment.GetHeldobject(Side.Right);

                    if ((leftObject == null && Player.local?.handLeft?.link != null && Player.local?.handLeft?.link.isActive == true && Player.local?.handLeft?.link.playerJointActive == true && Player.local?.handLeft?.ragdollHand?.climb != null && Player.local.handLeft.ragdollHand.climb.isGripping)
                        || (creature.ragdoll.ik != null && creature.ragdoll.ik.handLeftEnabled && creature.ragdoll.ik.handLeftTarget != null && leftObject == null && creature.equipment.GetHeldHandle(Side.Left) != null && Math.Abs(creature.ragdoll.ik.GetHandPositionWeight(Side.Left) - 1f) < TOLERANCE))
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

                    if ((rightObject == null && Player.local?.handRight?.link != null && Player.local?.handRight?.link.isActive == true && Player.local?.handRight?.link.playerJointActive == true && Player.local?.handRight?.ragdollHand?.climb != null && Player.local.handRight.ragdollHand.climb.isGripping)
                        || (creature.ragdoll.ik != null && creature.ragdoll.ik.handRightEnabled && creature.ragdoll.ik.handRightTarget != null && rightObject == null && creature.equipment.GetHeldHandle(Side.Right) != null && Math.Abs(creature.ragdoll.ik.GetHandPositionWeight(Side.Right) - 1f) < TOLERANCE))
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

                    Item leftItem = creature.equipment.GetHeldobject(Side.Left);
                    Item rightItem = creature.equipment.GetHeldobject(Side.Right);

                    if (leftItem != null)
                    {
                        ParticleSystem temp_leftItemShootVFX = null;

                        if (leftItem.GetCustomReference("FireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            temp_leftItemShootVFX = leftItem.GetCustomReference("FireEffect").GetComponent<ParticleSystem>();
                        }

                        foreach (var vfx in VFXList)
                        {
                            if (leftItem.transform?.Find(vfx)?.gameObject?.GetComponentInChildren<ParticleSystem>() != null)
                            {
                                temp_leftItemShootVFX = leftItem.transform.Find(vfx).gameObject.GetComponentInChildren<ParticleSystem>();
                                if (temp_leftItemShootVFX != null)
                                    break;
                            }
                            else if (leftItem.GetCustomReference(vfx)?.GetComponent<ParticleSystem>() != null)
                            {
                                temp_leftItemShootVFX = (ParticleSystem)((Component)leftItem.GetCustomReference(vfx)).GetComponent<ParticleSystem>();
                                if (temp_leftItemShootVFX != null)
                                    break;
                            }
                        }

                        leftItemShootVFX = temp_leftItemShootVFX;

                        if (leftItem.GetCustomReference("AltFireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            leftItemShoot2VFX = leftItem.GetCustomReference("AltFireEffect").GetComponent<ParticleSystem>();
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
                            else if (leftItem.GetCustomReference(sfx)?.GetComponent<AudioSource>() != null)
                            {
                                leftItemShootSFX = (AudioSource)((Component)leftItem.GetCustomReference(sfx)).GetComponent<AudioSource>();
                                if (leftItemShootSFX != null)
                                    break;
                            }
                        }

                        if (leftItem.transform?.Find("ChargeReadySounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            leftItemChargeReadySFX = leftItem.transform.Find("ChargeReadySounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (leftItem.GetCustomReference("ChargeReadySounds")?.GetComponent<AudioSource>() != null)
                        {
                            leftItemChargeReadySFX = (AudioSource)((Component)leftItem.GetCustomReference("ChargeReadySounds")).GetComponent<AudioSource>();
                        }

                        if (leftItem.transform?.Find("ChargeStartSounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            leftItemChargeSFX = leftItem.transform.Find("ChargeStartSounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (leftItem.GetCustomReference("ChargeStartSounds")?.GetComponent<AudioSource>() != null)
                        {
                            leftItemChargeSFX = (AudioSource)((Component)leftItem.GetCustomReference("ChargeStartSounds")).GetComponent<AudioSource>();
                        }
                        else if (leftItem.transform?.Find("ChargeSounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            leftItemChargeSFX = leftItem.transform.Find("ChargeSounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (leftItem.GetCustomReference("ChargeSounds")?.GetComponent<AudioSource>() != null)
                        {
                            leftItemChargeSFX = (AudioSource)((Component)leftItem.GetCustomReference("ChargeSounds")).GetComponent<AudioSource>();
                        }

                        int fireMode = 0;
                        bool stunMode = false;
                        bool isChargedFire = false;
                        bool charging = false;
                        Component itemBlasterComponent = leftItem.GetComponent("ItemBlaster");
                        if (itemBlasterComponent != null)
                        {
                            fireMode = Utility.GetValue<int>(itemBlasterComponent, "currentFiremode");
                            stunMode = Utility.GetValuePrivate<bool>(itemBlasterComponent, "altFireEnabled");
                            isChargedFire = Utility.GetValuePrivate<bool>(itemBlasterComponent, "isChargedFire");

                            ParticleSystem chargeEffect = Utility.GetValuePrivateParticleSystem(itemBlasterComponent, "chargeEffect");
                            if (chargeEffect != null && stunMode == false)
                            {
                                charging = true;
                            }
                            if (leftItemChargeReadySFX == null)
                            {
                                leftItemChargeReadySFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeReadySound");
                            }
                            if (leftItemChargeReadySFX == null)
                            {
                                leftItemChargeReadySFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeReadySound2");
                            }
                            if (leftItemChargeSFX == null)
                            {
                                leftItemChargeSFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeStartSound");
                            }
                            if (leftItemChargeSFX == null)
                            {
                                leftItemChargeSFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeStartSound2");
                            }
                            if (leftItemChargeSFX == null)
                            {
                                leftItemChargeSFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeSound");
                            }
                            if (leftItemChargeSFX == null)
                            {
                                leftItemChargeSFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeSound2");
                            }
                        }

                        bool modularFireArmIsFiring = false;
                        bool modularFireArmIsRoundChambered = false;
                        int modularFireArmFireMode = 1;
                        Component itemModularFireArmBaseComponent = leftItem.GetComponent("ItemFirearmBase");
                        if (itemModularFireArmBaseComponent != null)
                        {
                            modularFireArmIsFiring = Utility.GetValue<bool>(itemModularFireArmBaseComponent, "isFiring");
                            modularFireArmFireMode = Utility.GetValuePrivate<int>(itemModularFireArmBaseComponent, "fireModeSelection");
                            modularFireArmIsRoundChambered = Utility.GetValuePrivate<bool>(itemModularFireArmBaseComponent, "roundChambered");
                        }

                        if (itemModularFireArmBaseComponent == null)
                        {
                            itemModularFireArmBaseComponent = leftItem.GetComponent("ItemMagicFirearm");
                            if (itemModularFireArmBaseComponent != null)
                            {
                                modularFireArmIsFiring = Utility.GetValuePrivate<bool>(itemModularFireArmBaseComponent, "triggerPressed");
                                modularFireArmFireMode = Utility.GetValuePrivate<int>(itemModularFireArmBaseComponent, "fireModeSelection");
                                modularFireArmIsRoundChambered = modularFireArmIsFiring && leftItemUseStarted;
                            }
                        }

                        leftModularGunFiring = modularFireArmIsFiring;

                        if ((modularFireArmIsFiring && modularFireArmIsRoundChambered) || (charging && leftItemUseStarted) || (leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying) || (leftItemChargeSFX != null && leftItemChargeSFX.isPlaying) || (leftItemChargeReadySFX != null && leftItemChargeReadySFX.isPlaying))
                        {
                            //if (!GunUseMultipleShotMap.ContainsKey(leftItem.data.displayName))
                            //{
                            //    LOG("ERROR: GunUseMultipleShotMap doesn't contain key for " + leftItem.data.displayName);
                            //}


                            if (itemModularFireArmBaseComponent != null && modularFireArmIsFiring && modularFireArmIsRoundChambered && modularFireArmFireMode != 0)
                            {
                                if (itemModularFireArmBaseComponent != null)
                                    LOG("Left gun fireMode:" + modularFireArmFireMode.ToString());

                                if (modularFireArmFireMode == 3 || modularFireArmFireMode == 2) //This item allows multi shots
                                {
                                    if (!shootingLeftGun)
                                    {
                                        shootingLeftGun = true;
                                        Thread thread = new Thread(() => FireGunModularFireArms(leftItem.name, leftItem.data.displayName, true, modularFireArmFireMode == 2));
                                        thread.Start();
                                        LOG("Player is firing left gun: " + leftItem.data.displayName);
                                    }
                                }
                                else //This item doesn't allow multi shot. Don't play the effect until leftitemusestarted is first false, then true again.
                                {
                                    leftItemUseStarted = false;
                                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(leftItem.name, leftItem.data.displayName, false);
                                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, true);
                                    TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Left);
                                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                                    LOG("Fired left gun: " + leftItem.data.displayName);
                                }
                            }

                            if (itemModularFireArmBaseComponent == null && ((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemChargeSFX != null && leftItemChargeSFX.isPlaying) || (leftItemChargeReadySFX != null && leftItemChargeReadySFX.isPlaying))
                                                                        && ((leftItemUseStarted || (charging && leftItemUseStarted)) && GunUseMultipleShotMap.ContainsKey(leftItem.data.displayName))) // Item allows use and use started
                            {
                                if (itemBlasterComponent != null)
                                    LOG("Left gun fireMode:" + fireMode.ToString() + " StunMode:" + stunMode.ToString());

                                bool value = false;
                                if (GunUseMultipleShotMap.TryGetValue(leftItem.data.displayName, out value) || itemBlasterComponent != null)
                                {
                                    if ((itemBlasterComponent == null && value) || (fireMode < 0 || fireMode == 3) || (charging && leftItemUseStarted)) //This item allows multi shots
                                    {
                                        if (!shootingLeftGun)
                                        {
                                            shootingLeftGun = true;
                                            Thread thread = new Thread(() => FireGun(leftItem.name, leftItem.data.displayName, false, true, itemBlasterComponent != null && stunMode, fireMode == 3, (charging && leftItemUseStarted)));
                                            thread.Start();
                                            LOG("Player is firing left gun: " + leftItem.data.displayName);
                                        }
                                    }
                                    else //This item doesn't allow multi shot. Don't play the effect until leftitemusestarted is first false, then true again.
                                    {
                                        leftItemUseStarted = false;

                                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(leftItem.name, leftItem.data.displayName, itemBlasterComponent != null && stunMode);
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
                            if (itemModularFireArmBaseComponent == null && ((leftItemShootVFX != null && leftItemShootVFX.isPlaying) || (leftItemShootSFX != null && leftItemShootSFX.isPlaying) || (leftItemShoot2VFX != null && leftItemShoot2VFX.isPlaying))
                                                                        && (leftItemAltUseStarted && GunAltUseMultipleShotMap.ContainsKey(leftItem.data.displayName)) && itemBlasterComponent == null) // Item allows alt use and use started
                            {
                                bool value = false;
                                if (GunAltUseMultipleShotMap.TryGetValue(leftItem.data.displayName, out value))
                                {
                                    if (value) //This item allows multi shots
                                    {
                                        if (!altShootingLeftGun)
                                        {
                                            altShootingLeftGun = true;
                                            Thread thread = new Thread(() => FireGun(leftItem.name, leftItem.data.displayName, true, true, false, false, false));
                                            thread.Start();
                                            LOG("Player is alt firing left gun: " + leftItem.data.displayName);
                                        }
                                    }
                                    else //This item doesn't allow multi shot. Don't play the effect until leftitemaltusestarted is first false, then true again.
                                    {
                                        leftItemAltUseStarted = false;
                                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(leftItem.name, leftItem.data.displayName, false);
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

                        if (rightItem.GetCustomReference("FireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            temp_rightItemShootVFX = rightItem.GetCustomReference("FireEffect").GetComponent<ParticleSystem>();
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
                                else if (rightItem.GetCustomReference(vfx)?.GetComponent<ParticleSystem>() != null)
                                {
                                    temp_rightItemShootVFX = (ParticleSystem)((Component)rightItem.GetCustomReference(vfx)).GetComponent<ParticleSystem>();
                                    if (temp_rightItemShootVFX != null)
                                        break;
                                }
                            }
                        }

                        rightItemShootVFX = temp_rightItemShootVFX;

                        if (rightItem.GetCustomReference("AltFireEffect")?.GetComponent<ParticleSystem>() != null)
                        {
                            rightItemShoot2VFX = rightItem.GetCustomReference("AltFireEffect").GetComponent<ParticleSystem>();
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
                                if (rightItemShootSFX != null)
                                    break;
                            }
                            else if (rightItem.GetCustomReference(sfx)?.GetComponent<AudioSource>() != null)
                            {
                                rightItemShootSFX = (AudioSource)((Component)rightItem.GetCustomReference(sfx)).GetComponent<AudioSource>();
                                if (rightItemShootSFX != null)
                                    break;
                            }
                        }

                        if (rightItem.transform?.Find("ChargeReadySounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            rightItemChargeReadySFX = rightItem.transform.Find("ChargeReadySounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (rightItem.GetCustomReference("ChargeReadySounds")?.GetComponent<AudioSource>() != null)
                        {
                            rightItemChargeReadySFX = (AudioSource)((Component)rightItem.GetCustomReference("ChargeReadySounds")).GetComponent<AudioSource>();
                        }

                        if (rightItem.transform?.Find("ChargeStartSounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            rightItemChargeSFX = rightItem.transform.Find("ChargeStartSounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (rightItem.GetCustomReference("ChargeStartSounds")?.GetComponent<AudioSource>() != null)
                        {
                            rightItemChargeSFX = (AudioSource)((Component)rightItem.GetCustomReference("ChargeStartSounds")).GetComponent<AudioSource>();
                        }
                        else if (rightItem.transform?.Find("ChargeSounds")?.gameObject?.GetComponentInChildren<AudioSource>() != null)
                        {
                            rightItemChargeSFX = rightItem.transform.Find("ChargeSounds").gameObject.GetComponentInChildren<AudioSource>();
                        }
                        else if (rightItem.GetCustomReference("ChargeSounds")?.GetComponent<AudioSource>() != null)
                        {
                            rightItemChargeSFX = (AudioSource)((Component)rightItem.GetCustomReference("ChargeSounds")).GetComponent<AudioSource>();
                        }

                        int fireMode = 0;
                        bool stunMode = false;
                        bool isChargedFire = false;
                        Component itemBlasterComponent = rightItem.GetComponent("ItemBlaster");
                        bool charging = false;
                        if (itemBlasterComponent != null)
                        {
                            fireMode = Utility.GetValue<int>(itemBlasterComponent, "currentFiremode");
                            stunMode = Utility.GetValuePrivate<bool>(itemBlasterComponent, "altFireEnabled");
                            isChargedFire = Utility.GetValuePrivate<bool>(itemBlasterComponent, "isChargedFire");

                            ParticleSystem chargeEffect = Utility.GetValuePrivateParticleSystem(itemBlasterComponent, "chargeEffect");
                            if (chargeEffect != null && stunMode == false)
                            {
                                charging = true;
                            }
                            if (rightItemChargeReadySFX == null)
                            {
                                rightItemChargeReadySFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeReadySound");
                            }
                            if (rightItemChargeReadySFX == null)
                            {
                                rightItemChargeReadySFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeReadySound2");
                            }
                            if (rightItemChargeSFX == null)
                            {
                                rightItemChargeSFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeStartSound");
                            }
                            if (rightItemChargeSFX == null)
                            {
                                rightItemChargeSFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeStartSound2");
                            }
                            if (rightItemChargeSFX == null)
                            {
                                rightItemChargeSFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeSound");
                            }
                            if (rightItemChargeSFX == null)
                            {
                                rightItemChargeSFX = Utility.GetValuePrivateAudioSource(itemBlasterComponent, "chargeSound2");
                            }
                        }

                        bool modularFireArmIsFiring = false;
                        bool modularFireArmIsRoundChambered = false;
                        int modularFireArmFireMode = 1;
                        Component itemModularFireArmBaseComponent = rightItem.GetComponent("ItemFirearmBase");
                        if (itemModularFireArmBaseComponent != null)
                        {
                            modularFireArmIsFiring = Utility.GetValue<bool>(itemModularFireArmBaseComponent, "isFiring");
                            modularFireArmFireMode = Utility.GetValuePrivate<int>(itemModularFireArmBaseComponent, "fireModeSelection");
                            modularFireArmIsRoundChambered = Utility.GetValuePrivate<bool>(itemModularFireArmBaseComponent, "roundChambered");
                        }

                        if (itemModularFireArmBaseComponent == null)
                        {
                            itemModularFireArmBaseComponent = rightItem.GetComponent("ItemMagicFirearm");
                            if (itemModularFireArmBaseComponent != null)
                            {
                                modularFireArmIsFiring = Utility.GetValuePrivate<bool>(itemModularFireArmBaseComponent, "triggerPressed");
                                modularFireArmFireMode = Utility.GetValuePrivate<int>(itemModularFireArmBaseComponent, "fireModeSelection");
                                modularFireArmIsRoundChambered = modularFireArmIsFiring && rightItemUseStarted;
                            }
                        }
                        rightModularGunFiring = modularFireArmIsFiring;

                        if ((modularFireArmIsFiring && modularFireArmIsRoundChambered) || (charging && rightItemUseStarted) || (rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying) || (rightItemChargeSFX != null && rightItemChargeSFX.isPlaying) || (rightItemChargeReadySFX != null && rightItemChargeReadySFX.isPlaying))
                        {
                            //if (!GunUseMultipleShotMap.ContainsKey(rightItem.data.displayName))
                            //{
                            //    LOG("ERROR: GunUseMultipleShotMap doesn't contain key for " + rightItem.data.displayName);
                            //}

                            if (itemModularFireArmBaseComponent != null && modularFireArmIsFiring && modularFireArmIsRoundChambered && modularFireArmFireMode != 0)
                            {
                                if (itemModularFireArmBaseComponent != null)
                                    LOG("Right fireMode:" + modularFireArmFireMode.ToString());

                                if (modularFireArmFireMode == 3 || modularFireArmFireMode == 2) //This item allows multi shots
                                {
                                    if (!shootingRightGun)
                                    {
                                        shootingRightGun = true;
                                        Thread thread = new Thread(() => FireGunModularFireArms(rightItem.name, rightItem.data.displayName, false, modularFireArmFireMode == 2));
                                        thread.Start();
                                        LOG("Player is firing right gun: " + rightItem.data.displayName);
                                    }
                                }
                                else //This item doesn't allow multi shot. Don't play the effect until leftitemusestarted is first false, then true again.
                                {
                                    rightItemUseStarted = false;
                                    TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(rightItem.name, rightItem.data.displayName, false);
                                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                                    TactsuitVR.FeedbackType feedbackKickback = TactsuitVR.GetPlayerGunShootFeedbackKickback(feedback, Side.Right);
                                    tactsuitVr?.ProvideHapticFeedback(0, 0, feedbackKickback, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);

                                    LOG("Fired right gun: " + rightItem.data.displayName);
                                }
                            }

                            if (itemModularFireArmBaseComponent == null && ((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemChargeSFX != null && rightItemChargeSFX.isPlaying) || (rightItemChargeReadySFX != null && rightItemChargeReadySFX.isPlaying))
                                                                        && ((rightItemUseStarted || (charging && rightItemUseStarted)) && GunUseMultipleShotMap.ContainsKey(rightItem.data.displayName))) // Item allows use and use started
                            {
                                if (itemBlasterComponent != null)
                                    LOG("Right blaster fireMode:" + fireMode.ToString() + " StunMode:" + stunMode.ToString());

                                bool value = false;
                                if (GunUseMultipleShotMap.TryGetValue(rightItem.data.displayName, out value) || itemBlasterComponent != null)
                                {
                                    if ((itemBlasterComponent == null && value) || (fireMode < 0 || fireMode == 3) || (charging && rightItemUseStarted)) //This item allows multi shots
                                    {
                                        if (!shootingRightGun)
                                        {
                                            shootingRightGun = true;
                                            Thread thread = new Thread(() => FireGun(rightItem.name, rightItem.data.displayName, false, false, itemBlasterComponent != null && stunMode, fireMode == 3, (charging && rightItemUseStarted)));
                                            thread.Start();
                                            LOG("Player is firing right gun: " + rightItem.data.displayName);
                                        }
                                    }
                                    else //This item doesn't allow multi shot. Don't play the effect until rightitemusestarted is first false, then true again.
                                    {
                                        rightItemUseStarted = false;

                                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(rightItem.name, rightItem.data.displayName, itemBlasterComponent != null && stunMode);
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

                            if (itemModularFireArmBaseComponent == null && ((rightItemShootVFX != null && rightItemShootVFX.isPlaying) || (rightItemShootSFX != null && rightItemShootSFX.isPlaying) || (rightItemShoot2VFX != null && rightItemShoot2VFX.isPlaying))
                                                                        && (rightItemAltUseStarted && GunAltUseMultipleShotMap.ContainsKey(rightItem.data.displayName)) && itemBlasterComponent == null) // Item allows alt use and use started
                            {
                                bool value = false;
                                if (GunAltUseMultipleShotMap.TryGetValue(rightItem.data.displayName, out value))
                                {
                                    if (value) //This item allows multi shots
                                    {
                                        if (!altShootingRightGun)
                                        {
                                            altShootingRightGun = true;
                                            Thread thread = new Thread(() => FireGun(rightItem.name, rightItem.data.displayName, true, false, false, false, false));
                                            thread.Start();
                                            LOG("Player is alt firing right gun: " + rightItem.data.displayName);
                                        }
                                    }
                                    else //This item doesn't allow multi shot. Don't play the effect until rightitemaltusestarted is first false, then true again.
                                    {
                                        rightItemAltUseStarted = false;
                                        TactsuitVR.FeedbackType feedback = TactsuitVR.GetPlayerGunShootFeedback(rightItem.name, rightItem.data.displayName, false);
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
                (collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? collisionstruct.damageStruct.damager.data.penetrationSize : DamagerData.PenetrationSize.Small, (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown"), modifiedTargetColliderName, direction, imbueSpellId, (collisionstruct.damageStruct.damager?.data != null ? collisionstruct.damageStruct.damager.data.id : ""));
            
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
                LOG("Player got hit by Spell: " + (collisionstruct.casterHand?.spellInstance != null ? collisionstruct.casterHand.spellInstance.id : "null") + " Damager: " + (collisionstruct.damageStruct.damager != null ? collisionstruct.damageStruct.damager.name : "") + " DamagerDataId: " + (collisionstruct.damageStruct.damager?.data != null ? collisionstruct.damageStruct.damager.data.id : "") + " DamagerDataMaterialDamageId: " + (collisionstruct.damageStruct.damager?.data != null ? collisionstruct.damageStruct.damager.data.materialDamageId : "") + " Imbue: " + imbueSpellId + " - Source: " + (collisionstruct.sourceCollider != null ? collisionstruct.sourceCollider.name : "Unknown") + " on " + (collisionstruct.targetCollider != null ? collisionstruct.targetCollider.name : "whole body") + " with Hit Angle: " + hitAngle + " LocationHeight: " + locationHeight.ToString(CultureInfo.InvariantCulture) + " Intensity:" + collisionstruct.intensity.ToString(CultureInfo.InvariantCulture) + " " + ("Materials: " + ((collisionstruct.sourceMaterial != null ? collisionstruct.sourceMaterial.id : "Null") + " > " + (collisionstruct.targetMaterial != null ? collisionstruct.targetMaterial.id : "Null"))) + " DamageType: " + Utility.GetDamageTypeName(collisionstruct.damageStruct.damageType) + " Penetration: " + ((collisionstruct.damageStruct.damager != null && collisionstruct.damageStruct.damager.data != null) ? (collisionstruct.damageStruct.damager.data.penetrationSize == DamagerData.PenetrationSize.Small ? "Small" : "Large") : ""));

            bool reflected = modifiedTargetColliderName.Contains("Arm") && modifiedTargetColliderName.Contains("Left");
            
            tactsuitVr?.ProvideHapticFeedback(hitAngle, locationHeight, feedback, false, kill ? intensity * 5f : intensity, TactsuitVR.FeedbackType.NoFeedback, reflected);
            if (kill)
            {
                tactsuitVr?.ProvideHapticFeedback(hitAngle, locationHeight, feedback, false, intensity * 10f, TactsuitVR.FeedbackType.NoFeedback, reflected);
                tactsuitVr?.ProvideHapticFeedback(hitAngle, locationHeight, feedback, false, intensity * 5f, TactsuitVR.FeedbackType.NoFeedback, reflected);
            }

        }

        private void OnCreatureHitFunc(Creature creature, ref CollisionStruct collisionstruct)
        {
            if (creature && Player.local && Player.local.creature && Player.local.creature == creature)
            {
                var @struct = collisionstruct;
                Thread thread = new Thread(() => PlayerGotHit(@struct, false,0f));
                thread.Start();
            }
            else if (creature && Player.local && Player.local.creature && Player.local.creature != creature)
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
        
        private void OnKillFunc(ref CollisionStruct collisionstruct, EventTime eventTime)
        {
            if (eventTime != EventTime.OnStart)
                return;
            var @struct = collisionstruct;
            Thread thread = new Thread(() => PlayerGotHit(@struct, true,0f));
            thread.Start();
            LOG("Player is killed.");
            Heartbeating = false;
            HeartbeatingFast = false;
            lastFrameVelocity = Vector3.zero;
        }

        private void OnCreatureKillFunc(Creature creature, Player player, ref CollisionStruct collisionstruct, EventTime eventTime)
        {
            if (creature && Player.local && Player.local.creature && Player.local.creature == creature)
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
            if (creature && Player.local && Player.local.creature && Player.local.creature == creature)
            {
                //Play just healed effect.
                tactsuitVr?.ProvideHapticFeedback(0, 0, TactsuitVR.FeedbackType.Healing, true, 1.0f, TactsuitVR.FeedbackType.NoFeedback, false);
                LOG("Player is healed. Amount: " + heal.ToString(CultureInfo.InvariantCulture));
            }
        }

        private void OnDeflectFunc(Creature source, Item item, Creature target)
        {
            if (source && Player.local && Player.local.creature && Player.local.creature == source)
            {
                LOG("Player deflected source. Item: " + item.itemId);
            }

            if (target && Player.local && Player.local.creature && Player.local.creature == target)
            {
                LOG("Player deflected target. Item: " + item.itemId);
            }
        }

        #endregion
    }
}