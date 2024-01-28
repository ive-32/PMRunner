using UnityEngine;
using System.Collections.Generic;

namespace GameScene.Level.UiElements
{
    public class UiHealth : UiLabel
    {
        private int health;

        /**
         * List of stars
         */
        public List<GameObject> healthStars;

        
        /**
         * Health box
         */
        public GameObject HealthBar;
        
        /**
         * Died menu
         */
        public GameObject diedMenu;

        private void Start()
        {
            health = healthStars.Count;
        }
        
        public void LooseHealth()
        {
            healthStars[health - 1].SetActive(false);
            
            if (--health < 1)
            {
                Invoke(nameof(GameOver), 2);
            }
        }
        
        private void GameOver()
        {
            Time.timeScale = 0; // Если хотим стопнуть игру
            diedMenu.SetActive(true);
        }
    }
}
