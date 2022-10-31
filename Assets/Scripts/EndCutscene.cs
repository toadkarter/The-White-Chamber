using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutscene : MonoBehaviour
{
    [SerializeField] private int delay = 5;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ReturnToStart(delay));

    }

    private IEnumerator ReturnToStart(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
