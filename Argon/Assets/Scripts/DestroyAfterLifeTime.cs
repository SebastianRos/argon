using System.Collections;
using UnityEngine;

public class DestroyAfterLifeTime : MonoBehaviour {
  [SerializeField] private float liveTime = 3;

  void Start() {
    StartCoroutine(DestroyAfterLiveTime());
  }

  private IEnumerator DestroyAfterLiveTime() {
    yield return new WaitForSeconds(liveTime);
    Destroy(gameObject);
  }
}
