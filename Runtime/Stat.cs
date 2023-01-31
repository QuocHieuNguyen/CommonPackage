using System;
using System.Collections;
using System.Collections.Generic;
using Common.QuocHieu.SerializedDictionary;
using UnityEngine;

namespace Common.QuocHieu
{
    [System.Serializable]
    public class Stat 
    {
        [SerializeField]
        private float baseValue;
        [SerializeField]
        private StatDictionary modifiers;
    
        public Stat(float baseValue)
        {
            this.baseValue = baseValue;
            modifiers = new StatDictionary();
        }
        public float GetValue()
        {
            float value = baseValue;
            if (modifiers == null)
            {
                modifiers = new StatDictionary();
            }
            foreach (var keyValuePair in modifiers)
            {
                value += keyValuePair.Value;
            }
            return value;
        }
    
        public void SetValue(float value)
        {
            baseValue = value;
        }
    
        public float GetBaseValue()
        {
            return baseValue;
        }
        public void AddModifier(string id,float modifier)
        {
            if (!modifiers.ContainsKey(id))
            {
                modifiers.Add(id,modifier);
            }
            
        }
        public void RemoveModifier(string id)
        {
            modifiers.Remove(id);
        }
    
        public StatDictionary Modifiers
        {
            get => modifiers;
            set => modifiers = value;
        }
    
        public void ClearAll()
        {
            modifiers = new StatDictionary();
        }
    }
    [Serializable]
    public class StatDictionary: SerializedDictionary<string, float>{}
}

