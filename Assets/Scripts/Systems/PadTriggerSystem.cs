using Entitas;
using UnityEngine;
using System.Collections.Generic;

public sealed class PadTriggerSystem : ReactiveSystem<GameEntity> {
    readonly GameContext _context;
    
    public PadTriggerSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Triggered);
    }
    
    protected override bool Filter(GameEntity entity) {
        return entity.hasPad && entity.isTriggered;  
    }
    
    protected override void Execute(List<GameEntity> entities) {
        var allPads = _context.GetEntities(GameMatcher.Pad);
        var triggeredPads = _context.GetEntities(GameMatcher.AllOf(GameMatcher.Pad, GameMatcher.Triggered));
        
        if (allPads.Length == triggeredPads.Length) {
            var winEntity = _context.CreateEntity();
            winEntity.isWin = true;
            
            var player = _context.GetEntities(GameMatcher.Player);
            foreach (var p in player) {
                p.Destroy();
            }
        }
    }
}