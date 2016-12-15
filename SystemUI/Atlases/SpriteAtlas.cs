﻿//-------------------------------------------------------
// LeopotamGroupLibrary for unity3d
// Copyright (c) 2012-2016 Leopotam <leopotam@gmail.com>
//-------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace LeopotamGroup.SystemUI.Atlases {
    public sealed class SpriteAtlas : MonoBehaviour {
        [SerializeField]
        string _name;

        [SerializeField]
        Sprite[] _sprites;

        Dictionary<string, Sprite> _index;

        void RebuildIndex () {
            _index.Clear ();
            if (_sprites != null) {
                Sprite spr;
                for (var i = _sprites.Length - 1; i >= 0; i--) {
                    spr = _sprites[i];
                    if ((System.Object) spr != null) {
                        _index[spr.name] = spr;
                    }
                }
            }
        }

        public string GetName () {
            return _name;
        }

        public void SetSprites (IList<Sprite> list) {
            if (list != null) {
                _sprites = new Sprite[list.Count];
                for (var i = _sprites.Length - 1; i >= 0; i--) {
                    _sprites[i] = list[i];
                }
            } else {
                _sprites = null;
            }
            if (_index != null) {
                RebuildIndex ();
            }
        }

        public Sprite Get (string spriteName) {
            if (_index == null) {
                _index = new Dictionary<string, Sprite> (_sprites != null ? _sprites.Length : 0);
                RebuildIndex ();
            }
            return _index.ContainsKey (spriteName) ? _index[spriteName] : null;
        }
    }
}