using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ThunderRoad;

namespace TactsuitBS
{
    public enum Direction
    {
        LeftRightDown,
        LeftRightUp,
        RightLeftDown,
        RightLeftUp
    }

    static class Utility
    {
        public static void LOG(string logStr)
        {
            try
            {
                using (StreamWriter w = File.AppendText("BladeAndSorcery_Data\\StreamingAssets\\TactsuitBS\\TactsuitBSLog.log"))
                {
                    w.WriteLine(logStr);
                }
                //Debug.Log(logStr);
            }
            catch (Exception ex)
            {
            }
        }

        public static string GetDamageTypeName(DamageType damageType)
        {
            if (damageType == DamageType.Blunt)
                return "Blunt";
            else if (damageType == DamageType.Energy)
                return "Energy";
            else if (damageType == DamageType.Pierce)
                return "Pierce";
            else if (damageType == DamageType.Slash)
                return "Slash";
            else
            {
                return "Unknown";
            }
        }

        public static float GetCurrentPull(BowString bowString)
        {
            try
            {
                FieldInfo stringHandleField = bowString.GetType().GetField("stringHandle", BindingFlags.NonPublic | BindingFlags.Instance);
                if (stringHandleField != null)
                {
                    Handle stringHandle = (Handle)stringHandleField.GetValue(bowString);
                    if (stringHandle.handlers.Count > 0 && (bool)(UnityEngine.Object)stringHandle.handlers[0].playerHand)
                    {
                        FieldInfo currentPullField = bowString.GetType().GetField("currentPull", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (currentPullField != null)
                        {
                            return (float)currentPullField.GetValue(bowString);
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return 0f;
        }

        public static float GetAngleForPosition(Vector3 pos)
        {
            float angle = 0.0f;

            if (Player.local != null && Player.local.body != null && Player.local.body.creature != null && Player.local.body.creature.initialized)
            {
                angle = UnityEngine.Vector3.SignedAngle(Player.local.body.creature.transform.forward.ToXZ(), pos.ToXZ() - Player.local.body.creature.transform.position.ToXZ(), Vector3.up);
                if (angle < 0)
                {
                    angle = -180 - angle;
                }
                else
                {
                    angle = 180 - angle;
                }

                angle += 180.0f;
            }

            return angle;
        }

        public static Direction GetDirectionFromVector(Vector3 velocity, Vector3 contactPoint, float contactAngle)
        {
            Vector3 firstPos = contactPoint - velocity;
            float firstAngle = GetAngleForPosition(firstPos);

            if (firstAngle < 90 && contactAngle > 270)
            {
                //Left to Right
                if (firstPos.y > contactPoint.y)
                {
                    //Left to Right Down
                    return Direction.LeftRightDown;
                }
                else
                {
                    //Left to Right Up
                    return Direction.LeftRightUp;
                }
            }
            else if (firstAngle > 270 && contactAngle < 90)
            {
                //Right to Left
                if (firstPos.y > contactPoint.y)
                {
                    //Right to Left Down
                    return Direction.RightLeftDown;
                }
                else
                {
                    //Right to Left Up
                    return Direction.RightLeftUp;
                }
            }
            else
            {
                float diff = firstAngle - contactAngle;
                if (diff < 0)
                {
                    //Right to Left
                    if (firstPos.y > contactPoint.y)
                    {
                        //Right to Left Down
                        return Direction.RightLeftDown;
                    }
                    else
                    {
                        //Right to Left Up
                        return Direction.RightLeftUp;
                    }
                }
                else
                {
                    //Left to Right
                    if (firstPos.y > contactPoint.y)
                    {
                        //Left to Right Down
                        return Direction.LeftRightDown;
                    }
                    else
                    {
                        //Left to Right Up
                        return Direction.LeftRightUp;
                    }
                }
            }
        }

        public static T GetReference<T>(object inObj, string fieldName) where T : class
        {
            return GetField(inObj, fieldName) as T;
        }


        public static T GetValue<T>(object inObj, string fieldName) where T : struct
        {
            return (T)GetField(inObj, fieldName);
        }
        

        private static object GetField(object inObj, string fieldName)
        {
            object ret = null;
            FieldInfo info = inObj.GetType().GetField(fieldName);
            if (info != null)
                ret = info.GetValue(inObj);
            return ret;
        }

        public static T GetValuePrivate<T>(object inObj, string fieldName) where T : struct
        {
            return (T)GetFieldPrivate(inObj, fieldName);
        }

        public static AudioSource GetValuePrivateAudioSource(object inObj, string fieldName)
        {
            return (AudioSource)GetFieldPrivate(inObj, fieldName);
        }

        public static ParticleSystem GetValuePrivateParticleSystem(object inObj, string fieldName)
        {
            return (ParticleSystem)GetFieldPrivate(inObj, fieldName);
        }

        private static object GetFieldPrivate(object inObj, string fieldName)
        {
            object ret = null;
            FieldInfo info = inObj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (info != null)
            {
                ret = info.GetValue(inObj);
            }

            return ret;
        }
    }
}
