using UnityEngine;
using Entitas;

public class PadView : EntityView {
    private MeshRenderer _renderer;

    void Awake() {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material.color = Color.red;
    }

    void Update() {
        base.Update();
        
        if (_entity != null && _entity.isTriggered) {
            _renderer.material.color = Color.green;
        }
    }
}