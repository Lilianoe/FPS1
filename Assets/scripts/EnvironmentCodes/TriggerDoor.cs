using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    private Animator _doorAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Controller"))
        {
            _doorAnimator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player Controller"))
        {
            _doorAnimator.SetTrigger("Closed");
        }
    }
}