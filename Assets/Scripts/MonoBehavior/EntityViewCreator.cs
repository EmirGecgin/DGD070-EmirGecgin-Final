using UnityEngine;
using Entitas;
using System.Collections.Generic;
public class EntityViewCreator : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject padPrefab;
    private GameContext _context;
    
    void Awake() {
        _context = Contexts.sharedInstance.game;
    }
    
    public void CreatePlayer(Vector3 position) {
        if (_context == null) {
            _context = Contexts.sharedInstance.game;
        }
        
        var entity = _context.CreateEntity();
        entity.isPlayer = true;
        entity.AddPosition(position);
        entity.AddVelocity(Vector3.zero);
        
        var playerGo = Instantiate(playerPrefab, position, Quaternion.identity);
        var view = playerGo.GetComponent<EntityView>();
        view.Initialize(entity);

        Debug.Log("Player created with position: " + position);
    }
    
    public void CreatePad(Vector3 position, int id) {
        if (_context == null) {
            _context = Contexts.sharedInstance.game;
        }
        
        var entity = _context.CreateEntity();
        entity.AddPad(id);
        entity.AddPosition(position);
        
        var padGo = Instantiate(padPrefab, position, Quaternion.identity);
        var view = padGo.GetComponent<EntityView>();
        view.Initialize(entity);
    }
}