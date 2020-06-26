using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Roasts.Level
{
    public class LevelDamage : Level
    {//ff
        RoastPlayer player;

        bool imHurting = false;

        float DPS;

        private void OnCollisionEnter(Collision collision)
        {
            imHurting = false;
        }

        private void OnCollisionExit(Collision collision)
        {
            player = collision.gameObject.GetComponent<RoastPlayer>();

            imHurting = true;

            player.TakeDamage(DPS);

        }

        IEnumerator AffectPlayerRoutine()
        {
            while (player.CurrentHP > 0 && imHurting == true)
            {
                player.TakeDamage(DPS);
            }

            yield return null;
        }

    }
}
