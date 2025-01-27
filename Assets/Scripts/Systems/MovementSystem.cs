using Entitas;
using UnityEngine;

public class MovementSystem : IExecuteSystem {
    readonly GameContext _context;
    
    public MovementSystem(Contexts contexts) {
        _context = contexts.game;
    }
    
    public void Execute() {
        var entities = _context.GetEntities(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
        
        foreach (var e in entities) {
            Vector3 currentPosition = e.position.position;
            Vector3 currentVelocity = e.velocity.velocity;
            
            if (currentVelocity.magnitude > 0) {
                Vector3 newPosition = currentPosition + currentVelocity * Time.deltaTime;
                Debug.Log($"Moving entity - Pos: {currentPosition} -> {newPosition}, Velocity: {currentVelocity}");
                e.ReplacePosition(newPosition);
            }
        }
    }
}