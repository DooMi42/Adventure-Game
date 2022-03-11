using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject P1;
    public GameObject P2;

    private int p1Life;
    private int p2Life;

    public int P1_maxLife;
    public int P2_maxLife;

    public GameObject p1Wins;
    public GameObject p2Wins;

    public GameObject[] hearts;

    private bool isP1Die;
    private bool isP2Die;
    // Start is called before the first frame update
    void Start()
    {
        p1Life = P1_maxLife;
        p2Life = P2_maxLife;

        isP1Die = isP2Die = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isP1Die || isP2Die) return;

        if (p1Life <= 0) PlayerDie();

        if (p2Life <= 0) SpiderDie();
    }
    public void HurtP1()
    {

        p1Life -= 1;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (p1Life > i)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public void HurtP2()
    {

        p2Life -= 1;
    }
    void SpiderDie()
    {
        P2.GetComponent<Animator>().enabled = false;
        isP2Die = true;
        p1Wins.SetActive(true);

        AudioManager.instance.Play("WinFanfare");
    }

    void PlayerDie()
    {
        P1.GetComponent<Animator>().SetTrigger("Die");
        isP1Die = true;
        p2Wins.SetActive(true);

        AudioManager.instance.Play("WinFanfare");
    }
}
