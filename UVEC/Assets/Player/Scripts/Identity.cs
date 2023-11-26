using Fusion;
using Unity.VisualScripting;
using UnityEngine;

public class Identity : NetworkBehaviour
{
    public bool ready;
    public MeshRenderer MeshRenderer;
    [Networked(OnChanged = nameof(NetworkedColorChanged))]
    public Color NetworkedColor { get; set; }
    
    private static void NetworkedColorChanged(Changed<Identity> changed)
    {
        changed.Behaviour.MeshRenderer.material.color = changed.Behaviour.NetworkedColor;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //this is a hack to only collide with pads
        if (!other.gameObject.name.StartsWith("Pad"))
            return;
        
        gameObject.tag = other.gameObject.tag;
        NetworkedColor = other.gameObject.GetComponent<MeshRenderer>().material.color;
        ready = true;
        GameState.Instance.CheckAllReady();
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     //this is a hack to only collide with pads
    //     if (!other.gameObject.name.StartsWith("Pad"))
    //         return;
    //     
    //     gameObject.tag = "Untagged";
    //     NetworkedColor = Color.white;
    // }
}
