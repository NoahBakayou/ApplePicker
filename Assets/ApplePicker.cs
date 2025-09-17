using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public GameObject appleTreePrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    
    [Header("Tree Spawning")]
    public float treeSpacing = 8f; // Distance between trees
    public float treeY = 0f; // Y position for new trees
    public int treesSpawned = 0; // Track how many trees we've spawned
    public int nextTreeAtScore = 1000; // Score threshold for next tree

    void Start() {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed() {
        // Destroy all of the falling Apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray) {
            Destroy(tempGO);
        }

        // Destroy one of the Baskets
        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // If there are no Baskets left, restart the game
        if (basketList.Count == 0) {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void CheckForNewTree(int currentScore) {
        // Check if we should spawn a new tree
        if (currentScore >= nextTreeAtScore) {
            SpawnNewTree();
            nextTreeAtScore += 1000; // Next tree at 2000, 3000, etc.
        }
    }

    void SpawnNewTree() {
        if (appleTreePrefab == null) {
            Debug.LogError("Apple Tree Prefab not assigned in ApplePicker!");
            return;
        }

        // Calculate position for the new tree
        Vector3 newTreePos = new Vector3();
        newTreePos.x = treeSpacing * (treesSpawned + 1); // Space trees apart
        newTreePos.y = treeY;
        newTreePos.z = 0;

        // Instantiate the new tree
        GameObject newTree = Instantiate(appleTreePrefab, newTreePos, Quaternion.identity);
        
        // Configure the new tree with staggered timing
        AppleTree treeScript = newTree.GetComponent<AppleTree>();
        if (treeScript != null) {
            // Stagger the initial drop delay based on how many trees we have
            treeScript.initialDropDelay = (treesSpawned + 1) * 0.3f;
        }

        treesSpawned++;
        Debug.Log($"Spawned new tree #{treesSpawned} at position {newTreePos}");
    }
}