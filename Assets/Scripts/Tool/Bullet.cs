using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Type m_typeCurrent;
    protected int m_level;
    protected GameObject m_gunThisCameFrom;
    protected Manager m_manager;

    virtual public void Insialize(Type type, int level, GameObject gun, Manager manager)
    {
        m_typeCurrent = type;
        m_level = level;
        m_gunThisCameFrom = gun;
        m_manager = manager;
    }

    virtual protected void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<PopUp>())
        {
            Destroy(this.gameObject);
            return;
        }

    }
}
