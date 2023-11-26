
using Unity.VisualScripting;
using UnityEngine;

public class ReadyCheck : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
            // //this is a hack to only collide with pads
            // if (!other.gameObject.name.StartsWith("Pad"))
            //     return;
            //
            // gameObject.tag = other.gameObject.tag;
            // NetworkedColor = other.gameObject.GetComponent<MeshRenderer>().material.color;
            // GameState.Instance.PlayersReady[Runner.LocalPlayer] = true;
            // GameState.Instance.CheckAllReady();
    }
    
}
