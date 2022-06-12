using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int Blood = 5;
    [SerializeField] GameObject BloodBar;

    [SerializeField] GameObject ReplayButton;
    int floorStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        Blood = 5;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Floor":
                other.gameObject.GetComponent<AudioSource>().Play();
                floorStep++;
                if (floorStep > 3)
                {
                    floorStep = 0;
                    CalcBlood(1);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Finish":
                CalcBlood(-10);
                other.gameObject.GetComponent<AudioSource>().Play();
                break;
            case "Eat":
                CalcBlood(-2);
                other.gameObject.GetComponent<AudioSource>().Play();
                break;
        }
    }

    void CalcBlood(int blood)
    {

        Blood += blood;
        Blood = Blood > 5 ? 5 : Blood;
        Blood = Blood < 0 ? 0 : Blood;

        for (int i = 0; i < BloodBar.transform.childCount; i++)
        {
            if (Blood > i)
            {
                BloodBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                BloodBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        if (Blood == 0)
        {
            Time.timeScale = 0f;
            ReplayButton.SetActive(true);
        }
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {

        }
    }
}