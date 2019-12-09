using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void Death(string killer)
    {
        IEnumerator coroutine = Wait5Seconds();

        animator.SetLayerWeight(2, 1);

        StartCoroutine(coroutine);
    }

    IEnumerator Wait5Seconds()
    {
        yield return new WaitForSeconds(5f);
    }
}
