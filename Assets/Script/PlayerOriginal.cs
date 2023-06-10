using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOriginal : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    [SerializeField] float moveSpeed;
    // Vector2 moveInput;
    public Animator anim;
    public float speed;

    public int pilhas;
    public int vidas;

    // Update is called once per frame
    void Update()
    {

        if (dialogueUI.IsOpen) return;


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);
        
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interactable?.Interact(this);
        }
    }

    
}
