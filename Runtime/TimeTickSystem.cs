using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.QuocHieu
{
    public static class TimeTickSystem
    {
        public class OnTickEventArgs : EventArgs
        {
            public int tick;
        }

        public class OnFloatTickEventArgs : EventArgs
        {
            public float tick;
        }

        public static event EventHandler<OnTickEventArgs> OnTick;
        public static event EventHandler<OnFloatTickEventArgs> OnDecimalTick;

        private const float TICK_TIMER_MAX = 0.2f;

        private static GameObject timeTickSystemGameObject;
        private static int tick;

        public static void Create()
        {
            if (timeTickSystemGameObject == null)
            {
                timeTickSystemGameObject = new GameObject("TimeTickSystem");
                timeTickSystemGameObject.AddComponent<TimeTickSystemObject>();
            }
        }

        public static int GetTick()
        {
            return tick;
        }

        private class TimeTickSystemObject : MonoBehaviour
        {
            private float tickTimer;

            private void Awake()
            {
                tick = 0;
                DontDestroyOnLoad(gameObject);
            }

            private void Update()
            {
                tickTimer += Time.deltaTime;
                if (tickTimer >= TICK_TIMER_MAX)
                {
                    if (OnDecimalTick != null) OnDecimalTick(this, new OnFloatTickEventArgs {tick = tickTimer});
                    tickTimer -= TICK_TIMER_MAX;
                    tick++;
                    if (OnTick != null) OnTick(this, new OnTickEventArgs {tick = tick});
                }
            }
        }
    }
}