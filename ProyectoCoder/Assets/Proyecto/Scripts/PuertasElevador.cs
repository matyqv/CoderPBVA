using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasElevador : MonoBehaviour
{

    [SerializeField] Transform PuertaBajo;
    [SerializeField] Transform PuertaAlto;
    [SerializeField] Elevador Elevador;

    float X;
    public int Pso;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(AbrirPuerta());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DelegarPosicion(int P)
    {
        if (P == 0) { StartCoroutine(AbrirPuerta(Pso)); }
        if (P == 1) { StartCoroutine(CerrarPuerta()); }
    }
    public void Posicion(int i)
    {
        Pso = i;
    }
    public IEnumerator AbrirPuerta(int Pos)
    {
        while (X > 0.2f)
        {
            if (Pos == -1)
            { PuertaBajo.localScale = new Vector3(X, 1, 1); }
            if (Pos == 1)
            { PuertaAlto.localScale = new Vector3(X, 1, 1); }
            X -= 1 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
    public IEnumerator CerrarPuerta()
    {
        while (X < 1f)
        {
            PuertaBajo.localScale = new Vector3(X, 1, 1);
            PuertaAlto.localScale = new Vector3(X, 1, 1);
            X += 1 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

}
