using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roasts.Item
{
    public interface IItemModifiable<T> where T:Effect
    {
        void ApplyItem(T effect);

        void UnApplyItem(T effect);
    }
}

