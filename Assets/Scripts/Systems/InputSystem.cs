using Entitas;
using UnityEngine;
public class InputSystem : IExecuteSystem {
    readonly GameContext _context;
    private float moveSpeed = 5f;
    
    public InputSystem(Contexts contexts) {
        _context = contexts.game;
    }
    
    public void Execute() {
        
        Debug.Log("Context: " + (_context != null ? "Valid" : "Null"));
        
        var entities = _context.GetEntities(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position, GameMatcher.Velocity));
        
        
        Debug.Log("Found player entities: " + entities.Length);
        
        foreach (var e in entities) {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            
            Vector3 velocity = new Vector3(horizontalInput, 0f, verticalInput);
            if (velocity.magnitude > 0) {
                velocity = velocity.normalized * moveSpeed;
            }
            
            e.ReplaceVelocity(velocity);
        }
    }
}