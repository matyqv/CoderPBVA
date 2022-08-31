using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorSonidos : MonoBehaviour
{
    public AudioClip Pasos;
    public AudioClip Espada1;
    public AudioClip Roll;


    public AudioSource Audio;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim)
        {
            AnimatorStateInfo State = Anim.GetCurrentAnimatorStateInfo(0);
            if (State.IsName("run"))
            {
                Rep_Pasos();
            }
            else if (State.IsTag("AT"))
            {
            }
            else if (State.IsName("Roll"))
            {
            }
            else
            { Silencio(); }
        }
    }
    void Rep_Pasos()
    {
        Anim = GetComponent<MovimientoPlayer>().Anim;
        Audio.clip = Pasos;
        if (!Audio.isPlaying)
        {
            Audio.Play();
        }
    }

    public void Rep_Espada1()
    {
        Audio.loop = false;
        Audio.clip = Espada1;
        { Audio.PlayOneShot(Espada1,0.4f); }
    }
    public void Rep_Rol()
    {
        Audio.loop = false;
        Audio.clip = Roll;
        { Audio.PlayOneShot(Roll,0.05f); }
    }
    void Silencio()
    {
        Audio.loop = false;
        Audio.clip = null;
    }
}
