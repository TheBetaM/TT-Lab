﻿using System;

namespace TT_Lab.Assets.Graphics
{
    public class Mesh : RigidModel
    {
        public override String Type => "Mesh";

        public Mesh(UInt32 id, String name) : base(id, name) {}

        public override void ToRaw(Byte[] data)
        {
            throw new NotImplementedException();
        }

        public override Byte[] ToFormat()
        {
            throw new NotImplementedException();
        }
    }
}
