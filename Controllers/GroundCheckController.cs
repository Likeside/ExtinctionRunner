using UnityEngine;

namespace PlatformerMVC
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
            //float extraHeight = 0.01f;
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
            
            // Debug.DrawRay((Vector2)_collider2D.bounds.center + new Vector2(_collider2D.bounds.extents.x, 0), Vector2.down * (_collider2D.bounds.extents.y + extraHeight), rayColor);
            // Debug.DrawRay((Vector2)_collider2D.bounds.center - new Vector2(_collider2D.bounds.extents.x, 0), Vector2.down * (_collider2D.bounds.extents.y + extraHeight), rayColor);
            // //Debug.DrawRay((Vector2)collider2D.bounds.center - new Vector2(0, collider2D.bounds.extents.y), Vector2.down * (collider2D.bounds.extents.y + extraHeight), rayColor);
            // Debug.Log(raycastHit2D.collider);

            return raycastHit2D.collider != null;
        }
    }
}