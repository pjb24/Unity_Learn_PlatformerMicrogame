using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// �÷��̾��� Ư�� ���� ���¸� ����ϴ� ����ü (���� 0.1s �� ���¸� ����)
    /// </summary>
    [System.Serializable]
    public struct PlayerState
    {
        public float Timestamp;
        public Vector3 Position;
        public bool IsFlipped;
    }
}
