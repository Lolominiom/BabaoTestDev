using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    //liste initiale des pions
    [SerializeField] private List<GameObject> init = new List<GameObject>();

    //liste des positions dans le cadre
    [SerializeField] private List<GameObject> positions = new List<GameObject>();

    //reference pion vide
    [SerializeField] private GameObject pionVide;

    //texte du timer
    [SerializeField] private Text timerText;

    private int timer = 2;
    private float second = 60f;

    private void Start()
    {
        //Randomize la disposition des pions et les instancies
        List<GameObject> randomized = new List<GameObject>();

        randomized = init.OrderBy(i => Random.value).ToList();

        for (int i = 0; i < randomized.Count; i++)
        {
            Instantiate(randomized[i], positions[i].transform.position, Quaternion.identity);
        }

        init.Remove(init[init.Count - 1]);
    }

    private void Update()
    {
        //Timer de 3min avec affichage des secondes
        second -= Time.deltaTime;
        if (second <= 0f)
        {
            timer -= 1;
            second = 60f;
        }
        timerText.text = timer.ToString() + ":" + second.ToString("F0");

        //Stop le jeu a la fin du timer
        if(timer <= 0 && second <= 0)
        {
            Time.timeScale = 0;
        }
    }

    public void Finish()
    {
        bool check = false;

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Pion");

        foreach(GameObject gameObject in gameObjects)
        {
            MoveProvider provider = gameObject.GetComponent<MoveProvider>();

            GameObject pos = GameObject.Find("Pos" + provider.posNum);

            Clamp clamp = pos.GetComponent<Clamp>();


            if(clamp.actualObject == gameObject)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }

        if(check)
        {
            Debug.Log("GG");
        }
    }
}

