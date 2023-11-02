using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpotlightHolder : MonoBehaviour
{
    public List<GameObject> Spotlights = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOff()
    {
        var delay = 3000;
        foreach (GameObject obj in Spotlights)
        {
            var spotlight = obj.GetComponent<SpotlightManager>();
            spotlight.TurnOff(delay);
            delay += 1000;
        }

        SceneManager.LoadScene("BattleScene");
    }
}
