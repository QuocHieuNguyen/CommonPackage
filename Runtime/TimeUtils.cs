using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.QuocHieu
{
    public class TimeUtils
    {
        private static TimeSpan timeSpan;
        public static string FormatTimeMin(float duration)
        {
            timeSpan = TimeSpan.FromSeconds(duration);
            string formatTime = $"{timeSpan.Minutes} mins";
            return formatTime;
        }
        public static string FormatTimeMinAndSeconds(float duration)
        {
            timeSpan = TimeSpan.FromSeconds(duration);
            string formatTime = $"0{timeSpan.Minutes}m {timeSpan.Seconds}s";
            return formatTime;
        }
    }
}

