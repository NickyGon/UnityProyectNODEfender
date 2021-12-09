using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    public PlayableDirector director;
    public Animator anim;
    public UIScript ui;
    public AudioSource roar;

    private bool fix = false;


    public enum SpawnState
    {
        SPAWNING,WAITING,COUNTING,FINISHED
    };

    [System.Serializable]
   public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Transform[] spawnPoints;

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown=1f;

    public SpawnState state = SpawnState.COUNTING;



    void Start()
    {
        waveCountText.text = "Enemy wave: " + (nextWave + 1).ToString() + " of " + waves.Length.ToString();
        waveCountdown = timeBetweenWaves;
    }

    

    void Update()
    {
        if (director.state == PlayState.Paused && !fix)
        {
            if (state==SpawnState.FINISHED)
            {
                ui.animateEnd();
                return;
            }
            if (state == SpawnState.WAITING)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }
            if (waveCountdown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    waveCountText.text = "Enemy wave: " + (nextWave+1).ToString() + " of " + waves.Length.ToString(); 
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }


    void WaveCompleted()
    {

        //WaveCompleted!
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1>waves.Length-1)
        {
            state = SpawnState.FINISHED;
            //All waves done!
        } else
        {
            nextWave++;
        }
        
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        roar.Play();

        //Wave spawning
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f /_wave.rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
  
        Transform _sp =spawnPoints[Random.Range(0,spawnPoints.Length)];
        Debug.Log(_sp.position);
        Instantiate(_enemy, _sp.position, _sp.rotation);
       
    }
}
