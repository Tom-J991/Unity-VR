using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected int m_level;
    protected GameObject m_gunThisCameFrom;
    protected EventSystem m_eventSystem;

    public AudioSource impactSound;
    public AudioSource travelSound;

    virtual public void Initialize(int level, GameObject gun)
    {
        m_level = level;
        m_gunThisCameFrom = gun;
        m_eventSystem = GameManager.Instance().eventSystem;
        impactSound = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        travelSound = gameObject.transform.GetChild(1).GetComponent<AudioSource>();
    }

    virtual protected void OnCollisionEnter(Collision collision)
    {
        Region region = RevolutionTrigger.GetRegionFromParent(collision.gameObject.transform);
        if (region == null)
        {
            impactSound.Play();
            Destroy(this.gameObject, impactSound.clip.length);
            return;
        }

    }
}
