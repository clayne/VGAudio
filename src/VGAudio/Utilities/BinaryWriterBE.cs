﻿using System.IO;
using System.Text;

namespace VGAudio.Utilities
{
    internal class BinaryWriterBE : BinaryWriter
    {
        public BinaryWriterBE(Stream input) : base(input) { }

        public BinaryWriterBE(Stream output, Encoding encoding, bool leaveOpen) : base(output, encoding, leaveOpen) { }

        private readonly byte[] _buffer = new byte[16];

        public override void Write(short value)
        {
            _buffer[0] = (byte)(value >> 8);
            _buffer[1] = (byte)value;
            OutStream.Write(_buffer, 0, 2);
        }

        public override void Write(ushort value)
        {
            _buffer[0] = (byte)(value >> 8);
            _buffer[1] = (byte)value;
            OutStream.Write(_buffer, 0, 2);
        }

        public override void Write(int value)
        {
            _buffer[0] = (byte)(value >> 24);
            _buffer[1] = (byte)(value >> 16);
            _buffer[2] = (byte)(value >> 8);
            _buffer[3] = (byte)value;
            OutStream.Write(_buffer, 0, 4);
        }
    }
}