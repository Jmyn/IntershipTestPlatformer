using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {
    public GameObject[] enemies;
    public int difficulty = 0;

    public void SpawnEnemy()
    {
        transform.position = new Vector3( Random.Range(-6.5f,83.0f),transform.position.y,transform.position.z);
        GameObject enemy = Instantiate(enemies[Random.Range(0,enemies.Length)],
            transform.position,Quaternion.identity) as GameObject;
        enemy.name = "Enemy" + GameControl.current.enemyCnt; 
        EnemyAI ai = enemy.GetComponent<EnemyAI>();

        //Increase enemy stats with difficulty
        ai.setSpeed(ai.maxSpeed + (2*difficulty));
        ComponentHealth enemyHp = enemy.GetComponent<ComponentHealth>();
        enemyHp.SetMaxHp(enemyHp.MaxHP + (2*difficulty));
        enemyHp.setCurrHp(enemyHp.MaxHP);

        GameControl.current.enemyCnt++;
    }

    public void increaseDifficulty(int amt)
    {
        difficulty += amt;
    }

}
