using UnityEngine;
using UnityEngine.EventSystems;

public class MenuClicks : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioClip hoverSound; 
    [SerializeField] private AudioSource audioSource; 

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound); 
        }
    }
}

