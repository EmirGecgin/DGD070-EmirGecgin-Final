using UnityEngine;
using Entitas;

public class WinSystem : IExecuteSystem {
    readonly GameContext _context;
    private readonly GameController _gameController;

    public WinSystem(Contexts contexts) {
        _context = contexts.game;
        _gameController = GameObject.FindObjectOfType<GameController>();
    }

    public void Execute() {
        var winEntities = _context.GetEntities(GameMatcher.Win);

        if (winEntities.Length > 0) {
            Debug.Log("A WINRAR IS YOU");
            _gameController.ShowWinMessage();

            return;
        }
    }
}