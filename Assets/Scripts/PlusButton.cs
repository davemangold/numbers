using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlusButton : MonoBehaviour
{

    public GameObject countableBox;
    public GameObject countablePrefab;
    public AudioSource audioSource;
    public AudioClip audioClip;
    private BoxCollider2D boxCollider;
    private Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        boxCollider = countableBox.GetComponent<BoxCollider2D>();

        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Plus button clicked.");

        float spawnSpeed = 250f;

        GameObject countable = Instantiate(countablePrefab, countableBox.transform.position, Quaternion.identity);
        countable.transform.eulerAngles = new Vector3(
            countable.transform.eulerAngles.x,
            countable.transform.eulerAngles.y,
            Random.Range(-60, 60));
        Vector2 force = new Vector2(countable.transform.up.x, countable.transform.up.y);
        countable.GetComponent<Rigidbody2D>().AddForce(force.normalized * spawnSpeed);
        SpawnSound();
    }

    void SpawnSound() {
        audioSource.PlayOneShot(audioClip);
    }
}
