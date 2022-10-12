using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestorDeObjetosRecibidos : MonoBehaviour
{
    [SerializeField] GameObject GO;

 //   [SerializeField] string CartelTexto; 
    [SerializeField]List<GameObject> Cartel;
    // Start is called before the first frame update
    void Awake()
    {
        TrigerEventCartelObjeto.Mensaje += InsanciarCartel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsanciarCartel(string Texto)
    {
        
        foreach (GameObject G in Cartel)
        {
            if (G != null)
            {
                G.transform.localPosition += new Vector3(0, 100, 0);
            }
            else
            {
                Cartel.Remove(G);
            }
        }

        GameObject N_Cartel = Instantiate(GO,transform);
        TextMeshProUGUI TextPro = N_Cartel.transform.GetChild(0).GetComponent<TextMeshProUGUI>(); 
        TextPro.text= Texto;

        Cartel.Add(N_Cartel);
        StartCoroutine(RemoverCartel(N_Cartel));
    }

    IEnumerator RemoverCartel(GameObject G)
    {
        yield return new WaitForSeconds(5);
        Cartel.Remove(G);
        Destroy(G);
    }

    public void OnDisable()
    {
        TrigerEventCartelObjeto.Mensaje -= InsanciarCartel;
    }
}
