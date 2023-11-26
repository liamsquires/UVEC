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

    private Camera _camera;
    
    public override void Spawned()
    {
        if(!HasInputAuthority)
            return;
        var c = Instantiate(camPrefab, new Vector3(transform.position.x, transform.position.y + 0.95f, transform.position.z),
            Quaternion.identity);
        c.transform.parent = transform;
        GetComponent<TestPlayerController>()._camera = _camera = c.GetComponent<Camera>();
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
        // //this is a hack to only collide with pads
        // if (!other.gameObject.name.StartsWith("Pad"))
        //     return;
        
        gameObject.tag = other.gameObject.tag;
        int _defaultLayer = LayerMask.NameToLayer("Default");
        int _redLayer = LayerMask.NameToLayer("RedPlayer");
        int _blueLayer = LayerMask.NameToLayer("BluePlayer");
        int _greenLayer = LayerMask.NameToLayer("GreenPlayer");
        
        switch (gameObject.tag)
        {
            case "P1":
                gameObject.layer = LayerMask.NameToLayer("RedPlayer");
                _camera.cullingMask = (1 << _blueLayer) | (1 << _greenLayer) | (1 << _defaultLayer);
                break;
            case "P2":
                gameObject.layer = LayerMask.NameToLayer("GreenPlayer");
                _camera.cullingMask = (1 << _blueLayer) | (1 << _redLayer) | (1 << _defaultLayer);
                break;
            case "P3":
                gameObject.layer = LayerMask.NameToLayer("BluePlayer");
                _camera.cullingMask = (1 << _redLayer) | (1 << _greenLayer) | (1 << _defaultLayer);
                break;
        }
        
        
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
