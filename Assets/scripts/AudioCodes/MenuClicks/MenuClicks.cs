using UnityEngine;
using UnityEngine.EventSystems;

public class MenuClicks : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioClip hoverSound; // Son à jouer lorsque la souris survole un bouton
    [SerializeField] private AudioSource audioSource; // Source audio pour jouer le son

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound); // Joue le son de survol
        }
    }
}

