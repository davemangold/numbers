using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxRight : MonoBehaviour
{

    public int maxCountables = 10;
    public Text targetText;
    public Text countText;
    public Button plusButton;
    private int targetValue;
    private List<GameObject> countables;
    private BoxCollider2D collider;

    void Start()
    {
        countables = new List<GameObject>();
        collider = gameObject.GetComponent<BoxCollider2D>();
        ResetTarget();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collider entered box.");
        countables.Add(other.gameObject);
        countText.text = countables.Count.ToString();
        CheckStatus();
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Collider exited box.");
        countables.Remove(other.gameObject);
        countText.text = countables.Count.ToString();
        CheckStatus();
    }

    void CheckStatus() {

        float waitTime = 1.5f;

        if (countables.Count == targetValue) {
            Debug.Log("Target value reached.");
            plusButton.interactable = false;
            Invoke("Celebrate", waitTime);
        }
    }

    void Celebrate() {

        float jumpSpeed = 250f;
        float scaleFactor = 1.5f;
        float waitTime = 1.8f;

        foreach (GameObject countable in countables) {
            countable.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
        }

        targetText.transform.localScale *= scaleFactor;
        Invoke("RestartScene", waitTime);

    }

    void RestartScene() {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }

    void ResetTarget() {
        targetValue = Random.Range(1, maxCountables + 1);
        targetText.text = targetValue.ToString();
    }
}
