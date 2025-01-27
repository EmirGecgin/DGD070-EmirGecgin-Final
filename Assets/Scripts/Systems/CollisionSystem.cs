using UnityEngine;
using Entitas;
using System.Linq;

public class CollisionSystem : IExecuteSystem {
    readonly GameContext _context;
    private readonly float _triggerDistance = 1f;

    public CollisionSystem(Contexts contexts) {
        _context = contexts.game;
    }

    public void Execute() {
        var player = _context.GetEntities(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position))
            .FirstOrDefault();

        if (player == null) return;

        var pads = _context.GetEntities(GameMatcher.AllOf(GameMatcher.Pad, GameMatcher.Position));
        var playerPos = player.position.position;

        foreach (var pad in pads) {
            if (!pad.isTriggered && Vector3.Distance(playerPos, pad.position.position) < _triggerDistance) {
                pad.isTriggered = true;
                Debug.Log("Pad triggered!");
            }
        }
    }
}