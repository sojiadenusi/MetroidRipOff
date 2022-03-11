using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour
{
    public static DontDestroyAudio instance;
    private void Awake() {
        if (SceneManager.GetActiveScene().buildIndex < 6){
            DontDestroyOnLoad(transform.gameObject);
        }
        // if (instance == null){
        //     instance = this;
        // }else{
        //     DestroyImmediate(this);
        // }
    }
}
//     private void Start() {
//         DontDestroyOnLoad(this);
//     }
// }
