using FMODUnity;
using System.Collections;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private int symbolCount = 0;
    [SerializeField] private int numberOfSymbols = 3;
    private Animator animator;
    private FMOD.Studio.EventInstance instance;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(symbolCount == numberOfSymbols)
        {

            instance = FMODUnity.RuntimeManager.CreateInstance("event:/SymbolActive");
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
            instance.start();
            instance.release();
            animator.SetBool("chest_open", true);
        }
    }

    public void ActivateSymbol()
    {
        symbolCount++;
    }
}