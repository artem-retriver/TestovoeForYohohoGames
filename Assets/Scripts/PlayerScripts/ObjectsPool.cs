using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Yohoho
{
    public class ObjectsPool : MonoBehaviour
    {

        /*public List<ClaimableObject> Items;

        private Sequence sequence;

        public float YPos = 0.25f;

        public void AddNewItem(ClaimableObject claimableObject)
        {
            Sequence sequence = DOTween.Sequence();

            sequence.AppendCallback(() => { Items.Add(claimableObject); });

            sequence.AppendInterval(0.11f);

            sequence.AppendCallback(() => { claimableObject.transform.position = transform.position; });
            sequence.AppendCallback(() => 
            {
                if (Items.Count > 1)
                {
                    Items[^1].transform.DOMoveY(transform.position.y + YPos, 0.1f);

                    YPos += 0.25f;
                }             
            });
        }

        public void ReduceItems(Vector3 endPos, int indexBridge)
        {
            if (Items.Count > 0)
            {
                sequence = DOTween.Sequence();

                sequence.AppendCallback(() => { Items[^1].transform.DOMove(new(endPos.x, endPos.y - 0.5f, endPos.z), 0.1f); });

                sequence.AppendInterval(0.1f);

                sequence.AppendCallback(() => { Destroy(Items[^1].gameObject); });
                sequence.AppendCallback(() => { Items.RemoveAt(Items.Count - 1); });

                sequence.AppendCallback(() => 
                {
                    if (YPos > 0.25f)
                    {
                        YPos -= 0.25f;
                    }                    
                });

                sequence.AppendCallback(() =>
                {
                    if (Items.Count <= 0 || _pricesBridges[indexBridge].PriceCount <= 0)
                    {
                        sequence.Kill();
                    }
                });                

                sequence.SetLoops(-1);                        
            }
        }*/
    }
}