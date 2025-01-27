using Entitas;

public class GameFeature : Feature {
    public GameFeature(Contexts contexts) : base("Game Systems") {
        Add(new InputSystem(contexts));
        Add(new MovementSystem(contexts));
        Add(new BoundarySystem(contexts));
        Add(new CollisionSystem(contexts));  
        Add(new PadTriggerSystem(contexts));
        Add(new WinSystem(contexts));
    }
}