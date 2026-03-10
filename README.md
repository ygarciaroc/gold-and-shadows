Gold and Shadows: Project Overview & Workflow ⚔️

Welcome to the Gold & Shadows production repository. As we approach our semester delivery deadline, we are shifting from individual "mini-project" development to a unified, team-based pipeline.

This repository is now the single source of truth for our game build. Please read the following changes carefully.
⚠️ What Has Changed?

To ensure we deliver a stable demo by the end of the semester, we are abandoning the "manual package import" system in favor of a Single-Project Workflow.

    From "Loose Demos" to "Integrated Development": We are no longer working in isolated mini-projects. Everyone is now contributing to the central GoldAndShadows Unity project.

    Version Control: We are enforcing a Feature-Branching strategy. No one pushes directly to main.

    Asset Management: We are using strict folder hierarchies to prevent file clutter and merge conflicts.

🛠 Branching Strategy

To keep the game stable, follow this flow for every task:

    Branching: Create a branch for your specific task: feature/[team]/[task-name].

        Example: feature/rogue/dash-mechanic or feature/knight/heavy-attack.

    Development: Work in your branch. Use the Assets/Dev/ folder for your testing scenes.

    Pull Requests: Once your feature is tested and working, open a Pull Request (PR) to merge into develop.

    Integration: The Technical Team will review and merge your PR into the main game build.

📂 Project Structure

To keep our workspace organized, please use these folders:

    _Core/: Global systems, base combat classes, and ScriptableObjects. (Do not modify without Lead approval).

    Characters/: Models, animations, and prefabs.

    Combat/: Ability logic, hitboxes, and particles.

    Dev/: Your personal playground. Create your test scenes here. Never use these for the final build.

    UI/: Menus, HUD, and loading screens.

    Audio/: Sound effects and music.

💻 Technical Standards

    Namespacing: All code must be wrapped in your module's namespace to avoid conflicts.
    C#

    namespace GoldAndShadows.Combat { /* Your code here */ }

    Use Prefabs: Do not hard-reference objects in scenes. Always create a Prefab of your character or object.

    ScriptableObjects: Use ScriptableObjects for game balance data (damage, speed, etc.). This allows Designers to tweak numbers without opening scripts.

    Git LFS: If your file is binary (models, textures, audio), ensure it is tracked by Git LFS. If you aren't sure, check the .gitattributes file.

🚨 Troubleshooting

    Merge Conflicts: If you encounter a conflict in a .unity or .prefab file, STOP. Do not force-push. Message the Tech Team immediately.

    Missing References: If something looks broken, check if your Assets are inside the proper folders or if a dependency hasn't been pulled from develop.

“Discipline in our workflow is the only way we deliver a polished experience by the end of the semester. Let’s get to work.”
