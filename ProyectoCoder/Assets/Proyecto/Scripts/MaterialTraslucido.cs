using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTraslucido : MonoBehaviour
{

    [SerializeField] List<MeshRenderer> Meshes;

    [SerializeField] List<Material> Mat_O;
    public Material T;
    public List<Material> Mat_T;
    int i;

  [SerializeField]  float A;

    void Start()
    {
        foreach (MeshRenderer X in Meshes)
        {
            if (X == null)
            {
                Meshes.Remove(X);
            }
        }

        foreach (MeshRenderer X in Meshes)
        {
            foreach (Material Mat in X.materials)
            {
                Material N_mat = new Material(Mat);            
                Mat_O.Add(N_mat);  
            }
        }

        foreach (Material M in Mat_O)
        {
            Material MT = new Material(T);
            MT.mainTexture = M.mainTexture;
            MT.color = M.color;
            MT.mainTextureScale = M.mainTextureScale;
            MT.name = M.name;
            Mat_T.Add(MT);
        }


        i = 0;
   /*     foreach (MeshRenderer X in Meshes)
        {
            foreach (Material Mat in X.materials)
            {
                Mat.CopyPropertiesFromMaterial(Mat_T[i]);
                i++;
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      

        if (other.CompareTag("Player"))
        {
            StartCoroutine(Traslucir());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Opacar());
        }
    }

     IEnumerator Traslucir()
     {
        //Equipar Material
        i = 0;
        foreach (MeshRenderer X in Meshes)
        {
            foreach (Material Mat in X.materials)
            {
                Mat.CopyPropertiesFromMaterial(Mat_T[i]);
                i++;
            }
        }


        //Iniciar Traslucir

        A = 1;
        float SpeedChange = 1;

        while (A > 0.4f)
        {
            A -= SpeedChange * Time.deltaTime;
            foreach (MeshRenderer X in Meshes)
            {
                foreach (Material Mat in X.materials)
                {
                    Mat.color = new Color(Mat.color.r, Mat.color.g, Mat.color.b, A);
                }
            }
            yield return new WaitForEndOfFrame();
        }
     }

    IEnumerator Opacar()
    {  

        //Iniciar Opacar

        A = 0.4f;
        float SpeedChange = 1;

        while (A < 1)
        {
            A += SpeedChange * Time.deltaTime;
            foreach (MeshRenderer X in Meshes)
            {
                foreach (Material Mat in X.materials)
                {
                    Mat.color = new Color(Mat.color.r, Mat.color.g, Mat.color.b, A);
                }
            }
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();

        //Equipar Material
        i = 0;
        foreach (MeshRenderer X in Meshes)
        {
            foreach (Material Mat in X.materials)
            {
                Mat.CopyPropertiesFromMaterial(Mat_O[i]);
                i++;
            }
        }

    }
}

