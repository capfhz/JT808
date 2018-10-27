﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.JT808Formatters.MessageBodyFormatters
{
    public class JT808_0x8603Formatter : IJT808Formatter<JT808_0x8603>
    {
        public JT808_0x8603 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JT808_0x8603 jT808_0X8603 = new JT808_0x8603();
            jT808_0X8603.AreaCount = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset);
            jT808_0X8603.AreaIds = new List<uint>();
            if (jT808_0X8603.AreaCount > 0)
            {
                for (var i = 0; i < jT808_0X8603.AreaCount; i++)
                {
                    jT808_0X8603.AreaIds.Add(JT808BinaryExtensions.ReadUInt32Little(bytes, ref offset));
                }
            }
            readSize = offset;
            return jT808_0X8603;
        }

        public int Serialize(IMemoryOwner<byte> memoryOwner, int offset, JT808_0x8603 value)
        {
            if (value.AreaIds != null)
            {
                offset += JT808BinaryExtensions.WriteByteLittle(memoryOwner, offset, (byte)value.AreaIds.Count);
                foreach (var item in value.AreaIds)
                {
                    offset += JT808BinaryExtensions.WriteUInt32Little(memoryOwner, offset, item);
                }
            }
            return offset;
        }
    }
}