using UnityEngine;
using System.Collections;

public class MonoBeh : MonoBehaviour
{
    private static MonoBeh Mono
    {
        get
        {
            if (_mono == null)
            {
                var go = new GameObject("MonoBeh");
                _mono = go.AddComponent<MonoBeh>();
                DontDestroyOnLoad(go);             
            }
            return _mono;
        }
    }

    private static MonoBeh _mono;
   
    public static Coroutine StartRoroutine(IEnumerator enumerator)
    {
        return Mono.StartCoroutine(enumerator);
    }
    public static void StopRoroutine(Coroutine coroutine)
    {
        Mono.StopCoroutine(coroutine);
    }
}
