using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class WaveMonster
{
    public WaveMonster(int time, int quantity)
    {
        this.time = time;
        this.quantity = quantity;
    }

    public int time;
    public int quantity;
}

public class WaveManager : MonoBehaviour {

    List<WaveMonster> monsters = new List<WaveMonster>();
    int currentWave = 0;
    int lastSecond = 0;
    float currentTime;
    public float waveLength = 60;
    public GameObject enemy;
    public GameObject[] pathPoints;
    public Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
        LoadNextWave();
	}
	
	// Update is called once per frame
	void Update () {
        currentTime = currentTime + Time.deltaTime;
        Debug.Log(currentTime);
        Debug.Log(Mathf.Round(currentTime));
	    if(waveLength < Mathf.Round(currentTime))
        {
            if (NextWaveValid())
            {
                currentWave++;
                LoadNextWave();
            } else
            {
                //end game
            }
        } else if (lastSecond < Mathf.Round(currentTime))
        {
            foreach(WaveMonster monster in monsters)
            {
                Debug.Log("GardenRake");
                if (monster.time == lastSecond)
                {
                    Instantiate(enemy, spawnPoint, Quaternion.identity);
                    monsters.Remove(monster);
                    Debug.Log("StaticFlame");
                }
            }
            lastSecond++;
        }
	}

    bool NextWaveValid ()
    {
        return File.Exists((currentWave+1) + ".wave");
    }

    void LoadNextWave()
    {
        monsters.Clear();
        int time, quantity;
        StreamReader waveFile = new StreamReader("assets/" + currentWave + ".wave");

        while (!waveFile.EndOfStream)
        {
          string[] currentLine = waveFile.ReadLine().Split(',');
            if (currentLine[0] != null)
            {
                Debug.Log(currentLine[0]);
                time = int.Parse(currentLine[0]);
                if (currentLine.Length > 1)
                {
                    quantity = int.Parse(currentLine[1]);
                } else
                {
                    quantity = 1;
                }

                WaveMonster tempMonster = new WaveMonster(time, quantity);
                monsters.Add(tempMonster);
                Debug.Log(tempMonster.time);
            }
        }


        Debug.Log(monsters.Count);
        waveFile.Close();
    }

    public float GetWaveTime()
    {
        return Mathf.Round(currentTime);
    }

    public GameObject[] GetPathPoints()
    {
        return pathPoints;
    }
}
