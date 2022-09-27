using UnityEngine;

namespace GameCharacters
{
    struct Player
    {
        private GameObject characterObject;
        private float maxHealth;
        private float currentHealth;
        private string characterName;
        public string CharacterName { set { characterName = value; } get { return characterName; } }
        public GameObject CharObject { set { characterObject = value; } get { return characterObject; } }
        public float MaxHealth { set { maxHealth = value; } get { return maxHealth; } }
        public float CurrentHealth { set { currentHealth = value; } get { return currentHealth; } }

        public void CharacterSetup(CustomStuff info)
        {
            CharacterName = info.characterName;
            CharObject = info.characterObject;
            MaxHealth = info.maxHealth;
            CurrentHealth = info.currentHealth;
        }
    }

    struct Enemy
    {
        private GameObject characterObject;
        private float maxHealth;
        private float currentHealth;
        private string characterName;
        public string CharacterName { set { characterName = value; } get { return characterName; } }
        public GameObject CharObject { set { characterObject = value; } get { return characterObject; } }
        public float MaxHealth { set { maxHealth = value; } get { return maxHealth; } }
        public float CurrentHealth { set { currentHealth = value; } get { return currentHealth; } }
    
        public void CharacterSetup(CustomStuff info)
        {
            CharacterName = info.characterName;
            CharObject = info.characterObject;
            MaxHealth = info.maxHealth;
            CurrentHealth = info.currentHealth;
        }
    }

    [CreateAssetMenu(fileName = "CharacterInformation", menuName = "CustomStuff/CharacterInformation", order = 1)]
    class CustomStuff: ScriptableObject
    {
        public string characterName;
        public GameObject characterObject;
        public float maxHealth;
        public float currentHealth;
    }
}
