﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_Lab.AssetData.Instance.Scenery;

namespace TT_Lab.ViewModels.Instance.Scenery
{
    public class SceneryRootViewModel : SceneryNodeViewModel
    {
        private UInt32 unkUInt;
        private IList<SceneryBaseData> baseTree;

        public SceneryRootViewModel(SceneryBaseData data, IList<SceneryBaseData> sceneryTree) : base(data)
        {
            var rootData = (SceneryRootData)data;
            unkUInt = rootData.UnkUInt;
            baseTree = sceneryTree;
        }

        public void BuildTree()
        {
            foreach (var sc in SceneryTypes)
            {
                if (sc == 0x1600)
                {
                    var node = baseTree[0];
                    baseTree = baseTree.Skip(1).ToList();
                    var newNode = new SceneryNodeViewModel(node);
                    Children.Add(newNode);
                    newNode.BuildTree(ref baseTree);
                }
                else if (sc == 0x1605)
                {
                    var leaf = baseTree[0];
                    baseTree = baseTree.Skip(1).ToList();
                    Children.Add(new SceneryLeafViewModel(leaf));
                }
            }
            if (baseTree.Count != 0)
            {
                throw new Exception("Houston, we failed to build the scenery tree correctly!");
            }
        }

        public UInt32 UnkUInt
        {
            get => unkUInt;
            set
            {
                if (unkUInt != value)
                {
                    unkUInt = value;
                    NotifyChange();
                }
            }
        }
    }
}
