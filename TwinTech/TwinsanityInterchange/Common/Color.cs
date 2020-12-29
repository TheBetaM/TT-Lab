﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twinsanity.TwinsanityInterchange.Enumerations;
using Twinsanity.TwinsanityInterchange.Interfaces;

namespace Twinsanity.TwinsanityInterchange.Common
{
    public class Color : ITwinSerializable
    {
        public Byte A { get; set; }
        public Byte R { get; set; }
        public Byte G { get; set; }
        public Byte B { get; set; }
        public int GetLength()
        {
            return 4;
        }

        public void Read(BinaryReader reader, int length)
        {
            R = reader.ReadByte();
            G = reader.ReadByte();
            B = reader.ReadByte();
            A = reader.ReadByte();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(R);
            writer.Write(G);
            writer.Write(B);
            writer.Write(A);
        }
        public Vector4 GetVector()
        {
            Vector4 vec = new Vector4();
            vec.X = R / 255.0f;
            vec.Y = G / 255.0f;
            vec.Z = B / 255.0f;
            vec.W = A / 255.0f;
            return vec;
        }

        public UInt32 ToARGB()
        {
            return (UInt32)((A << 24) | (R << 16) | (G << 8) | (B));
        }
        public void FromABGR(UInt32 val)
        {
            A = (Byte)(((val >> 24) & 0xFF) << 1);
            B = (Byte)(((val >> 16) & 0xFF) << 1);
            G = (Byte)(((val >> 8) & 0xFF) << 1);
            R = (Byte)(((val >> 0) & 0xFF) << 1);
        }

    }
}
