using FMODUnity;
using System.Collections;
using UnityEngine;

public class SymbolTrigger : MonoBehaviour
{
    [SerializeField] private GameObject ChestInstance;
    private FMOD.Studio.EventInstance instance;

    public static int SH_col = Shader.PropertyToID("Color_Emision");

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ChestInstance.GetComponent<ChestOpen>().ActivateSymbol();

            instance = FMODUnity.RuntimeManager.CreateInstance("event:/SymbolActive");
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            instance.start();
            instance.release();

            GetComponent<Collider>().enabled = false;

            //Mijs
            GetComponent<Material>().SetColor(SH_col, Color.black);
        }
    }
}