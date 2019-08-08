using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class UnclaimedCarGameOver: MonoBehaviour
    {
        public AudioPlayer _audioPlayer;

        private void OnCollisionEnter(Collision other) => HandleCollision(other.gameObject);
        private void OnCollisionEnter2D(Collision2D other) => HandleCollision(other.gameObject);
        private void OnTriggerEnter(Collider other) => HandleCollision(other.gameObject);
        private void OnTriggerEnter2D(Collider2D other) => HandleCollision(other.gameObject);

        private void HandleCollision(GameObject other)
        {
            const int carLayer = 8;
            if (other.layer == carLayer)
            {
                var car = other.GetComponent<MovingCar>();
                if (!car.hasPassenger) OnunclaimedCar();
            }
        }

        private void OnunclaimedCar()
        {
            _audioPlayer.PlayUnclaimedCar();
            GameState.Current.DecreaseStarRating();
        }
    }
}
