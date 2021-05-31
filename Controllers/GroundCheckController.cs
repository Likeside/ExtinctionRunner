using UnityEngine;

namespace ExtinctionRunner.Controllers
{
    public class GroundCheckController
    {
        private LayerMask _layerMask;
        private Collider2D _collider2D;
        private float _extraHeight;

        public GroundCheckController(LayerMask layerMask, Collider2D collider2D, float extraHeight)
        {
            _layerMask = layerMask;
            _collider2D = collider2D;
            _extraHeight = extraHeight;
        }
        public bool IsGrounded()
        {
           
            RaycastHit2D raycastHit2D = Physics2D.Raycast(_collider2D.bounds.center, 
                Vector2.down, _collider2D.bounds.extents.y + _extraHeight, _layerMask);

            Color rayColor;

            if (raycastHit2D.collider != null)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }

            Debug.DrawRay(_collider2D.bounds.center, Vector2.down * (_collider2D.bounds.extents.y + _extraHeight), rayColor);

            return raycastHit2D.collider != null;
        }
    }
}