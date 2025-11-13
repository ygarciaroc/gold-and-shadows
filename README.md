# Tech Bandit Demos

Welcome to the Tech Bandit demos repository! 🎮  
This repository is designed for the team to add **C# demo scripts and Unity mini-projects** in an organized way. Follow the instructions below to keep everything modular and easy to work with.

---

## Repository Structure

Each team member should create their **own branch** for their work. Inside your branch, organize your Unity mini-projects like this:

Assets/
CharacterMovement/
Scripts/
PlayerMovement.cs
JumpController.cs
Prefabs/
DemoScene.unity

CameraSystem/
Scripts/
FixedCamera.cs
CameraController.cs
Prefabs/
DemoScene.unity

InventorySystem/
Scripts/
InventoryManager.cs
ItemSlot.cs
Prefabs/
DemoScene.unity


**Notes:**  
- Each mini-project/module has its **own folder** under `Assets/`.  
- Keep **scripts, prefabs, and demo scenes together** for easy import.  
- Use **namespaces** in C# scripts to avoid class name conflicts between modules:

```csharp
namespace CharacterMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        // Your code here
    }
}
