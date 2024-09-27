using UnityEngine;

namespace AFStudio.Common.Behaviours
{
    public class InflictDamage : MonoBehaviour
    {
        public float Damage = 100;
        
        public void InflictDamageOn(GameObject target)
        {
            var damageable = target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.DealDamage(Damage);
            }
        } 
    }
    
    public interface IDamageable
    {
        void DealDamage(float damage);
    }
}