using TMPro;
using UnityEngine;
using Entitas;
public class GameController : MonoBehaviour {
    private Systems _systems;
    private EntityViewCreator _entityCreator;
    public TextMeshProUGUI winText;

    void Awake() {
        var contexts = Contexts.sharedInstance;
        _entityCreator = GetComponent<EntityViewCreator>();
        
        
        _systems = new Feature("Systems")
            .Add(new InputSystem(contexts))
            .Add(new MovementSystem(contexts))
            .Add(new BoundarySystem(contexts))
            .Add(new CollisionSystem(contexts))
            .Add(new PadTriggerSystem(contexts))
            .Add(new WinSystem(contexts));
    }
    
    void Start() {
        Time.timeScale = 1;
        
        
        Invoke("CreateEntities", 0.1f);
    }

    private void CreateEntities() {
        _entityCreator.CreatePlayer(Vector3.zero);
        _entityCreator.CreatePad(new Vector3(-8f, 0f, 4f), 0);
        _entityCreator.CreatePad(new Vector3(8f, 0f, 4f), 1);
        _entityCreator.CreatePad(new Vector3(-8f, 0f, -4f), 2);
        _entityCreator.CreatePad(new Vector3(8f, 0f, -4f), 3);
        
        Debug.Log("Entities created successfully");
    }
    
    void Update() {
        _systems.Execute();
    }
    
    void OnDestroy() {
        _systems.TearDown();
    }
    
    public void ShowWinMessage() {
        winText.gameObject.SetActive(true);
        winText.text = "A WINRAR IS YOU!";
        Time.timeScale = 0;
    }
}