using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Foxglove
{
    [Flags]
    public enum KeyType : byte
    {
        None = 0,
        Red = 1 << 0, // 1
        Green = 1 << 1, // 2
        Blue = 1 << 2, // 4
        Yellow = 1 << 3, // 8
    }

    public class Keyring
    {
        private KeyType _collectedKeys = KeyType.None;

        public void AddKey(KeyType key)
        {
            _collectedKeys = _collectedKeys | key;
        }

        public bool HasKey(KeyType key)
        {
            return (_collectedKeys & key) == key;
        }
    }
}
