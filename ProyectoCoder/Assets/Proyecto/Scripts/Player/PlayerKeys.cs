using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    public  Dictionary<string, GameObject> Keys_;
    // Start is called before the first frame update
    void Start()
    {
        Keys_ = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
    }

   public void AdherirKey(GameObject Other)
   {
        Keys_.Add(Other.name, Other);
        Debug.Log( "Se Ha Añadido Al Inventario");
        Other.transform.gameObject.SetActive(false);
   }
}
