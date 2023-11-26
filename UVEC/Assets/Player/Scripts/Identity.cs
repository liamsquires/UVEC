using Fusion;
using Unity.VisualScripting;
using UnityEngine;

public class Identity : NetworkBehaviour
{
    public bool ready;
    public MeshRenderer MeshRenderer;
    [Networked(OnChanged = nameof(NetworkedColorChanged))]
    public Color NetworkedColor { get; set; }

    public GameObject camPrefab;

    public override void Spawned()
    {
        if(!HasInputAuthority)
            return;
        var c = Instantiate(camPrefab, new Vector3(transform.position.x, transform.position.y + 0.95f, transform.position.z),
            Quaternion.identity);
        c.transform.parent = transform;
        GetComponent<TestPlayerController>()._camera = c.GetComponent<Camera>();
    }

    public void OnEnable()
    {
        // if (Runner.)
        //     return;

    }
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
