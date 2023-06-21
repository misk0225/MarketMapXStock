using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiskCore
{
    public static class EnumExtension 
    {
        public static T GetRandom<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            return (T) values.GetValue(UnityEngine.Random.Range(0, values.Length));
        }
    }
}

