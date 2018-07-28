using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
        Dieses Script ist für das Minispiel in WinstonsRoom zuständig.
        Innerhalb eines festlegbaren Bereichs wird beim 'Treffen' eines GameObjects
        eine neue Position dafür zufällig ermittelt.
        Je häufiger man trifft, desto kürzer ist die Zeit, die erlaubt ist, bevor ein
        Fehlschlag vermerkt wird. Vergeht die Zeit, ohne das man 'trifft', wird ein Fehlschlag vermerkt
        und eine neue Position wird ermittelt, es sei denn, mah hat bereits drei Fehlschläge.

        Die Iterationen, sowie die Fehlschläge und Treffer werden an den ScoreManager übergeben.
     
     */

public class Sc_Workout : MonoBehaviour {

    public GameObject active;

    [Range(0f,100f)]
    public float rangeX;

    [Range(0f, 100f)]
    public float rangeZ;

    [Range(0f, 100f)]
    public float rangeY;

    public AudioSource soundCaught;
    public AudioSource soundMissed;

    public AudioSource good;
    public AudioSource ungood;
    public AudioSource doubleplusungood;
    public AudioSource doubleplusgood;

    [SerializeField]
    private float coreX;

    [SerializeField]
    private float coreY;

    [SerializeField]
    private float coreZ;

    [SerializeField]
    private float timeLeft;


    private bool gameisOn;
    private int gameLoopIteration;

    private int missed;
    private int caught;

    public Sc_ScoreManager ScoreManager;

    void Start () {
        coreX = active.transform.position.x;
        coreY = active.transform.position.y;
        coreZ = active.transform.position.z;
        gameisOn = false;
        gameLoopIteration = 0;
        missed = 0;
        caught = 0;

        WorkOutGame();
    }
	
	void Update () {
        if (gameisOn)
        {
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0)
        {
            if(missed <= 3) {
                ReplaceMissed();
            }
            else
            {
                EndGame();
            }   
        }
	}

    public void WorkOutGame()
    {
        active.SetActive(true);
        
        gameisOn = true;
        timeLeft = 5.0f;
    }

    public void EndGame()
    {
        active.SetActive(false);
        gameisOn = false;
        timeLeft = 0f;
        Debug.Log("STATS: Caught:" + caught + "; Missed:" + missed + "; ITERAION: " + gameLoopIteration);
        if(caught <= 2)
        {
            doubleplusungood.Play();
        }
        else if( caught <= 5)
        {
            ungood.Play();
        }
        else if( caught <= 15)
        {
            good.Play();
        }
        else
        {
            doubleplusgood.Play();
        }
        try
        {
            ScoreManager = GameObject.Find("ScoreManager").GetComponent<Sc_ScoreManager>();
            ScoreManager.workout = true;
            ScoreManager.workoutCount = caught;
        }
        catch {
            Debug.Log("Something went Wrong");
        }
    }

    public void Replace()
    {
        soundCaught.Play();
        caught++;
        float x = Random.Range(coreX - rangeX, coreX + rangeX);
        float z = Random.Range(coreZ - rangeZ, coreZ + rangeZ);
        float y = Random.Range(coreY - rangeY, coreY + rangeY);
        active.transform.position = new Vector3(x, y, z);
        gameLoopIteration++;
        if (gameLoopIteration <= 7)
        {
            timeLeft = 5.0f - gameLoopIteration * 0.5f;
        }
        else
        {
            timeLeft = 1f;
        }
        this.transform.LookAt(Camera.main.transform);
    }

    public void ReplaceMissed()
    {
        soundMissed.Play();
        float x = Random.Range(coreX - rangeX, coreX + rangeX);
        float z = Random.Range(coreZ - rangeZ, coreZ + rangeZ);
        float y = Random.Range(coreY - rangeY, coreY + rangeY);
        active.transform.position = new Vector3(x, y, z);
        missed++;
        gameLoopIteration++;
        if (gameLoopIteration <= 7)
        {
            timeLeft = 5.0f - gameLoopIteration * 0.5f;
        }
        else
        {
            timeLeft = 1f;
        }
            this.transform.LookAt(Camera.main.transform);
    }
}
