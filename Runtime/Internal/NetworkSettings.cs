using System;
using UnityEngine;

namespace Gamebase.Loader.Internal
{
    [Serializable]
    internal sealed class NetworkSettings
    {
        [SerializeField, Range(0, 10)] private int timeout = default;

        public int Timeout => timeout;
    }
}