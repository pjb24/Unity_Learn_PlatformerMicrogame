using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// 플레이어의 특정 시점 상태를 기록하는 구조체 (펫이 0.1s 전 상태를 읽음)
    /// </summary>
    [System.Serializable]
    public struct PlayerState
    {
        public float Timestamp;
        public Vector3 Position;
        public bool IsFlipped;
    }
}
