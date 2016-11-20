﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CSharpTest.Net.Serialization;

namespace Ocorrências_Aeronáuticas
{
    public class ProtoNetSerializer<T> : ISerializer<T>
    {
        public T ReadFrom(Stream stream)
        {
            return ProtoBuf.Serializer.DeserializeWithLengthPrefix<T>(stream, ProtoBuf.PrefixStyle.Base128);
        }
        public void WriteTo(T value, Stream stream)
        {
            ProtoBuf.Serializer.SerializeWithLengthPrefix<T>(stream, value, ProtoBuf.PrefixStyle.Base128);
        }
    }
}
