﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twinsanity.TwinsanityInterchange.Common;
using Twinsanity.TwinsanityInterchange.Interfaces;
using Twinsanity.TwinsanityInterchange.Interfaces.Items;

namespace Twinsanity.TwinsanityInterchange.Implementations.PS2.Items.Graphics
{
    public class PS2AnyModel : ITwinModel
    {
        UInt32 id;
        public List<SubModel> SubModels { get; private set; }
        public PS2AnyModel()
        {
            SubModels = new List<SubModel>();
        }

        public UInt32 GetID()
        {
            return id;
        }

        public Int32 GetLength()
        {
            Int32 totalLength = 4;
            foreach (ITwinSerializable e in SubModels)
            {
                totalLength += e.GetLength();
            }
            return totalLength;
        }

        public void Read(BinaryReader reader, Int32 length)
        {
            int subCnt = reader.ReadInt32();
            SubModels.Clear();
            for (int i = 0; i < subCnt; ++i)
            {
                SubModel model = new SubModel();
                model.Read(reader, length);
                SubModels.Add(model);
            }
        }

        public void SetID(UInt32 id)
        {
            this.id = id;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(SubModels.Count);
            foreach(ITwinSerializable e in SubModels)
            {
                e.Write(writer);
            }
        }

        public String GetName()
        {
            return $"Model {id:X}";
        }
    }
}
