using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected int m_level;
    protected GameObject m_gunThisCameFrom;
    protected EventSystem m_eventSystem;

    virtual public void Initialize(int level, GameObject gun)
    {
        m_level = level;
        m_gunThisCameFrom = gun;
        m_eventSystem = GameManager.Instance().eventSystem;
    }

    virtual protected void OnCollisionEnter(Collision collision)
    {
        Region region = RevolutionTrigger.GetRegionFromParent(collision.gameObject.transform);
        if (region == null)
        {
            Destroy(this.gameObject);
            return;
        }

    }
}
