using System.Linq;               // LastOrDefault ���
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// �÷��̾��� ���� ����� �о� Ư�� �����ð���ŭ ���� �������� ���¡��� �״�� ���󰡴� ��.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class PetController : MonoBehaviour
    {
        [Tooltip("���� �÷��̾� ������Ʈ�� �����մϴ�.")]
        public PlayerController player;

        [Tooltip("�÷��̾ ���� ���� ���� �ð�(��). �⺻ 0.1s")]
        public float delay = 0.1f;

        private SpriteRenderer spriteRenderer;
        private Animator animator;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

            if (player == null)
            {
                Debug.LogError("[PetController] Player ������ ��� �ֽ��ϴ�. �ν����Ϳ��� �Ҵ����ּ���.");
                enabled = false;
            }
        }

        void LateUpdate()
        {
            if (!enabled || player == null) return;
            if (player.stateHistory == null || player.stateHistory.Count == 0) return;

            float targetTime = Time.time - delay;

            // targetTime ���� �� ���� �ֱ�(���� ����� ����)�� ����
            PlayerState past = player.stateHistory.LastOrDefault(s => s.Timestamp <= targetTime);

            // ��ȿ�� ���� ����
            if (past.Timestamp > 0f)
            {
                ApplyState(past);
            }
            else
            {
                // �����丮�� ���� ª�� ��: ���� ������ ���� ���
                ApplyState(player.stateHistory[0]);
            }
        }

        private void ApplyState(PlayerState s)
        {
            transform.position = s.Position;

            if (spriteRenderer != null)
                spriteRenderer.flipX = s.IsFlipped;
        }
    }
}
