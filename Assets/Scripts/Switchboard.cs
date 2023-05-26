using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchboard : Interactable
{
    [SerializeField] private GameObject portal;
    private bool portalAppered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        portalAppered = !portalAppered;
        portal.GetComponent<Animator>().SetBool("IsAppered", portalAppered);
    }
}
