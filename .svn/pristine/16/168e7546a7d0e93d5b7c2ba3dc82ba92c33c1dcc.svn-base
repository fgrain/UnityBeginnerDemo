using UnityEngine;
public class Hurted : MonoBehaviour
{
    public float blood = 1;
    public bool IsLiving = true;
    public float initBlood = 1;
    private bool m_isInAttactRange;
    private bool m_isTrapHurt;
    private bool m_isEnemyHurt;
    private bool m_isSlowDown;

    public bool IsInAttactRange { get => m_isInAttactRange; set => m_isInAttactRange = value; }
    public bool IsTrapHurt { get => m_isTrapHurt; set => m_isTrapHurt = value; }
    public bool IsEnemyHurt { get => m_isEnemyHurt; set => m_isEnemyHurt = value; }
    public bool IsSlowDown { get => m_isSlowDown; set => m_isSlowDown = value; }

    public void Attacked(float hurt)
    {
        blood -= hurt;
        if (blood <= 0)
        {
            IsLiving = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}