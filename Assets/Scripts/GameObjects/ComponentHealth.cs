using UnityEngine;
using System.Collections;

public class ComponentHealth : MonoBehaviour
{
    public float invulnerablePeriod = 1f;
    public float knockBackForce = 20f;
    private bool isInvul = false;
    private bool timerActive = false;
    private float m_time;
	[SerializeField]
	protected int m_MaxHP = 10;
	
	protected int m_CurrHP;
	
	// Getter
	public int CurrHP {	get	{ return m_CurrHP; } }
	public int MaxHP {	get	{ return m_MaxHP; } }
	public float FractionHP { get { return (float)(m_CurrHP)/(float)(m_MaxHP); } }

	
	void Start()
	{
		m_CurrHP = m_MaxHP;
	}

    void Update()
    {
        if (timerActive && Time.time >= m_time + invulnerablePeriod)
        {
            timerActive = false;
            isInvul = false;
        }
    }
	
	public void Modify(int amount)
	{
        UIFloatingText.current.Show(transform.position, amount+"");
		m_CurrHP += amount;
		
		if (m_CurrHP > m_MaxHP)
		{
			m_CurrHP = m_MaxHP;
		}
		else if (m_CurrHP <= 0)
		{
			Die();
		}
	}

    

    void OnTriggerStay(Collider collider)
    {
        if (this.collider.tag == "Player" &&collider.tag == "Enemy" && !isInvul)
        {
            Modify(-1);
            isInvul = true;
            StartTimer();
            KnockBack();
        }

    }

    void KnockBack()
    {

        rigidbody.AddForce(new Vector3(-transform.rigidbody.velocity.x * knockBackForce, 5, 0), ForceMode.VelocityChange);
    }

    void StartTimer()
    {
        m_time = Time.time;
        timerActive = true;
    }
	
	public void Set(int amount)
	{
		m_CurrHP = amount;
		Modify (0); // run thru the checks in Modify()
	}
		
	public void Die()
	{
        if(tag == "Enemy") {
            GameControl.current.EnemyDied();
        }
		Destroy(this.gameObject);
	}

    public void SetMaxHp(int amt)
    {
        m_MaxHP = amt;
    }

    public void setCurrHp(int amt)
    {
        m_CurrHP = amt;
    }
}
