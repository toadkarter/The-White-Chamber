using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Source: https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
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
