using UnityEngine;
using System.Collections;

//Decompile by Si Borokokok

[ExecuteInEditMode]
public class SPLATTER : MonoBehaviour
{
    private object aSplat;
    private float hei;
    private int numSplats;
    public float slideSpeed = 0.4f;
    public Texture2D[] splatTextures;
    private float wid;
    private float xPos;
    private float yPos;

    public void FixedUpdate()
    {
        yPos += slideSpeed;
        hei += 1.1f;
        wid += 0.1f;
        if (yPos > 350)
        {
            Destroy(gameObject);
        }
    }

    public void Main()
    {
    }

    public void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(((float) Screen.width) / 600f, ((float) Screen.height) / 450f, (float) 1));
        if (aSplat != null)
        {
            aSplat = splatTextures[0];
        }
        GUI.DrawTexture(new Rect(xPos, yPos, wid, hei), splatTextures[0]);
    }

    public void Start()
    {
        numSplats = (splatTextures).Length;
        wid = Random.Range(0x20, 0x100);
        hei = Random.Range(0x20, 0x100);
        xPos = Random.Range(0, 500);
        yPos = Random.Range(0, 200);
        aSplat = splatTextures[Random.Range(0, numSplats)];
    }
}

 

