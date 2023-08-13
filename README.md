Name-Based Material Transfer for Unity

This Unity Editor tool allows for easy transfer of materials between two models based on their name. Designed for models with skeletal animations, this tool uses the SkinnedMeshRenderer to match and transfer materials.

Features

Easy-to-use Unity Editor window.
Transfer materials between models based on matching names.
Visual feedback: Get logs for unmatched renderers or if source/target models are not set.

Installation

Manual Installation:
Clone this repository.
Copy the NameBasedMaterialTransfer.cs script into your Unity project's Editor folder.
Via Unity Package Manager (if provided as UPM):
Open Unity Package Manager.
Click on the + button and choose "Add package from git URL..."
Enter the repository's URL.

Usage

In the Unity Editor, go to Window > ARAWN > Name-Based Material Transfer.
In the opened window, assign your source and target models.
Click the "Transfer Materials" button.

Notes

The tool currently supports SkinnedMeshRenderer. If you want to support MeshRenderer, modifications to the script will be necessary.
Ensure that the source and target models have correctly named child objects if you want a successful material transfer.
Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

License

MIT
