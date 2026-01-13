using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float vitesse = 5;

    void Start()
    {
        // Désactiver tous les enfants
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Choisir un enfant au hasard
        int index = Random.Range(0, transform.childCount);
        transform.GetChild(index).gameObject.SetActive(true);
    }

    void Update()
    {
        // Déplacement vers la gauche
        transform.position -= new Vector3(vitesse * Time.deltaTime, 0, 0);
    }
}
