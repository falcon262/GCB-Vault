using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject coin1950s;
    public GameObject coin1960s;
    public GameObject coin1970s;
    public GameObject coin1990s;
    public GameObject coin2000s;

    public GameObject[] spawn1950s;
    public GameObject[] spawn1960s;
    public GameObject[] spawn1970s;
    public GameObject[] spawn1990s;
    public GameObject[] spawn2000s;

    public GameObject[] spawnObstacles;

    public TextMeshProUGUI timerText;
    public float startTime;
    public float timer;

    public bool gameStart;

    public AudioSource coinPick;
    public AudioSource stumble;
    public AudioSource takeOff;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        //StartCoroutine(StartTimer());
        CoinPopulation();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator StartTimer()
    {
        timer = startTime;
        //timeUp = true;

        do
        {
            timer -= Time.deltaTime;
            FormatText();
            yield return null;
        } while (timer > 0 /*&& !WinScreen.activeSelf*/);
    }

    void FormatText()
    {
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);

        //timerText.text = "TIME: " + minutes + ":" + seconds;
        if (minutes < 10 && seconds > 9)
        {
            timerText.text = "0" + minutes + ":" + seconds;
        }
        else if (minutes < 10 && seconds < 10)
        {
            timerText.text = "0" + minutes + ":0" + seconds;
        }
        else if (minutes > 9 && seconds < 10)
        {
            timerText.text = minutes + ":0" + seconds;
        }
        else
        {
            timerText.text = minutes + ":" + seconds;
        }
    }

    private void Spawn1950s()
    {
        List<GameObject> spawnables = new List<GameObject>();
        spawnables.Clear();
        spawnables.Add(coin1950s);
        foreach (var item in spawnObstacles)
        {
            spawnables.Add(item);
        }

        foreach (var item in spawn1950s)
        {
            int rand = Random.Range(0, spawnables.Count);
            int rand1 = Random.Range(0, spawnables.Count);
            int rand2 = Random.Range(0, spawnables.Count);

            var spawnable = Instantiate(spawnables[rand], item.transform.GetChild(0).position, spawnables[rand].transform.rotation);
            var spawnable1 = Instantiate(spawnables[rand1], item.transform.GetChild(1).position, spawnables[rand1].transform.rotation);
            var spawnable2 = Instantiate(spawnables[rand2], item.transform.GetChild(2).position, spawnables[rand2].transform.rotation);

            if (spawnable.name.Contains("1956") || spawnable.name.Contains("JetPack"))
            {
                spawnable.transform.position = new Vector3(spawnable.transform.position.x, spawnable.transform.position.y + 1, spawnable.transform.position.z);
                if (spawnable.name.Contains("1956"))
                {
                    for (int i = 3; i <= 24; i+=3)
                    {
                        Instantiate(spawnable, new Vector3(spawnable.transform.position.x, spawnable.transform.position.y, spawnable.transform.position.z + i), spawnable.transform.rotation);
                    }
                    
                }
                else if (spawnable.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable.transform.position.x, spawnable.transform.position.y + 3.5f, spawnable.transform.position.z + i), spawnables[0].transform.rotation);
                    }

                }
            }

            if (spawnable1.name.Contains("1956") || spawnable1.name.Contains("JetPack"))
            {
                spawnable1.transform.position = new Vector3(spawnable1.transform.position.x, spawnable1.transform.position.y + 1, spawnable1.transform.position.z);
                if (spawnable1.name.Contains("1956"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnable1, new Vector3(spawnable1.transform.position.x, spawnable1.transform.position.y, spawnable1.transform.position.z + i), spawnable1.transform.rotation);
                    }

                }
                else if (spawnable1.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable1.transform.position.x, spawnable1.transform.position.y + 3.5f, spawnable1.transform.position.z + i), spawnables[0].transform.rotation);
                    }

                }
            }

            if (spawnable2.name.Contains("1956") || spawnable2.name.Contains("JetPack"))
            {
                spawnable2.transform.position = new Vector3(spawnable2.transform.position.x, spawnable2.transform.position.y + 1, spawnable2.transform.position.z);
                if (spawnable2.name.Contains("1956"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnable2, new Vector3(spawnable2.transform.position.x, spawnable2.transform.position.y, spawnable2.transform.position.z + i), spawnable2.transform.rotation);
                    }

                }
                else if (spawnable2.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable2.transform.position.x, spawnable2.transform.position.y + 3.5f, spawnable2.transform.position.z + i), spawnables[0].transform.rotation);
                    }

                }
            }

        }
    }    

    private void Spawn1960s()
    {
        List<GameObject> spawnables = new List<GameObject>();
        spawnables.Clear();
        spawnables.Add(coin1960s);
        foreach (var item in spawnObstacles)
        {
            spawnables.Add(item);
        }

        foreach (var item in spawn1960s)
        {
            int rand = Random.Range(0, spawnables.Count);
            int rand1 = Random.Range(0, spawnables.Count);
            int rand2 = Random.Range(0, spawnables.Count);

            var spawnable = Instantiate(spawnables[rand], item.transform.GetChild(0).position, spawnables[rand].transform.rotation);
            var spawnable1 = Instantiate(spawnables[rand1], item.transform.GetChild(1).position, spawnables[rand1].transform.rotation);
            var spawnable2 = Instantiate(spawnables[rand2], item.transform.GetChild(2).position, spawnables[rand2].transform.rotation);

            if (spawnable.name.Contains("1967") || spawnable.name.Contains("JetPack"))
            {
                spawnable.transform.position = new Vector3(spawnable.transform.position.x, spawnable.transform.position.y + 1, spawnable.transform.position.z);
                if (spawnable.name.Contains("1967"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnable, new Vector3(spawnable.transform.position.x + i, spawnable.transform.position.y, spawnable.transform.position.z), spawnable.transform.rotation);
                    }

                }
                else if (spawnable.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable.transform.position.x + i, spawnable.transform.position.y + 3.5f, spawnable.transform.position.z), spawnables[0].transform.rotation);
                    }

                }
            }

            if (spawnable1.name.Contains("1967") || spawnable1.name.Contains("JetPack"))
            {
                spawnable1.transform.position = new Vector3(spawnable1.transform.position.x, spawnable1.transform.position.y + 1, spawnable1.transform.position.z);
                if (spawnable1.name.Contains("1967"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnable1, new Vector3(spawnable1.transform.position.x + i, spawnable1.transform.position.y, spawnable1.transform.position.z), spawnable1.transform.rotation);
                    }

                }
                else if (spawnable1.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable1.transform.position.x + i, spawnable1.transform.position.y + 3.5f, spawnable1.transform.position.z), spawnables[0].transform.rotation);
                    }

                }
            }

            if (spawnable2.name.Contains("1967") || spawnable2.name.Contains("JetPack"))
            {
                spawnable2.transform.position = new Vector3(spawnable2.transform.position.x, spawnable2.transform.position.y + 1, spawnable2.transform.position.z);
                if (spawnable2.name.Contains("1967"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnable2, new Vector3(spawnable2.transform.position.x + i, spawnable2.transform.position.y, spawnable2.transform.position.z), spawnable2.transform.rotation);
                    }

                }
                else if (spawnable2.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable2.transform.position.x + i, spawnable2.transform.position.y + 3.5f, spawnable2.transform.position.z), spawnables[0].transform.rotation);
                    }

                }
            }

        }
    }    
    private void Spawn1970s()
    {
        List<GameObject> spawnables = new List<GameObject>();
        spawnables.Clear();
        spawnables.Add(coin1970s);
        foreach (var item in spawnObstacles)
        {
            spawnables.Add(item);
        }

        foreach (var item in spawn1970s)
        {
            int rand = Random.Range(0, spawnables.Count);
            int rand1 = Random.Range(0, spawnables.Count);
            int rand2 = Random.Range(0, spawnables.Count);

            var spawnable = Instantiate(spawnables[rand], item.transform.GetChild(0).position, spawnables[rand].transform.rotation);
            var spawnable1 = Instantiate(spawnables[rand1], item.transform.GetChild(1).position, spawnables[rand1].transform.rotation);
            var spawnable2 = Instantiate(spawnables[rand2], item.transform.GetChild(2).position, spawnables[rand2].transform.rotation);

            if (spawnable.name.Contains("1979") || spawnable.name.Contains("JetPack"))
            {
                spawnable.transform.position = new Vector3(spawnable.transform.position.x, spawnable.transform.position.y + 1, spawnable.transform.position.z);
                if (spawnable.name.Contains("1979"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnable, new Vector3(spawnable.transform.position.x, spawnable.transform.position.y, spawnable.transform.position.z + i), spawnable.transform.rotation);
                    }

                }
                else if (spawnable.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable.transform.position.x, spawnable.transform.position.y + 3.5f, spawnable.transform.position.z + i), spawnables[0].transform.rotation);
                    }

                }
            }

            if (spawnable1.name.Contains("1979") || spawnable1.name.Contains("JetPack"))
            {
                spawnable1.transform.position = new Vector3(spawnable1.transform.position.x, spawnable1.transform.position.y + 1, spawnable1.transform.position.z);
                if (spawnable1.name.Contains("1979"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnable1, new Vector3(spawnable1.transform.position.x, spawnable1.transform.position.y, spawnable1.transform.position.z + i), spawnable1.transform.rotation);
                    }

                }
                else if (spawnable1.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable1.transform.position.x, spawnable1.transform.position.y + 3.5f, spawnable1.transform.position.z + i), spawnables[0].transform.rotation);
                    }

                }
            }

            if (spawnable2.name.Contains("1979") || spawnable2.name.Contains("JetPack"))
            {
                spawnable2.transform.position = new Vector3(spawnable2.transform.position.x, spawnable2.transform.position.y + 1, spawnable2.transform.position.z);
                if (spawnable2.name.Contains("1979"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnable2, new Vector3(spawnable2.transform.position.x, spawnable2.transform.position.y, spawnable2.transform.position.z + i), spawnable2.transform.rotation);
                    }

                }
                else if (spawnable2.name.Contains("JetPack"))
                {
                    for (int i = 3; i <= 24; i += 3)
                    {
                        Instantiate(spawnables[0], new Vector3(spawnable2.transform.position.x, spawnable2.transform.position.y + 3.5f, spawnable2.transform.position.z + i), spawnables[0].transform.rotation);
                    }

                }
            }
        }
    }    
    private void Spawn1990s()
    {
        foreach (var item in spawn1990s)
        {
            int rand = Random.Range(0, 3);
            int oRand = Random.Range(0, 3);
            int obsRand = Random.Range(0, 2);

            var coin = Instantiate(coin1990s, item.transform.GetChild(rand).position, item.transform.rotation);
            var obstacle = Instantiate(spawnObstacles[obsRand], item.transform.GetChild(oRand).position + new Vector3(0, item.transform.GetChild(oRand).position.y - 9.6f, 0), item.transform.GetChild(oRand).rotation);
            if (obstacle.gameObject.name.Contains("Atm"))
            {
                obstacle.gameObject.transform.Rotate(0, 180, 0);
                obstacle.gameObject.transform.position = obstacle.transform.position + new Vector3(0, obstacle.transform.position.y - 8.6f, 0);
            }
        }
    }    
    private void Spawn2000s()
    {
        foreach (var item in spawn2000s)
        {
            int rand = Random.Range(0, 3);
            int oRand = Random.Range(0, 3);
            int obsRand = Random.Range(0, 2);

            var coin = Instantiate(coin2000s, item.transform.GetChild(rand).position, item.transform.rotation);
            var obstacle = Instantiate(spawnObstacles[obsRand], item.transform.GetChild(0).position + new Vector3(0, item.transform.GetChild(oRand).position.y - 9.6f, 0), item.transform.GetChild(oRand).rotation);
            if (obstacle.gameObject.name.Contains("Atm"))
            {
                obstacle.gameObject.transform.Rotate(0, 180, 0);
                obstacle.gameObject.transform.position = obstacle.transform.position + new Vector3(0, obstacle.transform.position.y - 8.6f, 0);
            }
        }
    }

    private void CoinPopulation()
    {
        Spawn1950s();
        Spawn1960s();
        Spawn1970s();
        /*Spawn1990s();
        Spawn2000s();*/
    }
}
