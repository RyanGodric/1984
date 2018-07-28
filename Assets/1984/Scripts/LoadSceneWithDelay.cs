using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public class LoadSceneWithDelay : MonoBehaviour
 {
     public string SceneToLoad = "";
     public float DelayTime = 3.0f;
     public void Start()
     {
         StartCoroutine("Wait");
     }
     private IEnumerator Wait()
     {
         yield return new WaitForSeconds(DelayTime);
 
         SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
 
     }
 }