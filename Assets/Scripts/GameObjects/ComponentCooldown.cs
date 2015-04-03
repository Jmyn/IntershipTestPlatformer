using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ComponentShoot))]
public class ComponentCooldown : MonoBehaviour
{

	public float m_cooldownTimer = 1f;
    private bool active = false;
	private float m_timeStamp;
    private ComponentShoot cs;

    void Awake()
    {
        cs = GetComponent<ComponentShoot>();
    }
	// Use this for initialization
	void Start ()
	{
		m_timeStamp = Time.time + m_cooldownTimer;
	}

	// Update is called once per frame
	void Update ()
	{
		if (active && Time.time >= m_timeStamp+ m_cooldownTimer )
		{
            active = false;
            cs.SetCooldown(false);
		}
	}

    public void SetCooldownTime(float cd)
    {
        m_cooldownTimer = cd;
    }

    public void StartCooldown()
    {
        active = true;
        m_timeStamp = Time.time;
    }
}
